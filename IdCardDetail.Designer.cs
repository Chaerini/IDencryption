namespace project2
{
    partial class IdCardDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdCardDetail));
            lb_name = new System.Windows.Forms.Label();
            lb_pnumber = new System.Windows.Forms.Label();
            lb_address = new System.Windows.Forms.Label();
            lb_pdate = new System.Windows.Forms.Label();
            lb_issuer = new System.Windows.Forms.Label();
            pb_pimage = new System.Windows.Forms.PictureBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            bt_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pb_pimage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lb_name
            // 
            lb_name.BackColor = System.Drawing.Color.Transparent;
            lb_name.Font = new System.Drawing.Font("맑은 고딕", 21.75F);
            lb_name.Location = new System.Drawing.Point(186, 100);
            lb_name.Name = "lb_name";
            lb_name.Size = new System.Drawing.Size(109, 36);
            lb_name.TabIndex = 0;
            lb_name.Text = "팜하니";
            lb_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_pnumber
            // 
            lb_pnumber.BackColor = System.Drawing.Color.Transparent;
            lb_pnumber.Font = new System.Drawing.Font("맑은 고딕", 20.25F);
            lb_pnumber.Location = new System.Drawing.Point(135, 143);
            lb_pnumber.Name = "lb_pnumber";
            lb_pnumber.Size = new System.Drawing.Size(233, 31);
            lb_pnumber.TabIndex = 1;
            lb_pnumber.Text = "000000-0000000";
            // 
            // lb_address
            // 
            lb_address.AutoEllipsis = true;
            lb_address.BackColor = System.Drawing.Color.Transparent;
            lb_address.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            lb_address.Location = new System.Drawing.Point(114, 212);
            lb_address.Name = "lb_address";
            lb_address.Size = new System.Drawing.Size(288, 98);
            lb_address.TabIndex = 2;
            lb_address.Text = "서울특별시 강남구 삼성동";
            // 
            // lb_pdate
            // 
            lb_pdate.BackColor = System.Drawing.Color.Transparent;
            lb_pdate.Font = new System.Drawing.Font("맑은 고딕", 18F);
            lb_pdate.Location = new System.Drawing.Point(278, 310);
            lb_pdate.Name = "lb_pdate";
            lb_pdate.Size = new System.Drawing.Size(173, 40);
            lb_pdate.TabIndex = 3;
            lb_pdate.Text = "2022.01.01";
            lb_pdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_issuer
            // 
            lb_issuer.BackColor = System.Drawing.Color.Transparent;
            lb_issuer.Font = new System.Drawing.Font("맑은 고딕", 20.25F);
            lb_issuer.Location = new System.Drawing.Point(186, 345);
            lb_issuer.Name = "lb_issuer";
            lb_issuer.Size = new System.Drawing.Size(349, 41);
            lb_issuer.TabIndex = 4;
            lb_issuer.Text = "서울특별시 용산구청장";
            lb_issuer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_pimage
            // 
            pb_pimage.Location = new System.Drawing.Point(460, 33);
            pb_pimage.Name = "pb_pimage";
            pb_pimage.Size = new System.Drawing.Size(240, 251);
            pb_pimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb_pimage.TabIndex = 5;
            pb_pimage.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(520, 313);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(71, 73);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // bt_close
            // 
            bt_close.BackColor = System.Drawing.Color.Transparent;
            bt_close.FlatAppearance.BorderSize = 0;
            bt_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            bt_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bt_close.Font = new System.Drawing.Font("맑은 고딕", 12.75F);
            bt_close.Location = new System.Drawing.Point(700, 2);
            bt_close.Name = "bt_close";
            bt_close.Size = new System.Drawing.Size(32, 32);
            bt_close.TabIndex = 12;
            bt_close.Text = "X";
            bt_close.UseVisualStyleBackColor = false;
            bt_close.Click += bt_close_Click;
            // 
            // IdCardDetail
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(734, 411);
            Controls.Add(bt_close);
            Controls.Add(pictureBox1);
            Controls.Add(pb_pimage);
            Controls.Add(lb_issuer);
            Controls.Add(lb_pdate);
            Controls.Add(lb_address);
            Controls.Add(lb_pnumber);
            Controls.Add(lb_name);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "IdCardDetail";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "IdCardDetail";
            Load += IdCardDetail_Load;
            ((System.ComponentModel.ISupportInitialize)pb_pimage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_pnumber;
        private System.Windows.Forms.Label lb_address;
        private System.Windows.Forms.Label lb_pdate;
        private System.Windows.Forms.Label lb_issuer;
        private System.Windows.Forms.PictureBox pb_pimage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_close;
    }
}