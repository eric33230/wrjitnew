namespace WinForm
{
    partial class FrmFingerprintManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfip = new System.Windows.Forms.TextBox();
            this.txtfport = new System.Windows.Forms.TextBox();
            this.txtfname = new System.Windows.Forms.TextBox();
            this.txtfaddress = new System.Windows.Forms.TextBox();
            this.txtfnote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbaddringer = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbuyfone = new System.Windows.Forms.TextBox();
            this.txtbuyname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbfdept = new System.Windows.Forms.ComboBox();
            this.cbfhouse = new System.Windows.Forms.ComboBox();
            this.btnaddfinger = new System.Windows.Forms.Button();
            this.dtpbuydate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckaddfinger = new System.Windows.Forms.CheckBox();
            this.gbfingerlist = new System.Windows.Forms.GroupBox();
            this.dgvfinger = new System.Windows.Forms.DataGridView();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.btnonekeydownload = new System.Windows.Forms.Button();
            this.btnselectfp = new System.Windows.Forms.Button();
            this.gbkey = new System.Windows.Forms.GroupBox();
            this.lvLogs = new System.Windows.Forms.ListView();
            this.lvLogsch0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labbar = new System.Windows.Forms.Label();
            this.jingdutiao = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lv1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tomeClearl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.meclearl = new System.Windows.Forms.ToolStripMenuItem();
            this.btuploadtoserver = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbDisks = new System.Windows.Forms.ComboBox();
            this.gbaddringer.SuspendLayout();
            this.gbfingerlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfinger)).BeginInit();
            this.gbkey.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tomeClearl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "名字";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "位置";
            // 
            // txtfip
            // 
            this.txtfip.Location = new System.Drawing.Point(50, 17);
            this.txtfip.Name = "txtfip";
            this.txtfip.Size = new System.Drawing.Size(100, 21);
            this.txtfip.TabIndex = 6;
            this.txtfip.Text = "192.168.100.";
            // 
            // txtfport
            // 
            this.txtfport.Location = new System.Drawing.Point(197, 17);
            this.txtfport.Name = "txtfport";
            this.txtfport.Size = new System.Drawing.Size(53, 21);
            this.txtfport.TabIndex = 7;
            this.txtfport.Text = "4370";
            // 
            // txtfname
            // 
            this.txtfname.Location = new System.Drawing.Point(300, 17);
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(100, 21);
            this.txtfname.TabIndex = 8;
            // 
            // txtfaddress
            // 
            this.txtfaddress.Location = new System.Drawing.Point(50, 81);
            this.txtfaddress.Name = "txtfaddress";
            this.txtfaddress.Size = new System.Drawing.Size(350, 21);
            this.txtfaddress.TabIndex = 11;
            // 
            // txtfnote
            // 
            this.txtfnote.Location = new System.Drawing.Point(50, 113);
            this.txtfnote.Name = "txtfnote";
            this.txtfnote.Size = new System.Drawing.Size(350, 21);
            this.txtfnote.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "备注";
            // 
            // gbaddringer
            // 
            this.gbaddringer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gbaddringer.Controls.Add(this.label8);
            this.gbaddringer.Controls.Add(this.txtbuyfone);
            this.gbaddringer.Controls.Add(this.txtbuyname);
            this.gbaddringer.Controls.Add(this.label10);
            this.gbaddringer.Controls.Add(this.label9);
            this.gbaddringer.Controls.Add(this.cbfdept);
            this.gbaddringer.Controls.Add(this.cbfhouse);
            this.gbaddringer.Controls.Add(this.btnaddfinger);
            this.gbaddringer.Controls.Add(this.dtpbuydate);
            this.gbaddringer.Controls.Add(this.label6);
            this.gbaddringer.Controls.Add(this.label4);
            this.gbaddringer.Controls.Add(this.label7);
            this.gbaddringer.Controls.Add(this.txtfaddress);
            this.gbaddringer.Controls.Add(this.txtfnote);
            this.gbaddringer.Controls.Add(this.txtfname);
            this.gbaddringer.Controls.Add(this.txtfport);
            this.gbaddringer.Controls.Add(this.txtfip);
            this.gbaddringer.Controls.Add(this.label5);
            this.gbaddringer.Controls.Add(this.label3);
            this.gbaddringer.Controls.Add(this.label2);
            this.gbaddringer.Controls.Add(this.label1);
            this.gbaddringer.Enabled = false;
            this.gbaddringer.Location = new System.Drawing.Point(3, 5);
            this.gbaddringer.Name = "gbaddringer";
            this.gbaddringer.Size = new System.Drawing.Size(424, 270);
            this.gbaddringer.TabIndex = 14;
            this.gbaddringer.TabStop = false;
            this.gbaddringer.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "购买时间";
            // 
            // txtbuyfone
            // 
            this.txtbuyfone.Location = new System.Drawing.Point(248, 149);
            this.txtbuyfone.Name = "txtbuyfone";
            this.txtbuyfone.Size = new System.Drawing.Size(152, 21);
            this.txtbuyfone.TabIndex = 27;
            // 
            // txtbuyname
            // 
            this.txtbuyname.Location = new System.Drawing.Point(63, 183);
            this.txtbuyname.Name = "txtbuyname";
            this.txtbuyname.Size = new System.Drawing.Size(337, 21);
            this.txtbuyname.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(159, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "部门";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "栋别";
            // 
            // cbfdept
            // 
            this.cbfdept.FormattingEnabled = true;
            this.cbfdept.Location = new System.Drawing.Point(191, 48);
            this.cbfdept.Name = "cbfdept";
            this.cbfdept.Size = new System.Drawing.Size(98, 20);
            this.cbfdept.TabIndex = 23;
            // 
            // cbfhouse
            // 
            this.cbfhouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfhouse.FormattingEnabled = true;
            this.cbfhouse.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H"});
            this.cbfhouse.Location = new System.Drawing.Point(50, 44);
            this.cbfhouse.Name = "cbfhouse";
            this.cbfhouse.Size = new System.Drawing.Size(100, 20);
            this.cbfhouse.TabIndex = 22;
            // 
            // btnaddfinger
            // 
            this.btnaddfinger.Location = new System.Drawing.Point(171, 222);
            this.btnaddfinger.Name = "btnaddfinger";
            this.btnaddfinger.Size = new System.Drawing.Size(102, 29);
            this.btnaddfinger.TabIndex = 21;
            this.btnaddfinger.Text = "确认";
            this.btnaddfinger.UseVisualStyleBackColor = true;
            this.btnaddfinger.Click += new System.EventHandler(this.btnaddfinger_Click);
            // 
            // dtpbuydate
            // 
            this.dtpbuydate.Location = new System.Drawing.Point(73, 149);
            this.dtpbuydate.Name = "dtpbuydate";
            this.dtpbuydate.Size = new System.Drawing.Size(102, 21);
            this.dtpbuydate.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "供应商";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "购买时间";
            // 
            // ckaddfinger
            // 
            this.ckaddfinger.AutoSize = true;
            this.ckaddfinger.Location = new System.Drawing.Point(900, 9);
            this.ckaddfinger.Name = "ckaddfinger";
            this.ckaddfinger.Size = new System.Drawing.Size(84, 16);
            this.ckaddfinger.TabIndex = 16;
            this.ckaddfinger.Text = "添加指纹机";
            this.ckaddfinger.UseVisualStyleBackColor = true;
            this.ckaddfinger.CheckedChanged += new System.EventHandler(this.ckaddfinger_CheckedChanged);
            // 
            // gbfingerlist
            // 
            this.gbfingerlist.Controls.Add(this.gbaddringer);
            this.gbfingerlist.Controls.Add(this.dgvfinger);
            this.gbfingerlist.Location = new System.Drawing.Point(7, 29);
            this.gbfingerlist.Name = "gbfingerlist";
            this.gbfingerlist.Size = new System.Drawing.Size(556, 412);
            this.gbfingerlist.TabIndex = 18;
            this.gbfingerlist.TabStop = false;
            // 
            // dgvfinger
            // 
            this.dgvfinger.AllowUserToAddRows = false;
            this.dgvfinger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfinger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvfinger.Location = new System.Drawing.Point(3, 17);
            this.dgvfinger.Name = "dgvfinger";
            this.dgvfinger.RowTemplate.Height = 23;
            this.dgvfinger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvfinger.Size = new System.Drawing.Size(550, 392);
            this.dgvfinger.TabIndex = 0;
            this.dgvfinger.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfinger_CellClick);
            this.dgvfinger.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfinger_CellContentClick);
            this.dgvfinger.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfinger_CellEndEdit);
            this.dgvfinger.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvfinger_RowPostPaint);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(807, 5);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(75, 23);
            this.btnrefresh.TabIndex = 19;
            this.btnrefresh.Text = "刷新";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnonekeydownload
            // 
            this.btnonekeydownload.Location = new System.Drawing.Point(95, 5);
            this.btnonekeydownload.Name = "btnonekeydownload";
            this.btnonekeydownload.Size = new System.Drawing.Size(131, 23);
            this.btnonekeydownload.TabIndex = 20;
            this.btnonekeydownload.Text = "一键下载考勤资料";
            this.btnonekeydownload.UseVisualStyleBackColor = true;
            this.btnonekeydownload.Click += new System.EventHandler(this.btnonekeydownload_Click);
            // 
            // btnselectfp
            // 
            this.btnselectfp.Location = new System.Drawing.Point(13, 5);
            this.btnselectfp.Name = "btnselectfp";
            this.btnselectfp.Size = new System.Drawing.Size(77, 23);
            this.btnselectfp.TabIndex = 21;
            this.btnselectfp.Text = "全选";
            this.btnselectfp.UseVisualStyleBackColor = true;
            this.btnselectfp.Click += new System.EventHandler(this.btnselectfp_Click);
            // 
            // gbkey
            // 
            this.gbkey.Controls.Add(this.lvLogs);
            this.gbkey.Location = new System.Drawing.Point(566, 29);
            this.gbkey.Name = "gbkey";
            this.gbkey.Size = new System.Drawing.Size(434, 208);
            this.gbkey.TabIndex = 75;
            this.gbkey.TabStop = false;
            this.gbkey.Text = "考勤资料";
            // 
            // lvLogs
            // 
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvLogsch0,
            this.lvLogsch1,
            this.lvLogsch2,
            this.lvLogsch3});
            this.lvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLogs.GridLines = true;
            this.lvLogs.Location = new System.Drawing.Point(3, 17);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(428, 188);
            this.lvLogs.TabIndex = 21;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
            this.lvLogs.View = System.Windows.Forms.View.Details;
            this.lvLogs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvLogs_MouseDown);
            // 
            // lvLogsch0
            // 
            this.lvLogsch0.Text = "序号";
            this.lvLogsch0.Width = 40;
            // 
            // lvLogsch1
            // 
            this.lvLogsch1.Text = "用户ID";
            this.lvLogsch1.Width = 100;
            // 
            // lvLogsch2
            // 
            this.lvLogsch2.Text = "Date";
            this.lvLogsch2.Width = 150;
            // 
            // lvLogsch3
            // 
            this.lvLogsch3.Text = "指纹机IP";
            this.lvLogsch3.Width = 150;
            // 
            // labbar
            // 
            this.labbar.Location = new System.Drawing.Point(12, 444);
            this.labbar.Name = "labbar";
            this.labbar.Size = new System.Drawing.Size(716, 20);
            this.labbar.TabIndex = 76;
            this.labbar.Text = "jingdutiao";
            // 
            // jingdutiao
            // 
            this.jingdutiao.Location = new System.Drawing.Point(737, 444);
            this.jingdutiao.Name = "jingdutiao";
            this.jingdutiao.Size = new System.Drawing.Size(259, 20);
            this.jingdutiao.TabIndex = 77;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(569, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 198);
            this.groupBox2.TabIndex = 78;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "下载失败记录";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(422, 178);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // lv1
            // 
            this.lv1.Text = "记录";
            this.lv1.Width = 400;
            // 
            // tomeClearl
            // 
            this.tomeClearl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meclearl});
            this.tomeClearl.Name = "meClearlvLogs";
            this.tomeClearl.Size = new System.Drawing.Size(101, 26);
            // 
            // meclearl
            // 
            this.meclearl.Name = "meclearl";
            this.meclearl.Size = new System.Drawing.Size(100, 22);
            this.meclearl.Text = "清空";
            this.meclearl.Click += new System.EventHandler(this.meclearl_Click);
            // 
            // btuploadtoserver
            // 
            this.btuploadtoserver.Location = new System.Drawing.Point(232, 5);
            this.btuploadtoserver.Name = "btuploadtoserver";
            this.btuploadtoserver.Size = new System.Drawing.Size(127, 23);
            this.btuploadtoserver.TabIndex = 80;
            this.btuploadtoserver.Text = "上传考勤到服务器";
            this.btuploadtoserver.UseVisualStyleBackColor = true;
            this.btuploadtoserver.Click += new System.EventHandler(this.btuploadtoserver_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(433, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "停止下载";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 82;
            this.button1.Text = "上传图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(717, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 83;
            // 
            // cbDisks
            // 
            this.cbDisks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisks.FormattingEnabled = true;
            this.cbDisks.Location = new System.Drawing.Point(552, 8);
            this.cbDisks.Name = "cbDisks";
            this.cbDisks.Size = new System.Drawing.Size(78, 20);
            this.cbDisks.TabIndex = 84;
            this.cbDisks.Visible = false;
            this.cbDisks.SelectedIndexChanged += new System.EventHandler(this.cbDisks_SelectedIndexChanged);
            // 
            // FrmFingerprintManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 469);
            this.Controls.Add(this.cbDisks);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btuploadtoserver);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.jingdutiao);
            this.Controls.Add(this.labbar);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.ckaddfinger);
            this.Controls.Add(this.btnselectfp);
            this.Controls.Add(this.btnonekeydownload);
            this.Controls.Add(this.gbkey);
            this.Controls.Add(this.gbfingerlist);
            this.Name = "FrmFingerprintManager";
            this.Text = "指纹机管理";
            this.Activated += new System.EventHandler(this.FrmFingerprintManager_Activated);
            this.Load += new System.EventHandler(this.FrmFingerprintManager_Load);
            this.SizeChanged += new System.EventHandler(this.FrmFingerprintManager_SizeChanged);
            this.gbaddringer.ResumeLayout(false);
            this.gbaddringer.PerformLayout();
            this.gbfingerlist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvfinger)).EndInit();
            this.gbkey.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tomeClearl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfip;
        private System.Windows.Forms.TextBox txtfport;
        private System.Windows.Forms.TextBox txtfname;
        private System.Windows.Forms.TextBox txtfaddress;
        private System.Windows.Forms.TextBox txtfnote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbaddringer;
        private System.Windows.Forms.DateTimePicker dtpbuydate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnaddfinger;
        private System.Windows.Forms.CheckBox ckaddfinger;
        private System.Windows.Forms.GroupBox gbfingerlist;
        private System.Windows.Forms.DataGridView dgvfinger;
        private System.Windows.Forms.ComboBox cbfdept;
        private System.Windows.Forms.ComboBox cbfhouse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button btnonekeydownload;
        private System.Windows.Forms.Button btnselectfp;
        private System.Windows.Forms.GroupBox gbkey;
        private System.Windows.Forms.ListView lvLogs;
        private System.Windows.Forms.ColumnHeader lvLogsch1;
        private System.Windows.Forms.ColumnHeader lvLogsch2;
        private System.Windows.Forms.ColumnHeader lvLogsch3;
        private System.Windows.Forms.Label labbar;
        private System.Windows.Forms.ProgressBar jingdutiao;
        private System.Windows.Forms.ColumnHeader lvLogsch0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader lv1;
        private System.Windows.Forms.TextBox txtbuyname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbuyfone;
        private System.Windows.Forms.ContextMenuStrip tomeClearl;
        private System.Windows.Forms.ToolStripMenuItem meclearl;
        private System.Windows.Forms.Button btuploadtoserver;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbDisks;
    }
}