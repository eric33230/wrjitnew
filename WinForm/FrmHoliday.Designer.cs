namespace WinForm
{
    partial class FrmHoliday
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvHoloday = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.explain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtYear = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.开始 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtYear1 = new System.Windows.Forms.DateTimePicker();
            this.btnDelHoliday = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoloday)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "MM\'-\'dd";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(585, 113);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(142, 21);
            this.dtFrom.TabIndex = 0;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "MM\'-\'dd";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(585, 155);
            this.dtTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(142, 21);
            this.dtTo.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(585, 80);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 21);
            this.txtName.TabIndex = 2;
            // 
            // dgvHoloday
            // 
            this.dgvHoloday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoloday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.explain,
            this.time_f,
            this.time_t});
            this.dgvHoloday.Location = new System.Drawing.Point(8, 31);
            this.dgvHoloday.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHoloday.MultiSelect = false;
            this.dgvHoloday.Name = "dgvHoloday";
            this.dgvHoloday.RowHeadersWidth = 20;
            this.dgvHoloday.RowTemplate.Height = 31;
            this.dgvHoloday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoloday.Size = new System.Drawing.Size(445, 579);
            this.dgvHoloday.TabIndex = 3;
            this.dgvHoloday.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvHoloday_CellBeginEdit);
            this.dgvHoloday.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoloday_CellClick);
            this.dgvHoloday.SelectionChanged += new System.EventHandler(this.dgvHoloday_SelectionChanged);
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "年";
            this.date.Name = "date";
            this.date.Width = 40;
            // 
            // explain
            // 
            this.explain.DataPropertyName = "explain";
            this.explain.HeaderText = "节假日";
            this.explain.Name = "explain";
            this.explain.Width = 150;
            // 
            // time_f
            // 
            this.time_f.DataPropertyName = "time_f";
            this.time_f.HeaderText = "开始";
            this.time_f.Name = "time_f";
            this.time_f.Width = 50;
            // 
            // time_t
            // 
            this.time_t.DataPropertyName = "time_t";
            this.time_t.HeaderText = "结束";
            this.time_t.Name = "time_t";
            this.time_t.Width = 50;
            // 
            // dtYear
            // 
            this.dtYear.CustomFormat = "yyyy";
            this.dtYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtYear.Location = new System.Drawing.Point(585, 15);
            this.dtYear.Margin = new System.Windows.Forms.Padding(2);
            this.dtYear.Name = "dtYear";
            this.dtYear.Size = new System.Drawing.Size(142, 21);
            this.dtYear.TabIndex = 4;
            this.dtYear.ValueChanged += new System.EventHandler(this.dtYear_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "节假日";
            // 
            // 开始
            // 
            this.开始.AutoSize = true;
            this.开始.Location = new System.Drawing.Point(540, 121);
            this.开始.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.开始.Name = "开始";
            this.开始.Size = new System.Drawing.Size(29, 12);
            this.开始.TabIndex = 9;
            this.开始.Text = "开始";
            this.开始.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "结束";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 201);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 41);
            this.button1.TabIndex = 11;
            this.button1.Text = "增加节日";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtYear1
            // 
            this.dtYear1.CustomFormat = "yyyy";
            this.dtYear1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtYear1.Location = new System.Drawing.Point(8, 8);
            this.dtYear1.Margin = new System.Windows.Forms.Padding(2);
            this.dtYear1.Name = "dtYear1";
            this.dtYear1.Size = new System.Drawing.Size(102, 21);
            this.dtYear1.TabIndex = 12;
            this.dtYear1.ValueChanged += new System.EventHandler(this.dtYear1_ValueChanged);
            // 
            // btnDelHoliday
            // 
            this.btnDelHoliday.Location = new System.Drawing.Point(357, 5);
            this.btnDelHoliday.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelHoliday.Name = "btnDelHoliday";
            this.btnDelHoliday.Size = new System.Drawing.Size(96, 22);
            this.btnDelHoliday.TabIndex = 14;
            this.btnDelHoliday.Text = "删除节日";
            this.btnDelHoliday.UseVisualStyleBackColor = true;
            this.btnDelHoliday.Click += new System.EventHandler(this.btnDelHoliday_Click);
            // 
            // FrmHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 500);
            this.Controls.Add(this.btnDelHoliday);
            this.Controls.Add(this.dtYear1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.开始);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtYear);
            this.Controls.Add(this.dgvHoloday);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmHoliday";
            this.Text = "节假日";
            this.Activated += new System.EventHandler(this.FrmHoliday_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmHoliday_FormClosed);
            this.Load += new System.EventHandler(this.FrmHoliday_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoloday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvHoloday;
        private System.Windows.Forms.DateTimePicker dtYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label 开始;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtYear1;
        private System.Windows.Forms.Button btnDelHoliday;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn explain;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_f;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_t;
    }
}