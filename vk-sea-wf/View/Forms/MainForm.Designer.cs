namespace vk_sea_wf.View.Forms
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(88, 113);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(596, 664);
            this.listBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1326, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(832, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 372);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(894, 113);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(128, 20);
            this.lblUserInfo.TabIndex = 3;
            this.lblUserInfo.Text = "User Information";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1326, 1007);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserInfo;
    }
}