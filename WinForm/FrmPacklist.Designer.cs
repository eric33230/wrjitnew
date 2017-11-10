namespace WinForm
{
    partial class FrmPacklist
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
            this.YearMounth = new System.Windows.Forms.DateTimePicker();
            this.dgvPacklist = new System.Windows.Forms.DataGridView();
            this.CustomStyleCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOXNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.CustomStyleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packlisttotalcount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPackListIn = new System.Windows.Forms.Button();
            this.btnGetInnerCode = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtOrder1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPlanNo = new System.Windows.Forms.TextBox();
            this.txtCartonNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvPacklistShip = new System.Windows.Forms.DataGridView();
            this.CustomStyleCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOXNO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AimArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipScanTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxCBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOrderCheck = new System.Windows.Forms.Button();
            this.btnUpdateShip = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvPackOrder = new System.Windows.Forms.DataGridView();
            this.V = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomBuyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomStyleCode3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarNo3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.txtW = new System.Windows.Forms.TextBox();
            this.btnCancelBox = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnSeeShip = new System.Windows.Forms.Button();
            this.ctmsShip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TOEXCEL = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMorder = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacklistShip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackOrder)).BeginInit();
            this.ctmsShip.SuspendLayout();
            this.SuspendLayout();
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(165, 23);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(2);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(107, 27);
            this.YearMounth.TabIndex = 34;
            // 
            // dgvPacklist
            // 
            this.dgvPacklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacklist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomStyleCode1,
            this.BOXNO});
            this.dgvPacklist.Location = new System.Drawing.Point(12, 438);
            this.dgvPacklist.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPacklist.Name = "dgvPacklist";
            this.dgvPacklist.RowTemplate.Height = 30;
            this.dgvPacklist.Size = new System.Drawing.Size(259, 184);
            this.dgvPacklist.TabIndex = 36;
            // 
            // CustomStyleCode1
            // 
            this.CustomStyleCode1.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode1.HeaderText = "訂單";
            this.CustomStyleCode1.Name = "CustomStyleCode1";
            // 
            // BOXNO
            // 
            this.BOXNO.DataPropertyName = "BOXNO";
            this.BOXNO.HeaderText = "箱號";
            this.BOXNO.Name = "BOXNO";
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomStyleCode,
            this.TotalCount,
            this.Packlisttotalcount});
            this.dgvOrder.Location = new System.Drawing.Point(8, 171);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowTemplate.Height = 30;
            this.dgvOrder.Size = new System.Drawing.Size(259, 184);
            this.dgvOrder.TabIndex = 37;
            // 
            // CustomStyleCode
            // 
            this.CustomStyleCode.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode.HeaderText = "訂單";
            this.CustomStyleCode.Name = "CustomStyleCode";
            this.CustomStyleCode.Width = 80;
            // 
            // TotalCount
            // 
            this.TotalCount.DataPropertyName = "TotalCount";
            this.TotalCount.HeaderText = "訂單數";
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.Width = 80;
            // 
            // Packlisttotalcount
            // 
            this.Packlisttotalcount.DataPropertyName = "Packlisttotalcount";
            this.Packlisttotalcount.HeaderText = "裝箱數";
            this.Packlisttotalcount.Name = "Packlisttotalcount";
            this.Packlisttotalcount.Width = 80;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(8, 3);
            this.test.Margin = new System.Windows.Forms.Padding(2);
            this.test.Multiline = true;
            this.test.Name = "test";
            this.test.ReadOnly = true;
            this.test.Size = new System.Drawing.Size(154, 45);
            this.test.TabIndex = 43;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 77);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 41);
            this.button1.TabIndex = 44;
            this.button1.Text = "接轉裝箱數量";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 77);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 41);
            this.button2.TabIndex = 46;
            this.button2.Text = "查核裝箱數量";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPackListIn
            // 
            this.btnPackListIn.Location = new System.Drawing.Point(8, 77);
            this.btnPackListIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnPackListIn.Name = "btnPackListIn";
            this.btnPackListIn.Size = new System.Drawing.Size(58, 43);
            this.btnPackListIn.TabIndex = 47;
            this.btnPackListIn.Text = "接轉裝箱明細";
            this.btnPackListIn.UseVisualStyleBackColor = true;
            this.btnPackListIn.Click += new System.EventHandler(this.btnPackListIn_Click);
            // 
            // btnGetInnerCode
            // 
            this.btnGetInnerCode.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnGetInnerCode.Location = new System.Drawing.Point(210, 76);
            this.btnGetInnerCode.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetInnerCode.Name = "btnGetInnerCode";
            this.btnGetInnerCode.Size = new System.Drawing.Size(57, 43);
            this.btnGetInnerCode.TabIndex = 48;
            this.btnGetInnerCode.Text = "接轉內盒條碼";
            this.btnGetInnerCode.UseVisualStyleBackColor = false;
            this.btnGetInnerCode.Click += new System.EventHandler(this.btnGetInnerCode_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 386);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 43);
            this.button3.TabIndex = 49;
            this.button3.Text = "成箱明細按月接轉";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(9, 143);
            this.txtOrder.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(121, 21);
            this.txtOrder.TabIndex = 50;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(133, 123);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 43);
            this.button5.TabIndex = 51;
            this.button5.Text = "訂單裝箱明細接轉";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(210, 390);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 43);
            this.button6.TabIndex = 53;
            this.button6.Text = "成箱明細按訂單轉";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtOrder1
            // 
            this.txtOrder1.Location = new System.Drawing.Point(82, 405);
            this.txtOrder1.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrder1.Name = "txtOrder1";
            this.txtOrder1.Size = new System.Drawing.Size(124, 21);
            this.txtOrder1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 359);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 24);
            this.label1.TabIndex = 54;
            this.label1.Text = "-------------------------------------\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 367);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "成品倉外箱裝箱明細";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "QA掃描明細";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 24);
            this.label4.TabIndex = 56;
            this.label4.Text = "-------------------------------------\r\n\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "訂單年月";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 59;
            this.label6.Text = "QA重新接轉之訂單號";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 391);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 60;
            this.label7.Text = "成倉重新接轉之訂單號";
            // 
            // dtpdate
            // 
            this.dtpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtpdate.CustomFormat = "yyyy-MM-dd";
            this.dtpdate.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(285, 23);
            this.dtpdate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(97, 27);
            this.dtpdate.TabIndex = 61;
            this.dtpdate.ValueChanged += new System.EventHandler(this.dtpdate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(383, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 62;
            this.label8.Text = "計畫編號";
            // 
            // txtPlanNo
            // 
            this.txtPlanNo.Location = new System.Drawing.Point(385, 27);
            this.txtPlanNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPlanNo.Name = "txtPlanNo";
            this.txtPlanNo.ReadOnly = true;
            this.txtPlanNo.Size = new System.Drawing.Size(79, 21);
            this.txtPlanNo.TabIndex = 63;
            // 
            // txtCartonNo
            // 
            this.txtCartonNo.Location = new System.Drawing.Point(467, 27);
            this.txtCartonNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCartonNo.Name = "txtCartonNo";
            this.txtCartonNo.Size = new System.Drawing.Size(79, 21);
            this.txtCartonNo.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(465, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 66;
            this.label9.Text = "周貨櫃編號";
            // 
            // dgvPacklistShip
            // 
            this.dgvPacklistShip.AllowUserToResizeColumns = false;
            this.dgvPacklistShip.AllowUserToResizeRows = false;
            this.dgvPacklistShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPacklistShip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomStyleCode2,
            this.CarNo,
            this.BOXNO3,
            this.AimArea,
            this.CartonBarcode,
            this.ShipOut,
            this.ShipScanTime,
            this.BoxSize,
            this.BoxCBM});
            this.dgvPacklistShip.Location = new System.Drawing.Point(555, 94);
            this.dgvPacklistShip.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPacklistShip.Name = "dgvPacklistShip";
            this.dgvPacklistShip.ReadOnly = true;
            this.dgvPacklistShip.RowHeadersVisible = false;
            this.dgvPacklistShip.RowTemplate.Height = 30;
            this.dgvPacklistShip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacklistShip.Size = new System.Drawing.Size(297, 532);
            this.dgvPacklistShip.TabIndex = 67;
            this.dgvPacklistShip.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPacklistShip_CellMouseDown);
            // 
            // CustomStyleCode2
            // 
            this.CustomStyleCode2.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode2.HeaderText = "訂單號";
            this.CustomStyleCode2.Name = "CustomStyleCode2";
            this.CustomStyleCode2.ReadOnly = true;
            // 
            // CarNo
            // 
            this.CarNo.DataPropertyName = "CarNo";
            this.CarNo.HeaderText = "貨櫃編號";
            this.CarNo.Name = "CarNo";
            this.CarNo.ReadOnly = true;
            this.CarNo.Width = 60;
            // 
            // BOXNO3
            // 
            this.BOXNO3.DataPropertyName = "BOXNO";
            this.BOXNO3.HeaderText = "BOXNO";
            this.BOXNO3.Name = "BOXNO3";
            this.BOXNO3.ReadOnly = true;
            this.BOXNO3.Width = 60;
            // 
            // AimArea
            // 
            this.AimArea.DataPropertyName = "AimArea";
            this.AimArea.HeaderText = "目的地";
            this.AimArea.Name = "AimArea";
            this.AimArea.ReadOnly = true;
            this.AimArea.Width = 60;
            // 
            // CartonBarcode
            // 
            this.CartonBarcode.DataPropertyName = "CartonBarcode";
            this.CartonBarcode.HeaderText = "CartonBarcode";
            this.CartonBarcode.Name = "CartonBarcode";
            this.CartonBarcode.ReadOnly = true;
            // 
            // ShipOut
            // 
            this.ShipOut.DataPropertyName = "ShipOut";
            this.ShipOut.HeaderText = "ShipOut";
            this.ShipOut.Name = "ShipOut";
            this.ShipOut.ReadOnly = true;
            // 
            // ShipScanTime
            // 
            this.ShipScanTime.DataPropertyName = "ShipScanTime";
            this.ShipScanTime.HeaderText = "ShipScanTime";
            this.ShipScanTime.Name = "ShipScanTime";
            this.ShipScanTime.ReadOnly = true;
            // 
            // BoxSize
            // 
            this.BoxSize.DataPropertyName = "BoxSize";
            this.BoxSize.HeaderText = "BoxSize";
            this.BoxSize.Name = "BoxSize";
            this.BoxSize.ReadOnly = true;
            this.BoxSize.Width = 60;
            // 
            // BoxCBM
            // 
            this.BoxCBM.DataPropertyName = "BoxCBM";
            this.BoxCBM.HeaderText = "BoxCBM";
            this.BoxCBM.Name = "BoxCBM";
            this.BoxCBM.ReadOnly = true;
            // 
            // btnOrderCheck
            // 
            this.btnOrderCheck.Location = new System.Drawing.Point(445, 50);
            this.btnOrderCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderCheck.Name = "btnOrderCheck";
            this.btnOrderCheck.Size = new System.Drawing.Size(45, 39);
            this.btnOrderCheck.TabIndex = 68;
            this.btnOrderCheck.Text = "查詢訂單";
            this.btnOrderCheck.UseVisualStyleBackColor = true;
            this.btnOrderCheck.Click += new System.EventHandler(this.btnOrderCheck_Click);
            // 
            // btnUpdateShip
            // 
            this.btnUpdateShip.Location = new System.Drawing.Point(555, 50);
            this.btnUpdateShip.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateShip.Name = "btnUpdateShip";
            this.btnUpdateShip.Size = new System.Drawing.Size(73, 40);
            this.btnUpdateShip.TabIndex = 69;
            this.btnUpdateShip.Text = "更新貨櫃號";
            this.btnUpdateShip.UseVisualStyleBackColor = true;
            this.btnUpdateShip.Click += new System.EventHandler(this.btnUpdateShip_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 70;
            this.label10.Text = "計畫周日期";
            // 
            // dgvPackOrder
            // 
            this.dgvPackOrder.AllowUserToResizeColumns = false;
            this.dgvPackOrder.AllowUserToResizeRows = false;
            this.dgvPackOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.V,
            this.CustomBuyName,
            this.CustomStyleCode3,
            this.CarNo3});
            this.dgvPackOrder.Location = new System.Drawing.Point(285, 94);
            this.dgvPackOrder.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPackOrder.Name = "dgvPackOrder";
            this.dgvPackOrder.RowHeadersVisible = false;
            this.dgvPackOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPackOrder.RowTemplate.Height = 30;
            this.dgvPackOrder.Size = new System.Drawing.Size(259, 528);
            this.dgvPackOrder.TabIndex = 71;
            // 
            // V
            // 
            this.V.HeaderText = "V";
            this.V.Name = "V";
            this.V.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.V.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.V.Width = 30;
            // 
            // CustomBuyName
            // 
            this.CustomBuyName.DataPropertyName = "CustomBuyName";
            this.CustomBuyName.HeaderText = "買主";
            this.CustomBuyName.Name = "CustomBuyName";
            this.CustomBuyName.ReadOnly = true;
            this.CustomBuyName.Width = 40;
            // 
            // CustomStyleCode3
            // 
            this.CustomStyleCode3.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode3.HeaderText = "訂單號";
            this.CustomStyleCode3.Name = "CustomStyleCode3";
            this.CustomStyleCode3.ReadOnly = true;
            this.CustomStyleCode3.Width = 80;
            // 
            // CarNo3
            // 
            this.CarNo3.DataPropertyName = "CarNo";
            this.CarNo3.HeaderText = "貨櫃編號";
            this.CarNo3.Name = "CarNo3";
            this.CarNo3.ReadOnly = true;
            this.CarNo3.Width = 80;
            // 
            // txtBuyer
            // 
            this.txtBuyer.Location = new System.Drawing.Point(341, 50);
            this.txtBuyer.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(97, 21);
            this.txtBuyer.TabIndex = 72;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(284, 54);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 73;
            this.label11.Text = "客戶買主";
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.Location = new System.Drawing.Point(501, 51);
            this.btnOrderCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(43, 39);
            this.btnOrderCancel.TabIndex = 74;
            this.btnOrderCancel.Text = "取消訂單";
            this.btnOrderCancel.UseVisualStyleBackColor = true;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // txtW
            // 
            this.txtW.Location = new System.Drawing.Point(651, 2);
            this.txtW.Margin = new System.Windows.Forms.Padding(2);
            this.txtW.Multiline = true;
            this.txtW.Name = "txtW";
            this.txtW.ReadOnly = true;
            this.txtW.Size = new System.Drawing.Size(203, 45);
            this.txtW.TabIndex = 75;
            // 
            // btnCancelBox
            // 
            this.btnCancelBox.Location = new System.Drawing.Point(649, 49);
            this.btnCancelBox.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelBox.Name = "btnCancelBox";
            this.btnCancelBox.Size = new System.Drawing.Size(85, 40);
            this.btnCancelBox.TabIndex = 76;
            this.btnCancelBox.Text = "取消選中外箱";
            this.btnCancelBox.UseVisualStyleBackColor = true;
            this.btnCancelBox.Click += new System.EventHandler(this.btnCancelBox_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(755, 50);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(98, 40);
            this.button7.TabIndex = 77;
            this.button7.Text = "倒出貨櫃資料";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_2);
            // 
            // btnSeeShip
            // 
            this.btnSeeShip.Location = new System.Drawing.Point(555, 5);
            this.btnSeeShip.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeeShip.Name = "btnSeeShip";
            this.btnSeeShip.Size = new System.Drawing.Size(73, 40);
            this.btnSeeShip.TabIndex = 78;
            this.btnSeeShip.Text = "查詢貨櫃號";
            this.btnSeeShip.UseVisualStyleBackColor = true;
            this.btnSeeShip.Click += new System.EventHandler(this.btnSeeShip_Click);
            // 
            // ctmsShip
            // 
            this.ctmsShip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmsShip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TOEXCEL});
            this.ctmsShip.Name = "ctmsOrder";
            this.ctmsShip.Size = new System.Drawing.Size(149, 26);
            // 
            // TOEXCEL
            // 
            this.TOEXCEL.Name = "TOEXCEL";
            this.TOEXCEL.Size = new System.Drawing.Size(148, 22);
            this.TOEXCEL.Text = "导出到EXCEL";
            this.TOEXCEL.Click += new System.EventHandler(this.TOEXCEL_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(283, 76);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 79;
            this.label12.Text = "訂單號碼";
            // 
            // txtMorder
            // 
            this.txtMorder.Location = new System.Drawing.Point(341, 71);
            this.txtMorder.Margin = new System.Windows.Forms.Padding(2);
            this.txtMorder.Name = "txtMorder";
            this.txtMorder.Size = new System.Drawing.Size(97, 21);
            this.txtMorder.TabIndex = 80;
            // 
            // FrmPacklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 723);
            this.Controls.Add(this.txtMorder);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSeeShip);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnCancelBox);
            this.Controls.Add(this.txtW);
            this.Controls.Add(this.btnOrderCancel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBuyer);
            this.Controls.Add(this.dgvPackOrder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnUpdateShip);
            this.Controls.Add(this.btnOrderCheck);
            this.Controls.Add(this.dgvPacklistShip);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCartonNo);
            this.Controls.Add(this.txtPlanNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txtOrder1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGetInnerCode);
            this.Controls.Add(this.btnPackListIn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.test);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.dgvPacklist);
            this.Controls.Add(this.YearMounth);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPacklist";
            this.Text = "内盒条码装箱明细接转";
            this.Activated += new System.EventHandler(this.FrmPacklist_Activated);
            this.Load += new System.EventHandler(this.FrmPacklist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacklistShip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackOrder)).EndInit();
            this.ctmsShip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.DataGridView dgvPacklist;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.TextBox test;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPackListIn;
        private System.Windows.Forms.Button btnGetInnerCode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOXNO;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtOrder1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packlisttotalcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPlanNo;
        private System.Windows.Forms.TextBox txtCartonNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvPacklistShip;
        private System.Windows.Forms.Button btnOrderCheck;
        private System.Windows.Forms.Button btnUpdateShip;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvPackOrder;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOrderCancel;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.Button btnCancelBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomBuyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNo3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnSeeShip;
        private System.Windows.Forms.ContextMenuStrip ctmsShip;
        private System.Windows.Forms.ToolStripMenuItem TOEXCEL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOXNO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn AimArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipScanTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxCBM;
    }
}