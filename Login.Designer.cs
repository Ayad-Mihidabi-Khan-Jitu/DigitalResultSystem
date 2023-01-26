
namespace DigitalResultSystem
    {
    partial class Login
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
            this.checkBoxPasshow = new System.Windows.Forms.CheckBox();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.TextBoxUsername = new System.Windows.Forms.TextBox();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkBoxPasshow
            // 
            this.checkBoxPasshow.AutoSize = true;
            this.checkBoxPasshow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxPasshow.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.checkBoxPasshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.checkBoxPasshow.ForeColor = System.Drawing.Color.White;
            this.checkBoxPasshow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxPasshow.Location = new System.Drawing.Point(182, 272);
            this.checkBoxPasshow.Name = "checkBoxPasshow";
            this.checkBoxPasshow.Size = new System.Drawing.Size(129, 21);
            this.checkBoxPasshow.TabIndex = 71;
            this.checkBoxPasshow.Text = "Show Password";
            this.checkBoxPasshow.UseVisualStyleBackColor = true;
            this.checkBoxPasshow.CheckedChanged += new System.EventHandler(this.checkBoxPasshow_CheckedChanged);
            // 
            // ButtonClear
            // 
            this.ButtonClear.BackColor = System.Drawing.Color.Black;
            this.ButtonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClear.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClear.ForeColor = System.Drawing.Color.Red;
            this.ButtonClear.Location = new System.Drawing.Point(435, 308);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(100, 43);
            this.ButtonClear.TabIndex = 70;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = false;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.Black;
            this.ButtonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.Lime;
            this.ButtonLogin.Location = new System.Drawing.Point(182, 308);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(99, 43);
            this.ButtonLogin.TabIndex = 69;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.BackColor = System.Drawing.Color.Aquamarine;
            this.TextBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxPassword.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassword.Location = new System.Drawing.Point(182, 227);
            this.TextBoxPassword.MaxLength = 8;
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(353, 39);
            this.TextBoxPassword.TabIndex = 68;
            this.TextBoxPassword.Text = "Password";
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.BackColor = System.Drawing.Color.Aquamarine;
            this.TextBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxUsername.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxUsername.Location = new System.Drawing.Point(182, 152);
            this.TextBoxUsername.MaxLength = 20;
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(353, 39);
            this.TextBoxUsername.TabIndex = 67;
            this.TextBoxUsername.Text = "Username";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRole.ForeColor = System.Drawing.Color.DarkRed;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Teacher",
            "Admin"});
            this.comboBoxRole.Location = new System.Drawing.Point(461, 12);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(165, 33);
            this.comboBoxRole.TabIndex = 72;
            this.comboBoxRole.Text = "Role";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(638, 450);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.checkBoxPasshow);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUsername);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxPasshow;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.TextBox TextBoxUsername;
        private System.Windows.Forms.ComboBox comboBoxRole;
        }
    }