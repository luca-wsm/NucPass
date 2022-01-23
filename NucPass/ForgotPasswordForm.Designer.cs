
namespace NucPass
{
    partial class ForgotPasswordForm
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
            this.recoveryFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openRecoveryFileBtn = new System.Windows.Forms.Button();
            this.openRecoveryLabel = new System.Windows.Forms.Label();
            this.validFileCheck = new System.Windows.Forms.Label();
            this.methodBox = new System.Windows.Forms.ComboBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recoveryFileDialog
            // 
            this.recoveryFileDialog.FileName = "openFileDialog1";
            this.recoveryFileDialog.Filter = "NucPass File|*.np";
            // 
            // openRecoveryFileBtn
            // 
            this.openRecoveryFileBtn.Location = new System.Drawing.Point(12, 96);
            this.openRecoveryFileBtn.Name = "openRecoveryFileBtn";
            this.openRecoveryFileBtn.Size = new System.Drawing.Size(133, 39);
            this.openRecoveryFileBtn.TabIndex = 0;
            this.openRecoveryFileBtn.Text = "Open ";
            this.openRecoveryFileBtn.UseVisualStyleBackColor = true;
            this.openRecoveryFileBtn.Click += new System.EventHandler(this.openRecoveryFileBtn_Click);
            // 
            // openRecoveryLabel
            // 
            this.openRecoveryLabel.AutoSize = true;
            this.openRecoveryLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openRecoveryLabel.Location = new System.Drawing.Point(87, 9);
            this.openRecoveryLabel.Name = "openRecoveryLabel";
            this.openRecoveryLabel.Size = new System.Drawing.Size(113, 25);
            this.openRecoveryLabel.TabIndex = 1;
            this.openRecoveryLabel.Text = "Recoveryfile";
            // 
            // validFileCheck
            // 
            this.validFileCheck.AutoSize = true;
            this.validFileCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.validFileCheck.Location = new System.Drawing.Point(151, 103);
            this.validFileCheck.Name = "validFileCheck";
            this.validFileCheck.Size = new System.Drawing.Size(116, 21);
            this.validFileCheck.TabIndex = 2;
            this.validFileCheck.Text = "No file selected";
            // 
            // methodBox
            // 
            this.methodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodBox.FormattingEnabled = true;
            this.methodBox.Items.AddRange(new object[] {
            "Copy to clipboard",
            "Show MessageBox"});
            this.methodBox.Location = new System.Drawing.Point(12, 53);
            this.methodBox.Name = "methodBox";
            this.methodBox.Size = new System.Drawing.Size(258, 23);
            this.methodBox.TabIndex = 3;
            this.methodBox.SelectedIndex = 0;
            // 
            // encryptButton
            // 
            this.encryptButton.Enabled = false;
            this.encryptButton.Location = new System.Drawing.Point(87, 157);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(113, 38);
            this.encryptButton.TabIndex = 4;
            this.encryptButton.Text = "Encrypt Password";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 207);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.methodBox);
            this.Controls.Add(this.validFileCheck);
            this.Controls.Add(this.openRecoveryLabel);
            this.Controls.Add(this.openRecoveryFileBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NucPass » Forgot Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog recoveryFileDialog;
        private System.Windows.Forms.Button openRecoveryFileBtn;
        private System.Windows.Forms.Label openRecoveryLabel;
        private System.Windows.Forms.Label validFileCheck;
        private System.Windows.Forms.ComboBox methodBox;
        private System.Windows.Forms.Button encryptButton;
    }
}