namespace WinForm
{
    partial class FrmStyleSize
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
            this.dgvStyleSIze = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.YearMounth = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyleSIze)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStyleSIze
            // 
            this.dgvStyleSIze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStyleSIze.Location = new System.Drawing.Point(8, 58);
            this.dgvStyleSIze.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStyleSIze.Name = "dgvStyleSIze";
            this.dgvStyleSIze.RowTemplate.Height = 30;
            this.dgvStyleSIze.Size = new System.Drawing.Size(823, 491);
            this.dgvStyleSIze.TabIndex = 2;
            this.dgvStyleSIze.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStyleSIze_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 46);
            this.button1.TabIndex = 36;
            this.button1.Text = "查詢訂單尺碼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("PMingLiU", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(10, 17);
            this.YearMounth.Margin = new System.Windows.Forms.Padding(2);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(111, 33);
            this.YearMounth.TabIndex = 35;
            // 
            // FrmStyleSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.YearMounth);
            this.Controls.Add(this.dgvStyleSIze);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmStyleSize";
            this.Text = "FrmStyleSize";
            this.Activated += new System.EventHandler(this.FrmStyleSize_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStyleSize_FormClosing);
            this.Load += new System.EventHandler(this.FrmStyleSize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStyleSIze)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStyleSIze;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker YearMounth;
    }
}