namespace vk_sea_wf.View.Forms
{
    partial class CompanyInfoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStudy = new System.Windows.Forms.Button();
            this.txtBoxVk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "VK";
            // 
            // btnStudy
            // 
            this.btnStudy.Location = new System.Drawing.Point(182, 225);
            this.btnStudy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStudy.Name = "btnStudy";
            this.btnStudy.Size = new System.Drawing.Size(234, 42);
            this.btnStudy.TabIndex = 1;
            this.btnStudy.Text = "Study Decision Tree";
            this.btnStudy.UseVisualStyleBackColor = true;
            this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
            // 
            // txtBoxVk
            // 
            this.txtBoxVk.Location = new System.Drawing.Point(182, 154);
            this.txtBoxVk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxVk.Name = "txtBoxVk";
            this.txtBoxVk.Size = new System.Drawing.Size(340, 26);
            this.txtBoxVk.TabIndex = 2;
            this.txtBoxVk.Text = "57902527";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write down your Information system ID in social networks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Company Name";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(182, 108);
            this.txtBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(340, 26);
            this.txtBoxName.TabIndex = 5;
            this.txtBoxName.Text = "Петер-Сервис";
            // 
            // CompanyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 342);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxVk);
            this.Controls.Add(this.btnStudy);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CompanyInfoForm";
            this.Text = "CompanyInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStudy;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtBoxVk;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBoxName;
    }
}