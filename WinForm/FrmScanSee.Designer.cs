namespace WinForm
{
    partial class FrmScanSee
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.txtSeeOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.YearMounth = new System.Windows.Forms.DateTimePicker();
            this.dgvPackList = new System.Windows.Forms.DataGridView();
            this.CustomStyleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomBuyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOXNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InnerBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InnerBarcode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcodeNeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomStyleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPackListScan = new System.Windows.Forms.DataGridView();
            this.OrderDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomStyleCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InnerBarcode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanCount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanNO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Part1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.chkOrder = new System.Windows.Forms.CheckBox();
            this.chkScan = new System.Windows.Forms.CheckBox();
            this.ctmsPacklist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.COPYCELL = new System.Windows.Forms.ToolStripMenuItem();
            this.TOEXCEL = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmsPacklistScan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackListScan)).BeginInit();
            this.ctmsPacklist.SuspendLayout();
            this.ctmsPacklistScan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "客戶買主";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBuyer.Location = new System.Drawing.Point(197, 21);
            this.txtBuyer.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(89, 26);
            this.txtBuyer.TabIndex = 63;
            // 
            // txtSeeOrder
            // 
            this.txtSeeOrder.Location = new System.Drawing.Point(291, 46);
            this.txtSeeOrder.Margin = new System.Windows.Forms.Padding(2);
            this.txtSeeOrder.Name = "txtSeeOrder";
            this.txtSeeOrder.Size = new System.Drawing.Size(97, 43);
            this.txtSeeOrder.TabIndex = 62;
            this.txtSeeOrder.Text = "訂單查詢";
            this.txtSeeOrder.UseVisualStyleBackColor = true;
            this.txtSeeOrder.Click += new System.EventHandler(this.txtSeeOrder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 61;
            this.label3.Text = "訂單年月";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 60;
            this.label2.Text = "指令號";
            // 
            // txtOrder
            // 
            this.txtOrder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder.Location = new System.Drawing.Point(102, 21);
            this.txtOrder.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(89, 26);
            this.txtOrder.TabIndex = 59;
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(4, 19);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(2);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(89, 27);
            this.YearMounth.TabIndex = 58;
            // 
            // dgvPackList
            // 
            this.dgvPackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomStyleCode,
            this.CustomBuyName,
            this.Name1,
            this.Color,
            this.Type,
            this.BOXNO,
            this.SizeName,
            this.TotalCount,
            this.BarcodeCount,
            this.CartonBarcode,
            this.InnerBarcode,
            this.InnerBarcode1,
            this.CartonBarcodeNeed,
            this.Code,
            this.CustomStyleName,
            this.CustomPO,
            this.BoxSize});
            this.dgvPackList.Location = new System.Drawing.Point(4, 97);
            this.dgvPackList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPackList.Name = "dgvPackList";
            this.dgvPackList.ReadOnly = true;
            this.dgvPackList.RowHeadersVisible = false;
            this.dgvPackList.RowTemplate.Height = 30;
            this.dgvPackList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPackList.Size = new System.Drawing.Size(565, 515);
            this.dgvPackList.TabIndex = 69;
            this.dgvPackList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackList_CellContentClick);
            this.dgvPackList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackList_CellDoubleClick);
            this.dgvPackList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPackList_CellMouseDown);
            // 
            // CustomStyleCode
            // 
            this.CustomStyleCode.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode.HeaderText = "指令號碼";
            this.CustomStyleCode.Name = "CustomStyleCode";
            this.CustomStyleCode.ReadOnly = true;
            this.CustomStyleCode.Width = 80;
            // 
            // CustomBuyName
            // 
            this.CustomBuyName.DataPropertyName = "CustomBuyName";
            this.CustomBuyName.HeaderText = "客戶買主";
            this.CustomBuyName.Name = "CustomBuyName";
            this.CustomBuyName.ReadOnly = true;
            this.CustomBuyName.Width = 80;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "Name";
            this.Name1.HeaderText = "客戶型體";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            this.Name1.Width = 80;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "配色";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 60;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "類型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 60;
            // 
            // BOXNO
            // 
            this.BOXNO.DataPropertyName = "BOXNO";
            this.BOXNO.HeaderText = "箱號";
            this.BOXNO.Name = "BOXNO";
            this.BOXNO.ReadOnly = true;
            this.BOXNO.Width = 60;
            // 
            // SizeName
            // 
            this.SizeName.DataPropertyName = "SizeName";
            this.SizeName.HeaderText = "尺碼";
            this.SizeName.Name = "SizeName";
            this.SizeName.ReadOnly = true;
            this.SizeName.Width = 40;
            // 
            // TotalCount
            // 
            this.TotalCount.DataPropertyName = "TotalCount";
            this.TotalCount.HeaderText = "數量";
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.ReadOnly = true;
            this.TotalCount.Width = 40;
            // 
            // BarcodeCount
            // 
            this.BarcodeCount.DataPropertyName = "BarcodeCount";
            this.BarcodeCount.HeaderText = "已掃";
            this.BarcodeCount.Name = "BarcodeCount";
            this.BarcodeCount.ReadOnly = true;
            this.BarcodeCount.Width = 40;
            // 
            // CartonBarcode
            // 
            this.CartonBarcode.DataPropertyName = "CartonBarcode";
            this.CartonBarcode.HeaderText = "外箱號碼";
            this.CartonBarcode.Name = "CartonBarcode";
            this.CartonBarcode.ReadOnly = true;
            // 
            // InnerBarcode
            // 
            this.InnerBarcode.DataPropertyName = "InnerBarcode";
            this.InnerBarcode.HeaderText = "內盒條碼";
            this.InnerBarcode.Name = "InnerBarcode";
            this.InnerBarcode.ReadOnly = true;
            // 
            // InnerBarcode1
            // 
            this.InnerBarcode1.DataPropertyName = "InnerBarcode1";
            this.InnerBarcode1.HeaderText = "內盒條碼1";
            this.InnerBarcode1.Name = "InnerBarcode1";
            this.InnerBarcode1.ReadOnly = true;
            // 
            // CartonBarcodeNeed
            // 
            this.CartonBarcodeNeed.DataPropertyName = "CartonBarcodeNeed";
            this.CartonBarcodeNeed.HeaderText = "條碼列印";
            this.CartonBarcodeNeed.Name = "CartonBarcodeNeed";
            this.CartonBarcodeNeed.ReadOnly = true;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "工廠型體";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 120;
            // 
            // CustomStyleName
            // 
            this.CustomStyleName.DataPropertyName = "CustomStyleName";
            this.CustomStyleName.HeaderText = "型體名稱";
            this.CustomStyleName.Name = "CustomStyleName";
            this.CustomStyleName.ReadOnly = true;
            this.CustomStyleName.Width = 150;
            // 
            // CustomPO
            // 
            this.CustomPO.DataPropertyName = "CustomPO";
            this.CustomPO.HeaderText = "客戶編號";
            this.CustomPO.Name = "CustomPO";
            this.CustomPO.ReadOnly = true;
            // 
            // BoxSize
            // 
            this.BoxSize.DataPropertyName = "BoxSize";
            this.BoxSize.HeaderText = "外箱尺碼";
            this.BoxSize.Name = "BoxSize";
            this.BoxSize.ReadOnly = true;
            this.BoxSize.Width = 80;
            // 
            // dgvPackListScan
            // 
            this.dgvPackListScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackListScan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderDate1,
            this.CustomStyleCode1,
            this.CartonBarcode1,
            this.InnerBarcode2,
            this.ScanTime1,
            this.SizeName1,
            this.ScanCount1,
            this.ScanNO1,
            this.Part1});
            this.dgvPackListScan.Location = new System.Drawing.Point(573, 13);
            this.dgvPackListScan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPackListScan.Name = "dgvPackListScan";
            this.dgvPackListScan.RowHeadersVisible = false;
            this.dgvPackListScan.RowTemplate.Height = 30;
            this.dgvPackListScan.Size = new System.Drawing.Size(674, 600);
            this.dgvPackListScan.TabIndex = 70;
            this.dgvPackListScan.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPackListScan_CellMouseDown);
            // 
            // OrderDate1
            // 
            this.OrderDate1.DataPropertyName = "OrderDate";
            this.OrderDate1.HeaderText = "訂單年月";
            this.OrderDate1.Name = "OrderDate1";
            this.OrderDate1.Width = 80;
            // 
            // CustomStyleCode1
            // 
            this.CustomStyleCode1.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode1.HeaderText = "指令號碼";
            this.CustomStyleCode1.Name = "CustomStyleCode1";
            this.CustomStyleCode1.Width = 80;
            // 
            // CartonBarcode1
            // 
            this.CartonBarcode1.DataPropertyName = "CartonBarcode";
            this.CartonBarcode1.HeaderText = "外箱條碼";
            this.CartonBarcode1.Name = "CartonBarcode1";
            // 
            // InnerBarcode2
            // 
            this.InnerBarcode2.DataPropertyName = "InnerBarcode";
            this.InnerBarcode2.HeaderText = "內盒條碼";
            this.InnerBarcode2.Name = "InnerBarcode2";
            // 
            // ScanTime1
            // 
            this.ScanTime1.DataPropertyName = "ScanTime";
            this.ScanTime1.HeaderText = "掃描時間";
            this.ScanTime1.Name = "ScanTime1";
            // 
            // SizeName1
            // 
            this.SizeName1.DataPropertyName = "SizeName";
            this.SizeName1.HeaderText = "尺碼";
            this.SizeName1.Name = "SizeName1";
            this.SizeName1.Width = 40;
            // 
            // ScanCount1
            // 
            this.ScanCount1.DataPropertyName = "ScanCount";
            this.ScanCount1.HeaderText = "掃瞄";
            this.ScanCount1.Name = "ScanCount1";
            this.ScanCount1.Width = 40;
            // 
            // ScanNO1
            // 
            this.ScanNO1.DataPropertyName = "ScanNO";
            this.ScanNO1.HeaderText = "序號";
            this.ScanNO1.Name = "ScanNO1";
            this.ScanNO1.Width = 40;
            // 
            // Part1
            // 
            this.Part1.DataPropertyName = "Part";
            this.Part1.HeaderText = "掃描備註";
            this.Part1.Name = "Part1";
            this.Part1.Width = 80;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(393, 21);
            this.test.Margin = new System.Windows.Forms.Padding(2);
            this.test.Multiline = true;
            this.test.Name = "test";
            this.test.ReadOnly = true;
            this.test.Size = new System.Drawing.Size(165, 69);
            this.test.TabIndex = 71;
            this.test.TextChanged += new System.EventHandler(this.test_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 73;
            this.label4.Text = "客戶型體";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(5, 65);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(89, 26);
            this.txtName.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 75;
            this.label6.Text = "配色";
            // 
            // txtColor
            // 
            this.txtColor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtColor.Location = new System.Drawing.Point(102, 65);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(89, 26);
            this.txtColor.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 77;
            this.label7.Text = "條碼類型";
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtType.Location = new System.Drawing.Point(199, 65);
            this.txtType.Margin = new System.Windows.Forms.Padding(2);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(89, 26);
            this.txtType.TabIndex = 76;
            // 
            // chkOrder
            // 
            this.chkOrder.AutoSize = true;
            this.chkOrder.Checked = true;
            this.chkOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrder.Location = new System.Drawing.Point(4, 3);
            this.chkOrder.Margin = new System.Windows.Forms.Padding(2);
            this.chkOrder.Name = "chkOrder";
            this.chkOrder.Size = new System.Drawing.Size(15, 14);
            this.chkOrder.TabIndex = 78;
            this.chkOrder.UseVisualStyleBackColor = true;
            // 
            // chkScan
            // 
            this.chkScan.AutoSize = true;
            this.chkScan.Location = new System.Drawing.Point(301, 21);
            this.chkScan.Margin = new System.Windows.Forms.Padding(2);
            this.chkScan.Name = "chkScan";
            this.chkScan.Size = new System.Drawing.Size(48, 16);
            this.chkScan.TabIndex = 79;
            this.chkScan.Text = "未掃";
            this.chkScan.UseVisualStyleBackColor = true;
            // 
            // ctmsPacklist
            // 
            this.ctmsPacklist.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmsPacklist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COPYCELL,
            this.TOEXCEL});
            this.ctmsPacklist.Name = "ctmsOrder";
            this.ctmsPacklist.Size = new System.Drawing.Size(161, 48);
            this.ctmsPacklist.Opening += new System.ComponentModel.CancelEventHandler(this.ctmsPacklist_Opening);
            // 
            // COPYCELL
            // 
            this.COPYCELL.Name = "COPYCELL";
            this.COPYCELL.Size = new System.Drawing.Size(160, 22);
            this.COPYCELL.Text = "复选当前单元格";
            this.COPYCELL.Click += new System.EventHandler(this.COPYCELL_Click);
            // 
            // TOEXCEL
            // 
            this.TOEXCEL.Name = "TOEXCEL";
            this.TOEXCEL.Size = new System.Drawing.Size(160, 22);
            this.TOEXCEL.Text = "导出到EXCEL";
            this.TOEXCEL.Click += new System.EventHandler(this.TOEXCEL_Click);
            // 
            // ctmsPacklistScan
            // 
            this.ctmsPacklistScan.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmsPacklistScan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.ctmsPacklistScan.Name = "ctmsOrder";
            this.ctmsPacklistScan.Size = new System.Drawing.Size(149, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "导出到EXCEL";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // FrmScanSee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 500);
            this.Controls.Add(this.chkScan);
            this.Controls.Add(this.chkOrder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.test);
            this.Controls.Add(this.dgvPackListScan);
            this.Controls.Add(this.dgvPackList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBuyer);
            this.Controls.Add(this.txtSeeOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.YearMounth);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmScanSee";
            this.Text = "扫描查询";
            this.Activated += new System.EventHandler(this.FrmScanSee_Activated);
            this.Load += new System.EventHandler(this.FrmScanSee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackListScan)).EndInit();
            this.ctmsPacklist.ResumeLayout(false);
            this.ctmsPacklistScan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Button txtSeeOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.DataGridView dgvPackList;
        private System.Windows.Forms.DataGridView dgvPackListScan;
        private System.Windows.Forms.TextBox test;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.CheckBox chkOrder;
        private System.Windows.Forms.CheckBox chkScan;
        private System.Windows.Forms.ContextMenuStrip ctmsPacklist;
        private System.Windows.Forms.ToolStripMenuItem COPYCELL;
        private System.Windows.Forms.ToolStripMenuItem TOEXCEL;
        private System.Windows.Forms.ContextMenuStrip ctmsPacklistScan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomBuyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOXNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InnerBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InnerBarcode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcodeNeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InnerBarcode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanCount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanNO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Part1;
    }
}