using NucPass.Constants;
using NucPass.Data;
using NucPass.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucPass
{
    public partial class LoginForm : Form
    {

        private protected MessageBoxService _messageBoxService;
        private protected PasswordService _passwordService;
        private protected EncryptionService _encryptionService;
        private int loginAttempts = 0;

        public LoginForm()
        {
            InitializeComponent();
            InitServices();
        }

        private void InitServices()
        {
            _messageBoxService = new MessageBoxService();
            _passwordService = new PasswordService();
            _encryptionService = new EncryptionService();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            if(masterPasswordBox.Text == string.Empty)
            {
                _messageBoxService.send(MessageBoxType.ERROR, MessageConstants.PASSWORD_BOX_EMPTY);
                return;
            }

            if (_encryptionService.decryptDatabase(masterPasswordBox.Text))
            {
                ShowMainPanel();
                PasswordData.masterPassword = masterPasswordBox.Text;
            }
            else
            {
                switch (loginAttempts)
                {
                    case 3:
                        _messageBoxService.send(MessageBoxType.WARNING, MessageConstants.LOGIN_ATTEMPT_WARNING);
                        loginAttempts++;
                        break;
                    case 5:
                        _passwordService.PanicDelete();
                        _messageBoxService.send(MessageBoxType.WARNING, MessageConstants.LOGIN_ATTEMPT_EXECUTION);
                        Application.Exit();
                        break;
                    default:
                        _messageBoxService.send(MessageBoxType.ERROR, "Your master password is not correct.");
                        loginAttempts++;
                        break;
                }
            }
        }

        private void forgotPasswordLabel_Click(object sender, EventArgs e)
        {
            ShowForgotPasswordPanel();
        }

        private void MainPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void ShowMainPanel()
        {
            var mainForm = new MainForm();
            mainForm.FormClosed += new FormClosedEventHandler(MainPanel_FormClosed);
            mainForm.Show();
            this.Hide();
        }

        private void ShowForgotPasswordPanel()
        {
            var forgotPasswordPanel = new ForgotPasswordForm();
            forgotPasswordPanel.FormClosed += new FormClosedEventHandler(MainPanel_FormClosed);
            forgotPasswordPanel.Show();
            this.Hide();
        }

    }
}
