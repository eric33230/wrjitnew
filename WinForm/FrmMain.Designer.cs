namespace WinForm

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem tsmiBarcode;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tsmiQAcheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWHin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScanSee = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQAREcheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmipdinventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiBasic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWorkCalendar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoleManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTestNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrderIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPackListers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiwxbarPrints = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMuneManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonManager1 = new System.Windows.Forms.ToolStripMenuItem();
            this.主計畫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStyleManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStyleBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBarcodeBasic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBuyer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPacklist = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInnerBox = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHR = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiArea = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClassManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmifingerprintManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKQ = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKQDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmicolseallwind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tsmipdMaterial = new System.Windows.Forms.ToolStripMenuItem();
            tsmiBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmiBarcode
            // 
            tsmiBarcode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQAcheck,
            this.tsmiWHin,
            this.tsmiScanSee,
            this.tsmiQAREcheck,
            this.tsmipdinventory,
            this.tsmipdMaterial});
            tsmiBarcode.Name = "tsmiBarcode";
            tsmiBarcode.Size = new System.Drawing.Size(68, 21);
            tsmiBarcode.Text = "條碼管理";
            // 
            // tsmiQAcheck
            // 
            this.tsmiQAcheck.Name = "tsmiQAcheck";
            this.tsmiQAcheck.Size = new System.Drawing.Size(166, 22);
            this.tsmiQAcheck.Text = "QA外箱內盒檢驗";
            this.tsmiQAcheck.Click += new System.EventHandler(this.tsmiQAcheck_Click);
            // 
            // tsmiWHin
            // 
            this.tsmiWHin.Name = "tsmiWHin";
            this.tsmiWHin.Size = new System.Drawing.Size(166, 22);
            this.tsmiWHin.Text = "成品箱入庫掃描";
            this.tsmiWHin.Click += new System.EventHandler(this.tsmiWHin_Click);
            // 
            // tsmiScanSee
            // 
            this.tsmiScanSee.Name = "tsmiScanSee";
            this.tsmiScanSee.Size = new System.Drawing.Size(166, 22);
            this.tsmiScanSee.Text = "扫描查询";
            this.tsmiScanSee.Click += new System.EventHandler(this.tsmiScanSee_Click);
            // 
            // tsmiQAREcheck
            // 
            this.tsmiQAREcheck.Name = "tsmiQAREcheck";
            this.tsmiQAREcheck.Size = new System.Drawing.Size(166, 22);
            this.tsmiQAREcheck.Text = "QA外箱内盒重检";
            this.tsmiQAREcheck.Click += new System.EventHandler(this.tsmiQAREcheck_Click);
            // 
            // tsmipdinventory
            // 
            this.tsmipdinventory.Name = "tsmipdinventory";
            this.tsmipdinventory.Size = new System.Drawing.Size(166, 22);
            this.tsmipdinventory.Text = "成品盘点";
            this.tsmipdinventory.Click += new System.EventHandler(this.tsmipdinventory_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBasic,
            this.tsmiPersonManager1,
            this.tsmiStyleManager,
            this.tsmiBarcodeBasic,
            tsmiBarcode,
            this.tsmiHR,
            this.tsmiKQ,
            this.tsmiWindow,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.tsmiWindow;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiBasic
            // 
            this.tsmiBasic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHoliday,
            this.tsmiWorkCalendar,
            this.tsmiRoleManager,
            this.tsmiTestNetwork,
            this.tsmiOrderIn,
            this.tsmiPackListers,
            this.tsmiwxbarPrints,
            this.tsmiMuneManager});
            this.tsmiBasic.Name = "tsmiBasic";
            this.tsmiBasic.Size = new System.Drawing.Size(68, 21);
            this.tsmiBasic.Text = "基本資料";
            this.tsmiBasic.Click += new System.EventHandler(this.tsmiUpUserName_Click);
            // 
            // tsmiHoliday
            // 
            this.tsmiHoliday.Name = "tsmiHoliday";
            this.tsmiHoliday.Size = new System.Drawing.Size(170, 22);
            this.tsmiHoliday.Text = "節假日";
            this.tsmiHoliday.Click += new System.EventHandler(this.tsmiHoliday_Click);
            // 
            // tsmiWorkCalendar
            // 
            this.tsmiWorkCalendar.Name = "tsmiWorkCalendar";
            this.tsmiWorkCalendar.Size = new System.Drawing.Size(170, 22);
            this.tsmiWorkCalendar.Text = "工作日曆";
            this.tsmiWorkCalendar.Click += new System.EventHandler(this.tsmiWorkCalendar_Click);
            // 
            // tsmiRoleManager
            // 
            this.tsmiRoleManager.Name = "tsmiRoleManager";
            this.tsmiRoleManager.Size = new System.Drawing.Size(170, 22);
            this.tsmiRoleManager.Text = "角色管理";
            this.tsmiRoleManager.Click += new System.EventHandler(this.tsmiRoleManager_Click);
            // 
            // tsmiTestNetwork
            // 
            this.tsmiTestNetwork.Name = "tsmiTestNetwork";
            this.tsmiTestNetwork.Size = new System.Drawing.Size(170, 22);
            this.tsmiTestNetwork.Text = "测试网络";
            this.tsmiTestNetwork.Click += new System.EventHandler(this.tsmiTestNetwork_Click);
            // 
            // tsmiOrderIn
            // 
            this.tsmiOrderIn.Name = "tsmiOrderIn";
            this.tsmiOrderIn.Size = new System.Drawing.Size(170, 22);
            this.tsmiOrderIn.Text = "导入ERP订单资料";
            this.tsmiOrderIn.Click += new System.EventHandler(this.tsmiOrderIn_Click_1);
            // 
            // tsmiPackListers
            // 
            this.tsmiPackListers.Name = "tsmiPackListers";
            this.tsmiPackListers.Size = new System.Drawing.Size(170, 22);
            this.tsmiPackListers.Text = "导入ERP装箱单";
            this.tsmiPackListers.Click += new System.EventHandler(this.tsmiPackListers_Click);
            // 
            // tsmiwxbarPrints
            // 
            this.tsmiwxbarPrints.Name = "tsmiwxbarPrints";
            this.tsmiwxbarPrints.Size = new System.Drawing.Size(170, 22);
            this.tsmiwxbarPrints.Text = "外箱条码打印";
            this.tsmiwxbarPrints.Click += new System.EventHandler(this.tsmiwxbarPrints_Click);
            // 
            // tsmiMuneManager
            // 
            this.tsmiMuneManager.Name = "tsmiMuneManager";
            this.tsmiMuneManager.Size = new System.Drawing.Size(170, 22);
            this.tsmiMuneManager.Text = "系统菜单管理";
            this.tsmiMuneManager.Click += new System.EventHandler(this.tsmiMuneManager_Click);
            // 
            // tsmiPersonManager1
            // 
            this.tsmiPersonManager1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主計畫ToolStripMenuItem});
            this.tsmiPersonManager1.Name = "tsmiPersonManager1";
            this.tsmiPersonManager1.Size = new System.Drawing.Size(68, 21);
            this.tsmiPersonManager1.Text = "生產管理";
            // 
            // 主計畫ToolStripMenuItem
            // 
            this.主計畫ToolStripMenuItem.Name = "主計畫ToolStripMenuItem";
            this.主計畫ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.主計畫ToolStripMenuItem.Text = "主計畫";
            this.主計畫ToolStripMenuItem.Click += new System.EventHandler(this.主計畫ToolStripMenuItem_Click);
            // 
            // tsmiStyleManager
            // 
            this.tsmiStyleManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStyleBase,
            this.tsmiStyle,
            this.tsmiSize});
            this.tsmiStyleManager.Name = "tsmiStyleManager";
            this.tsmiStyleManager.Size = new System.Drawing.Size(68, 21);
            this.tsmiStyleManager.Text = "鞋型管理";
            this.tsmiStyleManager.Click += new System.EventHandler(this.tsmiFeedBackManager_Click);
            // 
            // tsmiStyleBase
            // 
            this.tsmiStyleBase.Name = "tsmiStyleBase";
            this.tsmiStyleBase.Size = new System.Drawing.Size(133, 22);
            this.tsmiStyleBase.Text = "型体大類";
            this.tsmiStyleBase.Click += new System.EventHandler(this.tsmiStyleBase_Click);
            // 
            // tsmiStyle
            // 
            this.tsmiStyle.Name = "tsmiStyle";
            this.tsmiStyle.Size = new System.Drawing.Size(133, 22);
            this.tsmiStyle.Text = "配色尺码";
            this.tsmiStyle.Click += new System.EventHandler(this.tsmiStyle_Click);
            // 
            // tsmiSize
            // 
            this.tsmiSize.Name = "tsmiSize";
            this.tsmiSize.Size = new System.Drawing.Size(133, 22);
            this.tsmiSize.Text = "型体尺码...";
            this.tsmiSize.Click += new System.EventHandler(this.tsmiSize_Click);
            // 
            // tsmiBarcodeBasic
            // 
            this.tsmiBarcodeBasic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBuyer,
            this.tsmiOrder,
            this.tsmiPacklist,
            this.tsmiInnerBox});
            this.tsmiBarcodeBasic.Name = "tsmiBarcodeBasic";
            this.tsmiBarcodeBasic.Size = new System.Drawing.Size(68, 21);
            this.tsmiBarcodeBasic.Text = "條碼基楚";
            this.tsmiBarcodeBasic.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // tsmiBuyer
            // 
            this.tsmiBuyer.Name = "tsmiBuyer";
            this.tsmiBuyer.Size = new System.Drawing.Size(148, 22);
            this.tsmiBuyer.Text = "客戶買主";
            this.tsmiBuyer.Click += new System.EventHandler(this.tsmiBuyer_Click);
            // 
            // tsmiOrder
            // 
            this.tsmiOrder.Name = "tsmiOrder";
            this.tsmiOrder.Size = new System.Drawing.Size(148, 22);
            this.tsmiOrder.Text = "訂單接轉";
            this.tsmiOrder.Click += new System.EventHandler(this.tsmiOrder_Click);
            // 
            // tsmiPacklist
            // 
            this.tsmiPacklist.Name = "tsmiPacklist";
            this.tsmiPacklist.Size = new System.Drawing.Size(148, 22);
            this.tsmiPacklist.Text = "裝箱明細";
            this.tsmiPacklist.Click += new System.EventHandler(this.tsmiPacklist_Click);
            // 
            // tsmiInnerBox
            // 
            this.tsmiInnerBox.Name = "tsmiInnerBox";
            this.tsmiInnerBox.Size = new System.Drawing.Size(148, 22);
            this.tsmiInnerBox.Text = "內盒條碼接轉";
            this.tsmiInnerBox.Click += new System.EventHandler(this.tsmiInnerBox_Click);
            // 
            // tsmiHR
            // 
            this.tsmiHR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDepartment,
            this.tsmiPersonManager,
            this.tsmiArea,
            this.tsmiClassManager,
            this.tsmifingerprintManager});
            this.tsmiHR.Name = "tsmiHR";
            this.tsmiHR.Size = new System.Drawing.Size(85, 21);
            this.tsmiHR.Text = "人事管理HR";
            this.tsmiHR.Click += new System.EventHandler(this.tsmiHR_Click);
            // 
            // tsmiDepartment
            // 
            this.tsmiDepartment.Name = "tsmiDepartment";
            this.tsmiDepartment.Size = new System.Drawing.Size(181, 22);
            this.tsmiDepartment.Text = "部門組織Deptment";
            this.tsmiDepartment.Click += new System.EventHandler(this.tsmiDepartment_Click);
            // 
            // tsmiPersonManager
            // 
            this.tsmiPersonManager.Name = "tsmiPersonManager";
            this.tsmiPersonManager.Size = new System.Drawing.Size(181, 22);
            this.tsmiPersonManager.Text = "人员管理Employee";
            this.tsmiPersonManager.Click += new System.EventHandler(this.tsmiPersonManager_Click);
            // 
            // tsmiArea
            // 
            this.tsmiArea.Name = "tsmiArea";
            this.tsmiArea.Size = new System.Drawing.Size(181, 22);
            this.tsmiArea.Text = "地區";
            this.tsmiArea.Click += new System.EventHandler(this.tsmiArea_Click);
            // 
            // tsmiClassManager
            // 
            this.tsmiClassManager.Name = "tsmiClassManager";
            this.tsmiClassManager.Size = new System.Drawing.Size(181, 22);
            this.tsmiClassManager.Text = "班級管理";
            this.tsmiClassManager.Click += new System.EventHandler(this.tsmiClassManager_Click);
            // 
            // tsmifingerprintManager
            // 
            this.tsmifingerprintManager.Name = "tsmifingerprintManager";
            this.tsmifingerprintManager.Size = new System.Drawing.Size(181, 22);
            this.tsmifingerprintManager.Text = "指纹机管理";
            this.tsmifingerprintManager.Click += new System.EventHandler(this.tsmifingerprintManager_Click);
            // 
            // tsmiKQ
            // 
            this.tsmiKQ.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiKQDaily});
            this.tsmiKQ.Name = "tsmiKQ";
            this.tsmiKQ.Size = new System.Drawing.Size(86, 21);
            this.tsmiKQ.Text = "考勤管理KQ";
            // 
            // tsmiKQDaily
            // 
            this.tsmiKQDaily.Name = "tsmiKQDaily";
            this.tsmiKQDaily.Size = new System.Drawing.Size(112, 22);
            this.tsmiKQDaily.Text = "日考勤";
            this.tsmiKQDaily.Click += new System.EventHandler(this.tsmiKQDaily_Click);
            // 
            // tsmiWindow
            // 
            this.tsmiWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmicolseallwind});
            this.tsmiWindow.Name = "tsmiWindow";
            this.tsmiWindow.Size = new System.Drawing.Size(44, 21);
            this.tsmiWindow.Text = "窗口";
            // 
            // tsmicolseallwind
            // 
            this.tsmicolseallwind.Name = "tsmicolseallwind";
            this.tsmicolseallwind.Size = new System.Drawing.Size(148, 22);
            this.tsmicolseallwind.Text = "关闭所有窗口";
            this.tsmicolseallwind.Click += new System.EventHandler(this.tsmicolseallwind_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(44, 21);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "颖强鞋业";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // tsmipdMaterial
            // 
            this.tsmipdMaterial.Name = "tsmipdMaterial";
            this.tsmipdMaterial.Size = new System.Drawing.Size(166, 22);
            this.tsmipdMaterial.Text = "原料仓盘点";
            this.tsmipdMaterial.Click += new System.EventHandler(this.tsmipdMaterial_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 461);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "穎強鞋業";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiHR;
        private System.Windows.Forms.ToolStripMenuItem tsmiBasic;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonManager1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStyleManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiArea;
        private System.Windows.Forms.ToolStripMenuItem tsmiClassManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiHoliday;
        private System.Windows.Forms.ToolStripMenuItem tsmiWorkCalendar;
        private System.Windows.Forms.ToolStripMenuItem 主計畫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiQAcheck;
        private System.Windows.Forms.ToolStripMenuItem tsmiStyle;
        private System.Windows.Forms.ToolStripMenuItem tsmiSize;
        private System.Windows.Forms.ToolStripMenuItem tsmiStyleBase;
        private System.Windows.Forms.ToolStripMenuItem tsmiBarcodeBasic;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuyer;
        private System.Windows.Forms.ToolStripMenuItem tsmiInnerBox;
        private System.Windows.Forms.ToolStripMenuItem tsmiPacklist;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiWHin;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoleManager;
        private System.Windows.Forms.ToolStripMenuItem tsmicolseallwind;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestNetwork;
        private System.Windows.Forms.ToolStripMenuItem tsmiScanSee;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartment;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrderIn;
        private System.Windows.Forms.ToolStripMenuItem tsmiPackListers;
        private System.Windows.Forms.ToolStripMenuItem tsmiwxbarPrints;
        private System.Windows.Forms.ToolStripMenuItem tsmiMuneManager;
        private System.Windows.Forms.ToolStripMenuItem tsmifingerprintManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiKQ;
        private System.Windows.Forms.ToolStripMenuItem tsmiKQDaily;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiQAREcheck;
        private System.Windows.Forms.ToolStripMenuItem tsmipdinventory;
        private System.Windows.Forms.ToolStripMenuItem tsmipdMaterial;
    }
}