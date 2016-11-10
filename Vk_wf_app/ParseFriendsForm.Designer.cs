namespace Vk_wf_app
{
    partial class ParseFriendsForm
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
            this.ListBox = new System.Windows.Forms.ListBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 20;
            this.ListBox.Location = new System.Drawing.Point(44, 105);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(798, 784);
            this.ListBox.TabIndex = 0;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(382, 45);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(142, 20);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "Friends list of user ";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(374, 915);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(170, 46);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // ParseFriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 1013);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.ListBox);
            this.Name = "ParseFriendsForm";
            this.Text = "ParseFriendsForm";
            this.Load += new System.EventHandler(this.ParseFriendsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Button btnParse;
    }
}