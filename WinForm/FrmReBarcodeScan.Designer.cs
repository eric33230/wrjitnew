namespace WinForm
{
    partial class FrmReBarcodeScan
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
            this.lblBOXNO = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblNo = new System.Windows.Forms.Label();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSize11 = new System.Windows.Forms.Label();
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
            this.lblSize3 = new System.Windows.Forms.Label();
            this.lblSize2 = new System.Windows.Forms.Label();
            this.lblSize1 = new System.Windows.Forms.Label();
            this.lblSize9 = new System.Windows.Forms.Label();
            this.lblSize4 = new System.Windows.Forms.Label();
            this.lblSize8 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnrescan = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnError = new System.Windows.Forms.Button();
            this.msgDiv = new MsgDiv();
            this.SuspendLayout();
            // 
            // lblBOXNO
            // 
            this.lblBOXNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBOXNO.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOXNO.Location = new System.Drawing.Point(154, 246);
            this.lblBOXNO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBOXNO.Name = "lblBOXNO";
            this.lblBOXNO.Size = new System.Drawing.Size(119, 44);
            this.lblBOXNO.TabIndex = 128;
            this.lblBOXNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSize
            // 
            this.tbSize.Enabled = false;
            this.tbSize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSize.Location = new System.Drawing.Point(11, 246);
            this.tbSize.Margin = new System.Windows.Forms.Padding(2);
            this.tbSize.Multiline = true;
            this.tbSize.Name = "tbSize";
            this.tbSize.ReadOnly = true;
            this.tbSize.Size = new System.Drawing.Size(141, 283);
            this.tbSize.TabIndex = 127;
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.SystemColors.Control;
            this.txtPwd.Location = new System.Drawing.Point(12, 532);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(259, 21);
            this.txtPwd.TabIndex = 97;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // lblNo
            // 
            this.lblNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNo.Font = new System.Drawing.Font("Arial", 70F);
            this.lblNo.Location = new System.Drawing.Point(278, 9);
            this.lblNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(275, 93);
            this.lblNo.TabIndex = 122;
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb13
            // 
            this.tb13.Enabled = false;
            this.tb13.Location = new System.Drawing.Point(154, 292);
            this.tb13.Margin = new System.Windows.Forms.Padding(2);
            this.tb13.Multiline = true;
            this.tb13.Name = "tb13";
            this.tb13.ReadOnly = true;
            this.tb13.Size = new System.Drawing.Size(119, 237);
            this.tb13.TabIndex = 121;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(1004, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(7, 451);
            this.label4.TabIndex = 119;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(276, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(733, 9);
            this.label3.TabIndex = 118;
            // 
            // tb2
            // 
            this.tb2.Enabled = false;
            this.tb2.Location = new System.Drawing.Point(39, 499);
            this.tb2.Margin = new System.Windows.Forms.Padding(2);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(141, 21);
            this.tb2.TabIndex = 100;
            this.tb2.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(276, 549);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(733, 7);
            this.label2.TabIndex = 117;
            // 
            // lblSize11
            // 
            this.lblSize11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize11.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize11.Location = new System.Drawing.Point(291, 333);
            this.lblSize11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize11.Name = "lblSize11";
            this.lblSize11.Size = new System.Drawing.Size(234, 101);
            this.lblSize11.TabIndex = 114;
            this.lblSize11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(276, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 449);
            this.label1.TabIndex = 116;
            // 
            // lblColor
            // 
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(11, 127);
            this.lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(262, 57);
            this.lblColor.TabIndex = 103;
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStyle
            // 
            this.lblStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStyle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStyle.Location = new System.Drawing.Point(11, 67);
            this.lblStyle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(262, 57);
            this.lblStyle.TabIndex = 102;
            this.lblStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarton
            // 
            this.lblCarton.BackColor = System.Drawing.SystemColors.Control;
            this.lblCarton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCarton.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblCarton.Location = new System.Drawing.Point(11, 9);
            this.lblCarton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarton.Name = "lblCarton";
            this.lblCarton.Size = new System.Drawing.Size(262, 57);
            this.lblCarton.TabIndex = 99;
            this.lblCarton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize12
            // 
            this.lblSize12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize12.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSize12.Location = new System.Drawing.Point(291, 440);
            this.lblSize12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize12.Name = "lblSize12";
            this.lblSize12.Size = new System.Drawing.Size(234, 101);
            this.lblSize12.TabIndex = 115;
            this.lblSize12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCartonNo
            // 
            this.lblCartonNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCartonNo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblCartonNo.Location = new System.Drawing.Point(11, 188);
            this.lblCartonNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCartonNo.Name = "lblCartonNo";
            this.lblCartonNo.Size = new System.Drawing.Size(262, 57);
            this.lblCartonNo.TabIndex = 101;
            this.lblCartonNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize10
            // 
            this.lblSize10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize10.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize10.Location = new System.Drawing.Point(291, 226);
            this.lblSize10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize10.Name = "lblSize10";
            this.lblSize10.Size = new System.Drawing.Size(234, 101);
            this.lblSize10.TabIndex = 113;
            this.lblSize10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize7
            // 
            this.lblSize7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize7.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize7.Location = new System.Drawing.Point(528, 333);
            this.lblSize7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize7.Name = "lblSize7";
            this.lblSize7.Size = new System.Drawing.Size(234, 101);
            this.lblSize7.TabIndex = 110;
            this.lblSize7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize6
            // 
            this.lblSize6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize6.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize6.Location = new System.Drawing.Point(528, 226);
            this.lblSize6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize6.Name = "lblSize6";
            this.lblSize6.Size = new System.Drawing.Size(234, 101);
            this.lblSize6.TabIndex = 109;
            this.lblSize6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize5
            // 
            this.lblSize5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize5.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize5.Location = new System.Drawing.Point(528, 120);
            this.lblSize5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize5.Name = "lblSize5";
            this.lblSize5.Size = new System.Drawing.Size(234, 101);
            this.lblSize5.TabIndex = 108;
            this.lblSize5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize3
            // 
            this.lblSize3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize3.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize3.Location = new System.Drawing.Point(764, 333);
            this.lblSize3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize3.Name = "lblSize3";
            this.lblSize3.Size = new System.Drawing.Size(234, 101);
            this.lblSize3.TabIndex = 106;
            this.lblSize3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize2
            // 
            this.lblSize2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize2.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize2.Location = new System.Drawing.Point(764, 226);
            this.lblSize2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize2.Name = "lblSize2";
            this.lblSize2.Size = new System.Drawing.Size(234, 101);
            this.lblSize2.TabIndex = 105;
            this.lblSize2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize1
            // 
            this.lblSize1.BackColor = System.Drawing.SystemColors.Control;
            this.lblSize1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize1.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize1.Location = new System.Drawing.Point(764, 120);
            this.lblSize1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize1.Name = "lblSize1";
            this.lblSize1.Size = new System.Drawing.Size(234, 101);
            this.lblSize1.TabIndex = 104;
            this.lblSize1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize9
            // 
            this.lblSize9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize9.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize9.Location = new System.Drawing.Point(291, 120);
            this.lblSize9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize9.Name = "lblSize9";
            this.lblSize9.Size = new System.Drawing.Size(234, 101);
            this.lblSize9.TabIndex = 112;
            this.lblSize9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize4
            // 
            this.lblSize4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize4.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize4.Location = new System.Drawing.Point(764, 440);
            this.lblSize4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize4.Name = "lblSize4";
            this.lblSize4.Size = new System.Drawing.Size(234, 101);
            this.lblSize4.TabIndex = 107;
            this.lblSize4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSize8
            // 
            this.lblSize8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize8.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSize8.Location = new System.Drawing.Point(528, 440);
            this.lblSize8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize8.Name = "lblSize8";
            this.lblSize8.Size = new System.Drawing.Size(234, 101);
            this.lblSize8.TabIndex = 111;
            this.lblSize8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnrescan
            // 
            this.btnrescan.CausesValidation = false;
            this.btnrescan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnrescan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnrescan.Location = new System.Drawing.Point(735, 9);
            this.btnrescan.Name = "btnrescan";
            this.btnrescan.Size = new System.Drawing.Size(137, 93);
            this.btnrescan.TabIndex = 130;
            this.btnrescan.TabStop = false;
            this.btnrescan.Text = "刷新箱/重新刷";
            this.btnrescan.UseVisualStyleBackColor = true;
            this.btnrescan.Click += new System.EventHandler(this.btnrescan_Click);
            // 
            // btnclose
            // 
            this.btnclose.CausesValidation = false;
            this.btnclose.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnclose.Location = new System.Drawing.Point(878, 9);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(131, 93);
            this.btnclose.TabIndex = 131;
            this.btnclose.TabStop = false;
            this.btnclose.Text = "关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnError
            // 
            this.btnError.CausesValidation = false;
            this.btnError.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnError.ForeColor = System.Drawing.Color.Red;
            this.btnError.Location = new System.Drawing.Point(558, 9);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(171, 93);
            this.btnError.TabIndex = 132;
            this.btnError.TabStop = false;
            this.btnError.Text = "解除错误";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // msgDiv
            // 
            this.msgDiv.AutoSize = true;
            this.msgDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.msgDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgDiv.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgDiv.ForeColor = System.Drawing.Color.Red;
            this.msgDiv.Location = new System.Drawing.Point(17, 524);
            this.msgDiv.MaximumSize = new System.Drawing.Size(980, 525);
            this.msgDiv.Name = "msgDiv";
            this.msgDiv.Padding = new System.Windows.Forms.Padding(7);
            this.msgDiv.Size = new System.Drawing.Size(86, 31);
            this.msgDiv.TabIndex = 123;
            this.msgDiv.Text = "msgDiv1";
            this.msgDiv.Visible = false;
            // 
            // FrmReBarcodeScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 561);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnrescan);
            this.Controls.Add(this.lblBOXNO);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSize11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.lblCarton);
            this.Controls.Add(this.lblSize12);
            this.Controls.Add(this.lblCartonNo);
            this.Controls.Add(this.lblSize10);
            this.Controls.Add(this.lblSize7);
            this.Controls.Add(this.lblSize6);
            this.Controls.Add(this.lblSize5);
            this.Controls.Add(this.lblSize3);
            this.Controls.Add(this.lblSize2);
            this.Controls.Add(this.lblSize1);
            this.Controls.Add(this.lblSize9);
            this.Controls.Add(this.lblSize4);
            this.Controls.Add(this.lblSize8);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tb13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmReBarcodeScan";
            this.Text = "重验QA扫描";
            this.Activated += new System.EventHandler(this.FrmReBarcodeScan_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBOXNO;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.TextBox tb13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private MsgDiv msgDiv;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSize11;
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
        private System.Windows.Forms.Label lblSize3;
        private System.Windows.Forms.Label lblSize2;
        private System.Windows.Forms.Label lblSize1;
        private System.Windows.Forms.Label lblSize9;
        private System.Windows.Forms.Label lblSize4;
        private System.Windows.Forms.Label lblSize8;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnrescan;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnError;
    }
}