namespace WinForm
{
    partial class FrmOutsideBarCodePrint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSelect = new System.Windows.Forms.Button();
            this.btnselectallcustomcode = new System.Windows.Forms.Button();
            this.dgvStyleCode = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnselectallboxno = new System.Windows.Forms.Button();
            this.dgvBoxNo = new System.Windows.Forms.DataGridView();
            this.btnbarcodeprint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckOrderDate = new System.Windows.Forms.CheckBox();
            this.dTOrderDate = new System.Windows.Forms.DateTimePicker();
            this.cknop = new System.Windows.Forms.CheckBox();
            this.ckneedp = new System.Windows.Forms.CheckBox();
            this.ckbStyleCode = new System.Windows.Forms.CheckBox();
            this.ckbCustomStyleCode = new System.Windows.Forms.CheckBox();
            this.txtStyleCode = new System.Windows.Forms.TextBox();
            this.txtCustomStyleCode = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnBarcodeReader = new System.Windows.Forms.Button();
            this.btnCreateQuickMark = new System.Windows.Forms.Button();
            this.btnCreateBarCode = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msg = new System.Windows.Forms.Label();
            this.meEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.meCopyRows = new System.Windows.Forms.ToolStripMenuItem();
            this.meCopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.meImproExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyleCode)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxNo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.meEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSelect);
            this.groupBox1.Controls.Add(this.btnselectallcustomcode);
            this.groupBox1.Controls.Add(this.dgvStyleCode);
            this.groupBox1.Location = new System.Drawing.Point(5, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 496);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指令明细（双击行展开明细）";
            // 
            // btnAddSelect
            // 
            this.btnAddSelect.Location = new System.Drawing.Point(666, 2);
            this.btnAddSelect.Name = "btnAddSelect";
            this.btnAddSelect.Size = new System.Drawing.Size(111, 21);
            this.btnAddSelect.TabIndex = 45;
            this.btnAddSelect.Text = "勾选的指令号";
            this.btnAddSelect.UseVisualStyleBackColor = true;
            this.btnAddSelect.Click += new System.EventHandler(this.btnAddSelect_Click);
            // 
            // btnselectallcustomcode
            // 
            this.btnselectallcustomcode.Location = new System.Drawing.Point(569, 2);
            this.btnselectallcustomcode.Name = "btnselectallcustomcode";
            this.btnselectallcustomcode.Size = new System.Drawing.Size(91, 21);
            this.btnselectallcustomcode.TabIndex = 26;
            this.btnselectallcustomcode.Text = "全选/全不选";
            this.btnselectallcustomcode.UseVisualStyleBackColor = true;
            this.btnselectallcustomcode.Click += new System.EventHandler(this.btnselectallcustomcode_Click);
            // 
            // dgvStyleCode
            // 
            this.dgvStyleCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStyleCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStyleCode.Location = new System.Drawing.Point(3, 17);
            this.dgvStyleCode.Name = "dgvStyleCode";
            this.dgvStyleCode.RowTemplate.Height = 23;
            this.dgvStyleCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStyleCode.Size = new System.Drawing.Size(781, 476);
            this.dgvStyleCode.TabIndex = 6;
            this.dgvStyleCode.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStyleCode_CellDoubleClick);
            this.dgvStyleCode.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStyleCode_CellMouseDown);
            this.dgvStyleCode.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvStyleCode_RowPostPaint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnselectallboxno);
            this.groupBox3.Controls.Add(this.dgvBoxNo);
            this.groupBox3.Location = new System.Drawing.Point(795, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 493);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "箱号明细";
            // 
            // btnselectallboxno
            // 
            this.btnselectallboxno.Location = new System.Drawing.Point(260, 0);
            this.btnselectallboxno.Name = "btnselectallboxno";
            this.btnselectallboxno.Size = new System.Drawing.Size(93, 20);
            this.btnselectallboxno.TabIndex = 25;
            this.btnselectallboxno.Text = "全选/全不选";
            this.btnselectallboxno.UseVisualStyleBackColor = true;
            this.btnselectallboxno.Click += new System.EventHandler(this.btnselectallboxno_Click);
            // 
            // dgvBoxNo
            // 
            this.dgvBoxNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoxNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoxNo.Location = new System.Drawing.Point(3, 17);
            this.dgvBoxNo.Name = "dgvBoxNo";
            this.dgvBoxNo.RowTemplate.Height = 23;
            this.dgvBoxNo.Size = new System.Drawing.Size(347, 473);
            this.dgvBoxNo.TabIndex = 0;
            this.dgvBoxNo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBoxNo_RowPostPaint);
            // 
            // btnbarcodeprint
            // 
            this.btnbarcodeprint.Location = new System.Drawing.Point(1046, 10);
            this.btnbarcodeprint.Name = "btnbarcodeprint";
            this.btnbarcodeprint.Size = new System.Drawing.Size(99, 36);
            this.btnbarcodeprint.TabIndex = 11;
            this.btnbarcodeprint.Text = "打印";
            this.btnbarcodeprint.UseVisualStyleBackColor = true;
            this.btnbarcodeprint.Click += new System.EventHandler(this.btnbarcodeprint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckOrderDate);
            this.groupBox2.Controls.Add(this.dTOrderDate);
            this.groupBox2.Controls.Add(this.cknop);
            this.groupBox2.Controls.Add(this.ckneedp);
            this.groupBox2.Controls.Add(this.ckbStyleCode);
            this.groupBox2.Controls.Add(this.ckbCustomStyleCode);
            this.groupBox2.Controls.Add(this.txtStyleCode);
            this.groupBox2.Controls.Add(this.txtCustomStyleCode);
            this.groupBox2.Controls.Add(this.btnsearch);
            this.groupBox2.Location = new System.Drawing.Point(5, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 46);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询";
            // 
            // ckOrderDate
            // 
            this.ckOrderDate.AutoSize = true;
            this.ckOrderDate.Location = new System.Drawing.Point(324, 22);
            this.ckOrderDate.Name = "ckOrderDate";
            this.ckOrderDate.Size = new System.Drawing.Size(72, 16);
            this.ckOrderDate.TabIndex = 43;
            this.ckOrderDate.Text = "订单年月";
            this.ckOrderDate.UseVisualStyleBackColor = true;
            this.ckOrderDate.CheckedChanged += new System.EventHandler(this.ckOrderDate_CheckedChanged);
            // 
            // dTOrderDate
            // 
            this.dTOrderDate.Location = new System.Drawing.Point(402, 18);
            this.dTOrderDate.Name = "dTOrderDate";
            this.dTOrderDate.Size = new System.Drawing.Size(80, 21);
            this.dTOrderDate.TabIndex = 42;
            this.dTOrderDate.Enter += new System.EventHandler(this.dTOrderDate_Enter);
            // 
            // cknop
            // 
            this.cknop.AutoSize = true;
            this.cknop.Location = new System.Drawing.Point(488, 25);
            this.cknop.Name = "cknop";
            this.cknop.Size = new System.Drawing.Size(72, 16);
            this.cknop.TabIndex = 13;
            this.cknop.Text = "无需打印";
            this.cknop.UseVisualStyleBackColor = true;
            // 
            // ckneedp
            // 
            this.ckneedp.AutoSize = true;
            this.ckneedp.Location = new System.Drawing.Point(488, 10);
            this.ckneedp.Name = "ckneedp";
            this.ckneedp.Size = new System.Drawing.Size(60, 16);
            this.ckneedp.TabIndex = 12;
            this.ckneedp.Text = "需打印";
            this.ckneedp.UseVisualStyleBackColor = true;
            // 
            // ckbStyleCode
            // 
            this.ckbStyleCode.AutoSize = true;
            this.ckbStyleCode.Location = new System.Drawing.Point(6, 20);
            this.ckbStyleCode.Name = "ckbStyleCode";
            this.ckbStyleCode.Size = new System.Drawing.Size(72, 16);
            this.ckbStyleCode.TabIndex = 11;
            this.ckbStyleCode.Text = "工厂型体";
            this.ckbStyleCode.UseVisualStyleBackColor = true;
            this.ckbStyleCode.CheckedChanged += new System.EventHandler(this.ckbStyleCode_CheckedChanged);
            // 
            // ckbCustomStyleCode
            // 
            this.ckbCustomStyleCode.AutoSize = true;
            this.ckbCustomStyleCode.Location = new System.Drawing.Point(170, 20);
            this.ckbCustomStyleCode.Name = "ckbCustomStyleCode";
            this.ckbCustomStyleCode.Size = new System.Drawing.Size(60, 16);
            this.ckbCustomStyleCode.TabIndex = 10;
            this.ckbCustomStyleCode.Text = "指令号";
            this.ckbCustomStyleCode.UseVisualStyleBackColor = true;
            this.ckbCustomStyleCode.CheckedChanged += new System.EventHandler(this.ckbCustomStyleCode_CheckedChanged);
            // 
            // txtStyleCode
            // 
            this.txtStyleCode.Location = new System.Drawing.Point(84, 18);
            this.txtStyleCode.Name = "txtStyleCode";
            this.txtStyleCode.Size = new System.Drawing.Size(82, 21);
            this.txtStyleCode.TabIndex = 9;
            this.txtStyleCode.Enter += new System.EventHandler(this.txtStyleCode_Enter);
            // 
            // txtCustomStyleCode
            // 
            this.txtCustomStyleCode.Location = new System.Drawing.Point(235, 18);
            this.txtCustomStyleCode.Name = "txtCustomStyleCode";
            this.txtCustomStyleCode.Size = new System.Drawing.Size(78, 21);
            this.txtCustomStyleCode.TabIndex = 6;
            this.txtCustomStyleCode.Enter += new System.EventHandler(this.txtCustomStyleCode_Enter);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(573, 10);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(84, 29);
            this.btnsearch.TabIndex = 5;
            this.btnsearch.Text = "查询";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnBarcodeReader
            // 
            this.btnBarcodeReader.Location = new System.Drawing.Point(955, 4);
            this.btnBarcodeReader.Name = "btnBarcodeReader";
            this.btnBarcodeReader.Size = new System.Drawing.Size(75, 45);
            this.btnBarcodeReader.TabIndex = 39;
            this.btnBarcodeReader.Text = "读码";
            this.btnBarcodeReader.UseVisualStyleBackColor = true;
            this.btnBarcodeReader.Click += new System.EventHandler(this.btnBarcodeReader_Click);
            // 
            // btnCreateQuickMark
            // 
            this.btnCreateQuickMark.Location = new System.Drawing.Point(939, 4);
            this.btnCreateQuickMark.Name = "btnCreateQuickMark";
            this.btnCreateQuickMark.Size = new System.Drawing.Size(75, 45);
            this.btnCreateQuickMark.TabIndex = 38;
            this.btnCreateQuickMark.Text = "生成二维码";
            this.btnCreateQuickMark.UseVisualStyleBackColor = true;
            this.btnCreateQuickMark.Click += new System.EventHandler(this.btnCreateQuickMark_Click);
            // 
            // btnCreateBarCode
            // 
            this.btnCreateBarCode.Location = new System.Drawing.Point(923, 7);
            this.btnCreateBarCode.Name = "btnCreateBarCode";
            this.btnCreateBarCode.Size = new System.Drawing.Size(75, 47);
            this.btnCreateBarCode.TabIndex = 37;
            this.btnCreateBarCode.Text = "生成条码";
            this.btnCreateBarCode.UseVisualStyleBackColor = true;
            this.btnCreateBarCode.Click += new System.EventHandler(this.btnCreateBarCode_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(671, 28);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 11);
            this.progressBar1.TabIndex = 35;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(671, 4);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(133, 21);
            this.txtMsg.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(810, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 45);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Location = new System.Drawing.Point(671, 40);
            this.msg.Margin = new System.Windows.Forms.Padding(0);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(23, 12);
            this.msg.TabIndex = 41;
            this.msg.Text = "msg";
            // 
            // meEdit
            // 
            this.meEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meCopyRows,
            this.meCopyCell,
            this.meImproExcel});
            this.meEdit.Name = "编辑";
            this.meEdit.Size = new System.Drawing.Size(161, 70);
            this.meEdit.Text = "编辑";
            // 
            // meCopyRows
            // 
            this.meCopyRows.Name = "meCopyRows";
            this.meCopyRows.Size = new System.Drawing.Size(160, 22);
            this.meCopyRows.Text = "复制选中行";
            this.meCopyRows.Click += new System.EventHandler(this.meCopyRows_Click);
            // 
            // meCopyCell
            // 
            this.meCopyCell.Name = "meCopyCell";
            this.meCopyCell.Size = new System.Drawing.Size(160, 22);
            this.meCopyCell.Text = "复选当前单元格";
            this.meCopyCell.Click += new System.EventHandler(this.meCopyCell_Click);
            // 
            // meImproExcel
            // 
            this.meImproExcel.Name = "meImproExcel";
            this.meImproExcel.Size = new System.Drawing.Size(160, 22);
            this.meImproExcel.Text = "导出到EXCEL";
            this.meImproExcel.Click += new System.EventHandler(this.meImproExcel_Click);
            // 
            // FrmOutsideBarCodePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 613);
            this.Controls.Add(this.btnBarcodeReader);
            this.Controls.Add(this.btnCreateQuickMark);
            this.Controls.Add(this.btnCreateBarCode);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnbarcodeprint);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmOutsideBarCodePrint";
            this.Text = "外箱条码打印";
            this.Activated += new System.EventHandler(this.FrmOutsideBarCodePrint_Activated);
            this.Load += new System.EventHandler(this.FrmOutsideBarCodePrint_Load);
            this.SizeChanged += new System.EventHandler(this.FrmOutsideBarCodePrint_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyleCode)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxNo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.meEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStyleCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvBoxNo;
        private System.Windows.Forms.Button btnbarcodeprint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStyleCode;
        private System.Windows.Forms.TextBox txtCustomStyleCode;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.CheckBox ckbCustomStyleCode;
        private System.Windows.Forms.Button btnselectallcustomcode;
        private System.Windows.Forms.Button btnselectallboxno;
        private System.Windows.Forms.CheckBox ckbStyleCode;
        private System.Windows.Forms.Button btnBarcodeReader;
        private System.Windows.Forms.Button btnCreateQuickMark;
        private System.Windows.Forms.Button btnCreateBarCode;
        private System.Windows.Forms.Button btnAddSelect;
        private System.Windows.Forms.CheckBox cknop;
        private System.Windows.Forms.CheckBox ckneedp;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.CheckBox ckOrderDate;
        private System.Windows.Forms.DateTimePicker dTOrderDate;
        private System.Windows.Forms.ContextMenuStrip meEdit;
        private System.Windows.Forms.ToolStripMenuItem meCopyRows;
        private System.Windows.Forms.ToolStripMenuItem meCopyCell;
        private System.Windows.Forms.ToolStripMenuItem meImproExcel;
    }
}