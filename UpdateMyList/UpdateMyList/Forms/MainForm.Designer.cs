namespace UpdateMyList.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listTypelb = new System.Windows.Forms.ListBox();
            this.settingbtn = new System.Windows.Forms.Button();
            this.tenrbtn = new System.Windows.Forms.RadioButton();
            this.hunrbtn = new System.Windows.Forms.RadioButton();
            this.fiftyrbtn = new System.Windows.Forms.RadioButton();
            this.allrbtn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idascrbtn = new System.Windows.Forms.RadioButton();
            this.iddescrbtn = new System.Windows.Forms.RadioButton();
            this.datedescrbtn = new System.Windows.Forms.RadioButton();
            this.dateascrbtn = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listTypelb
            // 
            this.listTypelb.FormattingEnabled = true;
            this.listTypelb.ItemHeight = 27;
            this.listTypelb.Location = new System.Drawing.Point(18, 20);
            this.listTypelb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listTypelb.Name = "listTypelb";
            this.listTypelb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listTypelb.Size = new System.Drawing.Size(216, 301);
            this.listTypelb.TabIndex = 1;
            this.listTypelb.SelectedIndexChanged += new System.EventHandler(this.listTypelb_SelectedIndexChanged);
            this.listTypelb.DoubleClick += new System.EventHandler(this.listTypelb_DoubleClick);
            this.listTypelb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listTypelb_KeyDown);
            // 
            // settingbtn
            // 
            this.settingbtn.Location = new System.Drawing.Point(247, 22);
            this.settingbtn.Name = "settingbtn";
            this.settingbtn.Size = new System.Drawing.Size(116, 36);
            this.settingbtn.TabIndex = 2;
            this.settingbtn.Text = "Setting";
            this.settingbtn.UseVisualStyleBackColor = true;
            this.settingbtn.Click += new System.EventHandler(this.settingbtn_Click);
            // 
            // tenrbtn
            // 
            this.tenrbtn.AutoSize = true;
            this.tenrbtn.Location = new System.Drawing.Point(65, 29);
            this.tenrbtn.Name = "tenrbtn";
            this.tenrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tenrbtn.Size = new System.Drawing.Size(57, 31);
            this.tenrbtn.TabIndex = 36;
            this.tenrbtn.TabStop = true;
            this.tenrbtn.Text = "10";
            this.tenrbtn.UseVisualStyleBackColor = true;
            // 
            // hunrbtn
            // 
            this.hunrbtn.AutoSize = true;
            this.hunrbtn.Location = new System.Drawing.Point(53, 85);
            this.hunrbtn.Name = "hunrbtn";
            this.hunrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hunrbtn.Size = new System.Drawing.Size(69, 31);
            this.hunrbtn.TabIndex = 35;
            this.hunrbtn.TabStop = true;
            this.hunrbtn.Text = "100";
            this.hunrbtn.UseVisualStyleBackColor = true;
            // 
            // fiftyrbtn
            // 
            this.fiftyrbtn.AutoSize = true;
            this.fiftyrbtn.Location = new System.Drawing.Point(65, 57);
            this.fiftyrbtn.Name = "fiftyrbtn";
            this.fiftyrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fiftyrbtn.Size = new System.Drawing.Size(57, 31);
            this.fiftyrbtn.TabIndex = 34;
            this.fiftyrbtn.TabStop = true;
            this.fiftyrbtn.Text = "50";
            this.fiftyrbtn.UseVisualStyleBackColor = true;
            // 
            // allrbtn
            // 
            this.allrbtn.AutoSize = true;
            this.allrbtn.Location = new System.Drawing.Point(63, 3);
            this.allrbtn.Name = "allrbtn";
            this.allrbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.allrbtn.Size = new System.Drawing.Size(59, 31);
            this.allrbtn.TabIndex = 33;
            this.allrbtn.TabStop = true;
            this.allrbtn.Text = "All";
            this.allrbtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.allrbtn);
            this.panel1.Controls.Add(this.tenrbtn);
            this.panel1.Controls.Add(this.fiftyrbtn);
            this.panel1.Controls.Add(this.hunrbtn);
            this.panel1.Location = new System.Drawing.Point(241, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 129);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.datedescrbtn);
            this.panel2.Controls.Add(this.dateascrbtn);
            this.panel2.Controls.Add(this.iddescrbtn);
            this.panel2.Controls.Add(this.idascrbtn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(242, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 121);
            this.panel2.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // idascrbtn
            // 
            this.idascrbtn.AutoSize = true;
            this.idascrbtn.Font = new System.Drawing.Font("Cloud", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idascrbtn.Location = new System.Drawing.Point(4, 35);
            this.idascrbtn.Name = "idascrbtn";
            this.idascrbtn.Size = new System.Drawing.Size(58, 23);
            this.idascrbtn.TabIndex = 2;
            this.idascrbtn.TabStop = true;
            this.idascrbtn.Text = "ASC";
            this.idascrbtn.UseVisualStyleBackColor = true;
            // 
            // iddescrbtn
            // 
            this.iddescrbtn.AutoSize = true;
            this.iddescrbtn.Font = new System.Drawing.Font("Cloud", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iddescrbtn.Location = new System.Drawing.Point(4, 64);
            this.iddescrbtn.Name = "iddescrbtn";
            this.iddescrbtn.Size = new System.Drawing.Size(65, 23);
            this.iddescrbtn.TabIndex = 3;
            this.iddescrbtn.TabStop = true;
            this.iddescrbtn.Text = "DESC";
            this.iddescrbtn.UseVisualStyleBackColor = true;
            // 
            // datedescrbtn
            // 
            this.datedescrbtn.AutoSize = true;
            this.datedescrbtn.Font = new System.Drawing.Font("Cloud", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datedescrbtn.Location = new System.Drawing.Point(68, 63);
            this.datedescrbtn.Name = "datedescrbtn";
            this.datedescrbtn.Size = new System.Drawing.Size(65, 23);
            this.datedescrbtn.TabIndex = 5;
            this.datedescrbtn.TabStop = true;
            this.datedescrbtn.Text = "DESC";
            this.datedescrbtn.UseVisualStyleBackColor = true;
            // 
            // dateascrbtn
            // 
            this.dateascrbtn.AutoSize = true;
            this.dateascrbtn.Font = new System.Drawing.Font("Cloud", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateascrbtn.Location = new System.Drawing.Point(68, 34);
            this.dateascrbtn.Name = "dateascrbtn";
            this.dateascrbtn.Size = new System.Drawing.Size(58, 23);
            this.dateascrbtn.TabIndex = 4;
            this.dateascrbtn.TabStop = true;
            this.dateascrbtn.Text = "ASC";
            this.dateascrbtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 334);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.settingbtn);
            this.Controls.Add(this.listTypelb);
            this.Font = new System.Drawing.Font("Cloud", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTypelb;
        private System.Windows.Forms.Button settingbtn;
        private System.Windows.Forms.RadioButton tenrbtn;
        private System.Windows.Forms.RadioButton hunrbtn;
        private System.Windows.Forms.RadioButton fiftyrbtn;
        private System.Windows.Forms.RadioButton allrbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton datedescrbtn;
        private System.Windows.Forms.RadioButton dateascrbtn;
        private System.Windows.Forms.RadioButton iddescrbtn;
        private System.Windows.Forms.RadioButton idascrbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}