namespace WinForm
{
    partial class FrmInnerBox
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
            this.btnInterBoxImpro = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dvgInnerBox = new System.Windows.Forms.DataGridView();
            this.btnSaveInnerBox = new System.Windows.Forms.Button();
            this.comsheetname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.textHeadno = new System.Windows.Forms.TextBox();
            this.btnCleanRe = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgInnerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInterBoxImpro
            // 
            this.btnInterBoxImpro.Location = new System.Drawing.Point(3, 10);
            this.btnInterBoxImpro.Name = "btnInterBoxImpro";
            this.btnInterBoxImpro.Size = new System.Drawing.Size(75, 23);
            this.btnInterBoxImpro.TabIndex = 0;
            this.btnInterBoxImpro.Text = "浏览";
            this.btnInterBoxImpro.UseVisualStyleBackColor = true;
            this.btnInterBoxImpro.Click += new System.EventHandler(this.btnInterBoxImpro_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dvgInnerBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(892, 407);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内盒条码信息";
            // 
            // dvgInnerBox
            // 
            this.dvgInnerBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgInnerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgInnerBox.Location = new System.Drawing.Point(3, 17);
            this.dvgInnerBox.Name = "dvgInnerBox";
            this.dvgInnerBox.RowTemplate.Height = 23;
            this.dvgInnerBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgInnerBox.Size = new System.Drawing.Size(886, 387);
            this.dvgInnerBox.TabIndex = 3;
            this.dvgInnerBox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgInnerBox_CellContentClick);
            this.dvgInnerBox.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dvgInnerBox_RowPostPaint);
            // 
            // btnSaveInnerBox
            // 
            this.btnSaveInnerBox.Location = new System.Drawing.Point(721, 10);
            this.btnSaveInnerBox.Name = "btnSaveInnerBox";
            this.btnSaveInnerBox.Size = new System.Drawing.Size(75, 23);
            this.btnSaveInnerBox.TabIndex = 3;
            this.btnSaveInnerBox.Text = "保存";
            this.btnSaveInnerBox.UseVisualStyleBackColor = true;
            this.btnSaveInnerBox.Click += new System.EventHandler(this.btnSaveInnerBox_Click);
            // 
            // comsheetname
            // 
            this.comsheetname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comsheetname.FormattingEnabled = true;
            this.comsheetname.Location = new System.Drawing.Point(361, 11);
            this.comsheetname.Name = "comsheetname";
            this.comsheetname.Size = new System.Drawing.Size(120, 20);
            this.comsheetname.TabIndex = 4;
            this.comsheetname.SelectedIndexChanged += new System.EventHandler(this.comsheetname_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "请选择工作表:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "表头行数:";
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(628, 10);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(75, 23);
            this.btnLoadExcel.TabIndex = 8;
            this.btnLoadExcel.Text = "加载EXCEL";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(84, 11);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.ReadOnly = true;
            this.txtfilename.Size = new System.Drawing.Size(161, 21);
            this.txtfilename.TabIndex = 9;
            // 
            // textHeadno
            // 
            this.textHeadno.Location = new System.Drawing.Point(579, 11);
            this.textHeadno.Name = "textHeadno";
            this.textHeadno.Size = new System.Drawing.Size(40, 21);
            this.textHeadno.TabIndex = 10;
            this.textHeadno.Text = "0";
            this.textHeadno.TextChanged += new System.EventHandler(this.textHeadno_TextChanged);
            // 
            // btnCleanRe
            // 
            this.btnCleanRe.Location = new System.Drawing.Point(804, 10);
            this.btnCleanRe.Name = "btnCleanRe";
            this.btnCleanRe.Size = new System.Drawing.Size(75, 23);
            this.btnCleanRe.TabIndex = 11;
            this.btnCleanRe.Text = "清理重复数据";
            this.btnCleanRe.UseVisualStyleBackColor = true;
            this.btnCleanRe.Click += new System.EventHandler(this.btnCleanRe_Click);
            // 
            // FrmInnerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 440);
            this.Controls.Add(this.btnCleanRe);
            this.Controls.Add(this.textHeadno);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.btnLoadExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comsheetname);
            this.Controls.Add(this.btnSaveInnerBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInterBoxImpro);
            this.Name = "FrmInnerBox";
            this.Text = "内盒条码导入";
            this.Activated += new System.EventHandler(this.FrmInnerBox_Activated);
            this.Load += new System.EventHandler(this.InterBoxLableWind_Load);
            this.SizeChanged += new System.EventHandler(this.InterBoxLableWind_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgInnerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInterBoxImpro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dvgInnerBox;
        private System.Windows.Forms.Button btnSaveInnerBox;
        private System.Windows.Forms.ComboBox comsheetname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.TextBox textHeadno;
        private System.Windows.Forms.Button btnCleanRe;
    }
}