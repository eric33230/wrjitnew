namespace WinForm
{
    partial class FrmTestNetwork
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
            this.btnlinkserver = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.cbdbname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelTestLinServer = new System.Windows.Forms.Label();
            this.btnlinkDB = new System.Windows.Forms.Button();
            this.txtdbuser = new System.Windows.Forms.TextBox();
            this.txtdbpwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnlinkserver
            // 
            this.btnlinkserver.Location = new System.Drawing.Point(177, 15);
            this.btnlinkserver.Name = "btnlinkserver";
            this.btnlinkserver.Size = new System.Drawing.Size(91, 23);
            this.btnlinkserver.TabIndex = 0;
            this.btnlinkserver.Text = "连接服务器";
            this.btnlinkserver.UseVisualStyleBackColor = true;
            this.btnlinkserver.Click += new System.EventHandler(this.btnlinkserver_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(73, 17);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(98, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.98.199";
            // 
            // cbdbname
            // 
            this.cbdbname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdbname.FormattingEnabled = true;
            this.cbdbname.Location = new System.Drawing.Point(103, 98);
            this.cbdbname.Name = "cbdbname";
            this.cbdbname.Size = new System.Drawing.Size(165, 20);
            this.cbdbname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "服务器IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择数据库";
            // 
            // LabelTestLinServer
            // 
            this.LabelTestLinServer.Location = new System.Drawing.Point(-2, 258);
            this.LabelTestLinServer.Name = "LabelTestLinServer";
            this.LabelTestLinServer.Size = new System.Drawing.Size(294, 34);
            this.LabelTestLinServer.TabIndex = 5;
            this.LabelTestLinServer.Text = "服务器状态：未测试";
            // 
            // btnlinkDB
            // 
            this.btnlinkDB.Location = new System.Drawing.Point(177, 44);
            this.btnlinkDB.Name = "btnlinkDB";
            this.btnlinkDB.Size = new System.Drawing.Size(91, 48);
            this.btnlinkDB.TabIndex = 6;
            this.btnlinkDB.Text = "连接数据库";
            this.btnlinkDB.UseVisualStyleBackColor = true;
            this.btnlinkDB.Click += new System.EventHandler(this.btnlinkDB_Click);
            // 
            // txtdbuser
            // 
            this.txtdbuser.Location = new System.Drawing.Point(103, 44);
            this.txtdbuser.Name = "txtdbuser";
            this.txtdbuser.Size = new System.Drawing.Size(68, 21);
            this.txtdbuser.TabIndex = 7;
            this.txtdbuser.Text = "sa";
            // 
            // txtdbpwd
            // 
            this.txtdbpwd.Location = new System.Drawing.Point(103, 71);
            this.txtdbpwd.Name = "txtdbpwd";
            this.txtdbpwd.PasswordChar = '*';
            this.txtdbpwd.Size = new System.Drawing.Size(68, 21);
            this.txtdbpwd.TabIndex = 8;
            this.txtdbpwd.Text = "wingstar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "数据库用户名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "密码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 124);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 110);
            this.textBox1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sql";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "执行SQL";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmTestNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 293);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdbpwd);
            this.Controls.Add(this.txtdbuser);
            this.Controls.Add(this.btnlinkDB);
            this.Controls.Add(this.LabelTestLinServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbdbname);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnlinkserver);
            this.Name = "FrmTestNetwork";
            this.Text = "测试网络";
            this.Load += new System.EventHandler(this.FrmTestNetwork_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlinkserver;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.ComboBox cbdbname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelTestLinServer;
        private System.Windows.Forms.Button btnlinkDB;
        private System.Windows.Forms.TextBox txtdbuser;
        private System.Windows.Forms.TextBox txtdbpwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}