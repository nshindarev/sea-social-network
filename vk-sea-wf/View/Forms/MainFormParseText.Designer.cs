namespace vk_sea_wf.View.Forms {
    partial class MainFormParseText {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.getTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getTextToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(473, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // getTextToolStripMenuItem
            // 
            this.getTextToolStripMenuItem.Name = "getTextToolStripMenuItem";
            this.getTextToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.getTextToolStripMenuItem.Text = "Get Text Data";
            this.getTextToolStripMenuItem.Click += new System.EventHandler(this.getTextToolStripMenuItem_Click);
            // 
            // MainFormParseText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 487);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFormParseText";
            this.Text = "MainFormTree";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem getTextToolStripMenuItem;
    }
}