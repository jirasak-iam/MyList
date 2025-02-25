﻿namespace UpdateMyList.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.myListtap = new System.Windows.Forms.TabControl();
            this.listtap = new System.Windows.Forms.TabPage();
            this.copybtn = new System.Windows.Forms.Button();
            this.clearTxtGen = new System.Windows.Forms.Button();
            this.gensearchtxt = new System.Windows.Forms.TextBox();
            this.clearTxtSea = new System.Windows.Forms.Button();
            this.seasearchtxt = new System.Windows.Forms.TextBox();
            this.clearTxt = new System.Windows.Forms.Button();
            this.reloadbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stsnoteqrdb = new System.Windows.Forms.RadioButton();
            this.stseqrdb = new System.Windows.Forms.RadioButton();
            this.nonrdb = new System.Windows.Forms.RadioButton();
            this.stslastlb = new System.Windows.Forms.ListBox();
            this.notincb = new System.Windows.Forms.CheckBox();
            this.labelcountpage = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbpage = new System.Windows.Forms.ListBox();
            this.tenrbtn = new System.Windows.Forms.RadioButton();
            this.hunrbtn = new System.Windows.Forms.RadioButton();
            this.fiftyrbtn = new System.Windows.Forms.RadioButton();
            this.allrbtn = new System.Windows.Forms.RadioButton();
            this.genrelb = new System.Windows.Forms.ListBox();
            this.seasonlb = new System.Windows.Forms.ListBox();
            this.stslb = new System.Windows.Forms.ListBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mainbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inserttap = new System.Windows.Forms.TabPage();
            this.minuslastdecbtn = new System.Windows.Forms.Button();
            this.pluslastdecbtn = new System.Windows.Forms.Button();
            this.minusdecbtn = new System.Windows.Forms.Button();
            this.plusdecbtn = new System.Windows.Forms.Button();
            this.maxbtn = new System.Windows.Forms.Button();
            this.stslastcbb = new System.Windows.Forms.ComboBox();
            this.minuslastbtn = new System.Windows.Forms.Button();
            this.pluslastbtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.eplasttxt = new System.Windows.Forms.TextBox();
            this.searchGenTxt = new System.Windows.Forms.TextBox();
            this.searchSeaTxt = new System.Windows.Forms.TextBox();
            this.deletebtn = new System.Windows.Forms.Button();
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
            this.listwebtab = new System.Windows.Forms.TabPage();
            this.searchlistwebtxt = new System.Windows.Forms.TextBox();
            this.weblistlb = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.myListtap.SuspendLayout();
            this.listtap.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.inserttap.SuspendLayout();
            this.listwebtab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.myListtap);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2032, 674);
            this.panel1.TabIndex = 2;
            // 
            // myListtap
            // 
            this.myListtap.Controls.Add(this.listtap);
            this.myListtap.Controls.Add(this.inserttap);
            this.myListtap.Controls.Add(this.listwebtab);
            this.myListtap.ItemSize = new System.Drawing.Size(50, 30);
            this.myListtap.Location = new System.Drawing.Point(0, 2);
            this.myListtap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.myListtap.Name = "myListtap";
            this.myListtap.SelectedIndex = 0;
            this.myListtap.Size = new System.Drawing.Size(2545, 875);
            this.myListtap.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.myListtap.TabIndex = 1;
            this.myListtap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myListap_KeyDown);
            // 
            // listtap
            // 
            this.listtap.AutoScroll = true;
            this.listtap.Controls.Add(this.copybtn);
            this.listtap.Controls.Add(this.clearTxtGen);
            this.listtap.Controls.Add(this.gensearchtxt);
            this.listtap.Controls.Add(this.clearTxtSea);
            this.listtap.Controls.Add(this.seasearchtxt);
            this.listtap.Controls.Add(this.clearTxt);
            this.listtap.Controls.Add(this.reloadbtn);
            this.listtap.Controls.Add(this.panel2);
            this.listtap.Controls.Add(this.stslastlb);
            this.listtap.Controls.Add(this.notincb);
            this.listtap.Controls.Add(this.labelcountpage);
            this.listtap.Controls.Add(this.label10);
            this.listtap.Controls.Add(this.lbpage);
            this.listtap.Controls.Add(this.tenrbtn);
            this.listtap.Controls.Add(this.hunrbtn);
            this.listtap.Controls.Add(this.fiftyrbtn);
            this.listtap.Controls.Add(this.allrbtn);
            this.listtap.Controls.Add(this.genrelb);
            this.listtap.Controls.Add(this.seasonlb);
            this.listtap.Controls.Add(this.stslb);
            this.listtap.Controls.Add(this.searchbtn);
            this.listtap.Controls.Add(this.label6);
            this.listtap.Controls.Add(this.searchtxt);
            this.listtap.Controls.Add(this.label4);
            this.listtap.Controls.Add(this.mainbtn);
            this.listtap.Controls.Add(this.dataGridView1);
            this.listtap.Location = new System.Drawing.Point(4, 34);
            this.listtap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listtap.Name = "listtap";
            this.listtap.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listtap.Size = new System.Drawing.Size(2537, 837);
            this.listtap.TabIndex = 0;
            this.listtap.Text = "รายการ";
            this.listtap.UseVisualStyleBackColor = true;
            // 
            // copybtn
            // 
            this.copybtn.Location = new System.Drawing.Point(1748, 2);
            this.copybtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.copybtn.Name = "copybtn";
            this.copybtn.Size = new System.Drawing.Size(63, 30);
            this.copybtn.TabIndex = 45;
            this.copybtn.Text = "Copy";
            this.copybtn.UseVisualStyleBackColor = true;
            this.copybtn.Click += new System.EventHandler(this.copybtn_Click);
            // 
            // clearTxtGen
            // 
            this.clearTxtGen.Font = new System.Drawing.Font("Cloud", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.clearTxtGen.ForeColor = System.Drawing.Color.Red;
            this.clearTxtGen.Location = new System.Drawing.Point(1496, -1);
            this.clearTxtGen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearTxtGen.Name = "clearTxtGen";
            this.clearTxtGen.Size = new System.Drawing.Size(24, 23);
            this.clearTxtGen.TabIndex = 44;
            this.clearTxtGen.Text = "X";
            this.clearTxtGen.UseVisualStyleBackColor = true;
            this.clearTxtGen.Click += new System.EventHandler(this.clearTxtGen_Click);
            // 
            // gensearchtxt
            // 
            this.gensearchtxt.Location = new System.Drawing.Point(1225, 0);
            this.gensearchtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gensearchtxt.Name = "gensearchtxt";
            this.gensearchtxt.Size = new System.Drawing.Size(271, 22);
            this.gensearchtxt.TabIndex = 43;
            this.gensearchtxt.TextChanged += new System.EventHandler(this.gensearchtxt_TextChanged);
            // 
            // clearTxtSea
            // 
            this.clearTxtSea.Font = new System.Drawing.Font("Cloud", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.clearTxtSea.ForeColor = System.Drawing.Color.Red;
            this.clearTxtSea.Location = new System.Drawing.Point(1195, -1);
            this.clearTxtSea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearTxtSea.Name = "clearTxtSea";
            this.clearTxtSea.Size = new System.Drawing.Size(24, 23);
            this.clearTxtSea.TabIndex = 42;
            this.clearTxtSea.Text = "X";
            this.clearTxtSea.UseVisualStyleBackColor = true;
            this.clearTxtSea.Click += new System.EventHandler(this.clearTxtSea_Click);
            // 
            // seasearchtxt
            // 
            this.seasearchtxt.Location = new System.Drawing.Point(924, 0);
            this.seasearchtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seasearchtxt.Name = "seasearchtxt";
            this.seasearchtxt.Size = new System.Drawing.Size(271, 22);
            this.seasearchtxt.TabIndex = 41;
            this.seasearchtxt.TextChanged += new System.EventHandler(this.seasearchtxt_TextChanged);
            this.seasearchtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seasearchtxt_KeyDown);
            // 
            // clearTxt
            // 
            this.clearTxt.Font = new System.Drawing.Font("Cloud", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.clearTxt.ForeColor = System.Drawing.Color.Red;
            this.clearTxt.Location = new System.Drawing.Point(227, 7);
            this.clearTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearTxt.Name = "clearTxt";
            this.clearTxt.Size = new System.Drawing.Size(24, 23);
            this.clearTxt.TabIndex = 40;
            this.clearTxt.Text = "X";
            this.clearTxt.UseVisualStyleBackColor = true;
            this.clearTxt.Click += new System.EventHandler(this.clearTxt_Click);
            // 
            // reloadbtn
            // 
            this.reloadbtn.Location = new System.Drawing.Point(1671, 2);
            this.reloadbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reloadbtn.Name = "reloadbtn";
            this.reloadbtn.Size = new System.Drawing.Size(71, 30);
            this.reloadbtn.TabIndex = 39;
            this.reloadbtn.Text = "Reload";
            this.reloadbtn.UseVisualStyleBackColor = true;
            this.reloadbtn.Click += new System.EventHandler(this.reloadbtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.stsnoteqrdb);
            this.panel2.Controls.Add(this.stseqrdb);
            this.panel2.Controls.Add(this.nonrdb);
            this.panel2.Location = new System.Drawing.Point(1650, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 89);
            this.panel2.TabIndex = 38;
            // 
            // stsnoteqrdb
            // 
            this.stsnoteqrdb.AutoSize = true;
            this.stsnoteqrdb.Location = new System.Drawing.Point(3, 57);
            this.stsnoteqrdb.Name = "stsnoteqrdb";
            this.stsnoteqrdb.Size = new System.Drawing.Size(137, 21);
            this.stsnoteqrdb.TabIndex = 2;
            this.stsnoteqrdb.TabStop = true;
            this.stsnoteqrdb.Text = "อ่าน/ดู ยังไม่ถึงล่าสุด";
            this.stsnoteqrdb.UseVisualStyleBackColor = true;
            this.stsnoteqrdb.CheckedChanged += new System.EventHandler(this.stsnoteqrdb_CheckedChanged);
            // 
            // stseqrdb
            // 
            this.stseqrdb.AutoSize = true;
            this.stseqrdb.Location = new System.Drawing.Point(3, 30);
            this.stseqrdb.Name = "stseqrdb";
            this.stseqrdb.Size = new System.Drawing.Size(109, 21);
            this.stseqrdb.TabIndex = 1;
            this.stseqrdb.TabStop = true;
            this.stseqrdb.Text = "อ่าน/ดู ถึงล่าสุด";
            this.stseqrdb.UseVisualStyleBackColor = true;
            this.stseqrdb.CheckedChanged += new System.EventHandler(this.stseqrdb_CheckedChanged);
            // 
            // nonrdb
            // 
            this.nonrdb.AutoSize = true;
            this.nonrdb.Location = new System.Drawing.Point(3, 3);
            this.nonrdb.Name = "nonrdb";
            this.nonrdb.Size = new System.Drawing.Size(63, 21);
            this.nonrdb.TabIndex = 0;
            this.nonrdb.TabStop = true;
            this.nonrdb.Text = "None";
            this.nonrdb.UseVisualStyleBackColor = true;
            this.nonrdb.CheckedChanged += new System.EventHandler(this.nonrdb_CheckedChanged);
            // 
            // stslastlb
            // 
            this.stslastlb.FormattingEnabled = true;
            this.stslastlb.ItemHeight = 16;
            this.stslastlb.Location = new System.Drawing.Point(624, 0);
            this.stslastlb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stslastlb.Name = "stslastlb";
            this.stslastlb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.stslastlb.Size = new System.Drawing.Size(295, 116);
            this.stslastlb.TabIndex = 5;
            this.stslastlb.SelectedIndexChanged += new System.EventHandler(this.stslastlb_SelectedIndexChanged);
            this.stslastlb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stslastlb_KeyDown);
            // 
            // notincb
            // 
            this.notincb.AutoSize = true;
            this.notincb.Location = new System.Drawing.Point(1533, 37);
            this.notincb.Name = "notincb";
            this.notincb.Size = new System.Drawing.Size(111, 21);
            this.notincb.TabIndex = 36;
            this.notincb.Text = "Not In Genre";
            this.notincb.UseVisualStyleBackColor = true;
            this.notincb.CheckedChanged += new System.EventHandler(this.notincb_CheckedChanged);
            // 
            // labelcountpage
            // 
            this.labelcountpage.AutoSize = true;
            this.labelcountpage.Location = new System.Drawing.Point(1830, 102);
            this.labelcountpage.Name = "labelcountpage";
            this.labelcountpage.Size = new System.Drawing.Size(0, 17);
            this.labelcountpage.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "หน้าที่";
            // 
            // lbpage
            // 
            this.lbpage.FormattingEnabled = true;
            this.lbpage.ItemHeight = 16;
            this.lbpage.Location = new System.Drawing.Point(131, 35);
            this.lbpage.Name = "lbpage";
            this.lbpage.Size = new System.Drawing.Size(120, 84);
            this.lbpage.TabIndex = 33;
            this.lbpage.SelectedIndexChanged += new System.EventHandler(this.lbpage_SelectedIndexChanged);
            // 
            // tenrbtn
            // 
            this.tenrbtn.AutoSize = true;
            this.tenrbtn.Location = new System.Drawing.Point(23, 54);
            this.tenrbtn.Name = "tenrbtn";
            this.tenrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tenrbtn.Size = new System.Drawing.Size(45, 21);
            this.tenrbtn.TabIndex = 32;
            this.tenrbtn.Text = "10";
            this.tenrbtn.UseVisualStyleBackColor = true;
            this.tenrbtn.Click += new System.EventHandler(this.tenrbtn_Click);
            // 
            // hunrbtn
            // 
            this.hunrbtn.AutoSize = true;
            this.hunrbtn.Location = new System.Drawing.Point(15, 96);
            this.hunrbtn.Name = "hunrbtn";
            this.hunrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hunrbtn.Size = new System.Drawing.Size(53, 21);
            this.hunrbtn.TabIndex = 31;
            this.hunrbtn.Text = "100";
            this.hunrbtn.UseVisualStyleBackColor = true;
            this.hunrbtn.Click += new System.EventHandler(this.hunrbtn_Click);
            // 
            // fiftyrbtn
            // 
            this.fiftyrbtn.AutoSize = true;
            this.fiftyrbtn.Location = new System.Drawing.Point(23, 76);
            this.fiftyrbtn.Name = "fiftyrbtn";
            this.fiftyrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fiftyrbtn.Size = new System.Drawing.Size(45, 21);
            this.fiftyrbtn.TabIndex = 30;
            this.fiftyrbtn.Text = "50";
            this.fiftyrbtn.UseVisualStyleBackColor = true;
            this.fiftyrbtn.Click += new System.EventHandler(this.fiftyrbtn_Click);
            // 
            // allrbtn
            // 
            this.allrbtn.AutoSize = true;
            this.allrbtn.Location = new System.Drawing.Point(24, 34);
            this.allrbtn.Name = "allrbtn";
            this.allrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.allrbtn.Size = new System.Drawing.Size(44, 21);
            this.allrbtn.TabIndex = 29;
            this.allrbtn.Text = "All";
            this.allrbtn.UseVisualStyleBackColor = true;
            this.allrbtn.Click += new System.EventHandler(this.allrbtn_Click);
            // 
            // genrelb
            // 
            this.genrelb.FormattingEnabled = true;
            this.genrelb.ItemHeight = 16;
            this.genrelb.Location = new System.Drawing.Point(1224, 32);
            this.genrelb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.genrelb.Name = "genrelb";
            this.genrelb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.genrelb.Size = new System.Drawing.Size(295, 84);
            this.genrelb.TabIndex = 7;
            this.genrelb.SelectedIndexChanged += new System.EventHandler(this.genrelb_SelectedIndexChanged);
            this.genrelb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.genrelb_KeyDown);
            // 
            // seasonlb
            // 
            this.seasonlb.FormattingEnabled = true;
            this.seasonlb.ItemHeight = 16;
            this.seasonlb.Location = new System.Drawing.Point(924, 32);
            this.seasonlb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seasonlb.Name = "seasonlb";
            this.seasonlb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.seasonlb.Size = new System.Drawing.Size(295, 84);
            this.seasonlb.TabIndex = 6;
            this.seasonlb.SelectedIndexChanged += new System.EventHandler(this.seasonlb_SelectedIndexChanged);
            this.seasonlb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seasonlb_KeyDown);
            // 
            // stslb
            // 
            this.stslb.FormattingEnabled = true;
            this.stslb.ItemHeight = 16;
            this.stslb.Location = new System.Drawing.Point(323, 0);
            this.stslb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stslb.Name = "stslb";
            this.stslb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.stslb.Size = new System.Drawing.Size(295, 116);
            this.stslb.TabIndex = 4;
            this.stslb.SelectedIndexChanged += new System.EventHandler(this.stslb_SelectedIndexChanged);
            this.stslb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stslb_KeyDown);
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(1533, 2);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(63, 30);
            this.searchbtn.TabIndex = 4;
            this.searchbtn.Text = "ค้นหา";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            this.searchbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchbtn_KeyDown);
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
            this.searchtxt.Location = new System.Drawing.Point(59, 7);
            this.searchtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(171, 22);
            this.searchtxt.TabIndex = 1;
            this.searchtxt.TextChanged += new System.EventHandler(this.searchtxt_TextChanged);
            this.searchtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxt_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "ชื่อเรื่อง";
            // 
            // mainbtn
            // 
            this.mainbtn.Location = new System.Drawing.Point(1602, 2);
            this.mainbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainbtn.Name = "mainbtn";
            this.mainbtn.Size = new System.Drawing.Size(63, 30);
            this.mainbtn.TabIndex = 5;
            this.mainbtn.Text = "Main";
            this.mainbtn.UseVisualStyleBackColor = true;
            this.mainbtn.Click += new System.EventHandler(this.mainbtn_Click);
            this.mainbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainbtn_KeyDown);
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 132);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(2017, 469);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // inserttap
            // 
            this.inserttap.Controls.Add(this.minuslastdecbtn);
            this.inserttap.Controls.Add(this.pluslastdecbtn);
            this.inserttap.Controls.Add(this.minusdecbtn);
            this.inserttap.Controls.Add(this.plusdecbtn);
            this.inserttap.Controls.Add(this.maxbtn);
            this.inserttap.Controls.Add(this.stslastcbb);
            this.inserttap.Controls.Add(this.minuslastbtn);
            this.inserttap.Controls.Add(this.pluslastbtn);
            this.inserttap.Controls.Add(this.label11);
            this.inserttap.Controls.Add(this.eplasttxt);
            this.inserttap.Controls.Add(this.searchGenTxt);
            this.inserttap.Controls.Add(this.searchSeaTxt);
            this.inserttap.Controls.Add(this.deletebtn);
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
            this.inserttap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inserttap.Name = "inserttap";
            this.inserttap.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inserttap.Size = new System.Drawing.Size(2537, 837);
            this.inserttap.TabIndex = 1;
            this.inserttap.Text = "เพื่ม/แก้ไข";
            this.inserttap.UseVisualStyleBackColor = true;
            // 
            // minuslastdecbtn
            // 
            this.minuslastdecbtn.Location = new System.Drawing.Point(1066, 101);
            this.minuslastdecbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minuslastdecbtn.Name = "minuslastdecbtn";
            this.minuslastdecbtn.Size = new System.Drawing.Size(48, 23);
            this.minuslastdecbtn.TabIndex = 44;
            this.minuslastdecbtn.Text = "-.1";
            this.minuslastdecbtn.UseVisualStyleBackColor = true;
            this.minuslastdecbtn.Click += new System.EventHandler(this.minuslastdecbtn_Click);
            // 
            // pluslastdecbtn
            // 
            this.pluslastdecbtn.Location = new System.Drawing.Point(1012, 101);
            this.pluslastdecbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pluslastdecbtn.Name = "pluslastdecbtn";
            this.pluslastdecbtn.Size = new System.Drawing.Size(48, 23);
            this.pluslastdecbtn.TabIndex = 43;
            this.pluslastdecbtn.Text = "+.1";
            this.pluslastdecbtn.UseVisualStyleBackColor = true;
            this.pluslastdecbtn.Click += new System.EventHandler(this.pluslastdecbtn_Click);
            // 
            // minusdecbtn
            // 
            this.minusdecbtn.Location = new System.Drawing.Point(1067, 68);
            this.minusdecbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minusdecbtn.Name = "minusdecbtn";
            this.minusdecbtn.Size = new System.Drawing.Size(48, 23);
            this.minusdecbtn.TabIndex = 42;
            this.minusdecbtn.Text = "-.1";
            this.minusdecbtn.UseVisualStyleBackColor = true;
            this.minusdecbtn.Click += new System.EventHandler(this.minusdecbtn_Click);
            // 
            // plusdecbtn
            // 
            this.plusdecbtn.Location = new System.Drawing.Point(1013, 68);
            this.plusdecbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plusdecbtn.Name = "plusdecbtn";
            this.plusdecbtn.Size = new System.Drawing.Size(48, 23);
            this.plusdecbtn.TabIndex = 41;
            this.plusdecbtn.Text = "+.1";
            this.plusdecbtn.UseVisualStyleBackColor = true;
            this.plusdecbtn.Click += new System.EventHandler(this.plusdecbtn_Click);
            // 
            // maxbtn
            // 
            this.maxbtn.Location = new System.Drawing.Point(1121, 69);
            this.maxbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxbtn.Name = "maxbtn";
            this.maxbtn.Size = new System.Drawing.Size(27, 23);
            this.maxbtn.TabIndex = 40;
            this.maxbtn.Text = "M";
            this.maxbtn.UseVisualStyleBackColor = true;
            this.maxbtn.Click += new System.EventHandler(this.maxbtn_Click);
            // 
            // stslastcbb
            // 
            this.stslastcbb.DisplayMember = "stsDesc";
            this.stslastcbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stslastcbb.FormattingEnabled = true;
            this.stslastcbb.Location = new System.Drawing.Point(418, 215);
            this.stslastcbb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stslastcbb.Name = "stslastcbb";
            this.stslastcbb.Size = new System.Drawing.Size(250, 24);
            this.stslastcbb.TabIndex = 20;
            this.stslastcbb.ValueMember = "stsId";
            // 
            // minuslastbtn
            // 
            this.minuslastbtn.Location = new System.Drawing.Point(979, 101);
            this.minuslastbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minuslastbtn.Name = "minuslastbtn";
            this.minuslastbtn.Size = new System.Drawing.Size(27, 23);
            this.minuslastbtn.TabIndex = 15;
            this.minuslastbtn.Text = "-";
            this.minuslastbtn.UseVisualStyleBackColor = true;
            this.minuslastbtn.Click += new System.EventHandler(this.minuslastbtn_Click);
            this.minuslastbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.minuslastbtn_KeyDown);
            // 
            // pluslastbtn
            // 
            this.pluslastbtn.Location = new System.Drawing.Point(946, 101);
            this.pluslastbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pluslastbtn.Name = "pluslastbtn";
            this.pluslastbtn.Size = new System.Drawing.Size(27, 23);
            this.pluslastbtn.TabIndex = 14;
            this.pluslastbtn.Text = "+";
            this.pluslastbtn.UseVisualStyleBackColor = true;
            this.pluslastbtn.Click += new System.EventHandler(this.pluslastbtn_Click);
            this.pluslastbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pluslastbtn_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 39;
            this.label11.Text = "ตอนล่าสุด";
            // 
            // eplasttxt
            // 
            this.eplasttxt.Location = new System.Drawing.Point(151, 102);
            this.eplasttxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eplasttxt.Name = "eplasttxt";
            this.eplasttxt.Size = new System.Drawing.Size(789, 22);
            this.eplasttxt.TabIndex = 13;
            this.eplasttxt.TextChanged += new System.EventHandler(this.eplasttxt_TextChanged);
            this.eplasttxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eplasttxt_KeyDown);
            this.eplasttxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eplasttxt_KeyPress);
            // 
            // searchGenTxt
            // 
            this.searchGenTxt.Location = new System.Drawing.Point(151, 295);
            this.searchGenTxt.Name = "searchGenTxt";
            this.searchGenTxt.Size = new System.Drawing.Size(250, 22);
            this.searchGenTxt.TabIndex = 23;
            this.searchGenTxt.TextChanged += new System.EventHandler(this.searchGenTxt_TextChanged);
            this.searchGenTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchGenTxt_KeyDown);
            // 
            // searchSeaTxt
            // 
            this.searchSeaTxt.Location = new System.Drawing.Point(151, 252);
            this.searchSeaTxt.Name = "searchSeaTxt";
            this.searchSeaTxt.Size = new System.Drawing.Size(250, 22);
            this.searchSeaTxt.TabIndex = 21;
            this.searchSeaTxt.TextChanged += new System.EventHandler(this.searchSeaTxt_TextChanged);
            this.searchSeaTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchSeaTxt_KeyDown);
            // 
            // deletebtn
            // 
            this.deletebtn.Font = new System.Drawing.Font("Cloud", 12F, System.Drawing.FontStyle.Bold);
            this.deletebtn.Location = new System.Drawing.Point(869, 531);
            this.deletebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(75, 32);
            this.deletebtn.TabIndex = 27;
            this.deletebtn.Text = "ลบ";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            this.deletebtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deletebtn_KeyDown);
            // 
            // genreclb
            // 
            this.genreclb.CheckOnClick = true;
            this.genreclb.FormattingEnabled = true;
            this.genreclb.Location = new System.Drawing.Point(418, 295);
            this.genreclb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.genreclb.Name = "genreclb";
            this.genreclb.Size = new System.Drawing.Size(300, 259);
            this.genreclb.TabIndex = 24;
            this.genreclb.Click += new System.EventHandler(this.genreclb_Click);
            this.genreclb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.genreclb_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "Genre";
            // 
            // seasoncbb
            // 
            this.seasoncbb.DisplayMember = "stsDesc";
            this.seasoncbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seasoncbb.FormattingEnabled = true;
            this.seasoncbb.IntegralHeight = false;
            this.seasoncbb.ItemHeight = 16;
            this.seasoncbb.Location = new System.Drawing.Point(418, 252);
            this.seasoncbb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seasoncbb.Name = "seasoncbb";
            this.seasoncbb.Size = new System.Drawing.Size(250, 24);
            this.seasoncbb.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Season";
            // 
            // gobtn
            // 
            this.gobtn.Location = new System.Drawing.Point(947, 135);
            this.gobtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gobtn.Name = "gobtn";
            this.gobtn.Size = new System.Drawing.Size(27, 23);
            this.gobtn.TabIndex = 17;
            this.gobtn.Text = "G";
            this.gobtn.UseVisualStyleBackColor = true;
            this.gobtn.Click += new System.EventHandler(this.gobtn_Click);
            this.gobtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gobtn_KeyDown);
            // 
            // minusbtn
            // 
            this.minusbtn.Location = new System.Drawing.Point(980, 68);
            this.minusbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minusbtn.Name = "minusbtn";
            this.minusbtn.Size = new System.Drawing.Size(27, 23);
            this.minusbtn.TabIndex = 12;
            this.minusbtn.Text = "-";
            this.minusbtn.UseVisualStyleBackColor = true;
            this.minusbtn.Click += new System.EventHandler(this.minusbtn_Click);
            this.minusbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.minusbtn_KeyDown);
            // 
            // plusbtn
            // 
            this.plusbtn.Location = new System.Drawing.Point(947, 68);
            this.plusbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plusbtn.Name = "plusbtn";
            this.plusbtn.Size = new System.Drawing.Size(27, 23);
            this.plusbtn.TabIndex = 11;
            this.plusbtn.Text = "+";
            this.plusbtn.UseVisualStyleBackColor = true;
            this.plusbtn.Click += new System.EventHandler(this.plusbtn_Click);
            this.plusbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.plusbtn_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Comment";
            // 
            // commenttxt
            // 
            this.commenttxt.Location = new System.Drawing.Point(151, 178);
            this.commenttxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commenttxt.Name = "commenttxt";
            this.commenttxt.Size = new System.Drawing.Size(789, 22);
            this.commenttxt.TabIndex = 18;
            this.commenttxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commenttxt_KeyDown);
            // 
            // stscbb
            // 
            this.stscbb.DisplayMember = "stsDesc";
            this.stscbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stscbb.FormattingEnabled = true;
            this.stscbb.ItemHeight = 16;
            this.stscbb.Location = new System.Drawing.Point(151, 215);
            this.stscbb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stscbb.Name = "stscbb";
            this.stscbb.Size = new System.Drawing.Size(250, 24);
            this.stscbb.TabIndex = 19;
            this.stscbb.ValueMember = "stsId";
            this.stscbb.SelectedIndexChanged += new System.EventHandler(this.stscbb_SelectedIndexChanged);
            this.stscbb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stscbb_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "สถานะ";
            // 
            // claerbtn
            // 
            this.claerbtn.Font = new System.Drawing.Font("Cloud", 12F, System.Drawing.FontStyle.Bold);
            this.claerbtn.Location = new System.Drawing.Point(869, 580);
            this.claerbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.claerbtn.Name = "claerbtn";
            this.claerbtn.Size = new System.Drawing.Size(75, 32);
            this.claerbtn.TabIndex = 26;
            this.claerbtn.Text = "เคลียร์";
            this.claerbtn.UseVisualStyleBackColor = true;
            this.claerbtn.Click += new System.EventHandler(this.claerbtn_Click);
            this.claerbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.claerbtn_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "ตอนปัจจุบัน";
            // 
            // ePtxt
            // 
            this.ePtxt.Location = new System.Drawing.Point(151, 69);
            this.ePtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ePtxt.Name = "ePtxt";
            this.ePtxt.Size = new System.Drawing.Size(789, 22);
            this.ePtxt.TabIndex = 10;
            this.ePtxt.TextChanged += new System.EventHandler(this.ePtxt_TextChanged);
            this.ePtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ePtxt_KeyDown);
            this.ePtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ePtxt_KeyPress);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Cloud", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(787, 580);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 32);
            this.saveBtn.TabIndex = 25;
            this.saveBtn.Text = "บันทึก";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            this.saveBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saveBtn_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Link";
            // 
            // linkUrltxt
            // 
            this.linkUrltxt.Location = new System.Drawing.Point(151, 135);
            this.linkUrltxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.linkUrltxt.Name = "linkUrltxt";
            this.linkUrltxt.Size = new System.Drawing.Size(789, 22);
            this.linkUrltxt.TabIndex = 16;
            this.linkUrltxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.linkUrltxt_KeyDown);
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
            this.nametxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(789, 22);
            this.nametxt.TabIndex = 9;
            this.nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nametxt_KeyDown);
            // 
            // listwebtab
            // 
            this.listwebtab.Controls.Add(this.searchlistwebtxt);
            this.listwebtab.Controls.Add(this.weblistlb);
            this.listwebtab.Location = new System.Drawing.Point(4, 34);
            this.listwebtab.Name = "listwebtab";
            this.listwebtab.Padding = new System.Windows.Forms.Padding(3);
            this.listwebtab.Size = new System.Drawing.Size(2537, 837);
            this.listwebtab.TabIndex = 2;
            this.listwebtab.Text = "List Web";
            this.listwebtab.UseVisualStyleBackColor = true;
            // 
            // searchlistwebtxt
            // 
            this.searchlistwebtxt.Location = new System.Drawing.Point(22, 25);
            this.searchlistwebtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchlistwebtxt.Name = "searchlistwebtxt";
            this.searchlistwebtxt.Size = new System.Drawing.Size(318, 22);
            this.searchlistwebtxt.TabIndex = 6;
            this.searchlistwebtxt.TextChanged += new System.EventHandler(this.searchlistwebtxt_TextChanged);
            this.searchlistwebtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchlistwebtxt_KeyDown);
            // 
            // weblistlb
            // 
            this.weblistlb.FormattingEnabled = true;
            this.weblistlb.ItemHeight = 16;
            this.weblistlb.Location = new System.Drawing.Point(22, 65);
            this.weblistlb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.weblistlb.Name = "weblistlb";
            this.weblistlb.Size = new System.Drawing.Size(318, 260);
            this.weblistlb.TabIndex = 5;
            this.weblistlb.Click += new System.EventHandler(this.weblistlb_Click);
            this.weblistlb.DoubleClick += new System.EventHandler(this.weblistlb_DoubleClick);
            // 
            // MyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 698);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MyListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyListForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyListForm_FormClosed);
            this.Load += new System.EventHandler(this.MyListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.myListtap.ResumeLayout(false);
            this.listtap.ResumeLayout(false);
            this.listtap.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.inserttap.ResumeLayout(false);
            this.inserttap.PerformLayout();
            this.listwebtab.ResumeLayout(false);
            this.listwebtab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl myListtap;
        private System.Windows.Forms.TabPage listtap;
        private System.Windows.Forms.Label labelcountpage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbpage;
        private System.Windows.Forms.RadioButton tenrbtn;
        private System.Windows.Forms.RadioButton hunrbtn;
        private System.Windows.Forms.RadioButton fiftyrbtn;
        private System.Windows.Forms.RadioButton allrbtn;
        private System.Windows.Forms.ListBox genrelb;
        private System.Windows.Forms.ListBox seasonlb;
        private System.Windows.Forms.ListBox stslb;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button mainbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage inserttap;
        private System.Windows.Forms.CheckedListBox genreclb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox seasoncbb;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.CheckBox notincb;
        private System.Windows.Forms.TextBox searchGenTxt;
        private System.Windows.Forms.TextBox searchSeaTxt;
        private System.Windows.Forms.ListBox stslastlb;
        private System.Windows.Forms.ComboBox stslastcbb;
        private System.Windows.Forms.Button minuslastbtn;
        private System.Windows.Forms.Button pluslastbtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox eplasttxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton stsnoteqrdb;
        private System.Windows.Forms.RadioButton stseqrdb;
        private System.Windows.Forms.RadioButton nonrdb;
        private System.Windows.Forms.Button maxbtn;
        private System.Windows.Forms.Button reloadbtn;
        private System.Windows.Forms.Button clearTxt;
        private System.Windows.Forms.Button clearTxtSea;
        private System.Windows.Forms.TextBox seasearchtxt;
        private System.Windows.Forms.Button clearTxtGen;
        private System.Windows.Forms.TextBox gensearchtxt;
        private System.Windows.Forms.Button minusdecbtn;
        private System.Windows.Forms.Button plusdecbtn;
        private System.Windows.Forms.Button minuslastdecbtn;
        private System.Windows.Forms.Button pluslastdecbtn;
        private System.Windows.Forms.Button copybtn;
        private System.Windows.Forms.TabPage listwebtab;
        private System.Windows.Forms.ListBox weblistlb;
        private System.Windows.Forms.TextBox searchlistwebtxt;
    }
}