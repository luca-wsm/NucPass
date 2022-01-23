using NucPass.Constants;
using NucPass.Data;
using NucPass.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucPass
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnShutdown);
            if (File.Exists(FileConstants.DATABASE_FILE_ENCRYPTED) || File.Exists(FileConstants.DATABASE_FILE_COMBINED)) {
                Application.Run(new LoginForm()); 
            } else
            {
                Application.Run(new registerForm());
            }

            if(!Directory.Exists(FileConstants.GENERAL_FOLDER))
            {
                Directory.CreateDirectory(FileConstants.GENERAL_FOLDER);
            }

        }
        private static void OnShutdown(object sender, EventArgs e)
        {
            if(PasswordData.masterPassword != null)
            {
                new EncryptionService().encryptDatabase(PasswordData.masterPassword);
            }  
        }
    }
}
