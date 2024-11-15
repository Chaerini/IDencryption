namespace project2
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            btn_idext = new System.Windows.Forms.Button();
            btn_dataload = new System.Windows.Forms.Button();
            rbtn_encrypt = new System.Windows.Forms.RadioButton();
            rbtn_decrypt = new System.Windows.Forms.RadioButton();
            gb_dbloading = new System.Windows.Forms.GroupBox();
            btn_back = new System.Windows.Forms.Button();
            gb_dbloading.SuspendLayout();
            SuspendLayout();
            // 
            // btn_idext
            // 
            btn_idext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_idext.Image = (System.Drawing.Image)resources.GetObject("btn_idext.Image");
            btn_idext.Location = new System.Drawing.Point(100, 230);
            btn_idext.Margin = new System.Windows.Forms.Padding(0);
            btn_idext.Name = "btn_idext";
            btn_idext.Size = new System.Drawing.Size(185, 45);
            btn_idext.TabIndex = 0;
            btn_idext.UseVisualStyleBackColor = true;
            btn_idext.Click += btn_idext_Click;
            // 
            // btn_dataload
            // 
            btn_dataload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_dataload.Image = (System.Drawing.Image)resources.GetObject("btn_dataload.Image");
            btn_dataload.Location = new System.Drawing.Point(100, 290);
            btn_dataload.Name = "btn_dataload";
            btn_dataload.Size = new System.Drawing.Size(185, 45);
            btn_dataload.TabIndex = 1;
            btn_dataload.UseVisualStyleBackColor = true;
            btn_dataload.Click += btn_dataload_Click;
            // 
            // rbtn_encrypt
            // 
            rbtn_encrypt.AutoSize = true;
            rbtn_encrypt.Font = new System.Drawing.Font("Cafe24 Ohsquare air Light", 11.9999981F);
            rbtn_encrypt.Location = new System.Drawing.Point(3, 16);
            rbtn_encrypt.Name = "rbtn_encrypt";
            rbtn_encrypt.Size = new System.Drawing.Size(69, 24);
            rbtn_encrypt.TabIndex = 2;
            rbtn_encrypt.TabStop = true;
            rbtn_encrypt.Text = "암호화";
            rbtn_encrypt.UseVisualStyleBackColor = true;
            rbtn_encrypt.CheckedChanged += rbtn_encrypt_CheckedChanged;
            // 
            // rbtn_decrypt
            // 
            rbtn_decrypt.AutoSize = true;
            rbtn_decrypt.Font = new System.Drawing.Font("Cafe24 Ohsquare air Light", 11.9999981F);
            rbtn_decrypt.Location = new System.Drawing.Point(113, 16);
            rbtn_decrypt.Name = "rbtn_decrypt";
            rbtn_decrypt.Size = new System.Drawing.Size(69, 24);
            rbtn_decrypt.TabIndex = 3;
            rbtn_decrypt.TabStop = true;
            rbtn_decrypt.Text = "복호화";
            rbtn_decrypt.UseVisualStyleBackColor = true;
            rbtn_decrypt.CheckedChanged += rbtn_decrypt_CheckedChanged;
            // 
            // gb_dbloading
            // 
            gb_dbloading.BackColor = System.Drawing.Color.Transparent;
            gb_dbloading.Controls.Add(rbtn_encrypt);
            gb_dbloading.Controls.Add(rbtn_decrypt);
            gb_dbloading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            gb_dbloading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            gb_dbloading.ForeColor = System.Drawing.Color.Black;
            gb_dbloading.Location = new System.Drawing.Point(100, 324);
            gb_dbloading.Margin = new System.Windows.Forms.Padding(0);
            gb_dbloading.Name = "gb_dbloading";
            gb_dbloading.Padding = new System.Windows.Forms.Padding(0);
            gb_dbloading.Size = new System.Drawing.Size(185, 40);
            gb_dbloading.TabIndex = 0;
            gb_dbloading.TabStop = false;
            // 
            // btn_back
            // 
            btn_back.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_back.BackgroundImage");
            btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_back.Location = new System.Drawing.Point(295, 15);
            btn_back.Name = "btn_back";
            btn_back.Size = new System.Drawing.Size(75, 30);
            btn_back.TabIndex = 2;
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // menu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new System.Drawing.Size(384, 411);
            Controls.Add(btn_back);
            Controls.Add(btn_dataload);
            Controls.Add(btn_idext);
            Controls.Add(gb_dbloading);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "menu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manager Menu";
            gb_dbloading.ResumeLayout(false);
            gb_dbloading.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_idext;
        private System.Windows.Forms.Button btn_dataload;
        private System.Windows.Forms.RadioButton rbtn_encrypt;
        private System.Windows.Forms.RadioButton rbtn_decrypt;
        private System.Windows.Forms.GroupBox gb_dbloading;
        private System.Windows.Forms.Button btn_back;
    }
}
