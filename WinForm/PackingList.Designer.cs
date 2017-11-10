namespace WinForm
{
    partial class PackingList
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.butSave = new System.Windows.Forms.Button();
            this.butSelectPK = new System.Windows.Forms.Button();
            this.picMT = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radFactoryOperateDate = new System.Windows.Forms.RadioButton();
            this.radCustomCode = new System.Windows.Forms.RadioButton();
            this.dateTimePickerOperateDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerOperateDate = new System.Windows.Forms.DateTimePicker();
            this.txtCreateCustomStyleCode = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.yiyongshi = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.yitiaoshu = new System.Windows.Forms.Label();
            this.txtjingdutiao = new System.Windows.Forms.Label();
            this.jingdutiao = new System.Windows.Forms.ProgressBar();
            this.zongyongshi = new System.Windows.Forms.Label();
            this.txtSumMT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotsumcount = new System.Windows.Forms.TextBox();
            this.dataGridViewPacking = new System.Windows.Forms.DataGridView();
            this.txtBoxsumcount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewOrderBoxDocDetail = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcustomstylename = new System.Windows.Forms.TextBox();
            this.txtCustomStyleCode2 = new System.Windows.Forms.TextBox();
            this.txtGoodsTypeEnName = new System.Windows.Forms.TextBox();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckFactoryOrderCode = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustomStyleCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMT)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacking)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderBoxDocDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.butSave);
            this.groupBox4.Controls.Add(this.butSelectPK);
            this.groupBox4.Controls.Add(this.picMT);
            this.groupBox4.Location = new System.Drawing.Point(639, 470);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 169);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "唛头";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(196, 140);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 32;
            this.butSave.Text = "保存";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butSelectPK
            // 
            this.butSelectPK.Location = new System.Drawing.Point(42, 140);
            this.butSelectPK.Name = "butSelectPK";
            this.butSelectPK.Size = new System.Drawing.Size(75, 23);
            this.butSelectPK.TabIndex = 31;
            this.butSelectPK.Text = "选择唛头图片";
            this.butSelectPK.UseVisualStyleBackColor = true;
            this.butSelectPK.Click += new System.EventHandler(this.butSelectPK_Click);
            // 
            // picMT
            // 
            this.picMT.Location = new System.Drawing.Point(10, 14);
            this.picMT.Name = "picMT";
            this.picMT.Size = new System.Drawing.Size(322, 123);
            this.picMT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMT.TabIndex = 30;
            this.picMT.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(857, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "總體積：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(737, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 55;
            this.label6.Text = "總雙數：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(896, 638);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "取消保存";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radFactoryOperateDate);
            this.groupBox5.Controls.Add(this.radCustomCode);
            this.groupBox5.Controls.Add(this.dateTimePickerOperateDateEnd);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.dateTimePickerOperateDate);
            this.groupBox5.Controls.Add(this.txtCreateCustomStyleCode);
            this.groupBox5.Controls.Add(this.btnCreate);
            this.groupBox5.Location = new System.Drawing.Point(277, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(715, 51);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "生成装箱单";
            // 
            // radFactoryOperateDate
            // 
            this.radFactoryOperateDate.AutoSize = true;
            this.radFactoryOperateDate.Location = new System.Drawing.Point(264, 23);
            this.radFactoryOperateDate.Name = "radFactoryOperateDate";
            this.radFactoryOperateDate.Size = new System.Drawing.Size(95, 16);
            this.radFactoryOperateDate.TabIndex = 21;
            this.radFactoryOperateDate.TabStop = true;
            this.radFactoryOperateDate.Text = "订单年月  从";
            this.radFactoryOperateDate.UseVisualStyleBackColor = true;
            this.radFactoryOperateDate.CheckedChanged += new System.EventHandler(this.radFactoryOperateDate_CheckedChanged);
            // 
            // radCustomCode
            // 
            this.radCustomCode.AutoSize = true;
            this.radCustomCode.Location = new System.Drawing.Point(31, 24);
            this.radCustomCode.Name = "radCustomCode";
            this.radCustomCode.Size = new System.Drawing.Size(59, 16);
            this.radCustomCode.TabIndex = 20;
            this.radCustomCode.TabStop = true;
            this.radCustomCode.Text = "指令号";
            this.radCustomCode.UseVisualStyleBackColor = true;
            this.radCustomCode.CheckedChanged += new System.EventHandler(this.radCustomCode_CheckedChanged);
            // 
            // dateTimePickerOperateDateEnd
            // 
            this.dateTimePickerOperateDateEnd.Location = new System.Drawing.Point(472, 20);
            this.dateTimePickerOperateDateEnd.Name = "dateTimePickerOperateDateEnd";
            this.dateTimePickerOperateDateEnd.Size = new System.Drawing.Size(79, 21);
            this.dateTimePickerOperateDateEnd.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(453, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "至";
            // 
            // dateTimePickerOperateDate
            // 
            this.dateTimePickerOperateDate.Location = new System.Drawing.Point(365, 20);
            this.dateTimePickerOperateDate.Name = "dateTimePickerOperateDate";
            this.dateTimePickerOperateDate.Size = new System.Drawing.Size(81, 21);
            this.dateTimePickerOperateDate.TabIndex = 17;
            // 
            // txtCreateCustomStyleCode
            // 
            this.txtCreateCustomStyleCode.Location = new System.Drawing.Point(100, 21);
            this.txtCreateCustomStyleCode.Name = "txtCreateCustomStyleCode";
            this.txtCreateCustomStyleCode.Size = new System.Drawing.Size(137, 21);
            this.txtCreateCustomStyleCode.TabIndex = 14;
            this.txtCreateCustomStyleCode.Click += new System.EventHandler(this.txtCreateCustomStyleCode_Click);
            this.txtCreateCustomStyleCode.TextChanged += new System.EventHandler(this.txtCustomStyleCode_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(578, 16);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(116, 32);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "生成装箱单";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(635, 663);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 64;
            this.label10.Text = "估计总需时(秒)：";
            // 
            // yiyongshi
            // 
            this.yiyongshi.AutoSize = true;
            this.yiyongshi.Location = new System.Drawing.Point(457, 662);
            this.yiyongshi.Name = "yiyongshi";
            this.yiyongshi.Size = new System.Drawing.Size(0, 12);
            this.yiyongshi.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 662);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 62;
            this.label9.Text = "已用时(秒)：";
            // 
            // yitiaoshu
            // 
            this.yitiaoshu.AutoSize = true;
            this.yitiaoshu.Location = new System.Drawing.Point(22, 657);
            this.yitiaoshu.Name = "yitiaoshu";
            this.yitiaoshu.Size = new System.Drawing.Size(0, 12);
            this.yitiaoshu.TabIndex = 61;
            // 
            // txtjingdutiao
            // 
            this.txtjingdutiao.AutoSize = true;
            this.txtjingdutiao.Location = new System.Drawing.Point(16, 660);
            this.txtjingdutiao.Name = "txtjingdutiao";
            this.txtjingdutiao.Size = new System.Drawing.Size(0, 12);
            this.txtjingdutiao.TabIndex = 59;
            // 
            // jingdutiao
            // 
            this.jingdutiao.Location = new System.Drawing.Point(18, 637);
            this.jingdutiao.Name = "jingdutiao";
            this.jingdutiao.Size = new System.Drawing.Size(865, 20);
            this.jingdutiao.TabIndex = 58;
            // 
            // zongyongshi
            // 
            this.zongyongshi.AutoSize = true;
            this.zongyongshi.Location = new System.Drawing.Point(726, 663);
            this.zongyongshi.Name = "zongyongshi";
            this.zongyongshi.Size = new System.Drawing.Size(0, 12);
            this.zongyongshi.TabIndex = 65;
            // 
            // txtSumMT
            // 
            this.txtSumMT.Location = new System.Drawing.Point(912, 66);
            this.txtSumMT.Name = "txtSumMT";
            this.txtSumMT.ReadOnly = true;
            this.txtSumMT.Size = new System.Drawing.Size(80, 21);
            this.txtSumMT.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "總箱數：";
            // 
            // txtTotsumcount
            // 
            this.txtTotsumcount.Location = new System.Drawing.Point(648, 64);
            this.txtTotsumcount.Name = "txtTotsumcount";
            this.txtTotsumcount.ReadOnly = true;
            this.txtTotsumcount.Size = new System.Drawing.Size(81, 21);
            this.txtTotsumcount.TabIndex = 51;
            // 
            // dataGridViewPacking
            // 
            this.dataGridViewPacking.AllowUserToAddRows = false;
            this.dataGridViewPacking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPacking.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewPacking.Name = "dataGridViewPacking";
            this.dataGridViewPacking.ReadOnly = true;
            this.dataGridViewPacking.RowTemplate.Height = 23;
            this.dataGridViewPacking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPacking.Size = new System.Drawing.Size(973, 364);
            this.dataGridViewPacking.TabIndex = 0;
            this.dataGridViewPacking.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewPacking_RowPostPaint);
            // 
            // txtBoxsumcount
            // 
            this.txtBoxsumcount.Location = new System.Drawing.Point(792, 65);
            this.txtBoxsumcount.Name = "txtBoxsumcount";
            this.txtBoxsumcount.ReadOnly = true;
            this.txtBoxsumcount.Size = new System.Drawing.Size(60, 21);
            this.txtBoxsumcount.TabIndex = 54;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewOrderBoxDocDetail);
            this.groupBox3.Location = new System.Drawing.Point(12, 462);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 169);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "內盒明細";
            // 
            // dataGridViewOrderBoxDocDetail
            // 
            this.dataGridViewOrderBoxDocDetail.AllowUserToAddRows = false;
            this.dataGridViewOrderBoxDocDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderBoxDocDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOrderBoxDocDetail.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewOrderBoxDocDetail.Name = "dataGridViewOrderBoxDocDetail";
            this.dataGridViewOrderBoxDocDetail.ReadOnly = true;
            this.dataGridViewOrderBoxDocDetail.RowTemplate.Height = 23;
            this.dataGridViewOrderBoxDocDetail.Size = new System.Drawing.Size(618, 149);
            this.dataGridViewOrderBoxDocDetail.TabIndex = 0;
            this.dataGridViewOrderBoxDocDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewOrderBoxDocDetail_RowPostPaint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "指令單號：";
            // 
            // txtcustomstylename
            // 
            this.txtcustomstylename.Location = new System.Drawing.Point(327, 64);
            this.txtcustomstylename.Name = "txtcustomstylename";
            this.txtcustomstylename.ReadOnly = true;
            this.txtcustomstylename.Size = new System.Drawing.Size(108, 21);
            this.txtcustomstylename.TabIndex = 46;
            // 
            // txtCustomStyleCode2
            // 
            this.txtCustomStyleCode2.Location = new System.Drawing.Point(505, 64);
            this.txtCustomStyleCode2.Name = "txtCustomStyleCode2";
            this.txtCustomStyleCode2.ReadOnly = true;
            this.txtCustomStyleCode2.Size = new System.Drawing.Size(86, 21);
            this.txtCustomStyleCode2.TabIndex = 47;
            // 
            // txtGoodsTypeEnName
            // 
            this.txtGoodsTypeEnName.Location = new System.Drawing.Point(199, 64);
            this.txtGoodsTypeEnName.Name = "txtGoodsTypeEnName";
            this.txtGoodsTypeEnName.ReadOnly = true;
            this.txtGoodsTypeEnName.Size = new System.Drawing.Size(85, 21);
            this.txtGoodsTypeEnName.TabIndex = 45;
            // 
            // txtCustomName
            // 
            this.txtCustomName.Location = new System.Drawing.Point(60, 64);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.ReadOnly = true;
            this.txtCustomName.Size = new System.Drawing.Size(77, 21);
            this.txtCustomName.TabIndex = 44;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(173, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 35);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询装箱单";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ckFactoryOrderCode
            // 
            this.ckFactoryOrderCode.AutoSize = true;
            this.ckFactoryOrderCode.Location = new System.Drawing.Point(6, 22);
            this.ckFactoryOrderCode.Name = "ckFactoryOrderCode";
            this.ckFactoryOrderCode.Size = new System.Drawing.Size(60, 16);
            this.ckFactoryOrderCode.TabIndex = 13;
            this.ckFactoryOrderCode.Text = "指令号";
            this.ckFactoryOrderCode.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "型體：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "鞋型種類：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 41;
            this.label1.Text = "客人：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.ckFactoryOrderCode);
            this.groupBox2.Controls.Add(this.txtCustomStyleCode);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 51);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // txtCustomStyleCode
            // 
            this.txtCustomStyleCode.Location = new System.Drawing.Point(72, 20);
            this.txtCustomStyleCode.Name = "txtCustomStyleCode";
            this.txtCustomStyleCode.Size = new System.Drawing.Size(95, 21);
            this.txtCustomStyleCode.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewPacking);
            this.groupBox1.Location = new System.Drawing.Point(13, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 384);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工厂装箱单";
            // 
            // PackingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 678);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.yiyongshi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.yitiaoshu);
            this.Controls.Add(this.txtjingdutiao);
            this.Controls.Add(this.jingdutiao);
            this.Controls.Add(this.zongyongshi);
            this.Controls.Add(this.txtSumMT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotsumcount);
            this.Controls.Add(this.txtBoxsumcount);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtcustomstylename);
            this.Controls.Add(this.txtCustomStyleCode2);
            this.Controls.Add(this.txtGoodsTypeEnName);
            this.Controls.Add(this.txtCustomName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PackingList";
            this.Text = "导入ERP装箱单";
            this.Activated += new System.EventHandler(this.PackingList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackingList_FormClosing);
            this.Load += new System.EventHandler(this.PackingList_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMT)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacking)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderBoxDocDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butSelectPK;
        private System.Windows.Forms.PictureBox picMT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radFactoryOperateDate;
        private System.Windows.Forms.RadioButton radCustomCode;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperateDateEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperateDate;
        private System.Windows.Forms.TextBox txtCreateCustomStyleCode;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label yiyongshi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label yitiaoshu;
        private System.Windows.Forms.Label txtjingdutiao;
        private System.Windows.Forms.ProgressBar jingdutiao;
        private System.Windows.Forms.Label zongyongshi;
        private System.Windows.Forms.TextBox txtSumMT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotsumcount;
        private System.Windows.Forms.DataGridView dataGridViewPacking;
        private System.Windows.Forms.TextBox txtBoxsumcount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewOrderBoxDocDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcustomstylename;
        private System.Windows.Forms.TextBox txtCustomStyleCode2;
        private System.Windows.Forms.TextBox txtGoodsTypeEnName;
        private System.Windows.Forms.TextBox txtCustomName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckFactoryOrderCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCustomStyleCode;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}