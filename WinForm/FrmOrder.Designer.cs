namespace WinForm
{
    partial class FrmOrder
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
            this.dgvOrderSize = new System.Windows.Forms.DataGridView();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客戶型體 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配色 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.尺碼 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工廠型體 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomStyleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.型體 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomBuyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcodeNeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOrderIn = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.TextBox();
            this.btnOrderSIze = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctmsOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.COPYROW = new System.Windows.Forms.ToolStripMenuItem();
            this.COPYCELL = new System.Windows.Forms.ToolStripMenuItem();
            this.TOEXCEL = new System.Windows.Forms.ToolStripMenuItem();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.txtSeeOrderSize = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.txtSeeOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderSize)).BeginInit();
            this.ctmsOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(8, 20);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(2);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(89, 27);
            this.YearMounth.TabIndex = 33;
            // 
            // dgvOrderSize
            // 
            this.dgvOrderSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderSize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.客戶,
            this.客戶型體,
            this.配色,
            this.Type,
            this.尺碼,
            this.SizeCount,
            this.工廠型體,
            this.CustomStyleCode,
            this.TotalCount,
            this.型體,
            this.CustomBuyName,
            this.CartonBarcodeNeed});
            this.dgvOrderSize.Location = new System.Drawing.Point(1, 51);
            this.dgvOrderSize.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrderSize.Name = "dgvOrderSize";
            this.dgvOrderSize.RowTemplate.Height = 30;
            this.dgvOrderSize.Size = new System.Drawing.Size(1230, 578);
            this.dgvOrderSize.TabIndex = 34;
            this.dgvOrderSize.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrderSize_CellMouseDown);
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "CustomName";
            this.客戶.HeaderText = "客戶";
            this.客戶.Name = "客戶";
            // 
            // 客戶型體
            // 
            this.客戶型體.DataPropertyName = "Name";
            this.客戶型體.HeaderText = "客戶型體";
            this.客戶型體.Name = "客戶型體";
            this.客戶型體.Width = 120;
            // 
            // 配色
            // 
            this.配色.DataPropertyName = "Color";
            this.配色.HeaderText = "配色";
            this.配色.Name = "配色";
            this.配色.Width = 80;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "條碼類型";
            this.Type.Name = "Type";
            this.Type.Width = 80;
            // 
            // 尺碼
            // 
            this.尺碼.DataPropertyName = "Size";
            this.尺碼.HeaderText = "尺碼";
            this.尺碼.Name = "尺碼";
            this.尺碼.Width = 60;
            // 
            // SizeCount
            // 
            this.SizeCount.DataPropertyName = "SizeCount";
            this.SizeCount.HeaderText = "尺碼數";
            this.SizeCount.Name = "SizeCount";
            this.SizeCount.Width = 80;
            // 
            // 工廠型體
            // 
            this.工廠型體.DataPropertyName = "Code";
            this.工廠型體.HeaderText = "工廠型體";
            this.工廠型體.Name = "工廠型體";
            this.工廠型體.Width = 150;
            // 
            // CustomStyleCode
            // 
            this.CustomStyleCode.DataPropertyName = "CustomStyleCode";
            this.CustomStyleCode.HeaderText = "指令號";
            this.CustomStyleCode.Name = "CustomStyleCode";
            // 
            // TotalCount
            // 
            this.TotalCount.DataPropertyName = "TotalCount";
            this.TotalCount.HeaderText = "指令數";
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.Width = 60;
            // 
            // 型體
            // 
            this.型體.DataPropertyName = "Style";
            this.型體.HeaderText = "型體";
            this.型體.Name = "型體";
            // 
            // CustomBuyName
            // 
            this.CustomBuyName.DataPropertyName = "CustomBuyName";
            this.CustomBuyName.HeaderText = "客戶買主";
            this.CustomBuyName.Name = "CustomBuyName";
            // 
            // CartonBarcodeNeed
            // 
            this.CartonBarcodeNeed.DataPropertyName = "CartonBarcodeNeed";
            this.CartonBarcodeNeed.HeaderText = "列印";
            this.CartonBarcodeNeed.Name = "CartonBarcodeNeed";
            this.CartonBarcodeNeed.Width = 60;
            // 
            // btnOrderIn
            // 
            this.btnOrderIn.Location = new System.Drawing.Point(103, 3);
            this.btnOrderIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderIn.Name = "btnOrderIn";
            this.btnOrderIn.Size = new System.Drawing.Size(71, 43);
            this.btnOrderIn.TabIndex = 35;
            this.btnOrderIn.Text = "订单接转";
            this.btnOrderIn.UseVisualStyleBackColor = true;
            this.btnOrderIn.Click += new System.EventHandler(this.btnOrderIn_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(178, 3);
            this.test.Margin = new System.Windows.Forms.Padding(2);
            this.test.Multiline = true;
            this.test.Name = "test";
            this.test.ReadOnly = true;
            this.test.Size = new System.Drawing.Size(223, 45);
            this.test.TabIndex = 43;
            this.test.TextChanged += new System.EventHandler(this.test_TextChanged);
            // 
            // btnOrderSIze
            // 
            this.btnOrderSIze.Location = new System.Drawing.Point(983, 4);
            this.btnOrderSIze.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderSIze.Name = "btnOrderSIze";
            this.btnOrderSIze.Size = new System.Drawing.Size(69, 43);
            this.btnOrderSIze.TabIndex = 44;
            this.btnOrderSIze.Text = "查詢內盒沒有條碼";
            this.btnOrderSIze.UseVisualStyleBackColor = true;
            this.btnOrderSIze.Click += new System.EventHandler(this.btnOrderSIze_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1059, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 42);
            this.button1.TabIndex = 46;
            this.button1.Text = "更新查詢訂單內盒";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctmsOrder
            // 
            this.ctmsOrder.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmsOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COPYROW,
            this.COPYCELL,
            this.TOEXCEL});
            this.ctmsOrder.Name = "ctmsOrder";
            this.ctmsOrder.Size = new System.Drawing.Size(161, 70);
            // 
            // COPYROW
            // 
            this.COPYROW.Name = "COPYROW";
            this.COPYROW.Size = new System.Drawing.Size(160, 22);
            this.COPYROW.Text = "复制选中行";
            this.COPYROW.Click += new System.EventHandler(this.COPYROW_Click);
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
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(495, 22);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(89, 26);
            this.txtName.TabIndex = 47;
            this.txtName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "客戶型體";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "指令號";
            // 
            // txtOrder
            // 
            this.txtOrder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder.Location = new System.Drawing.Point(587, 22);
            this.txtOrder.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(89, 26);
            this.txtOrder.TabIndex = 49;
            // 
            // txtSeeOrderSize
            // 
            this.txtSeeOrderSize.Location = new System.Drawing.Point(682, 4);
            this.txtSeeOrderSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtSeeOrderSize.Name = "txtSeeOrderSize";
            this.txtSeeOrderSize.Size = new System.Drawing.Size(69, 43);
            this.txtSeeOrderSize.TabIndex = 51;
            this.txtSeeOrderSize.Text = "訂單尺碼明細查詢";
            this.txtSeeOrderSize.UseVisualStyleBackColor = true;
            this.txtSeeOrderSize.Click += new System.EventHandler(this.txtSeeOrderSize_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 52;
            this.label3.Text = "訂單年月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 54;
            this.label4.Text = "客戶";
            // 
            // txtCustomName
            // 
            this.txtCustomName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomName.Location = new System.Drawing.Point(404, 22);
            this.txtCustomName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(89, 26);
            this.txtCustomName.TabIndex = 53;
            // 
            // txtSeeOrder
            // 
            this.txtSeeOrder.Location = new System.Drawing.Point(849, 4);
            this.txtSeeOrder.Margin = new System.Windows.Forms.Padding(2);
            this.txtSeeOrder.Name = "txtSeeOrder";
            this.txtSeeOrder.Size = new System.Drawing.Size(69, 43);
            this.txtSeeOrder.TabIndex = 55;
            this.txtSeeOrder.Text = "訂單查詢";
            this.txtSeeOrder.UseVisualStyleBackColor = true;
            this.txtSeeOrder.Click += new System.EventHandler(this.txtSeeOrder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(755, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 57;
            this.label5.Text = "客戶買主";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBuyer.Location = new System.Drawing.Point(755, 20);
            this.txtBuyer.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(89, 26);
            this.txtBuyer.TabIndex = 56;
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 682);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBuyer);
            this.Controls.Add(this.txtSeeOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeeOrderSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOrderSIze);
            this.Controls.Add(this.test);
            this.Controls.Add(this.btnOrderIn);
            this.Controls.Add(this.dgvOrderSize);
            this.Controls.Add(this.YearMounth);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmOrder";
            this.Text = "訂單";
            this.Activated += new System.EventHandler(this.FrmOrder_Activated);
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderSize)).EndInit();
            this.ctmsOrder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.DataGridView dgvOrderSize;
        private System.Windows.Forms.Button btnOrderIn;
        private System.Windows.Forms.TextBox test;
        private System.Windows.Forms.Button btnOrderSIze;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip ctmsOrder;
        private System.Windows.Forms.ToolStripMenuItem TOEXCEL;
        private System.Windows.Forms.ToolStripMenuItem COPYROW;
        private System.Windows.Forms.ToolStripMenuItem COPYCELL;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Button txtSeeOrderSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomName;
        private System.Windows.Forms.Button txtSeeOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶型體;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配色;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn 尺碼;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工廠型體;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomStyleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn 型體;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomBuyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcodeNeed;
    }
}