namespace UpdateMyList.Forms
{
    partial class MyListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyListForm));
            this.listMangatap = new System.Windows.Forms.TabControl();
            this.listtap = new System.Windows.Forms.TabPage();
            this.stslb = new System.Windows.Forms.ListBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mainbtn = new System.Windows.Forms.Button();
            this.reloadbtn = new System.Windows.Forms.Button();
            this.editbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inserttap = new System.Windows.Forms.TabPage();
            this.gobtn = new System.Windows.Forms.Button();
            this.minusbtn = new System.Windows.Forms.Button();
            this.plusbtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.commenttxt = new System.Windows.Forms.TextBox();
            this.stscbb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.claerbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ePtxt = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkUrltxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.listMangatap.SuspendLayout();
            this.listtap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.inserttap.SuspendLayout();
            this.SuspendLayout();
            // 
            // listMangatap
            // 
            this.listMangatap.Controls.Add(this.listtap);
            this.listMangatap.Controls.Add(this.inserttap);
            this.listMangatap.ItemSize = new System.Drawing.Size(50, 30);
            this.listMangatap.Location = new System.Drawing.Point(3, 1);
            this.listMangatap.Name = "listMangatap";
            this.listMangatap.SelectedIndex = 0;
            this.listMangatap.Size = new System.Drawing.Size(1579, 553);
            this.listMangatap.TabIndex = 10;
            // 
            // listtap
            // 
            this.listtap.AutoScroll = true;
            this.listtap.Controls.Add(this.stslb);
            this.listtap.Controls.Add(this.searchbtn);
            this.listtap.Controls.Add(this.label6);
            this.listtap.Controls.Add(this.searchtxt);
            this.listtap.Controls.Add(this.label4);
            this.listtap.Controls.Add(this.mainbtn);
            this.listtap.Controls.Add(this.reloadbtn);
            this.listtap.Controls.Add(this.editbtn);
            this.listtap.Controls.Add(this.dataGridView1);
            this.listtap.Location = new System.Drawing.Point(4, 34);
            this.listtap.Name = "listtap";
            this.listtap.Padding = new System.Windows.Forms.Padding(3);
            this.listtap.Size = new System.Drawing.Size(1571, 515);
            this.listtap.TabIndex = 0;
            this.listtap.Text = "รายการ";
            this.listtap.UseVisualStyleBackColor = true;
            // 
            // stslb
            // 
            this.stslb.FormattingEnabled = true;
            this.stslb.ItemHeight = 16;
            this.stslb.Location = new System.Drawing.Point(323, 0);
            this.stslb.Name = "stslb";
            this.stslb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.stslb.Size = new System.Drawing.Size(294, 36);
            this.stslb.TabIndex = 6;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(623, 1);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(63, 29);
            this.searchbtn.TabIndex = 7;
            this.searchbtn.Text = "ค้นหา";
            this.searchbtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "สถานะ";
            // 
            // searchtxt
            // 
            this.searchtxt.Location = new System.Drawing.Point(59, 8);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(192, 22);
            this.searchtxt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "ชื่อเรื่อง";
            // 
            // mainbtn
            // 
            this.mainbtn.Location = new System.Drawing.Point(692, 1);
            this.mainbtn.Name = "mainbtn";
            this.mainbtn.Size = new System.Drawing.Size(63, 28);
            this.mainbtn.TabIndex = 8;
            this.mainbtn.Text = "Main";
            this.mainbtn.UseVisualStyleBackColor = true;
            // 
            // reloadbtn
            // 
            this.reloadbtn.Location = new System.Drawing.Point(1429, 472);
            this.reloadbtn.Name = "reloadbtn";
            this.reloadbtn.Size = new System.Drawing.Size(86, 35);
            this.reloadbtn.TabIndex = 3;
            this.reloadbtn.Text = "Reload";
            this.reloadbtn.UseVisualStyleBackColor = true;
            // 
            // editbtn
            // 
            this.editbtn.Location = new System.Drawing.Point(1341, 472);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(82, 35);
            this.editbtn.TabIndex = 2;
            this.editbtn.Text = "แก้ไข";
            this.editbtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Angsana New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1512, 430);
            this.dataGridView1.TabIndex = 1;
            // 
            // inserttap
            // 
            this.inserttap.Controls.Add(this.gobtn);
            this.inserttap.Controls.Add(this.minusbtn);
            this.inserttap.Controls.Add(this.plusbtn);
            this.inserttap.Controls.Add(this.label9);
            this.inserttap.Controls.Add(this.commenttxt);
            this.inserttap.Controls.Add(this.stscbb);
            this.inserttap.Controls.Add(this.label5);
            this.inserttap.Controls.Add(this.claerbtn);
            this.inserttap.Controls.Add(this.label3);
            this.inserttap.Controls.Add(this.ePtxt);
            this.inserttap.Controls.Add(this.saveBtn);
            this.inserttap.Controls.Add(this.label2);
            this.inserttap.Controls.Add(this.linkUrltxt);
            this.inserttap.Controls.Add(this.label1);
            this.inserttap.Controls.Add(this.nametxt);
            this.inserttap.Location = new System.Drawing.Point(4, 34);
            this.inserttap.Name = "inserttap";
            this.inserttap.Padding = new System.Windows.Forms.Padding(3);
            this.inserttap.Size = new System.Drawing.Size(1571, 515);
            this.inserttap.TabIndex = 1;
            this.inserttap.Text = "เพื่ม/แก้ไข";
            this.inserttap.UseVisualStyleBackColor = true;
            // 
            // gobtn
            // 
            this.gobtn.Location = new System.Drawing.Point(946, 107);
            this.gobtn.Name = "gobtn";
            this.gobtn.Size = new System.Drawing.Size(27, 23);
            this.gobtn.TabIndex = 15;
            this.gobtn.Text = "G";
            this.gobtn.UseVisualStyleBackColor = true;
            // 
            // minusbtn
            // 
            this.minusbtn.Location = new System.Drawing.Point(946, 82);
            this.minusbtn.Name = "minusbtn";
            this.minusbtn.Size = new System.Drawing.Size(27, 23);
            this.minusbtn.TabIndex = 13;
            this.minusbtn.Text = "-";
            this.minusbtn.UseVisualStyleBackColor = true;
            // 
            // plusbtn
            // 
            this.plusbtn.Location = new System.Drawing.Point(946, 55);
            this.plusbtn.Name = "plusbtn";
            this.plusbtn.Size = new System.Drawing.Size(27, 23);
            this.plusbtn.TabIndex = 12;
            this.plusbtn.Text = "+";
            this.plusbtn.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Comment";
            // 
            // commenttxt
            // 
            this.commenttxt.Location = new System.Drawing.Point(151, 150);
            this.commenttxt.Name = "commenttxt";
            this.commenttxt.Size = new System.Drawing.Size(789, 22);
            this.commenttxt.TabIndex = 16;
            // 
            // stscbb
            // 
            this.stscbb.DisplayMember = "stsDesc";
            this.stscbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stscbb.FormattingEnabled = true;
            this.stscbb.Location = new System.Drawing.Point(151, 190);
            this.stscbb.Name = "stscbb";
            this.stscbb.Size = new System.Drawing.Size(179, 24);
            this.stscbb.TabIndex = 17;
            this.stscbb.ValueMember = "stsId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "สถานะ";
            // 
            // claerbtn
            // 
            this.claerbtn.Location = new System.Drawing.Point(871, 237);
            this.claerbtn.Name = "claerbtn";
            this.claerbtn.Size = new System.Drawing.Size(75, 32);
            this.claerbtn.TabIndex = 19;
            this.claerbtn.Text = "Clear";
            this.claerbtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "ตอนล่าสุด";
            // 
            // ePtxt
            // 
            this.ePtxt.Location = new System.Drawing.Point(151, 69);
            this.ePtxt.Name = "ePtxt";
            this.ePtxt.Size = new System.Drawing.Size(789, 22);
            this.ePtxt.TabIndex = 11;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(790, 237);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 32);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "บันทึก";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Link";
            // 
            // linkUrltxt
            // 
            this.linkUrltxt.Location = new System.Drawing.Point(151, 107);
            this.linkUrltxt.Name = "linkUrltxt";
            this.linkUrltxt.Size = new System.Drawing.Size(789, 22);
            this.linkUrltxt.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "ชื่อเรื่อง";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(151, 28);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(789, 22);
            this.nametxt.TabIndex = 10;
            // 
            // MyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 554);
            this.Controls.Add(this.listMangatap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyListForm";
            this.Text = "MyListForm";
            this.Load += new System.EventHandler(this.MyListForm_Load);
            this.listMangatap.ResumeLayout(false);
            this.listtap.ResumeLayout(false);
            this.listtap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.inserttap.ResumeLayout(false);
            this.inserttap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl listMangatap;
        private System.Windows.Forms.TabPage listtap;
        private System.Windows.Forms.ListBox stslb;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button mainbtn;
        private System.Windows.Forms.Button reloadbtn;
        private System.Windows.Forms.Button editbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage inserttap;
        private System.Windows.Forms.Button gobtn;
        private System.Windows.Forms.Button minusbtn;
        private System.Windows.Forms.Button plusbtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox commenttxt;
        private System.Windows.Forms.ComboBox stscbb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button claerbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ePtxt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox linkUrltxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nametxt;
    }
}