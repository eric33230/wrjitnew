namespace WinForm
{
    partial class FrmInnerboxOld
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
            this.dgvInnerbox = new System.Windows.Forms.DataGridView();
            this.InnerBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInput = new System.Windows.Forms.Button();
            this.YearMounth = new System.Windows.Forms.DateTimePicker();
            this.訂單年月 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.sP1 = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInnerbox)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInnerbox
            // 
            this.dgvInnerbox.AllowUserToAddRows = false;
            this.dgvInnerbox.ColumnHeadersHeight = 50;
            this.dgvInnerbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInnerbox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InnerBarcode,
            this.mName,
            this.Color,
            this.mSize,
            this.Type,
            this.NewCode,
            this.Style});
            this.dgvInnerbox.Location = new System.Drawing.Point(406, 9);
            this.dgvInnerbox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgvInnerbox.MultiSelect = false;
            this.dgvInnerbox.Name = "dgvInnerbox";
            this.dgvInnerbox.RowHeadersVisible = false;
            this.dgvInnerbox.RowTemplate.Height = 23;
            this.dgvInnerbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInnerbox.Size = new System.Drawing.Size(1385, 785);
            this.dgvInnerbox.TabIndex = 7;
            this.dgvInnerbox.UseWaitCursor = true;
            this.dgvInnerbox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassList_CellContentClick);
            // 
            // InnerBarcode
            // 
            this.InnerBarcode.DataPropertyName = "InnerBarcode";
            this.InnerBarcode.HeaderText = "InnerBarcode";
            this.InnerBarcode.Name = "InnerBarcode";
            this.InnerBarcode.Width = 200;
            // 
            // mName
            // 
            this.mName.DataPropertyName = "Name";
            this.mName.HeaderText = "Name";
            this.mName.Name = "mName";
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            // 
            // mSize
            // 
            this.mSize.DataPropertyName = "Size";
            this.mSize.HeaderText = "Size";
            this.mSize.Name = "mSize";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // NewCode
            // 
            this.NewCode.DataPropertyName = "NewCode";
            this.NewCode.HeaderText = "訂單年月";
            this.NewCode.Name = "NewCode";
            this.NewCode.Width = 150;
            // 
            // Style
            // 
            this.Style.DataPropertyName = "Style";
            this.Style.HeaderText = "Style";
            this.Style.Name = "Style";
            this.Style.Width = 200;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(22, 213);
            this.btnInput.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(346, 46);
            this.btnInput.TabIndex = 10;
            this.btnInput.Text = "尋找";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(22, 49);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(132, 33);
            this.YearMounth.TabIndex = 11;
            // 
            // 訂單年月
            // 
            this.訂單年月.AutoSize = true;
            this.訂單年月.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.訂單年月.Location = new System.Drawing.Point(18, 9);
            this.訂單年月.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.訂單年月.Name = "訂單年月";
            this.訂單年月.Size = new System.Drawing.Size(72, 16);
            this.訂單年月.TabIndex = 12;
            this.訂單年月.Text = "訂單年月";
            this.訂單年月.Click += new System.EventHandler(this.訂單年月_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(166, 49);
            this.txtName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 33);
            this.txtName.TabIndex = 13;
            this.txtName.Text = "T619N";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(166, 143);
            this.txtColor.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(202, 33);
            this.txtColor.TabIndex = 14;
            this.txtColor.Text = "Color";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(22, 143);
            this.txtSize.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(132, 33);
            this.txtSize.TabIndex = 15;
            this.txtSize.Text = "Size";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(15, 303);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(353, 33);
            this.txtBarcode.TabIndex = 16;
            // 
            // sP1
            // 
            this.sP1.PortName = "COM3";
            this.sP1.StopBits = System.IO.Ports.StopBits.Two;
            this.sP1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.sP1_DataReceived);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(162, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "客戶型體";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(18, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "尺碼";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(162, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "配色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(18, 274);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "掃描條碼號";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 491);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 46);
            this.button1.TabIndex = 22;
            this.button1.Text = "導入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 406);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(202, 33);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "t619n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(18, 377);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "條碼類型";
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(226, 406);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(142, 33);
            this.tb2.TabIndex = 25;
            // 
            // FrmInnerboxOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.訂單年月);
            this.Controls.Add(this.YearMounth);
            this.Controls.Add(this.dgvInnerbox);
            this.Controls.Add(this.btnInput);
            this.Font = new System.Drawing.Font("PMingLiU", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmInnerboxOld";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "內盒條碼接轉";
            this.Activated += new System.EventHandler(this.FrmInnerbox_Activated);
            this.Deactivate += new System.EventHandler(this.FrmInnerbox_Deactivate);
            this.Load += new System.EventHandler(this.FrmInnerboxIn_Load);
            this.ImeModeChanged += new System.EventHandler(this.FrmInnerbox_ImeModeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInnerbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInnerbox;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.Label 訂單年月;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.IO.Ports.SerialPort sP1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn InnerBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn mName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn mSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Style;
        private System.Windows.Forms.TextBox tb2;
    }
}