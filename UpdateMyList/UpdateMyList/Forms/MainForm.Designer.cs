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
            this.listTypelb.Size = new System.Drawing.Size(216, 274);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 315);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTypelb;
        private System.Windows.Forms.Button settingbtn;
    }
}