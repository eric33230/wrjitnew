namespace WinForm
{
    partial class FrmWHin
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
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblQA = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.dgvWHin = new System.Windows.Forms.DataGridView();
            this.BOXNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomStyleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblNO = new System.Windows.Forms.Label();
            this.cmbWH = new System.Windows.Forms.ComboBox();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.cmbHour = new System.Windows.Forms.ComboBox();
            this.btnScanList = new System.Windows.Forms.Button();
            this.dgvPackListScan = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvNotScan = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出倉次 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QAout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.订单年月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbNO = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvScan = new System.Windows.Forms.DataGridView();
            this.BOXNO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomStyleCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanOut2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WH2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanBatch2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmsShipScan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.COPYCELL = new System.Windows.Forms.ToolStripMenuItem();
            this.TOEXCEL = new System.Windows.Forms.ToolStripMenuItem();
            this.cboInOut = new System.Windows.Forms.ComboBox();
            this.gbError = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnQaout = new System.Windows.Forms.Button();
            this.btnScanOut = new System.Windows.Forms.Button();
            this.btnScanIn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCustomStyleCode = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btnBOXNO = new System.Windows.Forms.Button();
            this.btnCartonBarcode = new System.Windows.Forms.Button();
            this.msgDiv = new MsgDiv();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWHin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackListScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScan)).BeginInit();
            this.ctmsShipScan.SuspendLayout();
            this.gbError.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCheck
            // 
            this.lblCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCheck.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck.Location = new System.Drawing.Point(8, 170);
            this.lblCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(153, 82);
            this.lblCheck.TabIndex = 88;
            this.lblCheck.Text = "STOP";
            this.lblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQA
            // 
            this.lblQA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQA.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQA.Location = new System.Drawing.Point(8, 261);
            this.lblQA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQA.Name = "lblQA";
            this.lblQA.Size = new System.Drawing.Size(154, 82);
            this.lblQA.TabIndex = 89;
            this.lblQA.Text = "QA";
            this.lblQA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeat
            // 
            this.lblRepeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeat.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeat.Location = new System.Drawing.Point(8, 348);
            this.lblRepeat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(154, 82);
            this.lblRepeat.TabIndex = 90;
            this.lblRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvWHin
            // 
            this.dgvWHin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWHin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BOXNO,
            this.Part,
            this.ScanOut,
            this.ScanTime,
            this.ScanBatch,
            this.CartonBarcode,
            this.CustomStyleCode,
            this.QA,
            this.WH});
            this.dgvWHin.Location = new System.Drawing.Point(926, 285);
            this.dgvWHin.Margin = new System.Windows.Forms.Padding(2);
            this.dgvWHin.Name = "dgvWHin";
            this.dgvWHin.ReadOnly = true;
            this.dgvWHin.RowHeadersVisible = false;
            this.dgvWHin.RowTemplate.Height = 30;
            this.dgvWHin.Size = new System.Drawing.Size(339, 297);
            this.dgvWHin.TabIndex = 91;
            this.dgvWHin.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWHin_CellMouseDown);
            // 
            // BOXNO
            // 
            this.BOXNO.DataPropertyName = "BOXNO";
            this.BOXNO.FillWeight = 50F;
            this.BOXNO.HeaderText = "箱號";
            this.BOXNO.Name = "BOXNO";
            this.BOXNO.ReadOnly = true;
            this.BOXNO.Width = 40;
            // 
            // Part
            // 
            this.Part.DataPropertyName = "Part";
            this.Part.HeaderText = "Part";
            this.Part.Name = "Part";
            this.Part.ReadOnly = true;
            this.Part.Width = 50;
            // 
            // ScanOut
            // 
            this.ScanOut.DataPropertyName = "ScanOut";
            this.ScanOut.HeaderText = "出倉";
            this.ScanOut.Name = "ScanOut";
            this.ScanOut.ReadOnly = true;
            this.ScanOut.Width = 40;
            // 
            // ScanTime
            // 
            this.ScanTime.DataPropertyName = "ScanTime";
            this.ScanTime.HeaderText = "掃描時間";
            this.ScanTime.Name = "ScanTime";
            this.ScanTime.ReadOnly = true;
            this.ScanTime.Width = 105;
            // 
            // ScanBatch
            // 
            this.ScanBatch.DataPropertyName = "ScanBatch";
            this.ScanBatch.HeaderText = "掃描批號";
            this.ScanBatch.Name = "ScanBatch";
            this.ScanBatch.ReadOnly = true;
            // 
            // CartonBarcode
            // 
            this.CartonBarcode.DataPropertyName = "CartonBarcode";
            this.CartonBarcode.HeaderText = "外箱條碼";
            this.CartonBarcode.Name = "CartonBarcode";
            this.CartonBarcode.ReadOnly = true;
            // 
            // CustomStyleCode
            // 
            this.CustomStyleCode.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode.HeaderText = "指令號";
            this.CustomStyleCode.Name = "CustomStyleCode";
            this.CustomStyleCode.ReadOnly = true;
            this.CustomStyleCode.Width = 66;
            // 
            // QA
            // 
            this.QA.DataPropertyName = "QA";
            this.QA.HeaderText = "QA";
            this.QA.Name = "QA";
            this.QA.ReadOnly = true;
            this.QA.Width = 50;
            // 
            // WH
            // 
            this.WH.DataPropertyName = "WH";
            this.WH.HeaderText = "WH";
            this.WH.Name = "WH";
            this.WH.ReadOnly = true;
            this.WH.Width = 50;
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtPwd.Location = new System.Drawing.Point(8, 434);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(155, 21);
            this.txtPwd.TabIndex = 93;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // tb2
            // 
            this.tb2.Enabled = false;
            this.tb2.Location = new System.Drawing.Point(9, 457);
            this.tb2.Margin = new System.Windows.Forms.Padding(2);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(155, 21);
            this.tb2.TabIndex = 94;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // lblNO
            // 
            this.lblNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNO.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNO.Location = new System.Drawing.Point(8, 65);
            this.lblNO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNO.Name = "lblNO";
            this.lblNO.Size = new System.Drawing.Size(153, 102);
            this.lblNO.TabIndex = 96;
            this.lblNO.Text = "0";
            this.lblNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbWH
            // 
            this.cmbWH.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbWH.FormattingEnabled = true;
            this.cmbWH.Items.AddRange(new object[] {
            "WHA",
            "WHC",
            "WHE"});
            this.cmbWH.Location = new System.Drawing.Point(767, 9);
            this.cmbWH.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWH.Name = "cmbWH";
            this.cmbWH.Size = new System.Drawing.Size(57, 27);
            this.cmbWH.TabIndex = 97;
            this.cmbWH.Text = "WHA";
            // 
            // dtpdate
            // 
            this.dtpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtpdate.CustomFormat = "yyyy-MM-dd";
            this.dtpdate.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(827, 9);
            this.dtpdate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(97, 27);
            this.dtpdate.TabIndex = 98;
            // 
            // cmbHour
            // 
            this.cmbHour.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbHour.FormattingEnabled = true;
            this.cmbHour.Items.AddRange(new object[] {
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.cmbHour.Location = new System.Drawing.Point(767, 37);
            this.cmbHour.Margin = new System.Windows.Forms.Padding(2);
            this.cmbHour.Name = "cmbHour";
            this.cmbHour.Size = new System.Drawing.Size(57, 27);
            this.cmbHour.TabIndex = 99;
            this.cmbHour.Text = "07";
            // 
            // btnScanList
            // 
            this.btnScanList.Location = new System.Drawing.Point(827, 37);
            this.btnScanList.Margin = new System.Windows.Forms.Padding(2);
            this.btnScanList.Name = "btnScanList";
            this.btnScanList.Size = new System.Drawing.Size(95, 26);
            this.btnScanList.TabIndex = 100;
            this.btnScanList.Text = "批號查詢";
            this.btnScanList.UseVisualStyleBackColor = true;
            this.btnScanList.Click += new System.EventHandler(this.btnScanList_Click);
            // 
            // dgvPackListScan
            // 
            this.dgvPackListScan.AllowUserToAddRows = false;
            this.dgvPackListScan.AllowUserToDeleteRows = false;
            this.dgvPackListScan.AllowUserToResizeColumns = false;
            this.dgvPackListScan.AllowUserToResizeRows = false;
            this.dgvPackListScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackListScan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.ScanCount});
            this.dgvPackListScan.Location = new System.Drawing.Point(767, 65);
            this.dgvPackListScan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPackListScan.Name = "dgvPackListScan";
            this.dgvPackListScan.ReadOnly = true;
            this.dgvPackListScan.RowHeadersVisible = false;
            this.dgvPackListScan.RowTemplate.Height = 30;
            this.dgvPackListScan.Size = new System.Drawing.Size(155, 517);
            this.dgvPackListScan.TabIndex = 101;
            this.dgvPackListScan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackListScan_CellClick);
            this.dgvPackListScan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPackListScan_MouseClick_1);
            this.dgvPackListScan.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPackListScan_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ScanBatch";
            this.dataGridViewTextBoxColumn8.HeaderText = "掃描批號";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // ScanCount
            // 
            this.ScanCount.DataPropertyName = "ScanCount";
            this.ScanCount.HeaderText = "箱";
            this.ScanCount.Name = "ScanCount";
            this.ScanCount.ReadOnly = true;
            this.ScanCount.Width = 40;
            // 
            // txtOrder
            // 
            this.txtOrder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder.Location = new System.Drawing.Point(927, 10);
            this.txtOrder.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(109, 26);
            this.txtOrder.TabIndex = 102;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1101, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 26);
            this.button2.TabIndex = 103;
            this.button2.Text = "未掃描查詢";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvNotScan
            // 
            this.dgvNotScan.AllowUserToAddRows = false;
            this.dgvNotScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotScan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.出倉次,
            this.QAout,
            this.CartonBarcode1,
            this.订单年月});
            this.dgvNotScan.Location = new System.Drawing.Point(927, 39);
            this.dgvNotScan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNotScan.Name = "dgvNotScan";
            this.dgvNotScan.ReadOnly = true;
            this.dgvNotScan.RowHeadersVisible = false;
            this.dgvNotScan.RowTemplate.Height = 30;
            this.dgvNotScan.Size = new System.Drawing.Size(340, 239);
            this.dgvNotScan.TabIndex = 101;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BOXNO";
            this.dataGridViewTextBoxColumn1.HeaderText = "箱號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ScanIn";
            this.Column2.HeaderText = "入倉";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // 出倉次
            // 
            this.出倉次.DataPropertyName = "ScanOut";
            this.出倉次.HeaderText = "出倉";
            this.出倉次.Name = "出倉次";
            this.出倉次.ReadOnly = true;
            this.出倉次.Width = 40;
            // 
            // QAout
            // 
            this.QAout.DataPropertyName = "QAout";
            this.QAout.HeaderText = "QA";
            this.QAout.Name = "QAout";
            this.QAout.ReadOnly = true;
            this.QAout.Width = 40;
            // 
            // CartonBarcode1
            // 
            this.CartonBarcode1.DataPropertyName = "CartonBarcode";
            this.CartonBarcode1.HeaderText = "外箱條碼";
            this.CartonBarcode1.Name = "CartonBarcode1";
            this.CartonBarcode1.ReadOnly = true;
            // 
            // 订单年月
            // 
            this.订单年月.DataPropertyName = "OrderDate";
            this.订单年月.HeaderText = "订单年月";
            this.订单年月.Name = "订单年月";
            this.订单年月.ReadOnly = true;
            this.订单年月.Width = 80;
            // 
            // cmbNO
            // 
            this.cmbNO.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbNO.FormattingEnabled = true;
            this.cmbNO.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbNO.Location = new System.Drawing.Point(1041, 10);
            this.cmbNO.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNO.Name = "cmbNO";
            this.cmbNO.Size = new System.Drawing.Size(53, 27);
            this.cmbNO.TabIndex = 105;
            this.cmbNO.Text = "1";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1183, 8);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(84, 27);
            this.lblTotal.TabIndex = 107;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvScan
            // 
            this.dgvScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BOXNO2,
            this.OrderDate2,
            this.CartonBarcode2,
            this.CustomStyleCode2,
            this.ScanTime2,
            this.QA2,
            this.ScanOut2,
            this.WH2,
            this.ScanBatch2});
            this.dgvScan.Location = new System.Drawing.Point(165, 9);
            this.dgvScan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvScan.Name = "dgvScan";
            this.dgvScan.ReadOnly = true;
            this.dgvScan.RowHeadersVisible = false;
            this.dgvScan.RowTemplate.Height = 30;
            this.dgvScan.Size = new System.Drawing.Size(598, 573);
            this.dgvScan.TabIndex = 108;
            // 
            // BOXNO2
            // 
            this.BOXNO2.DataPropertyName = "BOXNO";
            this.BOXNO2.FillWeight = 50F;
            this.BOXNO2.HeaderText = "箱";
            this.BOXNO2.Name = "BOXNO2";
            this.BOXNO2.ReadOnly = true;
            this.BOXNO2.Width = 30;
            // 
            // OrderDate2
            // 
            this.OrderDate2.DataPropertyName = "OrderDate";
            this.OrderDate2.HeaderText = "年月";
            this.OrderDate2.Name = "OrderDate2";
            this.OrderDate2.ReadOnly = true;
            this.OrderDate2.Width = 54;
            // 
            // CartonBarcode2
            // 
            this.CartonBarcode2.DataPropertyName = "CartonBarcode";
            this.CartonBarcode2.HeaderText = "外箱條碼";
            this.CartonBarcode2.Name = "CartonBarcode2";
            this.CartonBarcode2.ReadOnly = true;
            this.CartonBarcode2.Width = 90;
            // 
            // CustomStyleCode2
            // 
            this.CustomStyleCode2.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode2.HeaderText = "指令號";
            this.CustomStyleCode2.Name = "CustomStyleCode2";
            this.CustomStyleCode2.ReadOnly = true;
            this.CustomStyleCode2.Width = 66;
            // 
            // ScanTime2
            // 
            this.ScanTime2.DataPropertyName = "ScanTime";
            this.ScanTime2.HeaderText = "掃描時間";
            this.ScanTime2.Name = "ScanTime2";
            this.ScanTime2.ReadOnly = true;
            this.ScanTime2.Width = 120;
            // 
            // QA2
            // 
            this.QA2.DataPropertyName = "QA";
            this.QA2.HeaderText = "QA";
            this.QA2.Name = "QA2";
            this.QA2.ReadOnly = true;
            this.QA2.Width = 50;
            // 
            // ScanOut2
            // 
            this.ScanOut2.DataPropertyName = "ScanOut";
            this.ScanOut2.HeaderText = "次";
            this.ScanOut2.Name = "ScanOut2";
            this.ScanOut2.ReadOnly = true;
            this.ScanOut2.Width = 30;
            // 
            // WH2
            // 
            this.WH2.DataPropertyName = "WH";
            this.WH2.HeaderText = "WH";
            this.WH2.Name = "WH2";
            this.WH2.ReadOnly = true;
            this.WH2.Width = 50;
            // 
            // ScanBatch2
            // 
            this.ScanBatch2.DataPropertyName = "ScanBatch";
            this.ScanBatch2.HeaderText = "掃描批號";
            this.ScanBatch2.Name = "ScanBatch2";
            this.ScanBatch2.ReadOnly = true;
            this.ScanBatch2.Width = 90;
            // 
            // ctmsShipScan
            // 
            this.ctmsShipScan.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmsShipScan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COPYCELL,
            this.TOEXCEL});
            this.ctmsShipScan.Name = "ctmsOrder";
            this.ctmsShipScan.ShowImageMargin = false;
            this.ctmsShipScan.Size = new System.Drawing.Size(136, 48);
            // 
            // COPYCELL
            // 
            this.COPYCELL.Name = "COPYCELL";
            this.COPYCELL.Size = new System.Drawing.Size(135, 22);
            this.COPYCELL.Text = "复选当前单元格";
            this.COPYCELL.Click += new System.EventHandler(this.COPYCELL_Click);
            // 
            // TOEXCEL
            // 
            this.TOEXCEL.Name = "TOEXCEL";
            this.TOEXCEL.Size = new System.Drawing.Size(135, 22);
            this.TOEXCEL.Text = "导出到EXCEL";
            this.TOEXCEL.Click += new System.EventHandler(this.TOEXCEL_Click);
            // 
            // cboInOut
            // 
            this.cboInOut.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboInOut.FormattingEnabled = true;
            this.cboInOut.Items.AddRange(new object[] {
            "IN-成品入庫",
            "OUT-成品出庫"});
            this.cboInOut.Location = new System.Drawing.Point(8, 11);
            this.cboInOut.Margin = new System.Windows.Forms.Padding(2);
            this.cboInOut.Name = "cboInOut";
            this.cboInOut.Size = new System.Drawing.Size(153, 27);
            this.cboInOut.TabIndex = 109;
            this.cboInOut.SelectedIndexChanged += new System.EventHandler(this.cboInOut_SelectedIndexChanged);
            // 
            // gbError
            // 
            this.gbError.Controls.Add(this.lbl1);
            this.gbError.Controls.Add(this.btnQaout);
            this.gbError.Controls.Add(this.btnScanOut);
            this.gbError.Controls.Add(this.btnScanIn);
            this.gbError.Controls.Add(this.label6);
            this.gbError.Controls.Add(this.label5);
            this.gbError.Controls.Add(this.label4);
            this.gbError.Controls.Add(this.label3);
            this.gbError.Controls.Add(this.label2);
            this.gbError.Controls.Add(this.label1);
            this.gbError.Controls.Add(this.btnCustomStyleCode);
            this.gbError.Controls.Add(this.btnOK);
            this.gbError.Controls.Add(this.txt1);
            this.gbError.Controls.Add(this.btnBOXNO);
            this.gbError.Controls.Add(this.btnCartonBarcode);
            this.gbError.Location = new System.Drawing.Point(182, 69);
            this.gbError.Name = "gbError";
            this.gbError.Size = new System.Drawing.Size(742, 496);
            this.gbError.TabIndex = 110;
            this.gbError.TabStop = false;
            this.gbError.Text = "未掃描錯誤";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Gold;
            this.lbl1.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(76, 33);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(566, 27);
            this.lbl1.TabIndex = 14;
            this.lbl1.Text = "前一工序沒有掃描完成,請把該箱找出重新掃描";
            // 
            // btnQaout
            // 
            this.btnQaout.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQaout.Location = new System.Drawing.Point(440, 313);
            this.btnQaout.Name = "btnQaout";
            this.btnQaout.Size = new System.Drawing.Size(144, 57);
            this.btnQaout.TabIndex = 13;
            this.btnQaout.UseVisualStyleBackColor = true;
            // 
            // btnScanOut
            // 
            this.btnScanOut.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanOut.Location = new System.Drawing.Point(260, 313);
            this.btnScanOut.Name = "btnScanOut";
            this.btnScanOut.Size = new System.Drawing.Size(144, 57);
            this.btnScanOut.TabIndex = 12;
            this.btnScanOut.UseVisualStyleBackColor = true;
            // 
            // btnScanIn
            // 
            this.btnScanIn.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanIn.Location = new System.Drawing.Point(91, 313);
            this.btnScanIn.Name = "btnScanIn";
            this.btnScanIn.Size = new System.Drawing.Size(144, 57);
            this.btnScanIn.TabIndex = 11;
            this.btnScanIn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(453, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "QA掃描";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(270, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "成品出庫";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(102, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "成品入庫";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(86, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "箱號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(86, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "訂單號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(86, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "外箱條碼";
            // 
            // btnCustomStyleCode
            // 
            this.btnCustomStyleCode.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCustomStyleCode.Location = new System.Drawing.Point(227, 138);
            this.btnCustomStyleCode.Name = "btnCustomStyleCode";
            this.btnCustomStyleCode.Size = new System.Drawing.Size(357, 50);
            this.btnCustomStyleCode.TabIndex = 4;
            this.btnCustomStyleCode.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.SpringGreen;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(260, 430);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(158, 56);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "確認";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(179, 391);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(296, 21);
            this.txt1.TabIndex = 2;
            this.txt1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt1_KeyDown);
            // 
            // btnBOXNO
            // 
            this.btnBOXNO.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBOXNO.Location = new System.Drawing.Point(227, 194);
            this.btnBOXNO.Name = "btnBOXNO";
            this.btnBOXNO.Size = new System.Drawing.Size(357, 57);
            this.btnBOXNO.TabIndex = 1;
            this.btnBOXNO.UseVisualStyleBackColor = true;
            // 
            // btnCartonBarcode
            // 
            this.btnCartonBarcode.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCartonBarcode.Location = new System.Drawing.Point(227, 85);
            this.btnCartonBarcode.Name = "btnCartonBarcode";
            this.btnCartonBarcode.Size = new System.Drawing.Size(357, 47);
            this.btnCartonBarcode.TabIndex = 0;
            this.btnCartonBarcode.UseVisualStyleBackColor = true;
            // 
            // msgDiv
            // 
            this.msgDiv.AutoSize = true;
            this.msgDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.msgDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgDiv.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgDiv.ForeColor = System.Drawing.Color.Red;
            this.msgDiv.Location = new System.Drawing.Point(8, 478);
            this.msgDiv.MaximumSize = new System.Drawing.Size(980, 525);
            this.msgDiv.Name = "msgDiv";
            this.msgDiv.Padding = new System.Windows.Forms.Padding(7);
            this.msgDiv.Size = new System.Drawing.Size(86, 31);
            this.msgDiv.TabIndex = 95;
            this.msgDiv.Text = "msgDiv1";
            this.msgDiv.Visible = false;
            // 
            // FrmWHin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.gbError);
            this.Controls.Add(this.cboInOut);
            this.Controls.Add(this.dgvScan);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cmbNO);
            this.Controls.Add(this.dgvNotScan);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.dgvPackListScan);
            this.Controls.Add(this.btnScanList);
            this.Controls.Add(this.cmbHour);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.cmbWH);
            this.Controls.Add(this.lblNO);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.msgDiv);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.dgvWHin);
            this.Controls.Add(this.lblRepeat);
            this.Controls.Add(this.lblQA);
            this.Controls.Add(this.lblCheck);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmWHin";
            this.Text = "成品倉入庫";
            this.Activated += new System.EventHandler(this.FrmWHin_Activated);
            this.Load += new System.EventHandler(this.FrmWHin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWHin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackListScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScan)).EndInit();
            this.ctmsShipScan.ResumeLayout(false);
            this.gbError.ResumeLayout(false);
            this.gbError.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Label lblQA;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.DataGridView dgvWHin;
        private System.Windows.Forms.TextBox txtPwd;
        private MsgDiv msgDiv;
        private System.Windows.Forms.TextBox tb2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblNO;
        private System.Windows.Forms.ComboBox cmbWH;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.ComboBox cmbHour;
        private System.Windows.Forms.Button btnScanList;
        private System.Windows.Forms.DataGridView dgvPackListScan;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvNotScan;
        private System.Windows.Forms.ComboBox cmbNO;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvScan;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOXNO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn QA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanOut2;
        private System.Windows.Forms.DataGridViewTextBoxColumn WH2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanBatch2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanCount;
        private System.Windows.Forms.ContextMenuStrip ctmsShipScan;
        private System.Windows.Forms.ToolStripMenuItem COPYCELL;
        private System.Windows.Forms.ToolStripMenuItem TOEXCEL;
        private System.Windows.Forms.ComboBox cboInOut;
        private System.Windows.Forms.GroupBox gbError;
        private System.Windows.Forms.Button btnCustomStyleCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button btnBOXNO;
        private System.Windows.Forms.Button btnCartonBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQaout;
        private System.Windows.Forms.Button btnScanOut;
        private System.Windows.Forms.Button btnScanIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOXNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Part;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QA;
        private System.Windows.Forms.DataGridViewTextBoxColumn WH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出倉次;
        private System.Windows.Forms.DataGridViewTextBoxColumn QAout;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 订单年月;
    }
}