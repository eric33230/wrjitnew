namespace WinForm
{
    partial class FrmPADInnerBox
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
            this.butupdatadblocal = new System.Windows.Forms.Button();
            this.labstylecode = new System.Windows.Forms.Label();
            this.labcolor = new System.Windows.Forms.Label();
            this.labtype = new System.Windows.Forms.Label();
            this.btnreadlocaldb = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.labguid = new System.Windows.Forms.Label();
            this.labname = new System.Windows.Forms.Label();
            this.labstyle = new System.Windows.Forms.Label();
            this.labsize = new System.Windows.Forms.Label();
            this.labCustomName = new System.Windows.Forms.Label();
            this.labnewcode = new System.Windows.Forms.Label();
            this.btnbarcodeprint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCreateBarCode = new System.Windows.Forms.Button();
            this.btnCreateQuickMark = new System.Windows.Forms.Button();
            this.btnBarcodeReader = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEdit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // butupdatadblocal
            // 
            this.butupdatadblocal.Location = new System.Drawing.Point(12, 12);
            this.butupdatadblocal.Name = "butupdatadblocal";
            this.butupdatadblocal.Size = new System.Drawing.Size(143, 69);
            this.butupdatadblocal.TabIndex = 0;
            this.butupdatadblocal.Text = "同步本地库资料";
            this.butupdatadblocal.UseVisualStyleBackColor = true;
            this.butupdatadblocal.Click += new System.EventHandler(this.butupdatadblocal_Click);
            // 
            // labstylecode
            // 
            this.labstylecode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labstylecode.Font = new System.Drawing.Font("宋体", 40F);
            this.labstylecode.Location = new System.Drawing.Point(176, 187);
            this.labstylecode.Name = "labstylecode";
            this.labstylecode.Size = new System.Drawing.Size(449, 70);
            this.labstylecode.TabIndex = 2;
            this.labstylecode.Text = "style.code";
            // 
            // labcolor
            // 
            this.labcolor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labcolor.Font = new System.Drawing.Font("宋体", 40F);
            this.labcolor.Location = new System.Drawing.Point(176, 363);
            this.labcolor.Name = "labcolor";
            this.labcolor.Size = new System.Drawing.Size(267, 70);
            this.labcolor.TabIndex = 3;
            this.labcolor.Text = "color";
            // 
            // labtype
            // 
            this.labtype.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labtype.Font = new System.Drawing.Font("宋体", 40F);
            this.labtype.Location = new System.Drawing.Point(737, 363);
            this.labtype.Name = "labtype";
            this.labtype.Size = new System.Drawing.Size(259, 70);
            this.labtype.TabIndex = 4;
            this.labtype.Text = "type";
            // 
            // btnreadlocaldb
            // 
            this.btnreadlocaldb.Location = new System.Drawing.Point(12, 103);
            this.btnreadlocaldb.Name = "btnreadlocaldb";
            this.btnreadlocaldb.Size = new System.Drawing.Size(143, 76);
            this.btnreadlocaldb.TabIndex = 5;
            this.btnreadlocaldb.Text = "查看本地数据";
            this.btnreadlocaldb.UseVisualStyleBackColor = true;
            this.btnreadlocaldb.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 80);
            this.button1.TabIndex = 6;
            this.button1.Text = "创建表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // txtbarcode
            // 
            this.txtbarcode.Font = new System.Drawing.Font("宋体", 45F);
            this.txtbarcode.Location = new System.Drawing.Point(176, 13);
            this.txtbarcode.Multiline = true;
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(810, 68);
            this.txtbarcode.TabIndex = 0;
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            this.txtbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbarcode_KeyDown);
            // 
            // labguid
            // 
            this.labguid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labguid.Font = new System.Drawing.Font("宋体", 30F);
            this.labguid.Location = new System.Drawing.Point(176, 99);
            this.labguid.Name = "labguid";
            this.labguid.Size = new System.Drawing.Size(805, 70);
            this.labguid.TabIndex = 7;
            this.labguid.Text = "GUID";
            // 
            // labname
            // 
            this.labname.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labname.Font = new System.Drawing.Font("宋体", 40F);
            this.labname.Location = new System.Drawing.Point(176, 270);
            this.labname.Name = "labname";
            this.labname.Size = new System.Drawing.Size(323, 70);
            this.labname.TabIndex = 8;
            this.labname.Text = "name";
            // 
            // labstyle
            // 
            this.labstyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labstyle.Font = new System.Drawing.Font("宋体", 40F);
            this.labstyle.Location = new System.Drawing.Point(529, 270);
            this.labstyle.Name = "labstyle";
            this.labstyle.Size = new System.Drawing.Size(467, 70);
            this.labstyle.TabIndex = 9;
            this.labstyle.Text = "style";
            // 
            // labsize
            // 
            this.labsize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labsize.Font = new System.Drawing.Font("宋体", 40F);
            this.labsize.Location = new System.Drawing.Point(475, 363);
            this.labsize.Name = "labsize";
            this.labsize.Size = new System.Drawing.Size(246, 70);
            this.labsize.TabIndex = 10;
            this.labsize.Text = "Size";
            // 
            // labCustomName
            // 
            this.labCustomName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labCustomName.Font = new System.Drawing.Font("宋体", 40F);
            this.labCustomName.Location = new System.Drawing.Point(794, 187);
            this.labCustomName.Name = "labCustomName";
            this.labCustomName.Size = new System.Drawing.Size(202, 70);
            this.labCustomName.TabIndex = 12;
            this.labCustomName.Text = "CustomName";
            // 
            // labnewcode
            // 
            this.labnewcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labnewcode.Font = new System.Drawing.Font("宋体", 40F);
            this.labnewcode.Location = new System.Drawing.Point(653, 187);
            this.labnewcode.Name = "labnewcode";
            this.labnewcode.Size = new System.Drawing.Size(135, 70);
            this.labnewcode.TabIndex = 11;
            this.labnewcode.Text = "newcode";
            // 
            // btnbarcodeprint
            // 
            this.btnbarcodeprint.Location = new System.Drawing.Point(12, 310);
            this.btnbarcodeprint.Name = "btnbarcodeprint";
            this.btnbarcodeprint.Size = new System.Drawing.Size(143, 86);
            this.btnbarcodeprint.TabIndex = 13;
            this.btnbarcodeprint.Text = "打印条码";
            this.btnbarcodeprint.UseVisualStyleBackColor = true;
            this.btnbarcodeprint.Click += new System.EventHandler(this.btnbarcodeprint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(229, 474);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 52);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnCreateBarCode
            // 
            this.btnCreateBarCode.Location = new System.Drawing.Point(12, 434);
            this.btnCreateBarCode.Name = "btnCreateBarCode";
            this.btnCreateBarCode.Size = new System.Drawing.Size(75, 23);
            this.btnCreateBarCode.TabIndex = 15;
            this.btnCreateBarCode.Text = "生成条码";
            this.btnCreateBarCode.UseVisualStyleBackColor = true;
            this.btnCreateBarCode.Click += new System.EventHandler(this.btnCreateBarCode_Click);
            // 
            // btnCreateQuickMark
            // 
            this.btnCreateQuickMark.Location = new System.Drawing.Point(12, 463);
            this.btnCreateQuickMark.Name = "btnCreateQuickMark";
            this.btnCreateQuickMark.Size = new System.Drawing.Size(75, 23);
            this.btnCreateQuickMark.TabIndex = 16;
            this.btnCreateQuickMark.Text = "生成二维码";
            this.btnCreateQuickMark.UseVisualStyleBackColor = true;
            this.btnCreateQuickMark.Click += new System.EventHandler(this.btnCreateQuickMark_Click);
            // 
            // btnBarcodeReader
            // 
            this.btnBarcodeReader.Location = new System.Drawing.Point(12, 492);
            this.btnBarcodeReader.Name = "btnBarcodeReader";
            this.btnBarcodeReader.Size = new System.Drawing.Size(75, 23);
            this.btnBarcodeReader.TabIndex = 17;
            this.btnBarcodeReader.Text = "读码";
            this.btnBarcodeReader.UseVisualStyleBackColor = true;
            this.btnBarcodeReader.Click += new System.EventHandler(this.btnBarcodeReader_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(139, 447);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(178, 21);
            this.txtMsg.TabIndex = 18;
            this.txtMsg.Text = "04560354150020";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 495);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(337, 474);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(395, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            // 
            // textBoxEdit
            // 
            this.textBoxEdit.Location = new System.Drawing.Point(471, 510);
            this.textBoxEdit.Name = "textBoxEdit";
            this.textBoxEdit.Size = new System.Drawing.Size(100, 21);
            this.textBoxEdit.TabIndex = 22;
            // 
            // FrmPADInnerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 542);
            this.Controls.Add(this.textBoxEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnBarcodeReader);
            this.Controls.Add(this.btnCreateQuickMark);
            this.Controls.Add(this.btnCreateBarCode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnbarcodeprint);
            this.Controls.Add(this.labCustomName);
            this.Controls.Add(this.labnewcode);
            this.Controls.Add(this.labsize);
            this.Controls.Add(this.labstyle);
            this.Controls.Add(this.labname);
            this.Controls.Add(this.labguid);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnreadlocaldb);
            this.Controls.Add(this.labtype);
            this.Controls.Add(this.labcolor);
            this.Controls.Add(this.labstylecode);
            this.Controls.Add(this.butupdatadblocal);
            this.Name = "FrmPADInnerBox";
            this.Text = "FrmPADInnerBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPADInnerBox_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butupdatadblocal;
        private System.Windows.Forms.Label labstylecode;
        private System.Windows.Forms.Label labcolor;
        private System.Windows.Forms.Label labtype;
        private System.Windows.Forms.Button btnreadlocaldb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label labguid;
        private System.Windows.Forms.Label labname;
        private System.Windows.Forms.Label labstyle;
        private System.Windows.Forms.Label labsize;
        private System.Windows.Forms.Label labCustomName;
        private System.Windows.Forms.Label labnewcode;
        private System.Windows.Forms.Button btnbarcodeprint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCreateBarCode;
        private System.Windows.Forms.Button btnCreateQuickMark;
        private System.Windows.Forms.Button btnBarcodeReader;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEdit;
    }
}