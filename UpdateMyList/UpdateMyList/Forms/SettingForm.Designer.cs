﻿namespace UpdateMyList.Forms
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.settingtap = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.consumecbb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listTypeclb = new System.Windows.Forms.CheckedListBox();
            this.gencodebtn = new System.Windows.Forms.Button();
            this.seasonlistlb = new System.Windows.Forms.ListBox();
            this.gbtn = new System.Windows.Forms.Button();
            this.tablenametxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sortseqnb = new System.Windows.Forms.NumericUpDown();
            this.recstatuscbb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.desctxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codetxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mapcbb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reloadbtn = new System.Windows.Forms.Button();
            this.mainbtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.settingtap.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sortseqnb)).BeginInit();
            this.SuspendLayout();
            // 
            // settingtap
            // 
            this.settingtap.Controls.Add(this.tabPage1);
            this.settingtap.Controls.Add(this.tabPage2);
            this.settingtap.Controls.Add(this.tabPage3);
            this.settingtap.Location = new System.Drawing.Point(12, 75);
            this.settingtap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingtap.Name = "settingtap";
            this.settingtap.SelectedIndex = 0;
            this.settingtap.Size = new System.Drawing.Size(888, 364);
            this.settingtap.TabIndex = 2;
            this.settingtap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settingtap_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(880, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "รายการ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(870, 324);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.consumecbb);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.listTypeclb);
            this.tabPage2.Controls.Add(this.gencodebtn);
            this.tabPage2.Controls.Add(this.seasonlistlb);
            this.tabPage2.Controls.Add(this.gbtn);
            this.tabPage2.Controls.Add(this.tablenametxt);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.clearbtn);
            this.tabPage2.Controls.Add(this.savebtn);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.sortseqnb);
            this.tabPage2.Controls.Add(this.recstatuscbb);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.desctxt);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.codetxt);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(880, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "เพิ่ม/แก้ไข";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // consumecbb
            // 
            this.consumecbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.consumecbb.FormattingEnabled = true;
            this.consumecbb.Location = new System.Drawing.Point(113, 167);
            this.consumecbb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.consumecbb.Name = "consumecbb";
            this.consumecbb.Size = new System.Drawing.Size(175, 24);
            this.consumecbb.TabIndex = 17;
            this.consumecbb.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "ประเภทสื่อ";
            this.label9.Visible = false;
            // 
            // listTypeclb
            // 
            this.listTypeclb.FormattingEnabled = true;
            this.listTypeclb.Location = new System.Drawing.Point(592, 16);
            this.listTypeclb.Name = "listTypeclb";
            this.listTypeclb.Size = new System.Drawing.Size(183, 140);
            this.listTypeclb.TabIndex = 15;
            this.listTypeclb.Visible = false;
            this.listTypeclb.Click += new System.EventHandler(this.listTypeclb_Click);
            // 
            // gencodebtn
            // 
            this.gencodebtn.Location = new System.Drawing.Point(490, 50);
            this.gencodebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gencodebtn.Name = "gencodebtn";
            this.gencodebtn.Size = new System.Drawing.Size(37, 31);
            this.gencodebtn.TabIndex = 14;
            this.gencodebtn.Text = "G";
            this.gencodebtn.UseVisualStyleBackColor = true;
            this.gencodebtn.Visible = false;
            this.gencodebtn.Click += new System.EventHandler(this.gencodebtn_Click);
            // 
            // seasonlistlb
            // 
            this.seasonlistlb.FormattingEnabled = true;
            this.seasonlistlb.ItemHeight = 16;
            this.seasonlistlb.Location = new System.Drawing.Point(592, 177);
            this.seasonlistlb.Name = "seasonlistlb";
            this.seasonlistlb.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.seasonlistlb.Size = new System.Drawing.Size(183, 132);
            this.seasonlistlb.TabIndex = 13;
            this.seasonlistlb.Visible = false;
            // 
            // gbtn
            // 
            this.gbtn.Location = new System.Drawing.Point(293, 126);
            this.gbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbtn.Name = "gbtn";
            this.gbtn.Size = new System.Drawing.Size(37, 31);
            this.gbtn.TabIndex = 12;
            this.gbtn.Text = "G";
            this.gbtn.UseVisualStyleBackColor = true;
            this.gbtn.Click += new System.EventHandler(this.gbtn_Click);
            // 
            // tablenametxt
            // 
            this.tablenametxt.Location = new System.Drawing.Point(592, 53);
            this.tablenametxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablenametxt.Name = "tablenametxt";
            this.tablenametxt.Size = new System.Drawing.Size(183, 22);
            this.tablenametxt.TabIndex = 11;
            this.tablenametxt.Visible = false;
            this.tablenametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tablenametxt_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "TableName";
            this.label6.Visible = false;
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(409, 202);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(75, 31);
            this.clearbtn.TabIndex = 9;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(328, 202);
            this.savebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 31);
            this.savebtn.TabIndex = 8;
            this.savebtn.Text = "บันทึก";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "เรียงลำดับ";
            // 
            // sortseqnb
            // 
            this.sortseqnb.Location = new System.Drawing.Point(115, 130);
            this.sortseqnb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sortseqnb.Name = "sortseqnb";
            this.sortseqnb.Size = new System.Drawing.Size(173, 22);
            this.sortseqnb.TabIndex = 7;
            this.sortseqnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sortseqnb_KeyDown);
            // 
            // recstatuscbb
            // 
            this.recstatuscbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recstatuscbb.FormattingEnabled = true;
            this.recstatuscbb.Location = new System.Drawing.Point(115, 90);
            this.recstatuscbb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recstatuscbb.Name = "recstatuscbb";
            this.recstatuscbb.Size = new System.Drawing.Size(175, 24);
            this.recstatuscbb.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "สถานะใช้งาน";
            // 
            // desctxt
            // 
            this.desctxt.Location = new System.Drawing.Point(115, 53);
            this.desctxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.desctxt.Name = "desctxt";
            this.desctxt.Size = new System.Drawing.Size(369, 22);
            this.desctxt.TabIndex = 5;
            this.desctxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.desctxt_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "รายละเอียด";
            // 
            // codetxt
            // 
            this.codetxt.Location = new System.Drawing.Point(115, 14);
            this.codetxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.codetxt.Name = "codetxt";
            this.codetxt.Size = new System.Drawing.Size(369, 22);
            this.codetxt.TabIndex = 4;
            this.codetxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codetxt_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "รหัส";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(880, 335);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "รายละเอียด";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // mapcbb
            // 
            this.mapcbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapcbb.FormattingEnabled = true;
            this.mapcbb.Location = new System.Drawing.Point(72, 12);
            this.mapcbb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mapcbb.Name = "mapcbb";
            this.mapcbb.Size = new System.Drawing.Size(428, 24);
            this.mapcbb.TabIndex = 1;
            this.mapcbb.SelectedIndexChanged += new System.EventHandler(this.mapcbb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Option";
            // 
            // reloadbtn
            // 
            this.reloadbtn.Location = new System.Drawing.Point(729, 7);
            this.reloadbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reloadbtn.Name = "reloadbtn";
            this.reloadbtn.Size = new System.Drawing.Size(75, 33);
            this.reloadbtn.TabIndex = 3;
            this.reloadbtn.Text = "Reload";
            this.reloadbtn.UseVisualStyleBackColor = true;
            this.reloadbtn.Click += new System.EventHandler(this.reloadbtn_Click);
            // 
            // mainbtn
            // 
            this.mainbtn.Location = new System.Drawing.Point(648, 7);
            this.mainbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainbtn.Name = "mainbtn";
            this.mainbtn.Size = new System.Drawing.Size(75, 33);
            this.mainbtn.TabIndex = 4;
            this.mainbtn.Text = "Main";
            this.mainbtn.UseVisualStyleBackColor = true;
            this.mainbtn.Click += new System.EventHandler(this.mainbtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "รหัส";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(72, 48);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(139, 22);
            this.txtcode.TabIndex = 6;
            this.txtcode.TextChanged += new System.EventHandler(this.txtcode_TextChanged);
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(313, 48);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(191, 22);
            this.txtdesc.TabIndex = 8;
            this.txtdesc.TextChanged += new System.EventHandler(this.txtdesc_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "รายละเอียด";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 450);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mainbtn);
            this.Controls.Add(this.reloadbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapcbb);
            this.Controls.Add(this.settingtap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SettingForm";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingForm_KeyDown);
            this.settingtap.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sortseqnb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl settingtap;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox mapcbb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox desctxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codetxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown sortseqnb;
        private System.Windows.Forms.ComboBox recstatuscbb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button reloadbtn;
        private System.Windows.Forms.Button mainbtn;
        private System.Windows.Forms.TextBox tablenametxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button gbtn;
        private System.Windows.Forms.ListBox seasonlistlb;
        private System.Windows.Forms.Button gencodebtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox listTypeclb;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox consumecbb;
        private System.Windows.Forms.Label label9;
    }
}