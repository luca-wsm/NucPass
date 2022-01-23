using NucPass.Constants;
using NucPass.Data;
using NucPass.Services;
using NucPass.SQL;
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
    public partial class registerForm : Form
    {

        private protected PasswordService _passwordService;
        private protected MessageBoxService _messageBoxService;

        public registerForm()
        {
            if (File.Exists(FileConstants.DATABASE_FILE_COMBINED)) { this.Hide(); ShowMainPanel(); }
            InitializeComponent();
            InitServices();
        }

        private void InitServices()
        {
            _passwordService = new PasswordService();
            _messageBoxService = new MessageBoxService();
        }

        private void backupBox_CheckedChanged(object sender, EventArgs e)
        {
            if(backupBox.Checked)
            {
                var box = MessageBox.Show(MessageConstants.RECOVERY_ENABLE_WARNING, MessageConstants.MESSAGEBOX_TITLE_WARNING, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(box == DialogResult.OK)
                {
                    backupFileDialog.ShowDialog();
                } else
                {
                    backupBox.Checked = false;
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(masterPasswordBox.Text == masterPasswortRepeatBox.Text)
            {
                var validation = _passwordService.ValidatePassword(masterPasswordBox.Text);

                if(validation == MessageConstants.PASSWORD_OK)
                {
                    using (SqlService sqlService = new SqlService()){}
                    PasswordData.masterPassword = masterPasswordBox.Text;
                    ShowMainPanel();

                    if(backupBox.Checked && backupFileDialog.FileName != string.Empty)
                    {
                        _passwordService.CreateRecoveryFile(backupFileDialog.FileName.Replace(".np", string.Empty), masterPasswordBox.Text);
                    }

                } else
                {
                    _messageBoxService.send(MessageBoxType.ERROR, validation);
                }

            } else
            {
                _messageBoxService.send(MessageBoxType.ERROR, MessageConstants.PASSWORD_NOT_MATCHES);
            }
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

        private void registerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
