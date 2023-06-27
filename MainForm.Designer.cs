namespace PowerfulWindSlickedBackHair
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.frameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.threadsList = new System.Windows.Forms.ListView();
            this.columnT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.frameLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 144);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(312, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
            // 
            // frameLabel
            // 
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(13, 20);
            this.frameLabel.Text = " ";
            // 
            // threadsList
            // 
            this.threadsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnT,
            this.columnS});
            this.threadsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadsList.HideSelection = false;
            this.threadsList.Location = new System.Drawing.Point(0, 0);
            this.threadsList.Name = "threadsList";
            this.threadsList.Size = new System.Drawing.Size(312, 144);
            this.threadsList.TabIndex = 2;
            this.threadsList.UseCompatibleStateImageBehavior = false;
            this.threadsList.View = System.Windows.Forms.View.Details;
            this.threadsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.threadsList_MouseDown);
            this.threadsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.threadsList_MouseUp);
            // 
            // columnT
            // 
            this.columnT.Text = "T";
            this.columnT.Width = 150;
            // 
            // columnS
            // 
            this.columnS.Text = "S";
            this.columnS.Width = 150;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 170);
            this.Controls.Add(this.threadsList);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel frameLabel;
        private System.Windows.Forms.ListView threadsList;
        private System.Windows.Forms.ColumnHeader columnT;
        private System.Windows.Forms.ColumnHeader columnS;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

