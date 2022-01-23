using NucPass.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Management;
using System.Windows.Forms;

namespace NucPass.Services
{
    public class PasswordService
    {

        private protected EncryptionService _encryptionService;
        public PasswordService()
        {
            _encryptionService = new EncryptionService();
        }


        public string ValidatePassword(String password)
        {
            var passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            var match = passwordRegex.Match(password);

            if (password.Length == 0)
            {
                return MessageConstants.PASSWORD_BOX_EMPTY;
            }
            else if (!match.Success)
            {
                return MessageConstants.PASSWORD_REGEX_ERROR;
            }
            return "OK";
        }

        public bool DatabaseExists()
        {
            return File.Exists(FileConstants.DATABASE_FILE_COMBINED);
        }

        public void CreateRecoveryFile(string path, string masterPassword)
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(masterPassword);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler " + ex.Message);
            }

            _encryptionService.encryptFile(path, path + ".np", getHWID());
        }

        public string GetRecoveryPassword(string path)
        {
            _encryptionService.decryptFile(path, FileConstants.GENERAL_FOLDER + "masterpassword.nuc", getHWID());
            var pwTemp = File.ReadAllText(FileConstants.GENERAL_FOLDER + "masterpassword.nuc");
            FileInfo fi = new FileInfo(FileConstants.GENERAL_FOLDER + "masterpassword.nuc");
            fi.Delete();
            return pwTemp;
        }

        public void PanicDelete()
        {
            if (File.Exists(FileConstants.DATABASE_FILE_COMBINED))
            {
                File.Delete(FileConstants.DATABASE_FILE_COMBINED);
            }
            else if (File.Exists(FileConstants.DATABASE_FILE_ENCRYPTED))
            {
                File.Delete(FileConstants.DATABASE_FILE_ENCRYPTED);
            } else
            {
                new MessageBoxService().send(MessageBoxType.ERROR, MessageConstants.PANIC_DELETE_ERROR);
            }
        }

        public String getHWID()
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorId"].ToString();
                break;
            }
            return id;
        }
    }
}
