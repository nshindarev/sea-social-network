namespace vk_sea_wf.View.Forms
{
    partial class CompanyInfoForm_v2
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStudy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.txtBoxName = new System.Windows.Forms.ComboBox();
            this.txtBoxVK = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Write down your Information system ID in social networks";
            // 
            // btnStudy
            // 
            this.btnStudy.Location = new System.Drawing.Point(209, 261);
            this.btnStudy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStudy.Name = "btnStudy";
            this.btnStudy.Size = new System.Drawing.Size(234, 42);
            this.btnStudy.TabIndex = 7;
            this.btnStudy.Text = "Study Decision Tree";
            this.btnStudy.UseVisualStyleBackColor = true;
            this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 194);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "VK";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // txtBoxName
            // 
            this.txtBoxName.FormattingEnabled = true;
            this.txtBoxName.Items.AddRange(new object[] {
            "Петер-Сервис",
            "Кодельная",
            "OpenWay"});
            this.txtBoxName.Location = new System.Drawing.Point(209, 145);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(327, 28);
            this.txtBoxName.TabIndex = 13;
            // 
            // txtBoxVK
            // 
            this.txtBoxVK.FormattingEnabled = true;
            this.txtBoxVK.Items.AddRange(new object[] {
            "57902527",
            "116186911",
            "132691943"});
            this.txtBoxVK.Location = new System.Drawing.Point(209, 191);
            this.txtBoxVK.Name = "txtBoxVK";
            this.txtBoxVK.Size = new System.Drawing.Size(327, 28);
            this.txtBoxVK.TabIndex = 14;
            // 
            // CompanyInfoForm_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 469);
            this.Controls.Add(this.txtBoxVK);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStudy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CompanyInfoForm_v2";
            this.Text = "CompanyInfoForm_v2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStudy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox txtBoxName;
        public System.Windows.Forms.ComboBox txtBoxVK;
    }
}