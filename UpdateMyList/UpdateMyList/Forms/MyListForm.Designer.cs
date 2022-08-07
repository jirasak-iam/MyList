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
            this.myListtap = new System.Windows.Forms.TabControl();
            this.listtap = new System.Windows.Forms.TabPage();
            this.genrelb = new System.Windows.Forms.ListBox();
            this.seasonlb = new System.Windows.Forms.ListBox();
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
            this.genreclb = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.seasoncbb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.myListtap.SuspendLayout();
            this.listtap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.inserttap.SuspendLayout();
            this.SuspendLayout();
            // 
            // myListtap
            // 
            this.myListtap.Controls.Add(this.listtap);
            this.myListtap.Controls.Add(this.inserttap);
            this.myListtap.ItemSize = new System.Drawing.Size(50, 30);
            this.myListtap.Location = new System.Drawing.Point(2, 1);
            this.myListtap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.myListtap.Name = "myListtap";
            this.myListtap.SelectedIndex = 0;
            this.myListtap.Size = new System.Drawing.Size(1527, 572);
            this.myListtap.TabIndex = 1;
            this.myListtap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myListap_KeyDown);
            // 
            // listtap
            // 
            this.listtap.AutoScroll = true;
            this.listtap.Controls.Add(this.genrelb);
            this.listtap.Controls.Add(this.seasonlb);
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
            this.listtap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listtap.Name = "listtap";
            this.listtap.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listtap.Size = new System.Drawing.Size(1519, 534);
            this.listtap.TabIndex = 0;
            this.listtap.Text = "รายการ";
            this.listtap.UseVisualStyleBackColor = true;
            // 
            // genrelb
            // 
            this.genrelb.FormattingEnabled = true;
            this.genrelb.Location = new System.Drawing.Point(692, 0);
            this.genrelb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.genrelb.Name = "genrelb";
            this.genrelb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.genrelb.Size = new System.Drawing.Size(222, 95);
            this.genrelb.TabIndex = 28;
            this.genrelb.SelectedIndexChanged += new System.EventHandler(this.genrelb_SelectedIndexChanged);
            this.genrelb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.genrelb_KeyDown);
            // 
            // seasonlb
            // 
            this.seasonlb.FormattingEnabled = true;
            this.seasonlb.Location = new System.Drawing.Point(467, 1);
            this.seasonlb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.seasonlb.Name = "seasonlb";
            this.seasonlb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.seasonlb.Size = new System.Drawing.Size(222, 95);
            this.seasonlb.TabIndex = 27;
            this.seasonlb.SelectedIndexChanged += new System.EventHandler(this.seasonlb_SelectedIndexChanged);
            this.seasonlb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seasonlb_KeyDown);
            // 
            // stslb
            // 
            this.stslb.FormattingEnabled = true;
            this.stslb.Location = new System.Drawing.Point(242, 0);
            this.stslb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stslb.Name = "stslb";
            this.stslb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.stslb.Size = new System.Drawing.Size(222, 95);
            this.stslb.TabIndex = 3;
            this.stslb.SelectedIndexChanged += new System.EventHandler(this.stslb_SelectedIndexChanged);
            this.stslb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stslb_KeyDown);
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(924, 2);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(47, 24);
            this.searchbtn.TabIndex = 4;
            this.searchbtn.Text = "ค้นหา";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            this.searchbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchbtn_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "สถานะ";
            // 
            // searchtxt
            // 
            this.searchtxt.Location = new System.Drawing.Point(44, 6);
            this.searchtxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(145, 20);
            this.searchtxt.TabIndex = 2;
            this.searchtxt.TextChanged += new System.EventHandler(this.searchtxt_TextChanged);
            this.searchtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxt_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "ชื่อเรื่อง";
            // 
            // mainbtn
            // 
            this.mainbtn.Location = new System.Drawing.Point(976, 2);
            this.mainbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainbtn.Name = "mainbtn";
            this.mainbtn.Size = new System.Drawing.Size(47, 23);
            this.mainbtn.TabIndex = 5;
            this.mainbtn.Text = "Main";
            this.mainbtn.UseVisualStyleBackColor = true;
            this.mainbtn.Click += new System.EventHandler(this.mainbtn_Click);
            this.mainbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainbtn_KeyDown);
            // 
            // reloadbtn
            // 
            this.reloadbtn.Location = new System.Drawing.Point(1451, 502);
            this.reloadbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reloadbtn.Name = "reloadbtn";
            this.reloadbtn.Size = new System.Drawing.Size(64, 28);
            this.reloadbtn.TabIndex = 8;
            this.reloadbtn.Text = "Reload";
            this.reloadbtn.UseVisualStyleBackColor = true;
            this.reloadbtn.Click += new System.EventHandler(this.reloadbtn_Click);
            this.reloadbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reloadbtn_KeyDown);
            // 
            // editbtn
            // 
            this.editbtn.Location = new System.Drawing.Point(1385, 502);
            this.editbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(62, 28);
            this.editbtn.TabIndex = 7;
            this.editbtn.Text = "แก้ไข";
            this.editbtn.UseVisualStyleBackColor = true;
            this.editbtn.Click += new System.EventHandler(this.editbtn_Click);
            this.editbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editbtn_KeyDown);
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
            this.dataGridView1.Location = new System.Drawing.Point(2, 107);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1513, 381);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // inserttap
            // 
            this.inserttap.Controls.Add(this.genreclb);
            this.inserttap.Controls.Add(this.label8);
            this.inserttap.Controls.Add(this.seasoncbb);
            this.inserttap.Controls.Add(this.label7);
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
            this.inserttap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inserttap.Name = "inserttap";
            this.inserttap.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inserttap.Size = new System.Drawing.Size(1424, 418);
            this.inserttap.TabIndex = 1;
            this.inserttap.Text = "เพื่ม/แก้ไข";
            this.inserttap.UseVisualStyleBackColor = true;
            // 
            // genreclb
            // 
            this.genreclb.CheckOnClick = true;
            this.genreclb.FormattingEnabled = true;
            this.genreclb.Location = new System.Drawing.Point(113, 222);
            this.genreclb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.genreclb.Name = "genreclb";
            this.genreclb.Size = new System.Drawing.Size(218, 94);
            this.genreclb.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 222);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Genre";
            // 
            // seasoncbb
            // 
            this.seasoncbb.DisplayMember = "stsDesc";
            this.seasoncbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seasoncbb.FormattingEnabled = true;
            this.seasoncbb.Location = new System.Drawing.Point(113, 187);
            this.seasoncbb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.seasoncbb.Name = "seasoncbb";
            this.seasoncbb.Size = new System.Drawing.Size(218, 21);
            this.seasoncbb.TabIndex = 18;
            this.seasoncbb.ValueMember = "stsId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 187);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Season";
            // 
            // gobtn
            // 
            this.gobtn.Location = new System.Drawing.Point(710, 87);
            this.gobtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gobtn.Name = "gobtn";
            this.gobtn.Size = new System.Drawing.Size(20, 19);
            this.gobtn.TabIndex = 14;
            this.gobtn.Text = "G";
            this.gobtn.UseVisualStyleBackColor = true;
            this.gobtn.Click += new System.EventHandler(this.gobtn_Click);
            this.gobtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gobtn_KeyDown);
            // 
            // minusbtn
            // 
            this.minusbtn.Location = new System.Drawing.Point(710, 67);
            this.minusbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minusbtn.Name = "minusbtn";
            this.minusbtn.Size = new System.Drawing.Size(20, 19);
            this.minusbtn.TabIndex = 12;
            this.minusbtn.Text = "-";
            this.minusbtn.UseVisualStyleBackColor = true;
            this.minusbtn.Click += new System.EventHandler(this.minusbtn_Click);
            this.minusbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.minusbtn_KeyDown);
            // 
            // plusbtn
            // 
            this.plusbtn.Location = new System.Drawing.Point(710, 45);
            this.plusbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plusbtn.Name = "plusbtn";
            this.plusbtn.Size = new System.Drawing.Size(20, 19);
            this.plusbtn.TabIndex = 11;
            this.plusbtn.Text = "+";
            this.plusbtn.UseVisualStyleBackColor = true;
            this.plusbtn.Click += new System.EventHandler(this.plusbtn_Click);
            this.plusbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.plusbtn_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 124);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Comment";
            // 
            // commenttxt
            // 
            this.commenttxt.Location = new System.Drawing.Point(113, 122);
            this.commenttxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.commenttxt.Name = "commenttxt";
            this.commenttxt.Size = new System.Drawing.Size(593, 20);
            this.commenttxt.TabIndex = 15;
            this.commenttxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commenttxt_KeyDown);
            // 
            // stscbb
            // 
            this.stscbb.DisplayMember = "stsDesc";
            this.stscbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stscbb.FormattingEnabled = true;
            this.stscbb.Location = new System.Drawing.Point(113, 154);
            this.stscbb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stscbb.Name = "stscbb";
            this.stscbb.Size = new System.Drawing.Size(218, 21);
            this.stscbb.TabIndex = 17;
            this.stscbb.ValueMember = "stsId";
            this.stscbb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stscbb_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "สถานะ";
            // 
            // claerbtn
            // 
            this.claerbtn.Location = new System.Drawing.Point(653, 321);
            this.claerbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.claerbtn.Name = "claerbtn";
            this.claerbtn.Size = new System.Drawing.Size(56, 26);
            this.claerbtn.TabIndex = 21;
            this.claerbtn.Text = "Clear";
            this.claerbtn.UseVisualStyleBackColor = true;
            this.claerbtn.Click += new System.EventHandler(this.claerbtn_Click);
            this.claerbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.claerbtn_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "ตอนล่าสุด";
            // 
            // ePtxt
            // 
            this.ePtxt.Location = new System.Drawing.Point(113, 56);
            this.ePtxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ePtxt.Name = "ePtxt";
            this.ePtxt.Size = new System.Drawing.Size(593, 20);
            this.ePtxt.TabIndex = 10;
            this.ePtxt.TextChanged += new System.EventHandler(this.ePtxt_TextChanged);
            this.ePtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ePtxt_KeyDown);
            this.ePtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ePtxt_KeyPress);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(592, 321);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(56, 26);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "บันทึก";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            this.saveBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saveBtn_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Link";
            // 
            // linkUrltxt
            // 
            this.linkUrltxt.Location = new System.Drawing.Point(113, 87);
            this.linkUrltxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.linkUrltxt.Name = "linkUrltxt";
            this.linkUrltxt.Size = new System.Drawing.Size(593, 20);
            this.linkUrltxt.TabIndex = 13;
            this.linkUrltxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.linkUrltxt_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "ชื่อเรื่อง";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(113, 23);
            this.nametxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(593, 20);
            this.nametxt.TabIndex = 9;
            this.nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nametxt_KeyDown);
            // 
            // MyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1540, 584);
            this.Controls.Add(this.myListtap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MyListForm";
            this.Text = "MyListForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyListForm_FormClosed);
            this.Load += new System.EventHandler(this.MyListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListForm_KeyDown);
            this.myListtap.ResumeLayout(false);
            this.listtap.ResumeLayout(false);
            this.listtap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.inserttap.ResumeLayout(false);
            this.inserttap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl myListtap;
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
        private System.Windows.Forms.ComboBox seasoncbb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox genreclb;
        private System.Windows.Forms.ListBox genrelb;
        private System.Windows.Forms.ListBox seasonlb;
    }
}