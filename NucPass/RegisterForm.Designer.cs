
namespace NucPass
{
    partial class registerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registerButton = new System.Windows.Forms.Button();
            this.backupBox = new System.Windows.Forms.CheckBox();
            this.masterPasswordBox = new System.Windows.Forms.TextBox();
            this.masterPasswortRepeatBox = new System.Windows.Forms.TextBox();
            this.backupFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(12, 100);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(99, 29);
            this.registerButton.TabIndex = 0;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // backupBox
            // 
            this.backupBox.AutoSize = true;
            this.backupBox.Location = new System.Drawing.Point(123, 106);
            this.backupBox.Name = "backupBox";
            this.backupBox.Size = new System.Drawing.Size(123, 19);
            this.backupBox.TabIndex = 1;
            this.backupBox.Text = "Create Backup File";
            this.backupBox.UseVisualStyleBackColor = true;
            this.backupBox.CheckedChanged += new System.EventHandler(this.backupBox_CheckedChanged);
            // 
            // masterPasswordBox
            // 
            this.masterPasswordBox.Location = new System.Drawing.Point(12, 12);
            this.masterPasswordBox.Name = "masterPasswordBox";
            this.masterPasswordBox.PasswordChar = '*';
            this.masterPasswordBox.PlaceholderText = "Master Password";
            this.masterPasswordBox.Size = new System.Drawing.Size(246, 23);
            this.masterPasswordBox.TabIndex = 2;
            this.masterPasswordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.masterPasswordBox.UseSystemPasswordChar = true;
            // 
            // masterPasswortRepeatBox
            // 
            this.masterPasswortRepeatBox.Location = new System.Drawing.Point(12, 57);
            this.masterPasswortRepeatBox.Name = "masterPasswortRepeatBox";
            this.masterPasswortRepeatBox.PasswordChar = '*';
            this.masterPasswortRepeatBox.PlaceholderText = "Repeat Master Password";
            this.masterPasswortRepeatBox.Size = new System.Drawing.Size(246, 23);
            this.masterPasswortRepeatBox.TabIndex = 3;
            this.masterPasswortRepeatBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.masterPasswortRepeatBox.UseSystemPasswordChar = true;
            // 
            // backupFileDialog
            // 
            this.backupFileDialog.DefaultExt = "nuc";
            this.backupFileDialog.Filter = "NucPass File|*.np";
            // 
            // registerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 138);
            this.Controls.Add(this.masterPasswortRepeatBox);
            this.Controls.Add(this.masterPasswordBox);
            this.Controls.Add(this.backupBox);
            this.Controls.Add(this.registerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "registerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NucPass » Register";
            this.Load += new System.EventHandler(this.registerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.CheckBox backupBox;
        private System.Windows.Forms.TextBox masterPasswordBox;
        private System.Windows.Forms.TextBox masterPasswortRepeatBox;
        private System.Windows.Forms.SaveFileDialog backupFileDialog;
    }
}

