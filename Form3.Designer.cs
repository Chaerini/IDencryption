namespace project2
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            tb_search = new System.Windows.Forms.TextBox();
            bt_condition = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            cb_select = new System.Windows.Forms.ComboBox();
            bt_search = new System.Windows.Forms.Button();
            pn_condition = new System.Windows.Forms.Panel();
            bt_save = new System.Windows.Forms.Button();
            tb_address = new System.Windows.Forms.TextBox();
            lb_address = new System.Windows.Forms.Label();
            checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            bt_choice = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            pn_condition.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tb_search
            // 
            tb_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tb_search.Location = new System.Drawing.Point(190, 27);
            tb_search.Name = "tb_search";
            tb_search.Size = new System.Drawing.Size(416, 23);
            tb_search.TabIndex = 0;
            // 
            // bt_condition
            // 
            bt_condition.BackgroundImage = (System.Drawing.Image)resources.GetObject("bt_condition.BackgroundImage");
            bt_condition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bt_condition.Location = new System.Drawing.Point(615, 27);
            bt_condition.Name = "bt_condition";
            bt_condition.Size = new System.Drawing.Size(85, 23);
            bt_condition.TabIndex = 1;
            bt_condition.UseVisualStyleBackColor = true;
            bt_condition.Click += bt_condition_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(666, 26);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(0, 0);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // cb_select
            // 
            cb_select.BackColor = System.Drawing.Color.White;
            cb_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cb_select.FormattingEnabled = true;
            cb_select.Items.AddRange(new object[] { "전체", "이름", "주민번호 앞자리" });
            cb_select.Location = new System.Drawing.Point(27, 27);
            cb_select.Name = "cb_select";
            cb_select.Size = new System.Drawing.Size(155, 23);
            cb_select.TabIndex = 3;
            cb_select.Text = "전체";
            // 
            // bt_search
            // 
            bt_search.BackgroundImage = (System.Drawing.Image)resources.GetObject("bt_search.BackgroundImage");
            bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bt_search.Location = new System.Drawing.Point(713, 27);
            bt_search.Name = "bt_search";
            bt_search.Size = new System.Drawing.Size(85, 23);
            bt_search.TabIndex = 4;
            bt_search.UseVisualStyleBackColor = true;
            bt_search.Click += bt_search_Click;
            // 
            // pn_condition
            // 
            pn_condition.Controls.Add(bt_save);
            pn_condition.Controls.Add(tb_address);
            pn_condition.Controls.Add(lb_address);
            pn_condition.Controls.Add(checkedListBox2);
            pn_condition.Controls.Add(checkedListBox1);
            pn_condition.Location = new System.Drawing.Point(471, 59);
            pn_condition.Name = "pn_condition";
            pn_condition.Size = new System.Drawing.Size(229, 125);
            pn_condition.TabIndex = 5;
            pn_condition.Visible = false;
            // 
            // bt_save
            // 
            bt_save.BackgroundImage = (System.Drawing.Image)resources.GetObject("bt_save.BackgroundImage");
            bt_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bt_save.Location = new System.Drawing.Point(81, 93);
            bt_save.Name = "bt_save";
            bt_save.Size = new System.Drawing.Size(78, 23);
            bt_save.TabIndex = 6;
            bt_save.UseVisualStyleBackColor = true;
            bt_save.Click += bt_save_Click;
            // 
            // tb_address
            // 
            tb_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tb_address.Location = new System.Drawing.Point(56, 64);
            tb_address.Name = "tb_address";
            tb_address.Size = new System.Drawing.Size(153, 23);
            tb_address.TabIndex = 6;
            // 
            // lb_address
            // 
            lb_address.AutoSize = true;
            lb_address.Location = new System.Drawing.Point(16, 66);
            lb_address.Name = "lb_address";
            lb_address.Size = new System.Drawing.Size(27, 15);
            lb_address.TabIndex = 6;
            lb_address.Text = "주소";
            // 
            // checkedListBox2
            // 
            checkedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { "남성", "여성" });
            checkedListBox2.Location = new System.Drawing.Point(142, 15);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new System.Drawing.Size(67, 38);
            checkedListBox2.TabIndex = 7;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "주민등록증", "운전면허증" });
            checkedListBox1.Location = new System.Drawing.Point(16, 15);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new System.Drawing.Size(101, 38);
            checkedListBox1.TabIndex = 6;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoScroll = true;
            tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 7;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Size = new System.Drawing.Size(771, 294);
            tableLayoutPanel.TabIndex = 8;
            // 
            // bt_choice
            // 
            bt_choice.BackgroundImage = (System.Drawing.Image)resources.GetObject("bt_choice.BackgroundImage");
            bt_choice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bt_choice.Location = new System.Drawing.Point(377, 369);
            bt_choice.Name = "bt_choice";
            bt_choice.Size = new System.Drawing.Size(85, 30);
            bt_choice.TabIndex = 9;
            bt_choice.UseVisualStyleBackColor = true;
            bt_choice.Click += bt_choice_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(tableLayoutPanel);
            panel1.Location = new System.Drawing.Point(27, 69);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(771, 294);
            panel1.TabIndex = 10;
            // 
            // Form3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(839, 411);
            Controls.Add(bt_choice);
            Controls.Add(pn_condition);
            Controls.Add(bt_search);
            Controls.Add(cb_select);
            Controls.Add(button2);
            Controls.Add(bt_condition);
            Controls.Add(tb_search);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Cafe24 Ohsquare air Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Form3";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Search";
            Load += Form3_Load;
            pn_condition.ResumeLayout(false);
            pn_condition.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Button bt_condition;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cb_select;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.Panel pn_condition;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.Label lb_address;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button bt_choice;
        private System.Windows.Forms.Panel panel1;
    }
}