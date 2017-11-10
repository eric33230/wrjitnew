namespace JIT

{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiHR = new System.Windows.Forms.ToolStripMenuItem();
            this.地區ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBasic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClassManager1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonManager1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFeedBackManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClassManager = new System.Windows.Forms.ToolStripMenuItem();
            this.學員管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrderIn = new System.Windows.Forms.ToolStripMenuItem();
            this.節假日ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工作日曆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.主計畫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.鞋舌標ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBasic,
            this.tsmiPersonManager1,
            this.tsmiHR,
            this.tsmiClassManager1,
            this.tsmiFeedBackManager,
            this.tsmiWindow,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.tsmiWindow;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1086, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiHR
            // 
            this.tsmiHR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地區ToolStripMenuItem,
            this.tsmiClassManager,
            this.學員管理ToolStripMenuItem});
            this.tsmiHR.Name = "tsmiHR";
            this.tsmiHR.Size = new System.Drawing.Size(94, 27);
            this.tsmiHR.Text = "人事管理";
            this.tsmiHR.Click += new System.EventHandler(this.tsmiUpdatePwd_Click);
            // 
            // 地區ToolStripMenuItem
            // 
            this.地區ToolStripMenuItem.Name = "地區ToolStripMenuItem";
            this.地區ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.地區ToolStripMenuItem.Text = "地區";
            this.地區ToolStripMenuItem.Click += new System.EventHandler(this.ArearToolStripMenuItem_Click);
            // 
            // tsmiBasic
            // 
            this.tsmiBasic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOrderIn,
            this.節假日ToolStripMenuItem,
            this.工作日曆ToolStripMenuItem});
            this.tsmiBasic.Name = "tsmiBasic";
            this.tsmiBasic.Size = new System.Drawing.Size(94, 27);
            this.tsmiBasic.Text = "基本資料";
            this.tsmiBasic.Click += new System.EventHandler(this.tsmiUpUserName_Click);
            // 
            // tsmiClassManager1
            // 
            this.tsmiClassManager1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.鞋舌標ToolStripMenuItem});
            this.tsmiClassManager1.Name = "tsmiClassManager1";
            this.tsmiClassManager1.Size = new System.Drawing.Size(94, 28);
            this.tsmiClassManager1.Text = "商標管理";
            // 
            // tsmiPersonManager1
            // 
            this.tsmiPersonManager1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主計畫ToolStripMenuItem});
            this.tsmiPersonManager1.Name = "tsmiPersonManager1";
            this.tsmiPersonManager1.Size = new System.Drawing.Size(94, 28);
            this.tsmiPersonManager1.Text = "生產管理";
            this.tsmiPersonManager1.Click += new System.EventHandler(this.tsmiPersonManager1_Click);
            // 
            // tsmiFeedBackManager
            // 
            this.tsmiFeedBackManager.Name = "tsmiFeedBackManager";
            this.tsmiFeedBackManager.Size = new System.Drawing.Size(130, 27);
            this.tsmiFeedBackManager.Text = "反馈信息管理";
            this.tsmiFeedBackManager.Click += new System.EventHandler(this.tsmiFeedBackManager_Click);
            // 
            // tsmiWindow
            // 
            this.tsmiWindow.Name = "tsmiWindow";
            this.tsmiWindow.Size = new System.Drawing.Size(58, 27);
            this.tsmiWindow.Text = "窗口";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(58, 27);
            this.tsmiExit.Text = "退出";
            // 
            // tsmiClassManager
            // 
            this.tsmiClassManager.Name = "tsmiClassManager";
            this.tsmiClassManager.Size = new System.Drawing.Size(211, 30);
            this.tsmiClassManager.Text = "班級管理";
            this.tsmiClassManager.Click += new System.EventHandler(this.tsmiClassManager_Click_1);
            // 
            // 學員管理ToolStripMenuItem
            // 
            this.學員管理ToolStripMenuItem.Name = "學員管理ToolStripMenuItem";
            this.學員管理ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.學員管理ToolStripMenuItem.Text = "學員管理";
            this.學員管理ToolStripMenuItem.Click += new System.EventHandler(this.學員管理ToolStripMenuItem_Click);
            // 
            // tsmiOrderIn
            // 
            this.tsmiOrderIn.Name = "tsmiOrderIn";
            this.tsmiOrderIn.Size = new System.Drawing.Size(211, 30);
            this.tsmiOrderIn.Text = "訂單接轉";
            // 
            // 節假日ToolStripMenuItem
            // 
            this.節假日ToolStripMenuItem.Name = "節假日ToolStripMenuItem";
            this.節假日ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.節假日ToolStripMenuItem.Text = "節假日";
            // 
            // 工作日曆ToolStripMenuItem
            // 
            this.工作日曆ToolStripMenuItem.Name = "工作日曆ToolStripMenuItem";
            this.工作日曆ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.工作日曆ToolStripMenuItem.Text = "工作日曆";
            // 
            // 主計畫ToolStripMenuItem
            // 
            this.主計畫ToolStripMenuItem.Name = "主計畫ToolStripMenuItem";
            this.主計畫ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.主計畫ToolStripMenuItem.Text = "主計畫";
            // 
            // 鞋舌標ToolStripMenuItem
            // 
            this.鞋舌標ToolStripMenuItem.Name = "鞋舌標ToolStripMenuItem";
            this.鞋舌標ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.鞋舌標ToolStripMenuItem.Text = "鞋舌標";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 692);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "穎強鞋業";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiHR;
        private System.Windows.Forms.ToolStripMenuItem tsmiBasic;
        private System.Windows.Forms.ToolStripMenuItem tsmiClassManager1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonManager1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFeedBackManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindow;
        private System.Windows.Forms.ToolStripMenuItem 地區ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiClassManager;
        private System.Windows.Forms.ToolStripMenuItem 學員管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrderIn;
        private System.Windows.Forms.ToolStripMenuItem 節假日ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工作日曆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 主計畫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 鞋舌標ToolStripMenuItem;
    }
}