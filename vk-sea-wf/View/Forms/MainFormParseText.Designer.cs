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
            this.tableDataParsed = new System.Windows.Forms.DataGridView();
            this.getExtendedTextDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataParsed)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getTextToolStripMenuItem,
            this.getExtendedTextDataToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(719, 24);
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
            // tableDataParsed
            // 
            this.tableDataParsed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableDataParsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataParsed.Location = new System.Drawing.Point(0, 27);
            this.tableDataParsed.Name = "tableDataParsed";
            this.tableDataParsed.Size = new System.Drawing.Size(719, 282);
            this.tableDataParsed.TabIndex = 3;
            // 
            // getExtendedTextDataToolStripMenuItem
            // 
            this.getExtendedTextDataToolStripMenuItem.Name = "getExtendedTextDataToolStripMenuItem";
            this.getExtendedTextDataToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.getExtendedTextDataToolStripMenuItem.Text = "Get Extended Text Data";
            this.getExtendedTextDataToolStripMenuItem.Click += new System.EventHandler(this.getExtendedTextDataToolStripMenuItem_Click);
            // 
            // MainFormParseText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 309);
            this.Controls.Add(this.tableDataParsed);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFormParseText";
            this.Text = "MainFormTree";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataParsed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem getTextToolStripMenuItem;
        private System.Windows.Forms.DataGridView tableDataParsed;
        private System.Windows.Forms.ToolStripMenuItem getExtendedTextDataToolStripMenuItem;
    }
}