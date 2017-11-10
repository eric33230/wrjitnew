namespace WinForm
{
    partial class FrmBarcodeRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBarcode = new System.Windows.Forms.DataGridView();
            this.myInnerBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRgetcb = new System.Windows.Forms.Button();
            this.btnCloses = new System.Windows.Forms.Button();
            this.tscbxCameras = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRgetCom = new System.Windows.Forms.Button();
            this.txtip = new System.Windows.Forms.TextBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lsbDevices = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tb2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.videoSourcePlayer2 = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.lblCarton = new System.Windows.Forms.Label();
            this.lblSize12 = new System.Windows.Forms.Label();
            this.lblCartonNo = new System.Windows.Forms.Label();
            this.lblSize10 = new System.Windows.Forms.Label();
            this.lblSize7 = new System.Windows.Forms.Label();
            this.lblSize6 = new System.Windows.Forms.Label();
            this.lblSize5 = new System.Windows.Forms.Label();
            this.lblSize4 = new System.Windows.Forms.Label();
            this.lblSize3 = new System.Windows.Forms.Label();
            this.lblSize2 = new System.Windows.Forms.Label();
            this.lblSize1 = new System.Windows.Forms.Label();
            this.lblSize9 = new System.Windows.Forms.Label();
            this.lblSize8 = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.lblBOXNO = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblSize11 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbError = new System.Windows.Forms.GroupBox();
            this.btntempsavebox = new System.Windows.Forms.Button();
            this.laberrorbarcode = new System.Windows.Forms.Label();
            this.labinfo = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.cbDisks = new System.Windows.Forms.ComboBox();
            this.btnbackimg = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.jingdutiao = new System.Windows.Forms.ProgressBar();
            this.labbar = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnrescan = new System.Windows.Forms.Button();
            this.msgDiv = new MsgDiv();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbError.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "摄像头2";
            // 
            // dgvBarcode
            // 
            this.dgvBarcode.AllowUserToAddRows = false;
            this.dgvBarcode.AllowUserToDeleteRows = false;
            this.dgvBarcode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBarcode.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvBarcode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvBarcode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBarcode.ColumnHeadersHeight = 25;
            this.dgvBarcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.myInnerBarcode,
            this.myStyle,
            this.myName,
            this.Color,
            this.mySize});
            this.dgvBarcode.Enabled = false;
            this.dgvBarcode.Location = new System.Drawing.Point(0, 3);
            this.dgvBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBarcode.Name = "dgvBarcode";
            this.dgvBarcode.ReadOnly = true;
            this.dgvBarcode.RowHeadersVisible = false;
            this.dgvBarcode.RowHeadersWidth = 20;
            this.dgvBarcode.RowTemplate.Height = 31;
            this.dgvBarcode.Size = new System.Drawing.Size(263, 63);
            this.dgvBarcode.TabIndex = 72;
            // 
            // myInnerBarcode
            // 
            this.myInnerBarcode.DataPropertyName = "InnerBarcode";
            this.myInnerBarcode.HeaderText = "內盒條碼";
            this.myInnerBarcode.Name = "myInnerBarcode";
            this.myInnerBarcode.ReadOnly = true;
            this.myInnerBarcode.Width = 50;
            // 
            // myStyle
            // 
            this.myStyle.DataPropertyName = "Style";
            this.myStyle.HeaderText = "型體";
            this.myStyle.Name = "myStyle";
            this.myStyle.ReadOnly = true;
            this.myStyle.Width = 50;
            // 
            // myName
            // 
            this.myName.DataPropertyName = "Name";
            this.myName.HeaderText = "Style:";
            this.myName.Name = "myName";
            this.myName.ReadOnly = true;
            this.myName.Width = 50;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color:";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 50;
            // 
            // mySize
            // 
            this.mySize.DataPropertyName = "Size";
            this.mySize.HeaderText = "Size";
            this.mySize.Name = "mySize";
            this.mySize.ReadOnly = true;
            this.mySize.Width = 50;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRgetcb);
            this.groupBox2.Controls.Add(this.btnCloses);
            this.groupBox2.Controls.Add(this.tscbxCameras);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.btnTake);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btnRgetCom);
            this.groupBox2.Controls.Add(this.txtip);
            this.groupBox2.Controls.Add(this.cmbComPort);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lsbDevices);
            this.groupBox2.Controls.Add(this.lblMessage);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(573, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 272);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Visible = false;
            // 
            // btnRgetcb
            // 
            this.btnRgetcb.Location = new System.Drawing.Point(201, 20);
            this.btnRgetcb.Name = "btnRgetcb";
            this.btnRgetcb.Size = new System.Drawing.Size(106, 23);
            this.btnRgetcb.TabIndex = 37;
            this.btnRgetcb.Text = "重新获取摄像头";
            this.btnRgetcb.UseVisualStyleBackColor = true;
            this.btnRgetcb.Visible = false;
            this.btnRgetcb.Click += new System.EventHandler(this.btnRgetcb_Click);
            // 
            // btnCloses
            // 
            this.btnCloses.Location = new System.Drawing.Point(131, 47);
            this.btnCloses.Name = "btnCloses";
            this.btnCloses.Size = new System.Drawing.Size(48, 23);
            this.btnCloses.TabIndex = 61;
            this.btnCloses.Text = "关闭";
            this.btnCloses.UseVisualStyleBackColor = true;
            // 
            // tscbxCameras
            // 
            this.tscbxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbxCameras.FormattingEnabled = true;
            this.tscbxCameras.Location = new System.Drawing.Point(23, 20);
            this.tscbxCameras.Name = "tscbxCameras";
            this.tscbxCameras.Size = new System.Drawing.Size(114, 20);
            this.tscbxCameras.TabIndex = 59;
            this.tscbxCameras.SelectedIndexChanged += new System.EventHandler(this.tscbxCameras_SelectedIndexChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(23, 47);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(48, 23);
            this.btnOpen.TabIndex = 60;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(77, 47);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(48, 23);
            this.btnTake.TabIndex = 58;
            this.btnTake.Text = "拍照";
            this.btnTake.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(209, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 57;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(209, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 56;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnRgetCom
            // 
            this.btnRgetCom.Location = new System.Drawing.Point(175, 221);
            this.btnRgetCom.Name = "btnRgetCom";
            this.btnRgetCom.Size = new System.Drawing.Size(75, 23);
            this.btnRgetCom.TabIndex = 79;
            this.btnRgetCom.Text = "刷新扫描枪";
            this.btnRgetCom.UseVisualStyleBackColor = true;
            // 
            // txtip
            // 
            this.txtip.Location = new System.Drawing.Point(105, 181);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(100, 21);
            this.txtip.TabIndex = 55;
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(18, 221);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(112, 20);
            this.cmbComPort.TabIndex = 78;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "设备信息";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(118, 96);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 53;
            this.btnConnect.Text = "配对";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(150, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 52;
            this.label7.Text = "label7";
            // 
            // lsbDevices
            // 
            this.lsbDevices.FormattingEnabled = true;
            this.lsbDevices.Location = new System.Drawing.Point(15, 130);
            this.lsbDevices.Name = "lsbDevices";
            this.lsbDevices.Size = new System.Drawing.Size(121, 20);
            this.lsbDevices.TabIndex = 51;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(33, 153);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(217, 23);
            this.lblMessage.TabIndex = 50;
            this.lblMessage.Text = "label7";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "搜索蓝牙设备";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.SystemColors.Control;
            this.txtPwd.Location = new System.Drawing.Point(0, 591);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(263, 21);
            this.txtPwd.TabIndex = 0;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "摄像头1";
            // 
            // lblNo
            // 
            this.lblNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNo.Font = new System.Drawing.Font("Arial", 70F);
            this.lblNo.Location = new System.Drawing.Point(267, 68);
            this.lblNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(275, 93);
            this.lblNo.TabIndex = 74;
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tb2
            // 
            this.tb2.Enabled = false;
            this.tb2.Location = new System.Drawing.Point(76, 548);
            this.tb2.Margin = new System.Windows.Forms.Padding(2);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(135, 21);
            this.tb2.TabIndex = 52;
            this.tb2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.videoSourcePlayer2);
            this.groupBox1.Location = new System.Drawing.Point(547, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 163);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            // 
            // videoSourcePlayer2
            // 
            this.videoSourcePlayer2.Location = new System.Drawing.Point(228, 24);
            this.videoSourcePlayer2.Name = "videoSourcePlayer2";
            this.videoSourcePlayer2.Size = new System.Drawing.Size(218, 138);
            this.videoSourcePlayer2.TabIndex = 35;
            this.videoSourcePlayer2.Text = "videoSourcePlayer2";
            this.videoSourcePlayer2.VideoSource = null;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(552, 28);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(218, 135);
            this.videoSourcePlayer1.TabIndex = 34;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // tb13
            // 
            this.tb13.Enabled = false;
            this.tb13.Location = new System.Drawing.Point(143, 351);
            this.tb13.Margin = new System.Windows.Forms.Padding(2);
            this.tb13.Multiline = true;
            this.tb13.Name = "tb13";
            this.tb13.ReadOnly = true;
            this.tb13.Size = new System.Drawing.Size(119, 237);
            this.tb13.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(993, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(7, 451);
            this.label4.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(265, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(733, 9);
            this.label3.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(265, 608);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(733, 7);
            this.label2.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(265, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 449);
            this.label1.TabIndex = 68;
            // 
            // lblColor
            // 
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(0, 186);
            this.lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(262, 57);
            this.lblColor.TabIndex = 55;
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStyle
            // 
            this.lblStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStyle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStyle.Location = new System.Drawing.Point(0, 126);
            this.lblStyle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(262, 57);
            this.lblStyle.TabIndex = 54;
            this.lblStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarton
            // 
            this.lblCarton.BackColor = System.Drawing.SystemColors.Control;
            this.lblCarton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCarton.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblCarton.Location = new System.Drawing.Point(0, 68);
            this.lblCarton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarton.Name = "lblCarton";
            this.lblCarton.Size = new System.Drawing.Size(262, 57);
            this.lblCarton.TabIndex = 51;
            this.lblCarton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize12
            // 
            this.lblSize12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize12.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSize12.Location = new System.Drawing.Point(280, 499);
            this.lblSize12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize12.Name = "lblSize12";
            this.lblSize12.Size = new System.Drawing.Size(234, 101);
            this.lblSize12.TabIndex = 67;
            this.lblSize12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCartonNo
            // 
            this.lblCartonNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCartonNo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblCartonNo.Location = new System.Drawing.Point(0, 247);
            this.lblCartonNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCartonNo.Name = "lblCartonNo";
            this.lblCartonNo.Size = new System.Drawing.Size(262, 57);
            this.lblCartonNo.TabIndex = 53;
            this.lblCartonNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize10
            // 
            this.lblSize10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize10.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize10.Location = new System.Drawing.Point(280, 285);
            this.lblSize10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize10.Name = "lblSize10";
            this.lblSize10.Size = new System.Drawing.Size(234, 101);
            this.lblSize10.TabIndex = 65;
            this.lblSize10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize7
            // 
            this.lblSize7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize7.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize7.Location = new System.Drawing.Point(517, 392);
            this.lblSize7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize7.Name = "lblSize7";
            this.lblSize7.Size = new System.Drawing.Size(234, 101);
            this.lblSize7.TabIndex = 62;
            this.lblSize7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize6
            // 
            this.lblSize6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize6.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize6.Location = new System.Drawing.Point(517, 285);
            this.lblSize6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize6.Name = "lblSize6";
            this.lblSize6.Size = new System.Drawing.Size(234, 101);
            this.lblSize6.TabIndex = 61;
            this.lblSize6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize5
            // 
            this.lblSize5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize5.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize5.Location = new System.Drawing.Point(517, 179);
            this.lblSize5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize5.Name = "lblSize5";
            this.lblSize5.Size = new System.Drawing.Size(234, 101);
            this.lblSize5.TabIndex = 60;
            this.lblSize5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize4
            // 
            this.lblSize4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize4.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize4.Location = new System.Drawing.Point(753, 499);
            this.lblSize4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize4.Name = "lblSize4";
            this.lblSize4.Size = new System.Drawing.Size(234, 101);
            this.lblSize4.TabIndex = 59;
            this.lblSize4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize3
            // 
            this.lblSize3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize3.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize3.Location = new System.Drawing.Point(753, 392);
            this.lblSize3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize3.Name = "lblSize3";
            this.lblSize3.Size = new System.Drawing.Size(234, 101);
            this.lblSize3.TabIndex = 58;
            this.lblSize3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize2
            // 
            this.lblSize2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize2.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize2.Location = new System.Drawing.Point(753, 285);
            this.lblSize2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize2.Name = "lblSize2";
            this.lblSize2.Size = new System.Drawing.Size(234, 101);
            this.lblSize2.TabIndex = 57;
            this.lblSize2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize1
            // 
            this.lblSize1.BackColor = System.Drawing.SystemColors.Control;
            this.lblSize1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize1.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize1.Location = new System.Drawing.Point(753, 179);
            this.lblSize1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize1.Name = "lblSize1";
            this.lblSize1.Size = new System.Drawing.Size(234, 101);
            this.lblSize1.TabIndex = 56;
            this.lblSize1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize9
            // 
            this.lblSize9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize9.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize9.Location = new System.Drawing.Point(280, 179);
            this.lblSize9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize9.Name = "lblSize9";
            this.lblSize9.Size = new System.Drawing.Size(234, 101);
            this.lblSize9.TabIndex = 64;
            this.lblSize9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize8
            // 
            this.lblSize8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize8.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSize8.Location = new System.Drawing.Point(517, 499);
            this.lblSize8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize8.Name = "lblSize8";
            this.lblSize8.Size = new System.Drawing.Size(234, 101);
            this.lblSize8.TabIndex = 63;
            this.lblSize8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSize
            // 
            this.tbSize.Enabled = false;
            this.tbSize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSize.Location = new System.Drawing.Point(0, 305);
            this.tbSize.Margin = new System.Windows.Forms.Padding(2);
            this.tbSize.Multiline = true;
            this.tbSize.Name = "tbSize";
            this.tbSize.ReadOnly = true;
            this.tbSize.Size = new System.Drawing.Size(141, 283);
            this.tbSize.TabIndex = 86;
            // 
            // lblBOXNO
            // 
            this.lblBOXNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBOXNO.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOXNO.Location = new System.Drawing.Point(143, 305);
            this.lblBOXNO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBOXNO.Name = "lblBOXNO";
            this.lblBOXNO.Size = new System.Drawing.Size(119, 44);
            this.lblBOXNO.TabIndex = 88;
            this.lblBOXNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "JAPEN SCAN",
            "Record SCAN"});
            this.comboBox1.Location = new System.Drawing.Point(363, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 20);
            this.comboBox1.TabIndex = 80;
            this.comboBox1.Tag = "";
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblSize11
            // 
            this.lblSize11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize11.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize11.Location = new System.Drawing.Point(280, 392);
            this.lblSize11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize11.Name = "lblSize11";
            this.lblSize11.Size = new System.Drawing.Size(234, 101);
            this.lblSize11.TabIndex = 66;
            this.lblSize11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbError
            // 
            this.gbError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbError.AutoSize = true;
            this.gbError.BackColor = System.Drawing.Color.OrangeRed;
            this.gbError.Controls.Add(this.btntempsavebox);
            this.gbError.Controls.Add(this.laberrorbarcode);
            this.gbError.Controls.Add(this.labinfo);
            this.gbError.Controls.Add(this.txtError);
            this.gbError.Controls.Add(this.label8);
            this.gbError.Location = new System.Drawing.Point(345, 197);
            this.gbError.Name = "gbError";
            this.gbError.Size = new System.Drawing.Size(447, 188);
            this.gbError.TabIndex = 89;
            this.gbError.TabStop = false;
            this.gbError.Text = "條碼錯誤";
            this.gbError.Visible = false;
            // 
            // btntempsavebox
            // 
            this.btntempsavebox.BackColor = System.Drawing.Color.OrangeRed;
            this.btntempsavebox.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btntempsavebox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btntempsavebox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btntempsavebox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntempsavebox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntempsavebox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btntempsavebox.Location = new System.Drawing.Point(333, 17);
            this.btntempsavebox.Margin = new System.Windows.Forms.Padding(0);
            this.btntempsavebox.Name = "btntempsavebox";
            this.btntempsavebox.Size = new System.Drawing.Size(100, 31);
            this.btntempsavebox.TabIndex = 9;
            this.btntempsavebox.Text = "暂存此箱";
            this.btntempsavebox.UseVisualStyleBackColor = false;
            this.btntempsavebox.Click += new System.EventHandler(this.btntempsavebox_Click);
            // 
            // laberrorbarcode
            // 
            this.laberrorbarcode.AutoSize = true;
            this.laberrorbarcode.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.laberrorbarcode.ForeColor = System.Drawing.Color.Yellow;
            this.laberrorbarcode.Location = new System.Drawing.Point(137, 27);
            this.laberrorbarcode.Name = "laberrorbarcode";
            this.laberrorbarcode.Size = new System.Drawing.Size(0, 19);
            this.laberrorbarcode.TabIndex = 7;
            // 
            // labinfo
            // 
            this.labinfo.AutoSize = true;
            this.labinfo.Font = new System.Drawing.Font("宋体", 21F, System.Drawing.FontStyle.Bold);
            this.labinfo.ForeColor = System.Drawing.Color.Black;
            this.labinfo.Location = new System.Drawing.Point(32, 88);
            this.labinfo.Name = "labinfo";
            this.labinfo.Size = new System.Drawing.Size(375, 28);
            this.labinfo.TabIndex = 6;
            this.labinfo.Text = "请先找出错误的内盒,再解锁";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(107, 140);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(220, 21);
            this.txtError.TabIndex = 1;
            this.txtError.TextChanged += new System.EventHandler(this.txtError_TextChanged);
            this.txtError.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtError_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(33, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "错误内盒：";
            // 
            // cbDisks
            // 
            this.cbDisks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisks.FormattingEnabled = true;
            this.cbDisks.Location = new System.Drawing.Point(330, 5);
            this.cbDisks.Name = "cbDisks";
            this.cbDisks.Size = new System.Drawing.Size(116, 20);
            this.cbDisks.TabIndex = 90;
            this.cbDisks.SelectedIndexChanged += new System.EventHandler(this.cbDisks_SelectedIndexChanged);
            // 
            // btnbackimg
            // 
            this.btnbackimg.Location = new System.Drawing.Point(456, 4);
            this.btnbackimg.Name = "btnbackimg";
            this.btnbackimg.Size = new System.Drawing.Size(86, 23);
            this.btnbackimg.TabIndex = 91;
            this.btnbackimg.Text = "备份照片";
            this.btnbackimg.UseVisualStyleBackColor = true;
            this.btnbackimg.Click += new System.EventHandler(this.btnbackimg_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 92;
            this.label10.Text = "备份盘符:";
            // 
            // jingdutiao
            // 
            this.jingdutiao.Location = new System.Drawing.Point(294, 31);
            this.jingdutiao.Name = "jingdutiao";
            this.jingdutiao.Size = new System.Drawing.Size(152, 13);
            this.jingdutiao.TabIndex = 94;
            // 
            // labbar
            // 
            this.labbar.AutoSize = true;
            this.labbar.Location = new System.Drawing.Point(268, 50);
            this.labbar.Name = "labbar";
            this.labbar.Size = new System.Drawing.Size(59, 12);
            this.labbar.TabIndex = 95;
            this.labbar.Text = "正在上传:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 93;
            this.label11.Text = "0/0";
            // 
            // btnrescan
            // 
            this.btnrescan.Location = new System.Drawing.Point(456, 28);
            this.btnrescan.Name = "btnrescan";
            this.btnrescan.Size = new System.Drawing.Size(86, 37);
            this.btnrescan.TabIndex = 96;
            this.btnrescan.Text = "重验箱扫描";
            this.btnrescan.UseVisualStyleBackColor = true;
            this.btnrescan.Click += new System.EventHandler(this.btnrescan_Click);
            // 
            // msgDiv
            // 
            this.msgDiv.AutoSize = true;
            this.msgDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.msgDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgDiv.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgDiv.ForeColor = System.Drawing.Color.Red;
            this.msgDiv.Location = new System.Drawing.Point(12, 556);
            this.msgDiv.MaximumSize = new System.Drawing.Size(980, 525);
            this.msgDiv.Name = "msgDiv";
            this.msgDiv.Padding = new System.Windows.Forms.Padding(7);
            this.msgDiv.Size = new System.Drawing.Size(86, 31);
            this.msgDiv.TabIndex = 75;
            this.msgDiv.Text = "msgDiv1";
            this.msgDiv.Visible = false;
            // 
            // FrmBarcodeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 623);
            this.Controls.Add(this.msgDiv);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.gbError);
            this.Controls.Add(this.btnrescan);
            this.Controls.Add(this.labbar);
            this.Controls.Add(this.jingdutiao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnbackimg);
            this.Controls.Add(this.cbDisks);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblBOXNO);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.dgvBarcode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.lblCarton);
            this.Controls.Add(this.lblSize12);
            this.Controls.Add(this.lblCartonNo);
            this.Controls.Add(this.lblSize11);
            this.Controls.Add(this.lblSize10);
            this.Controls.Add(this.lblSize7);
            this.Controls.Add(this.lblSize6);
            this.Controls.Add(this.lblSize5);
            this.Controls.Add(this.lblSize4);
            this.Controls.Add(this.lblSize3);
            this.Controls.Add(this.lblSize2);
            this.Controls.Add(this.lblSize1);
            this.Controls.Add(this.lblSize9);
            this.Controls.Add(this.lblSize8);
            this.Controls.Add(this.tbSize);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmBarcodeRecord";
            this.Text = "QA内盒外箱检验";
            this.Activated += new System.EventHandler(this.FrmBarcodeRecord_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBarcodeRecord_FormClosing);
            this.Load += new System.EventHandler(this.FrmBarcodeRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbError.ResumeLayout(false);
            this.gbError.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBarcode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCloses;
        private System.Windows.Forms.ComboBox tscbxCameras;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtip;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox lsbDevices;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPwd;
        private MsgDiv msgDiv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNo;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRgetcb;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer2;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.TextBox tb13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Label lblCarton;
        private System.Windows.Forms.Label lblSize12;
        private System.Windows.Forms.Label lblCartonNo;
        private System.Windows.Forms.Label lblSize10;
        private System.Windows.Forms.Label lblSize7;
        private System.Windows.Forms.Label lblSize6;
        private System.Windows.Forms.Label lblSize5;
        private System.Windows.Forms.Label lblSize4;
        private System.Windows.Forms.Label lblSize3;
        private System.Windows.Forms.Label lblSize2;
        private System.Windows.Forms.Label lblSize1;
        private System.Windows.Forms.Label lblSize9;
        private System.Windows.Forms.Label lblSize8;
        private System.Windows.Forms.Button btnRgetCom;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label lblBOXNO;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblSize11;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbError;
        private System.Windows.Forms.TextBox txtError;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ComboBox cbDisks;
        private System.Windows.Forms.Button btnbackimg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar jingdutiao;
        private System.Windows.Forms.Label labbar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn myInnerBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn myStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn myName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn mySize;
        private System.Windows.Forms.Button btnrescan;
        private System.Windows.Forms.Label labinfo;
        private System.Windows.Forms.Label laberrorbarcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btntempsavebox;
    }
}