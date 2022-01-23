
namespace NucPass
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.masterPasswordBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.forgotPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // masterPasswordBox
            // 
            this.masterPasswordBox.Location = new System.Drawing.Point(12, 12);
            this.masterPasswordBox.Name = "masterPasswordBox";
            this.masterPasswordBox.PasswordChar = '*';
            this.masterPasswordBox.PlaceholderText = "Master Password";
            this.masterPasswordBox.Size = new System.Drawing.Size(246, 23);
            this.masterPasswordBox.TabIndex = 3;
            this.masterPasswordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.masterPasswordBox.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(12, 41);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(245, 31);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // forgotPasswordLabel
            // 
            this.forgotPasswordLabel.AutoSize = true;
            this.forgotPasswordLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.forgotPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.forgotPasswordLabel.Location = new System.Drawing.Point(90, 81);
            this.forgotPasswordLabel.Name = "forgotPasswordLabel";
            this.forgotPasswordLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.forgotPasswordLabel.Size = new System.Drawing.Size(95, 15);
            this.forgotPasswordLabel.TabIndex = 5;
            this.forgotPasswordLabel.Text = "Forgot Password";
            this.forgotPasswordLabel.Click += new System.EventHandler(this.forgotPasswordLabel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 105);
            this.Controls.Add(this.forgotPasswordLabel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.masterPasswordBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NucPass » Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox masterPasswordBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label forgotPasswordLabel;
    }
}