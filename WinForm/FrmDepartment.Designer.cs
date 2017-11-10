namespace WinForm
{
    partial class FrmDepartment
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
            this.tvList = new System.Windows.Forms.TreeView();
            this.txtAID = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtEMPName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAIDTOP = new System.Windows.Forms.TextBox();
            this.txtUnitTOP = new System.Windows.Forms.TextBox();
            this.txtAPid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbDept = new System.Windows.Forms.CheckBox();
            this.txtEMPNameTOP = new System.Windows.Forms.TextBox();
            this.txtDeptID = new System.Windows.Forms.TextBox();
            this.txtUnitNameTOP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.lbEnrollNo = new System.Windows.Forms.Label();
            this.txtEnrollNo = new System.Windows.Forms.TextBox();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.AID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnrollNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accountno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProvinceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Education = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkBook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPermanent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsResign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResignType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResignReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResignDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test = new System.Windows.Forms.TextBox();
            this.ctmsEmployee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.COPYCELL = new System.Windows.Forms.ToolStripMenuItem();
            this.TOEXCEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comsheetname = new System.Windows.Forms.ComboBox();
            this.btnInterBoxImpro = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.ctmsEmployee.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.AllowDrop = true;
            this.tvList.Location = new System.Drawing.Point(9, 25);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(403, 579);
            this.tvList.TabIndex = 1;
            this.tvList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvList_ItemDrag);
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            this.tvList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvList_NodeMouseDoubleClick);
            this.tvList.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvList_DragDrop);
            this.tvList.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvList_DragEnter);
            // 
            // txtAID
            // 
            this.txtAID.Location = new System.Drawing.Point(495, 23);
            this.txtAID.Margin = new System.Windows.Forms.Padding(2);
            this.txtAID.Name = "txtAID";
            this.txtAID.ReadOnly = true;
            this.txtAID.Size = new System.Drawing.Size(121, 21);
            this.txtAID.TabIndex = 2;
            this.txtAID.TextChanged += new System.EventHandler(this.txtAID_TextChanged);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(495, 90);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(121, 21);
            this.txtUnit.TabIndex = 3;
            this.txtUnit.Text = "企劃";
            // 
            // txtEMPName
            // 
            this.txtEMPName.Location = new System.Drawing.Point(495, 147);
            this.txtEMPName.Margin = new System.Windows.Forms.Padding(2);
            this.txtEMPName.Name = "txtEMPName";
            this.txtEMPName.Size = new System.Drawing.Size(121, 21);
            this.txtEMPName.TabIndex = 4;
            this.txtEMPName.Text = "如中";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(435, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "部門";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(435, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "主管";
            // 
            // txtAIDTOP
            // 
            this.txtAIDTOP.Location = new System.Drawing.Point(618, 23);
            this.txtAIDTOP.Margin = new System.Windows.Forms.Padding(2);
            this.txtAIDTOP.Name = "txtAIDTOP";
            this.txtAIDTOP.ReadOnly = true;
            this.txtAIDTOP.Size = new System.Drawing.Size(121, 21);
            this.txtAIDTOP.TabIndex = 8;
            // 
            // txtUnitTOP
            // 
            this.txtUnitTOP.Location = new System.Drawing.Point(618, 90);
            this.txtUnitTOP.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitTOP.Name = "txtUnitTOP";
            this.txtUnitTOP.ReadOnly = true;
            this.txtUnitTOP.Size = new System.Drawing.Size(121, 21);
            this.txtUnitTOP.TabIndex = 9;
            this.txtUnitTOP.Text = "專案";
            // 
            // txtAPid
            // 
            this.txtAPid.Location = new System.Drawing.Point(495, 185);
            this.txtAPid.Margin = new System.Windows.Forms.Padding(2);
            this.txtAPid.Name = "txtAPid";
            this.txtAPid.ReadOnly = true;
            this.txtAPid.Size = new System.Drawing.Size(121, 21);
            this.txtAPid.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "轉換部門TransDept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbDept
            // 
            this.cbDept.AutoSize = true;
            this.cbDept.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDept.Location = new System.Drawing.Point(618, 59);
            this.cbDept.Margin = new System.Windows.Forms.Padding(2);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(115, 20);
            this.cbDept.TabIndex = 12;
            this.cbDept.Text = "上層NewDept";
            this.cbDept.UseVisualStyleBackColor = true;
            // 
            // txtEMPNameTOP
            // 
            this.txtEMPNameTOP.Location = new System.Drawing.Point(618, 147);
            this.txtEMPNameTOP.Margin = new System.Windows.Forms.Padding(2);
            this.txtEMPNameTOP.Name = "txtEMPNameTOP";
            this.txtEMPNameTOP.ReadOnly = true;
            this.txtEMPNameTOP.Size = new System.Drawing.Size(121, 21);
            this.txtEMPNameTOP.TabIndex = 13;
            this.txtEMPNameTOP.Text = "專案";
            // 
            // txtDeptID
            // 
            this.txtDeptID.Location = new System.Drawing.Point(495, 59);
            this.txtDeptID.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.ReadOnly = true;
            this.txtDeptID.Size = new System.Drawing.Size(121, 21);
            this.txtDeptID.TabIndex = 14;
            // 
            // txtUnitNameTOP
            // 
            this.txtUnitNameTOP.Location = new System.Drawing.Point(618, 113);
            this.txtUnitNameTOP.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitNameTOP.Name = "txtUnitNameTOP";
            this.txtUnitNameTOP.ReadOnly = true;
            this.txtUnitNameTOP.Size = new System.Drawing.Size(121, 21);
            this.txtUnitNameTOP.TabIndex = 17;
            this.txtUnitNameTOP.Text = "專案";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(435, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 16;
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(495, 113);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(121, 21);
            this.txtUnitName.TabIndex = 15;
            this.txtUnitName.Text = "企劃";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(435, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "備註";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(435, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "AID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(435, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "DeptID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(435, 188);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "APid";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(520, 317);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "1x-穎強";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(526, 336);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "4-處級";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(526, 357);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "5-部級";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(526, 379);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "6-課級";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(526, 401);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "7-組級";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(531, 424);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = ".1-生產";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(531, 443);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = ".2-品管";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(531, 464);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = ".3-生控";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(531, 485);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = ".4-總務";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(531, 503);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 31;
            this.label17.Text = ".5-專案";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(531, 522);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 12);
            this.label18.TabIndex = 32;
            this.label18.Text = ".6-技轉";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(531, 541);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 33;
            this.label19.Text = ".7-報關";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(531, 563);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 34;
            this.label20.Text = ".8-財務";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(495, 220);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 31);
            this.button2.TabIndex = 35;
            this.button2.Text = "更新部門UpdateDept";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(25, 23);
            this.btnEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(119, 31);
            this.btnEmployee.TabIndex = 36;
            this.btnEmployee.Text = "人事轉換";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // lbEnrollNo
            // 
            this.lbEnrollNo.AutoSize = true;
            this.lbEnrollNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEnrollNo.Location = new System.Drawing.Point(23, 67);
            this.lbEnrollNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEnrollNo.Name = "lbEnrollNo";
            this.lbEnrollNo.Size = new System.Drawing.Size(72, 16);
            this.lbEnrollNo.TabIndex = 38;
            this.lbEnrollNo.Text = "EnrollNo";
            // 
            // txtEnrollNo
            // 
            this.txtEnrollNo.Location = new System.Drawing.Point(98, 65);
            this.txtEnrollNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtEnrollNo.Name = "txtEnrollNo";
            this.txtEnrollNo.Size = new System.Drawing.Size(121, 21);
            this.txtEnrollNo.TabIndex = 37;
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AID,
            this.DeptID,
            this.EnrollNo,
            this.EmpID,
            this.KhName,
            this.Accountno,
            this.NationalID,
            this.JobID,
            this.ProvinceID,
            this.ShiftID,
            this.CallName,
            this.Gender,
            this.Status,
            this.PersonalID,
            this.NSSF,
            this.Education,
            this.WorkBook,
            this.CardNo,
            this.Address,
            this.IsPermanent,
            this.IsContract,
            this.IsResign,
            this.ResignType,
            this.ResignReason,
            this.ResignDate,
            this.BirthDate,
            this.CreateDate,
            this.Union1,
            this.Union2,
            this.Union3,
            this.Union4,
            this.Union5,
            this.Union6,
            this.Union7,
            this.Union8,
            this.Union9,
            this.Union10,
            this.Union11,
            this.Union12});
            this.dgvEmployee.Location = new System.Drawing.Point(38, 136);
            this.dgvEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowTemplate.Height = 30;
            this.dgvEmployee.Size = new System.Drawing.Size(427, 439);
            this.dgvEmployee.TabIndex = 39;
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            this.dgvEmployee.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployee_CellMouseDown);
            // 
            // AID
            // 
            this.AID.DataPropertyName = "AID";
            this.AID.HeaderText = "AID";
            this.AID.Name = "AID";
            // 
            // DeptID
            // 
            this.DeptID.DataPropertyName = "DeptID";
            this.DeptID.HeaderText = "DeptID";
            this.DeptID.Name = "DeptID";
            // 
            // EnrollNo
            // 
            this.EnrollNo.DataPropertyName = "EnrollNo";
            this.EnrollNo.HeaderText = "EnrollNo";
            this.EnrollNo.Name = "EnrollNo";
            // 
            // EmpID
            // 
            this.EmpID.DataPropertyName = "EmpID";
            this.EmpID.HeaderText = "EmpID";
            this.EmpID.Name = "EmpID";
            // 
            // KhName
            // 
            this.KhName.DataPropertyName = "KhName";
            this.KhName.HeaderText = "KhName";
            this.KhName.Name = "KhName";
            // 
            // Accountno
            // 
            this.Accountno.DataPropertyName = "Accountno";
            this.Accountno.HeaderText = "Accountno";
            this.Accountno.Name = "Accountno";
            // 
            // NationalID
            // 
            this.NationalID.DataPropertyName = "NationalID";
            this.NationalID.HeaderText = "NationalID";
            this.NationalID.Name = "NationalID";
            // 
            // JobID
            // 
            this.JobID.DataPropertyName = "JobID";
            this.JobID.HeaderText = "JobID";
            this.JobID.Name = "JobID";
            // 
            // ProvinceID
            // 
            this.ProvinceID.DataPropertyName = "ProvinceID";
            this.ProvinceID.HeaderText = "ProvinceID";
            this.ProvinceID.Name = "ProvinceID";
            // 
            // ShiftID
            // 
            this.ShiftID.DataPropertyName = "ShiftID";
            this.ShiftID.HeaderText = "ShiftID";
            this.ShiftID.Name = "ShiftID";
            // 
            // CallName
            // 
            this.CallName.DataPropertyName = "CallName";
            this.CallName.HeaderText = "CallName";
            this.CallName.Name = "CallName";
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // PersonalID
            // 
            this.PersonalID.DataPropertyName = "PersonalID";
            this.PersonalID.HeaderText = "PersonalID";
            this.PersonalID.Name = "PersonalID";
            // 
            // NSSF
            // 
            this.NSSF.DataPropertyName = "NSSF";
            this.NSSF.HeaderText = "NSSF";
            this.NSSF.Name = "NSSF";
            // 
            // Education
            // 
            this.Education.DataPropertyName = "Education";
            this.Education.HeaderText = "Education";
            this.Education.Name = "Education";
            // 
            // WorkBook
            // 
            this.WorkBook.DataPropertyName = "WorkBook";
            this.WorkBook.HeaderText = "WorkBook";
            this.WorkBook.Name = "WorkBook";
            // 
            // CardNo
            // 
            this.CardNo.DataPropertyName = "CardNo";
            this.CardNo.HeaderText = "CardNo";
            this.CardNo.Name = "CardNo";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // IsPermanent
            // 
            this.IsPermanent.DataPropertyName = "IsPermanent";
            this.IsPermanent.HeaderText = "IsPermanent";
            this.IsPermanent.Name = "IsPermanent";
            // 
            // IsContract
            // 
            this.IsContract.DataPropertyName = "IsContract";
            this.IsContract.HeaderText = "IsContract";
            this.IsContract.Name = "IsContract";
            // 
            // IsResign
            // 
            this.IsResign.DataPropertyName = "IsResign";
            this.IsResign.HeaderText = "IsResign";
            this.IsResign.Name = "IsResign";
            // 
            // ResignType
            // 
            this.ResignType.DataPropertyName = "ResignType";
            this.ResignType.HeaderText = "ResignType";
            this.ResignType.Name = "ResignType";
            // 
            // ResignReason
            // 
            this.ResignReason.DataPropertyName = "ResignReason";
            this.ResignReason.HeaderText = "ResignReason";
            this.ResignReason.Name = "ResignReason";
            // 
            // ResignDate
            // 
            this.ResignDate.DataPropertyName = "ResignDate";
            this.ResignDate.HeaderText = "ResignDate";
            this.ResignDate.Name = "ResignDate";
            // 
            // BirthDate
            // 
            this.BirthDate.DataPropertyName = "BirthDate";
            this.BirthDate.HeaderText = "BirthDate";
            this.BirthDate.Name = "BirthDate";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "CreateDate";
            this.CreateDate.Name = "CreateDate";
            // 
            // Union1
            // 
            this.Union1.DataPropertyName = "Union1";
            this.Union1.HeaderText = "Union1";
            this.Union1.Name = "Union1";
            // 
            // Union2
            // 
            this.Union2.DataPropertyName = "Union2";
            this.Union2.HeaderText = "Union2";
            this.Union2.Name = "Union2";
            // 
            // Union3
            // 
            this.Union3.DataPropertyName = "Union3";
            this.Union3.HeaderText = "Union3";
            this.Union3.Name = "Union3";
            // 
            // Union4
            // 
            this.Union4.DataPropertyName = "Union4";
            this.Union4.HeaderText = "Union4";
            this.Union4.Name = "Union4";
            // 
            // Union5
            // 
            this.Union5.DataPropertyName = "Union5";
            this.Union5.HeaderText = "Union5";
            this.Union5.Name = "Union5";
            // 
            // Union6
            // 
            this.Union6.DataPropertyName = "Union6";
            this.Union6.HeaderText = "Union6";
            this.Union6.Name = "Union6";
            // 
            // Union7
            // 
            this.Union7.DataPropertyName = "Union7";
            this.Union7.HeaderText = "Union7";
            this.Union7.Name = "Union7";
            // 
            // Union8
            // 
            this.Union8.DataPropertyName = "Union8";
            this.Union8.HeaderText = "Union8";
            this.Union8.Name = "Union8";
            // 
            // Union9
            // 
            this.Union9.DataPropertyName = "Union9";
            this.Union9.HeaderText = "Union9";
            this.Union9.Name = "Union9";
            // 
            // Union10
            // 
            this.Union10.DataPropertyName = "Union10";
            this.Union10.HeaderText = "Union10";
            this.Union10.Name = "Union10";
            // 
            // Union11
            // 
            this.Union11.DataPropertyName = "Union11";
            this.Union11.HeaderText = "Union11";
            this.Union11.Name = "Union11";
            // 
            // Union12
            // 
            this.Union12.DataPropertyName = "Union12";
            this.Union12.HeaderText = "Union12";
            this.Union12.Name = "Union12";
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(267, 39);
            this.test.Margin = new System.Windows.Forms.Padding(2);
            this.test.Multiline = true;
            this.test.Name = "test";
            this.test.ReadOnly = true;
            this.test.Size = new System.Drawing.Size(154, 45);
            this.test.TabIndex = 44;
            // 
            // ctmsEmployee
            // 
            this.ctmsEmployee.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmsEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COPYCELL,
            this.TOEXCEL});
            this.ctmsEmployee.Name = "ctmsOrder";
            this.ctmsEmployee.Size = new System.Drawing.Size(161, 48);
            this.ctmsEmployee.Opening += new System.ComponentModel.CancelEventHandler(this.ctmsShipScan_Opening);
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
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(398, 101);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(75, 30);
            this.btnLoadExcel.TabIndex = 45;
            this.btnLoadExcel.Text = "加载EXCEL";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(98, 113);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.ReadOnly = true;
            this.txtfilename.Size = new System.Drawing.Size(161, 21);
            this.txtfilename.TabIndex = 49;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(286, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 12);
            this.label21.TabIndex = 48;
            this.label21.Text = "请选择工作表:";
            // 
            // comsheetname
            // 
            this.comsheetname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comsheetname.FormattingEnabled = true;
            this.comsheetname.Location = new System.Drawing.Point(274, 114);
            this.comsheetname.Name = "comsheetname";
            this.comsheetname.Size = new System.Drawing.Size(120, 20);
            this.comsheetname.TabIndex = 47;
            // 
            // btnInterBoxImpro
            // 
            this.btnInterBoxImpro.Location = new System.Drawing.Point(98, 89);
            this.btnInterBoxImpro.Name = "btnInterBoxImpro";
            this.btnInterBoxImpro.Size = new System.Drawing.Size(75, 23);
            this.btnInterBoxImpro.TabIndex = 46;
            this.btnInterBoxImpro.Text = "浏览";
            this.btnInterBoxImpro.UseVisualStyleBackColor = true;
            this.btnInterBoxImpro.Click += new System.EventHandler(this.btnInterBoxImpro_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnEmployee);
            this.gb1.Controls.Add(this.dgvEmployee);
            this.gb1.Controls.Add(this.txtfilename);
            this.gb1.Controls.Add(this.txtEnrollNo);
            this.gb1.Controls.Add(this.label21);
            this.gb1.Controls.Add(this.lbEnrollNo);
            this.gb1.Controls.Add(this.comsheetname);
            this.gb1.Controls.Add(this.test);
            this.gb1.Controls.Add(this.btnInterBoxImpro);
            this.gb1.Controls.Add(this.btnLoadExcel);
            this.gb1.Location = new System.Drawing.Point(760, 28);
            this.gb1.Margin = new System.Windows.Forms.Padding(2);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(2);
            this.gb1.Size = new System.Drawing.Size(483, 606);
            this.gb1.TabIndex = 124;
            this.gb1.TabStop = false;
            this.gb1.Text = "人事轉換";
            // 
            // FrmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 500);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUnitNameTOP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUnitName);
            this.Controls.Add(this.txtDeptID);
            this.Controls.Add(this.txtEMPNameTOP);
            this.Controls.Add(this.cbDept);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAPid);
            this.Controls.Add(this.txtUnitTOP);
            this.Controls.Add(this.txtAIDTOP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEMPName);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtAID);
            this.Controls.Add(this.tvList);
            this.Controls.Add(this.gb1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDepartment";
            this.Text = "部门组织";
            this.Activated += new System.EventHandler(this.FrmDepartment_Activated);
            this.Load += new System.EventHandler(this.FrmDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ctmsEmployee.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.TextBox txtAID;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtEMPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAIDTOP;
        private System.Windows.Forms.TextBox txtUnitTOP;
        private System.Windows.Forms.TextBox txtAPid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbDept;
        private System.Windows.Forms.TextBox txtEMPNameTOP;
        private System.Windows.Forms.TextBox txtDeptID;
        private System.Windows.Forms.TextBox txtUnitNameTOP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Label lbEnrollNo;
        private System.Windows.Forms.TextBox txtEnrollNo;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.TextBox test;
        private System.Windows.Forms.ContextMenuStrip ctmsEmployee;
        private System.Windows.Forms.ToolStripMenuItem COPYCELL;
        private System.Windows.Forms.ToolStripMenuItem TOEXCEL;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comsheetname;
        private System.Windows.Forms.Button btnInterBoxImpro;
        private System.Windows.Forms.DataGridViewTextBoxColumn AID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnrollNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accountno;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvinceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Education;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPermanent;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsResign;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResignType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResignReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResignDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union12;
        private System.Windows.Forms.GroupBox gb1;
    }
}