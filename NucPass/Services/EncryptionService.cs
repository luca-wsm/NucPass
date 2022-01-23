using NucPass.Constants;
using NucPass.SQL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucPass.Services
{
    public class EncryptionService
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        public void encryptDatabase(string masterPassword)
        {
            encryptFile(FileConstants.DATABASE_FILE_COMBINED, FileConstants.DATABASE_FILE_ENCRYPTED, masterPassword);
        }

        public bool decryptDatabase(string masterPassword)
        {
            return decryptFile(FileConstants.DATABASE_FILE_ENCRYPTED, FileConstants.DATABASE_FILE_COMBINED, masterPassword);
        }

        public bool decryptFile(string encryptedFilename, string newFilename, string masterPassword)
        {
            masterPassword += DataConstants.ENCRYPTION_SECRET;
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(masterPassword);
            byte[] salt = new byte[32];

            FileInfo fi;
            FileInfo fiOut;
            CryptoStream cs = null;
            FileStream fsOut = null;

            using (FileStream fsCrypt = new FileStream(encryptedFilename, FileMode.Open))
            {
                try
                {
                    fsCrypt.Read(salt, 0, salt.Length);

                    RijndaelManaged AES = new RijndaelManaged();
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Padding = PaddingMode.PKCS7;
                    AES.Mode = CipherMode.CFB;

                    cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

                    fsOut = new FileStream(newFilename + ".temp", FileMode.Create);

                    int read;
                    byte[] buffer = new byte[1048576];

                    while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsOut.Write(buffer, 0, read);
                    }
                }
                catch (CryptographicException ex)
                {

                    fiOut = new FileInfo(newFilename + ".temp");
                    fsOut.Close();
                    fsCrypt.Close();
                    fiOut.Delete();
                    return false;
                }
                catch (Exception ex)
                {
                    throw;
                }

                try
                {
                    cs.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                finally
                {
                    fsOut.Close();
                    fsCrypt.Close();
                    fi = new FileInfo(encryptedFilename);
                    fi.Delete();
                    fiOut = new FileInfo(newFilename + ".temp");
                    fiOut.MoveTo(newFilename);
                }
            }
            return true;
        }

        public void encryptFile(string oldFilename, string newFilename, string password)
        {
            password += DataConstants.ENCRYPTION_SECRET;

            FileInfo fi = new FileInfo(oldFilename);
            FileStream fsCrypt = new FileStream(newFilename, FileMode.Create);

            byte[] salt = GenerateSalt();

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            using (FileStream fsIn = new FileStream(oldFilename, FileMode.Open))
            {
                byte[] buffer = new byte[1048576];
                int read;

                try
                {
                    while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        cs.Write(buffer, 0, read);
                    }

                    fsIn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    cs.Close();
                    fsCrypt.Close();
                    fi.Delete();
                }
            }
        }


        private byte[] GenerateSalt()
        {
            byte[] dt = new byte[32];

            using (RNGCryptoServiceProvider rn = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rn.GetBytes(dt);
                }
            }
            return dt;
        }
    }
}
