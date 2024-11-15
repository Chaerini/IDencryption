namespace project2
{
    partial class DrCardDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrCardDetail));
            pb_dimage = new System.Windows.Forms.PictureBox();
            pb_dimage2 = new System.Windows.Forms.PictureBox();
            lb_dltype = new System.Windows.Forms.Label();
            lb_dnumber = new System.Windows.Forms.Label();
            lb_name = new System.Windows.Forms.Label();
            lb_pnumber = new System.Windows.Forms.Label();
            lb_address = new System.Windows.Forms.Label();
            lb_ddate = new System.Windows.Forms.Label();
            lb_dissuer = new System.Windows.Forms.Label();
            bt_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pb_dimage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_dimage2).BeginInit();
            SuspendLayout();
            // 
            // pb_dimage
            // 
            pb_dimage.Location = new System.Drawing.Point(25, 101);
            pb_dimage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pb_dimage.Name = "pb_dimage";
            pb_dimage.Size = new System.Drawing.Size(249, 281);
            pb_dimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb_dimage.TabIndex = 0;
            pb_dimage.TabStop = false;
            // 
            // pb_dimage2
            // 
            pb_dimage2.Location = new System.Drawing.Point(606, 186);
            pb_dimage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pb_dimage2.Name = "pb_dimage2";
            pb_dimage2.Size = new System.Drawing.Size(111, 108);
            pb_dimage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb_dimage2.TabIndex = 1;
            pb_dimage2.TabStop = false;
            // 
            // lb_dltype
            // 
            lb_dltype.BackColor = System.Drawing.Color.Transparent;
            lb_dltype.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            lb_dltype.Location = new System.Drawing.Point(-7, 9);
            lb_dltype.Name = "lb_dltype";
            lb_dltype.Size = new System.Drawing.Size(100, 22);
            lb_dltype.TabIndex = 2;
            lb_dltype.Text = "1종보통";
            lb_dltype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_dnumber
            // 
            lb_dnumber.BackColor = System.Drawing.Color.Transparent;
            lb_dnumber.Font = new System.Drawing.Font("맑은 고딕", 32.75F);
            lb_dnumber.Location = new System.Drawing.Point(300, 52);
            lb_dnumber.Name = "lb_dnumber";
            lb_dnumber.Size = new System.Drawing.Size(370, 56);
            lb_dnumber.TabIndex = 3;
            lb_dnumber.Text = "00-00-000000-00";
            lb_dnumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_name
            // 
            lb_name.BackColor = System.Drawing.Color.Transparent;
            lb_name.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            lb_name.Location = new System.Drawing.Point(300, 116);
            lb_name.Name = "lb_name";
            lb_name.Size = new System.Drawing.Size(79, 31);
            lb_name.TabIndex = 4;
            lb_name.Text = "김민정";
            lb_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_pnumber
            // 
            lb_pnumber.BackColor = System.Drawing.Color.Transparent;
            lb_pnumber.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            lb_pnumber.Location = new System.Drawing.Point(300, 143);
            lb_pnumber.Name = "lb_pnumber";
            lb_pnumber.Size = new System.Drawing.Size(179, 31);
            lb_pnumber.TabIndex = 5;
            lb_pnumber.Text = "000000-0000000";
            lb_pnumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_address
            // 
            lb_address.AutoEllipsis = true;
            lb_address.BackColor = System.Drawing.Color.Transparent;
            lb_address.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            lb_address.Location = new System.Drawing.Point(300, 175);
            lb_address.Name = "lb_address";
            lb_address.Size = new System.Drawing.Size(273, 109);
            lb_address.TabIndex = 6;
            lb_address.Text = "서울특별시 강남구 삼성동";
            lb_address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ddate
            // 
            lb_ddate.BackColor = System.Drawing.Color.Transparent;
            lb_ddate.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            lb_ddate.Location = new System.Drawing.Point(296, 348);
            lb_ddate.Name = "lb_ddate";
            lb_ddate.Size = new System.Drawing.Size(131, 34);
            lb_ddate.TabIndex = 7;
            lb_ddate.Text = "2024.11.07";
            lb_ddate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_dissuer
            // 
            lb_dissuer.BackColor = System.Drawing.Color.Transparent;
            lb_dissuer.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            lb_dissuer.Location = new System.Drawing.Point(436, 348);
            lb_dissuer.Name = "lb_dissuer";
            lb_dissuer.Size = new System.Drawing.Size(226, 34);
            lb_dissuer.TabIndex = 8;
            lb_dissuer.Text = "부산광역시 경찰청장";
            lb_dissuer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            bt_close.TabIndex = 13;
            bt_close.Text = "X";
            bt_close.UseVisualStyleBackColor = false;
            bt_close.Click += bt_close_Click;
            // 
            // DrCardDetail
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(734, 411);
            Controls.Add(bt_close);
            Controls.Add(lb_dissuer);
            Controls.Add(lb_ddate);
            Controls.Add(lb_address);
            Controls.Add(lb_pnumber);
            Controls.Add(lb_name);
            Controls.Add(lb_dnumber);
            Controls.Add(lb_dltype);
            Controls.Add(pb_dimage2);
            Controls.Add(pb_dimage);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "DrCardDetail";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DrCardDetail";
            Load += DrCardDetail_Load;
            ((System.ComponentModel.ISupportInitialize)pb_dimage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_dimage2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pb_dimage;
        private System.Windows.Forms.PictureBox pb_dimage2;
        private System.Windows.Forms.Label lb_dltype;
        private System.Windows.Forms.Label lb_dnumber;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_pnumber;
        private System.Windows.Forms.Label lb_address;
        private System.Windows.Forms.Label lb_ddate;
        private System.Windows.Forms.Label lb_dissuer;
        private System.Windows.Forms.Button bt_close;
    }
}