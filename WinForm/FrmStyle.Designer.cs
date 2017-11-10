namespace WinForm
{
    partial class FrmStyle
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
            this.dgvStyle = new System.Windows.Forms.DataGridView();
            this.YearMounth = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStyle
            // 
            this.dgvStyle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStyle.Location = new System.Drawing.Point(1, 55);
            this.dgvStyle.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStyle.Name = "dgvStyle";
            this.dgvStyle.RowTemplate.Height = 30;
            this.dgvStyle.Size = new System.Drawing.Size(1222, 343);
            this.dgvStyle.TabIndex = 0;
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CalendarFont = new System.Drawing.Font("PMingLiU", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(1, 8);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(2);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.ShowUpDown = true;
            this.YearMounth.Size = new System.Drawing.Size(121, 46);
            this.YearMounth.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(159, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 46);
            this.button1.TabIndex = 34;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 422);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1222, 164);
            this.dataGridView1.TabIndex = 35;
            // 
            // FrmStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 500);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.YearMounth);
            this.Controls.Add(this.dgvStyle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmStyle";
            this.Text = "FrmStyle";
            this.Activated += new System.EventHandler(this.FrmStyle_Activated);
            this.Load += new System.EventHandler(this.FrmStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStyle;
        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}