namespace WinForm
{
    partial class FrmStyleBase
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
            this.dgvStyleBase = new System.Windows.Forms.DataGridView();
            this.Guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HourQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RBcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MDcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editionhandle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Innor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnALLStyle = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStyleBase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.YearMounth = new System.Windows.Forms.DateTimePicker();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyleBase)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStyleBase
            // 
            this.dgvStyleBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStyleBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Guid,
            this.CustomName,
            this.StyleBase,
            this.Style,
            this.HourQty,
            this.Name1,
            this.ModelNo,
            this.RBcode,
            this.MDcode,
            this.Editionhandle,
            this.Innor,
            this.OrderDate,
            this.NewCode});
            this.dgvStyleBase.Location = new System.Drawing.Point(8, 53);
            this.dgvStyleBase.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStyleBase.Name = "dgvStyleBase";
            this.dgvStyleBase.RowTemplate.Height = 31;
            this.dgvStyleBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStyleBase.Size = new System.Drawing.Size(1259, 549);
            this.dgvStyleBase.TabIndex = 31;
            this.dgvStyleBase.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvStyleBase_CellBeginEdit);
            this.dgvStyleBase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStyleBase_CellValueChanged);
            // 
            // Guid
            // 
            this.Guid.DataPropertyName = "Guid";
            this.Guid.HeaderText = "Guid";
            this.Guid.Name = "Guid";
            this.Guid.Visible = false;
            // 
            // CustomName
            // 
            this.CustomName.DataPropertyName = "CustomName";
            this.CustomName.HeaderText = "客户";
            this.CustomName.Name = "CustomName";
            this.CustomName.Width = 60;
            // 
            // StyleBase
            // 
            this.StyleBase.DataPropertyName = "StyleBase";
            this.StyleBase.HeaderText = "型体大类";
            this.StyleBase.Name = "StyleBase";
            // 
            // Style
            // 
            this.Style.DataPropertyName = "Style";
            this.Style.HeaderText = "型体";
            this.Style.Name = "Style";
            // 
            // HourQty
            // 
            this.HourQty.DataPropertyName = "HourQty";
            this.HourQty.HeaderText = "成型时产";
            this.HourQty.Name = "HourQty";
            this.HourQty.Width = 80;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "Name";
            this.Name1.HeaderText = "客户型体";
            this.Name1.Name = "Name1";
            this.Name1.Width = 120;
            // 
            // ModelNo
            // 
            this.ModelNo.DataPropertyName = "ModelNo";
            this.ModelNo.HeaderText = "成底编号";
            this.ModelNo.Name = "ModelNo";
            // 
            // RBcode
            // 
            this.RBcode.DataPropertyName = "RBcode";
            this.RBcode.HeaderText = "RB编号";
            this.RBcode.Name = "RBcode";
            // 
            // MDcode
            // 
            this.MDcode.DataPropertyName = "MDcode";
            this.MDcode.HeaderText = "MD编号";
            this.MDcode.Name = "MDcode";
            // 
            // Editionhandle
            // 
            this.Editionhandle.DataPropertyName = "Editionhandle";
            this.Editionhandle.HeaderText = "楦头编号";
            this.Editionhandle.Name = "Editionhandle";
            // 
            // Innor
            // 
            this.Innor.DataPropertyName = "Innor";
            this.Innor.HeaderText = "鞋垫编号";
            this.Innor.Name = "Innor";
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.HeaderText = "型体年月";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Width = 80;
            // 
            // NewCode
            // 
            this.NewCode.DataPropertyName = "NewCode";
            this.NewCode.HeaderText = "型体接单年月";
            this.NewCode.Name = "NewCode";
            this.NewCode.Width = 150;
            // 
            // btnALLStyle
            // 
            this.btnALLStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnALLStyle.Location = new System.Drawing.Point(218, 3);
            this.btnALLStyle.Margin = new System.Windows.Forms.Padding(2);
            this.btnALLStyle.Name = "btnALLStyle";
            this.btnALLStyle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnALLStyle.Size = new System.Drawing.Size(87, 49);
            this.btnALLStyle.TabIndex = 33;
            this.btnALLStyle.Text = "型体更新";
            this.btnALLStyle.UseVisualStyleBackColor = true;
            this.btnALLStyle.Click += new System.EventHandler(this.btnALLStyle_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(8, 6);
            this.test.Margin = new System.Windows.Forms.Padding(2);
            this.test.Multiline = true;
            this.test.Name = "test";
            this.test.ReadOnly = true;
            this.test.Size = new System.Drawing.Size(207, 45);
            this.test.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(423, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "型体大类";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtStyleBase
            // 
            this.txtStyleBase.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStyleBase.Location = new System.Drawing.Point(419, 25);
            this.txtStyleBase.Margin = new System.Windows.Forms.Padding(2);
            this.txtStyleBase.Name = "txtStyleBase";
            this.txtStyleBase.Size = new System.Drawing.Size(159, 26);
            this.txtStyleBase.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(585, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "型体";
            // 
            // txtStyle
            // 
            this.txtStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStyle.Location = new System.Drawing.Point(581, 24);
            this.txtStyle.Margin = new System.Windows.Forms.Padding(2);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(159, 26);
            this.txtStyle.TabIndex = 48;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(743, 25);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 26);
            this.txtName.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(741, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "客戶型体";
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDate.Location = new System.Drawing.Point(309, 3);
            this.cbDate.Margin = new System.Windows.Forms.Padding(2);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(107, 20);
            this.cbDate.TabIndex = 52;
            this.cbDate.Text = "新型体年月";
            this.cbDate.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheck.Location = new System.Drawing.Point(1067, 3);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(82, 49);
            this.btnCheck.TabIndex = 53;
            this.btnCheck.Text = "查询";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(309, 24);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(2);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(107, 27);
            this.YearMounth.TabIndex = 32;
            // 
            // txtModelNo
            // 
            this.txtModelNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtModelNo.Location = new System.Drawing.Point(905, 24);
            this.txtModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(159, 26);
            this.txtModelNo.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(903, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "成底编号";
            // 
            // FrmStyleBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 500);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStyleBase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.test);
            this.Controls.Add(this.btnALLStyle);
            this.Controls.Add(this.YearMounth);
            this.Controls.Add(this.dgvStyleBase);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmStyleBase";
            this.Text = "型体基本资料";
            this.Activated += new System.EventHandler(this.FrmStyleBase_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStyleBase_FormClosing);
            this.Load += new System.EventHandler(this.FrmStyleBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyleBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvStyleBase;
        private System.Windows.Forms.Button btnALLStyle;
        private System.Windows.Forms.TextBox test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStyleBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StyleBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Style;
        private System.Windows.Forms.DataGridViewTextBoxColumn HourQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RBcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MDcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Editionhandle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Innor;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewCode;
    }
}