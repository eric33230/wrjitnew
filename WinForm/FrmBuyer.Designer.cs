namespace WinForm
{
    partial class FrmBuyer
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
            this.YearMounth = new System.Windows.Forms.DateTimePicker();
            this.btnBuyerE = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvBuyer = new System.Windows.Forms.DataGridView();
            this.Guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonBarcodeNeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomBuyOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomBuyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Forwarder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryChinese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBuyerE = new System.Windows.Forms.DataGridView();
            this.CustomName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomBuyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCustomName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.btnquerybykey = new System.Windows.Forms.Button();
            this.cbcustomBuyName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyer)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyerE)).BeginInit();
            this.SuspendLayout();
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(80, 8);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(2);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(102, 27);
            this.YearMounth.TabIndex = 33;
            // 
            // btnBuyerE
            // 
            this.btnBuyerE.Location = new System.Drawing.Point(186, 8);
            this.btnBuyerE.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuyerE.Name = "btnBuyerE";
            this.btnBuyerE.Size = new System.Drawing.Size(91, 25);
            this.btnBuyerE.TabIndex = 57;
            this.btnBuyerE.Text = "查詢       ";
            this.btnBuyerE.UseVisualStyleBackColor = true;
            this.btnBuyerE.Click += new System.EventHandler(this.btnBuyerE_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBuyer);
            this.groupBox1.Location = new System.Drawing.Point(284, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 414);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户买主条码类型";
            // 
            // dgvBuyer
            // 
            this.dgvBuyer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Guid,
            this.CartonBarcodeNeed,
            this.CustomName,
            this.CustomBuyOwner,
            this.CustomBuyName,
            this.Forwarder,
            this.Type,
            this.State,
            this.Country,
            this.CountryChinese,
            this.Destination});
            this.dgvBuyer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuyer.Location = new System.Drawing.Point(3, 17);
            this.dgvBuyer.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBuyer.Name = "dgvBuyer";
            this.dgvBuyer.RowTemplate.Height = 30;
            this.dgvBuyer.Size = new System.Drawing.Size(725, 394);
            this.dgvBuyer.TabIndex = 34;
            this.dgvBuyer.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBuyer_CellBeginEdit);
            this.dgvBuyer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuyer_CellValueChanged);
            // 
            // Guid
            // 
            this.Guid.DataPropertyName = "Guid";
            this.Guid.HeaderText = "Guid";
            this.Guid.Name = "Guid";
            this.Guid.Visible = false;
            this.Guid.Width = 80;
            // 
            // CartonBarcodeNeed
            // 
            this.CartonBarcodeNeed.DataPropertyName = "CartonBarcodeNeed";
            this.CartonBarcodeNeed.HeaderText = "列印";
            this.CartonBarcodeNeed.Name = "CartonBarcodeNeed";
            this.CartonBarcodeNeed.Width = 60;
            // 
            // CustomName
            // 
            this.CustomName.DataPropertyName = "CustomName";
            this.CustomName.HeaderText = "客户";
            this.CustomName.Name = "CustomName";
            this.CustomName.Width = 60;
            // 
            // CustomBuyOwner
            // 
            this.CustomBuyOwner.DataPropertyName = "CustomBuyOwner";
            this.CustomBuyOwner.HeaderText = "客户管辖";
            this.CustomBuyOwner.Name = "CustomBuyOwner";
            this.CustomBuyOwner.Width = 80;
            // 
            // CustomBuyName
            // 
            this.CustomBuyName.DataPropertyName = "CustomBuyName";
            this.CustomBuyName.HeaderText = "客户买主";
            this.CustomBuyName.Name = "CustomBuyName";
            this.CustomBuyName.Width = 80;
            // 
            // Forwarder
            // 
            this.Forwarder.DataPropertyName = "Forwarder";
            this.Forwarder.HeaderText = "货代";
            this.Forwarder.Name = "Forwarder";
            this.Forwarder.Width = 200;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "条码";
            this.Type.Name = "Type";
            this.Type.Width = 60;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "州別";
            this.State.Name = "State";
            this.State.Width = 60;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国家(英)";
            this.Country.Name = "Country";
            this.Country.Width = 80;
            // 
            // CountryChinese
            // 
            this.CountryChinese.DataPropertyName = "CountryChinese";
            this.CountryChinese.HeaderText = "国家(中)";
            this.CountryChinese.Name = "CountryChinese";
            this.CountryChinese.Width = 80;
            // 
            // Destination
            // 
            this.Destination.DataPropertyName = "Destination";
            this.Destination.HeaderText = "目的地港口";
            this.Destination.Name = "Destination";
            this.Destination.Width = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBuyerE);
            this.groupBox2.Location = new System.Drawing.Point(-1, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 414);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "新增客户买主";
            // 
            // dgvBuyerE
            // 
            this.dgvBuyerE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyerE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomName1,
            this.Destination1,
            this.CustomBuyName1});
            this.dgvBuyerE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuyerE.Location = new System.Drawing.Point(3, 17);
            this.dgvBuyerE.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBuyerE.Name = "dgvBuyerE";
            this.dgvBuyerE.ReadOnly = true;
            this.dgvBuyerE.RowTemplate.Height = 30;
            this.dgvBuyerE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuyerE.Size = new System.Drawing.Size(277, 394);
            this.dgvBuyerE.TabIndex = 36;
            this.dgvBuyerE.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuyerE_CellDoubleClick);
            // 
            // CustomName1
            // 
            this.CustomName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CustomName1.DataPropertyName = "CustomName";
            this.CustomName1.HeaderText = "客户";
            this.CustomName1.Name = "CustomName1";
            this.CustomName1.ReadOnly = true;
            this.CustomName1.Width = 54;
            // 
            // Destination1
            // 
            this.Destination1.DataPropertyName = "Destination";
            this.Destination1.HeaderText = "目的地港口";
            this.Destination1.Name = "Destination1";
            this.Destination1.ReadOnly = true;
            // 
            // CustomBuyName1
            // 
            this.CustomBuyName1.DataPropertyName = "CustomBuyName";
            this.CustomBuyName1.HeaderText = "買主";
            this.CustomBuyName1.Name = "CustomBuyName1";
            this.CustomBuyName1.ReadOnly = true;
            this.CustomBuyName1.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "订单年月";
            // 
            // cbCustomName
            // 
            this.cbCustomName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomName.FormattingEnabled = true;
            this.cbCustomName.Location = new System.Drawing.Point(355, 9);
            this.cbCustomName.Name = "cbCustomName";
            this.cbCustomName.Size = new System.Drawing.Size(137, 20);
            this.cbCustomName.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "客户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(681, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 63;
            this.label3.Text = "目的地港口";
            // 
            // cbDestination
            // 
            this.cbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Location = new System.Drawing.Point(752, 9);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(146, 20);
            this.cbDestination.TabIndex = 64;
            // 
            // btnquerybykey
            // 
            this.btnquerybykey.Location = new System.Drawing.Point(933, 8);
            this.btnquerybykey.Name = "btnquerybykey";
            this.btnquerybykey.Size = new System.Drawing.Size(75, 23);
            this.btnquerybykey.TabIndex = 35;
            this.btnquerybykey.Text = "查询";
            this.btnquerybykey.UseVisualStyleBackColor = true;
            this.btnquerybykey.Click += new System.EventHandler(this.btnquerybykey_Click);
            // 
            // cbcustomBuyName
            // 
            this.cbcustomBuyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcustomBuyName.FormattingEnabled = true;
            this.cbcustomBuyName.Location = new System.Drawing.Point(557, 9);
            this.cbcustomBuyName.Name = "cbcustomBuyName";
            this.cbcustomBuyName.Size = new System.Drawing.Size(118, 20);
            this.cbcustomBuyName.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 66;
            this.label4.Text = "客户买主";
            // 
            // FrmBuyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 448);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbcustomBuyName);
            this.Controls.Add(this.btnquerybykey);
            this.Controls.Add(this.cbDestination);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCustomName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuyerE);
            this.Controls.Add(this.YearMounth);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmBuyer";
            this.Text = "客户买主";
            this.Activated += new System.EventHandler(this.FrmBuyer_Activated);
            this.Load += new System.EventHandler(this.FrmBuyer_Load);
            this.Resize += new System.EventHandler(this.FrmBuyer_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyerE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.Button btnBuyerE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBuyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonBarcodeNeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomBuyOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomBuyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Forwarder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryChinese;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBuyerE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomBuyName1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCustomName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.Button btnquerybykey;
        private System.Windows.Forms.ComboBox cbcustomBuyName;
        private System.Windows.Forms.Label label4;
    }
}