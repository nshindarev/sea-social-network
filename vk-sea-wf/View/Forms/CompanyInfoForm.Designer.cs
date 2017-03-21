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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VK";
            // 
            // btnStudy
            // 
            this.btnStudy.Location = new System.Drawing.Point(133, 120);
            this.btnStudy.Name = "btnStudy";
            this.btnStudy.Size = new System.Drawing.Size(156, 27);
            this.btnStudy.TabIndex = 1;
            this.btnStudy.Text = "Study Decision Tree";
            this.btnStudy.UseVisualStyleBackColor = true;
            this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
            // 
            // txtBoxVk
            // 
            this.txtBoxVk.Location = new System.Drawing.Point(105, 66);
            this.txtBoxVk.Name = "txtBoxVk";
            this.txtBoxVk.Size = new System.Drawing.Size(228, 20);
            this.txtBoxVk.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write down your Information system ID in social networks";
            // 
            // CompanyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 222);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxVk);
            this.Controls.Add(this.btnStudy);
            this.Controls.Add(this.label1);
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
    }
}