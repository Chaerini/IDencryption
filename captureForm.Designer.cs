namespace Mytrans
{
    partial class captureForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(captureForm));
            captureButten = new System.Windows.Forms.Button();
            btn_text = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            textBox1 = new System.Windows.Forms.TextBox();
            btn_save = new System.Windows.Forms.Button();
            btn_face = new System.Windows.Forms.Button();
            face_pic = new System.Windows.Forms.PictureBox();
            btn_back = new System.Windows.Forms.Button();
            btn_clear = new System.Windows.Forms.Button();
            btn_QR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)face_pic).BeginInit();
            SuspendLayout();
            // 
            // captureButten
            // 
            captureButten.BackgroundImage = (System.Drawing.Image)resources.GetObject("captureButten.BackgroundImage");
            captureButten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            captureButten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            captureButten.Location = new System.Drawing.Point(780, 155);
            captureButten.Margin = new System.Windows.Forms.Padding(0);
            captureButten.Name = "captureButten";
            captureButten.Size = new System.Drawing.Size(160, 60);
            captureButten.TabIndex = 0;
            captureButten.UseVisualStyleBackColor = true;
            captureButten.Click += captureButten_Click;
            // 
            // btn_text
            // 
            btn_text.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_text.BackgroundImage");
            btn_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btn_text.Location = new System.Drawing.Point(780, 227);
            btn_text.Margin = new System.Windows.Forms.Padding(0);
            btn_text.Name = "btn_text";
            btn_text.Size = new System.Drawing.Size(160, 60);
            btn_text.TabIndex = 1;
            btn_text.UseVisualStyleBackColor = true;
            btn_text.Click += btn_text_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(15, 15);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(500, 500);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.Location = new System.Drawing.Point(520, 15);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(250, 243);
            textBox1.TabIndex = 5;
            // 
            // btn_save
            // 
            btn_save.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_save.BackgroundImage");
            btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btn_save.Location = new System.Drawing.Point(780, 375);
            btn_save.Margin = new System.Windows.Forms.Padding(0);
            btn_save.Name = "btn_save";
            btn_save.Size = new System.Drawing.Size(160, 60);
            btn_save.TabIndex = 6;
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_face
            // 
            btn_face.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_face.BackgroundImage");
            btn_face.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_face.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btn_face.Location = new System.Drawing.Point(780, 300);
            btn_face.Margin = new System.Windows.Forms.Padding(0);
            btn_face.Name = "btn_face";
            btn_face.Size = new System.Drawing.Size(160, 60);
            btn_face.TabIndex = 7;
            btn_face.UseVisualStyleBackColor = true;
            btn_face.Click += btn_face_Click;
            // 
            // face_pic
            // 
            face_pic.Location = new System.Drawing.Point(520, 265);
            face_pic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            face_pic.Name = "face_pic";
            face_pic.Size = new System.Drawing.Size(250, 250);
            face_pic.TabIndex = 8;
            face_pic.TabStop = false;
            // 
            // btn_back
            // 
            btn_back.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_back.BackgroundImage");
            btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btn_back.Location = new System.Drawing.Point(780, 15);
            btn_back.Margin = new System.Windows.Forms.Padding(0);
            btn_back.Name = "btn_back";
            btn_back.Size = new System.Drawing.Size(160, 60);
            btn_back.TabIndex = 9;
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // btn_clear
            // 
            btn_clear.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_clear.BackgroundImage");
            btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btn_clear.Location = new System.Drawing.Point(780, 85);
            btn_clear.Margin = new System.Windows.Forms.Padding(0);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new System.Drawing.Size(160, 60);
            btn_clear.TabIndex = 10;
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_QR
            // 
            btn_QR.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_QR.BackgroundImage");
            btn_QR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_QR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btn_QR.Location = new System.Drawing.Point(780, 455);
            btn_QR.Margin = new System.Windows.Forms.Padding(0);
            btn_QR.Name = "btn_QR";
            btn_QR.Size = new System.Drawing.Size(160, 60);
            btn_QR.TabIndex = 11;
            btn_QR.UseVisualStyleBackColor = true;
            btn_QR.Click += btn_QR_Click;
            // 
            // captureForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(954, 531);
            Controls.Add(btn_QR);
            Controls.Add(btn_clear);
            Controls.Add(btn_back);
            Controls.Add(face_pic);
            Controls.Add(btn_face);
            Controls.Add(btn_save);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(btn_text);
            Controls.Add(captureButten);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "captureForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Detect";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)face_pic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button captureButten;
        private System.Windows.Forms.Button btn_text;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_face;
        private System.Windows.Forms.PictureBox face_pic;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_QR;
    }
}

