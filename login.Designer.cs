namespace project2
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            txt_username = new System.Windows.Forms.TextBox();
            txt_password = new System.Windows.Forms.TextBox();
            btn_login = new System.Windows.Forms.Button();
            btn_faceid = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // txt_username
            // 
            txt_username.BackColor = System.Drawing.Color.White;
            txt_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_username.Font = new System.Drawing.Font("맑은 고딕", 11F);
            txt_username.Location = new System.Drawing.Point(100, 225);
            txt_username.Margin = new System.Windows.Forms.Padding(0);
            txt_username.MaxLength = 10;
            txt_username.Name = "txt_username";
            txt_username.Size = new System.Drawing.Size(185, 27);
            txt_username.TabIndex = 0;
            txt_username.KeyDown += txt_username_KeyDown;
            // 
            // txt_password
            // 
            txt_password.BackColor = System.Drawing.Color.White;
            txt_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_password.Font = new System.Drawing.Font("맑은 고딕", 11F);
            txt_password.Location = new System.Drawing.Point(100, 260);
            txt_password.Margin = new System.Windows.Forms.Padding(0);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new System.Drawing.Size(185, 27);
            txt_password.TabIndex = 1;
            txt_password.KeyDown += txt_password_KeyDown;
            // 
            // btn_login
            // 
            btn_login.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_login.BackgroundImage");
            btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_login.Font = new System.Drawing.Font("맑은 고딕", 14.25F);
            btn_login.Location = new System.Drawing.Point(100, 295);
            btn_login.Margin = new System.Windows.Forms.Padding(0);
            btn_login.Name = "btn_login";
            btn_login.Size = new System.Drawing.Size(185, 27);
            btn_login.TabIndex = 2;
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // btn_faceid
            // 
            btn_faceid.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_faceid.BackgroundImage");
            btn_faceid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_faceid.Font = new System.Drawing.Font("맑은 고딕", 14.25F);
            btn_faceid.Location = new System.Drawing.Point(100, 330);
            btn_faceid.Margin = new System.Windows.Forms.Padding(0);
            btn_faceid.Name = "btn_faceid";
            btn_faceid.Size = new System.Drawing.Size(185, 27);
            btn_faceid.TabIndex = 3;
            btn_faceid.UseVisualStyleBackColor = true;
            btn_faceid.Click += btn_faceid_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new System.Drawing.Size(384, 411);
            Controls.Add(btn_faceid);
            Controls.Add(btn_login);
            Controls.Add(txt_username);
            Controls.Add(txt_password);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "login";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_faceid;
    }
}
