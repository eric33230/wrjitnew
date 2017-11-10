namespace WinForm
{
    partial class frmOrderInFromERPDB
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImproExcel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnIMPEXCEL = new System.Windows.Forms.TextBox();
            this.btnReLink = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTestLinServer = new System.Windows.Forms.Label();
            this.LabelTestLinServer = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtShipMentDateCount = new System.Windows.Forms.TextBox();
            this.txtPOCount = new System.Windows.Forms.TextBox();
            this.txtCodeCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.meEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.meCopyRows = new System.Windows.Forms.ToolStripMenuItem();
            this.meCopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.meImproExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mePritLable = new System.Windows.Forms.ToolStripMenuItem();
            this.mePrintSizeLable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.meCopyRowss = new System.Windows.Forms.ToolStripMenuItem();
            this.meCopySelectCell = new System.Windows.Forms.ToolStripMenuItem();
            this.meImporExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsearchAll = new System.Windows.Forms.Button();
            this.txtFactoryOrderCode = new System.Windows.Forms.TextBox();
            this.txtFactoryStyleCode = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.ckFactoryOrderCode = new System.Windows.Forms.CheckBox();
            this.ckFactoryStyleCode = new System.Windows.Forms.CheckBox();
            this.dateTimePickerOperateDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerOperateDate = new System.Windows.Forms.DateTimePicker();
            this.ckFactoryOperateDate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StyleCodeInfodataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSizeRun = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.picStylePhoto = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            this.meEdit.SuspendLayout();
            this.mePrintSizeLable.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StyleCodeInfodataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSizeRun)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStylePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(867, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImproExcel
            // 
            this.btnImproExcel.Location = new System.Drawing.Point(776, 13);
            this.btnImproExcel.Name = "btnImproExcel";
            this.btnImproExcel.Size = new System.Drawing.Size(75, 23);
            this.btnImproExcel.TabIndex = 22;
            this.btnImproExcel.Text = "导出到EXCEL";
            this.btnImproExcel.UseVisualStyleBackColor = true;
            this.btnImproExcel.Click += new System.EventHandler(this.btnImproExcel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(685, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnIMPEXCEL
            // 
            this.btnIMPEXCEL.AllowDrop = true;
            this.btnIMPEXCEL.Location = new System.Drawing.Point(90, 42);
            this.btnIMPEXCEL.Multiline = true;
            this.btnIMPEXCEL.Name = "btnIMPEXCEL";
            this.btnIMPEXCEL.ReadOnly = true;
            this.btnIMPEXCEL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.btnIMPEXCEL.Size = new System.Drawing.Size(857, 55);
            this.btnIMPEXCEL.TabIndex = 20;
            // 
            // btnReLink
            // 
            this.btnReLink.Location = new System.Drawing.Point(749, 655);
            this.btnReLink.Name = "btnReLink";
            this.btnReLink.Size = new System.Drawing.Size(75, 23);
            this.btnReLink.TabIndex = 23;
            this.btnReLink.Text = "重新连接";
            this.btnReLink.UseVisualStyleBackColor = true;
            this.btnReLink.Click += new System.EventHandler(this.btnReLink_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(830, 658);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(134, 19);
            this.progressBar.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 657);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "服务器状态";
            // 
            // txtTestLinServer
            // 
            this.txtTestLinServer.AutoSize = true;
            this.txtTestLinServer.Location = new System.Drawing.Point(146, 658);
            this.txtTestLinServer.Name = "txtTestLinServer";
            this.txtTestLinServer.Size = new System.Drawing.Size(0, 12);
            this.txtTestLinServer.TabIndex = 20;
            // 
            // LabelTestLinServer
            // 
            this.LabelTestLinServer.BackColor = System.Drawing.Color.Lime;
            this.LabelTestLinServer.Location = new System.Drawing.Point(99, 656);
            this.LabelTestLinServer.Name = "LabelTestLinServer";
            this.LabelTestLinServer.Size = new System.Drawing.Size(40, 15);
            this.LabelTestLinServer.TabIndex = 19;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnImproExcel);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnIMPEXCEL);
            this.groupBox3.Controls.Add(this.txtShipMentDateCount);
            this.groupBox3.Controls.Add(this.txtPOCount);
            this.groupBox3.Controls.Add(this.txtCodeCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(15, 542);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(953, 106);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计信息";
            // 
            // txtShipMentDateCount
            // 
            this.txtShipMentDateCount.Location = new System.Drawing.Point(523, 17);
            this.txtShipMentDateCount.Name = "txtShipMentDateCount";
            this.txtShipMentDateCount.ReadOnly = true;
            this.txtShipMentDateCount.Size = new System.Drawing.Size(81, 21);
            this.txtShipMentDateCount.TabIndex = 17;
            // 
            // txtPOCount
            // 
            this.txtPOCount.Location = new System.Drawing.Point(303, 17);
            this.txtPOCount.Name = "txtPOCount";
            this.txtPOCount.ReadOnly = true;
            this.txtPOCount.Size = new System.Drawing.Size(82, 21);
            this.txtPOCount.TabIndex = 16;
            // 
            // txtCodeCount
            // 
            this.txtCodeCount.Location = new System.Drawing.Point(91, 17);
            this.txtCodeCount.Name = "txtCodeCount";
            this.txtCodeCount.ReadOnly = true;
            this.txtCodeCount.Size = new System.Drawing.Size(78, 21);
            this.txtCodeCount.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "交期汇总：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "交期总数量：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "指令总双数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "型体总数量：";
            // 
            // meEdit
            // 
            this.meEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meCopyRows,
            this.meCopyCell,
            this.meImproExcel,
            this.mePritLable});
            this.meEdit.Name = "编辑";
            this.meEdit.Size = new System.Drawing.Size(161, 92);
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
            // mePritLable
            // 
            this.mePritLable.Name = "mePritLable";
            this.mePritLable.Size = new System.Drawing.Size(160, 22);
            this.mePritLable.Text = "打印鞋舌标";
            // 
            // mePrintSizeLable
            // 
            this.mePrintSizeLable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meCopyRowss,
            this.meCopySelectCell,
            this.meImporExcel,
            this.mePrint});
            this.mePrintSizeLable.Name = "mePrintSizeLable";
            this.mePrintSizeLable.Size = new System.Drawing.Size(161, 92);
            // 
            // meCopyRowss
            // 
            this.meCopyRowss.Name = "meCopyRowss";
            this.meCopyRowss.Size = new System.Drawing.Size(160, 22);
            this.meCopyRowss.Text = "复制选中行";
            this.meCopyRowss.Click += new System.EventHandler(this.meCopyRowss_Click);
            // 
            // meCopySelectCell
            // 
            this.meCopySelectCell.Name = "meCopySelectCell";
            this.meCopySelectCell.Size = new System.Drawing.Size(160, 22);
            this.meCopySelectCell.Text = "复选当前单元格";
            this.meCopySelectCell.Click += new System.EventHandler(this.meCopySelectCell_Click);
            // 
            // meImporExcel
            // 
            this.meImporExcel.Name = "meImporExcel";
            this.meImporExcel.Size = new System.Drawing.Size(160, 22);
            this.meImporExcel.Text = "导出到EXCEL";
            this.meImporExcel.Click += new System.EventHandler(this.meImporExcel_Click);
            // 
            // mePrint
            // 
            this.mePrint.Name = "mePrint";
            this.mePrint.Size = new System.Drawing.Size(160, 22);
            this.mePrint.Text = "打印鞋舌标";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnsearchAll);
            this.groupBox1.Controls.Add(this.txtFactoryOrderCode);
            this.groupBox1.Controls.Add(this.txtFactoryStyleCode);
            this.groupBox1.Controls.Add(this.btnsearch);
            this.groupBox1.Controls.Add(this.ckFactoryOrderCode);
            this.groupBox1.Controls.Add(this.ckFactoryStyleCode);
            this.groupBox1.Controls.Add(this.dateTimePickerOperateDateEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePickerOperateDate);
            this.groupBox1.Controls.Add(this.ckFactoryOperateDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 38);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnsearchAll
            // 
            this.btnsearchAll.Location = new System.Drawing.Point(725, 10);
            this.btnsearchAll.Name = "btnsearchAll";
            this.btnsearchAll.Size = new System.Drawing.Size(116, 25);
            this.btnsearchAll.TabIndex = 10;
            this.btnsearchAll.Text = "查询";
            this.btnsearchAll.UseVisualStyleBackColor = true;
            this.btnsearchAll.Click += new System.EventHandler(this.btnsearchAll_Click);
            // 
            // txtFactoryOrderCode
            // 
            this.txtFactoryOrderCode.Location = new System.Drawing.Point(597, 12);
            this.txtFactoryOrderCode.Name = "txtFactoryOrderCode";
            this.txtFactoryOrderCode.Size = new System.Drawing.Size(122, 21);
            this.txtFactoryOrderCode.TabIndex = 9;
            // 
            // txtFactoryStyleCode
            // 
            this.txtFactoryStyleCode.Location = new System.Drawing.Point(395, 12);
            this.txtFactoryStyleCode.Name = "txtFactoryStyleCode";
            this.txtFactoryStyleCode.Size = new System.Drawing.Size(131, 21);
            this.txtFactoryStyleCode.TabIndex = 8;
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(847, 9);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(90, 26);
            this.btnsearch.TabIndex = 7;
            this.btnsearch.Text = "生成订单明细";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // ckFactoryOrderCode
            // 
            this.ckFactoryOrderCode.AutoSize = true;
            this.ckFactoryOrderCode.Location = new System.Drawing.Point(535, 14);
            this.ckFactoryOrderCode.Name = "ckFactoryOrderCode";
            this.ckFactoryOrderCode.Size = new System.Drawing.Size(60, 16);
            this.ckFactoryOrderCode.TabIndex = 6;
            this.ckFactoryOrderCode.Text = "指令号";
            this.ckFactoryOrderCode.UseVisualStyleBackColor = true;
            // 
            // ckFactoryStyleCode
            // 
            this.ckFactoryStyleCode.AutoSize = true;
            this.ckFactoryStyleCode.Location = new System.Drawing.Point(316, 14);
            this.ckFactoryStyleCode.Name = "ckFactoryStyleCode";
            this.ckFactoryStyleCode.Size = new System.Drawing.Size(72, 16);
            this.ckFactoryStyleCode.TabIndex = 4;
            this.ckFactoryStyleCode.Text = "工厂型体";
            this.ckFactoryStyleCode.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerOperateDateEnd
            // 
            this.dateTimePickerOperateDateEnd.Location = new System.Drawing.Point(220, 12);
            this.dateTimePickerOperateDateEnd.Name = "dateTimePickerOperateDateEnd";
            this.dateTimePickerOperateDateEnd.Size = new System.Drawing.Size(80, 21);
            this.dateTimePickerOperateDateEnd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "至";
            // 
            // dateTimePickerOperateDate
            // 
            this.dateTimePickerOperateDate.Location = new System.Drawing.Point(105, 12);
            this.dateTimePickerOperateDate.Name = "dateTimePickerOperateDate";
            this.dateTimePickerOperateDate.Size = new System.Drawing.Size(83, 21);
            this.dateTimePickerOperateDate.TabIndex = 1;
            // 
            // ckFactoryOperateDate
            // 
            this.ckFactoryOperateDate.AutoSize = true;
            this.ckFactoryOperateDate.Location = new System.Drawing.Point(10, 14);
            this.ckFactoryOperateDate.Name = "ckFactoryOperateDate";
            this.ckFactoryOperateDate.Size = new System.Drawing.Size(96, 16);
            this.ckFactoryOperateDate.TabIndex = 0;
            this.ckFactoryOperateDate.Text = "订单年月  从";
            this.ckFactoryOperateDate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StyleCodeInfodataGridView);
            this.groupBox2.Location = new System.Drawing.Point(11, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 414);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订单明细";
            // 
            // StyleCodeInfodataGridView
            // 
            this.StyleCodeInfodataGridView.AllowUserToAddRows = false;
            this.StyleCodeInfodataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StyleCodeInfodataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StyleCodeInfodataGridView.Location = new System.Drawing.Point(3, 17);
            this.StyleCodeInfodataGridView.MultiSelect = false;
            this.StyleCodeInfodataGridView.Name = "StyleCodeInfodataGridView";
            this.StyleCodeInfodataGridView.ReadOnly = true;
            this.StyleCodeInfodataGridView.RowTemplate.Height = 23;
            this.StyleCodeInfodataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StyleCodeInfodataGridView.Size = new System.Drawing.Size(954, 394);
            this.StyleCodeInfodataGridView.TabIndex = 4;
            this.StyleCodeInfodataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StyleCodeInfodataGridView_CellDoubleClick);
            this.StyleCodeInfodataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.StyleCodeInfodataGridView_RowPostPaint);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridViewSizeRun);
            this.groupBox4.Location = new System.Drawing.Point(13, 453);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(759, 89);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SiZeRun( 双击订单明细的行，获取选中行的SIZE数量.双击SIZERUN的行，返加订单明细的选中行.)";
            // 
            // dataGridViewSizeRun
            // 
            this.dataGridViewSizeRun.AllowUserToAddRows = false;
            this.dataGridViewSizeRun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSizeRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSizeRun.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewSizeRun.Name = "dataGridViewSizeRun";
            this.dataGridViewSizeRun.ReadOnly = true;
            this.dataGridViewSizeRun.RowTemplate.Height = 23;
            this.dataGridViewSizeRun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewSizeRun.Size = new System.Drawing.Size(753, 69);
            this.dataGridViewSizeRun.TabIndex = 0;
            this.dataGridViewSizeRun.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSizeRun_CellDoubleClick);
            this.dataGridViewSizeRun.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSizeRun_CellMouseDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.picStylePhoto);
            this.groupBox5.Location = new System.Drawing.Point(775, 454);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(193, 90);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "型体图";
            // 
            // picStylePhoto
            // 
            this.picStylePhoto.Location = new System.Drawing.Point(3, 10);
            this.picStylePhoto.Name = "picStylePhoto";
            this.picStylePhoto.Size = new System.Drawing.Size(187, 70);
            this.picStylePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStylePhoto.TabIndex = 1;
            this.picStylePhoto.TabStop = false;
            this.picStylePhoto.DoubleClick += new System.EventHandler(this.picStylePhoto_DoubleClick);
            // 
            // frmOrderInFromERPDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 691);
            this.Controls.Add(this.btnReLink);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTestLinServer);
            this.Controls.Add(this.LabelTestLinServer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Name = "frmOrderInFromERPDB";
            this.Text = "导入ERP订单资料";
            this.Activated += new System.EventHandler(this.frmOrderInFromERPDB_Activated);
            this.Load += new System.EventHandler(this.frmOrderInFromERPDB_Load);
            this.SizeChanged += new System.EventHandler(this.frmOrderInFromERPDB_SizeChanged);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.meEdit.ResumeLayout(false);
            this.mePrintSizeLable.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StyleCodeInfodataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSizeRun)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStylePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImproExcel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox btnIMPEXCEL;
        private System.Windows.Forms.Button btnReLink;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtTestLinServer;
        private System.Windows.Forms.Label LabelTestLinServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtShipMentDateCount;
        private System.Windows.Forms.TextBox txtPOCount;
        private System.Windows.Forms.TextBox txtCodeCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip meEdit;
        private System.Windows.Forms.ToolStripMenuItem meCopyRows;
        private System.Windows.Forms.ToolStripMenuItem meCopyCell;
        private System.Windows.Forms.ToolStripMenuItem meImproExcel;
        private System.Windows.Forms.ToolStripMenuItem mePritLable;
        private System.Windows.Forms.ContextMenuStrip mePrintSizeLable;
        private System.Windows.Forms.ToolStripMenuItem meCopyRowss;
        private System.Windows.Forms.ToolStripMenuItem meCopySelectCell;
        private System.Windows.Forms.ToolStripMenuItem meImporExcel;
        private System.Windows.Forms.ToolStripMenuItem mePrint;
        private System.Windows.Forms.PictureBox picStylePhoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnsearchAll;
        private System.Windows.Forms.TextBox txtFactoryOrderCode;
        private System.Windows.Forms.TextBox txtFactoryStyleCode;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.CheckBox ckFactoryOrderCode;
        private System.Windows.Forms.CheckBox ckFactoryStyleCode;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperateDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperateDate;
        private System.Windows.Forms.CheckBox ckFactoryOperateDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView StyleCodeInfodataGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridViewSizeRun;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}