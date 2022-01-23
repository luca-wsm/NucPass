using NucPass.Constants;
using NucPass.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucPass
{
    public partial class ForgotPasswordForm : Form
    {

        private PasswordService _passwordService;
        private MessageBoxService _messageBoxService;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            InitServices();
        }

        private void InitServices()
        {
            _passwordService = new PasswordService();
            _messageBoxService = new MessageBoxService();
        }

            private void openRecoveryFileBtn_Click(object sender, EventArgs e)
        {
            recoveryFileDialog.ShowDialog();
            var fileName = Path.GetFileName(recoveryFileDialog.FileName);
            if (fileName.Contains(".np"))
            {

                encryptButton.Enabled = true;

                if(fileName.Length >= 13)
                {
                    validFileCheck.Text = "File is valid ✓";
                } else
                {
                    validFileCheck.Text = fileName + " ✓";
                }
            } else
            {
                encryptButton.Enabled = false;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            string password = string.Empty;

            try
            {
                password = _passwordService.GetRecoveryPassword(recoveryFileDialog.FileName);
                if(methodBox.SelectedIndex == 0) // Clipboard
                {
                    Clipboard.SetText(password);
                    _messageBoxService.send(MessageBoxType.INFORMATION, MessageConstants.RECOVERY_VALUE_CLIPBOARD);
                } else // 1 = Messagebox
                {
                    _messageBoxService.send(MessageBoxType.INFORMATION, MessageConstants.RECOVERY_VALUE_MESSAGEBOX + password + "\nThe Application will now be closed.");
                }
                password = null;
                GC.Collect();
                Application.Exit();
            }
            catch (Exception)
            {
                _messageBoxService.send(MessageBoxType.ERROR, MessageConstants.RECOVERY_FILE_NOT_VALID);
            }
        }
    }
}
