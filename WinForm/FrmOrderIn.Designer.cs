namespace WinForm
{
    partial class FrmOrderIn
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
            this.btnALLStyle = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // YearMounth
            // 
            this.YearMounth.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YearMounth.CustomFormat = "yyyy-MM";
            this.YearMounth.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YearMounth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearMounth.Location = new System.Drawing.Point(50, 22);
            this.YearMounth.Name = "YearMounth";
            this.YearMounth.Size = new System.Drawing.Size(184, 46);
            this.YearMounth.TabIndex = 2;
            // 
            // btnALLStyle
            // 
            this.btnALLStyle.Location = new System.Drawing.Point(50, 74);
            this.btnALLStyle.Name = "btnALLStyle";
            this.btnALLStyle.Size = new System.Drawing.Size(184, 109);
            this.btnALLStyle.TabIndex = 5;
            this.btnALLStyle.Text = "所有型体 這一個搞定";
            this.btnALLStyle.UseVisualStyleBackColor = true;
            this.btnALLStyle.Click += new System.EventHandler(this.btnALLStyle_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(262, 74);
            this.test.Multiline = true;
            this.test.Name = "test";
            this.test.ReadOnly = true;
            this.test.Size = new System.Drawing.Size(238, 109);
            this.test.TabIndex = 41;
            this.test.TextChanged += new System.EventHandler(this.test_TextChanged);
            // 
            // FrmOrderIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 422);
            this.Controls.Add(this.test);
            this.Controls.Add(this.btnALLStyle);
            this.Controls.Add(this.YearMounth);
            this.Name = "FrmOrderIn";
            this.Text = "訂單接轉";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrderIn_FormClosing);
            this.Load += new System.EventHandler(this.FrmOrderIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker YearMounth;
        private System.Windows.Forms.Button btnALLStyle;
        private System.Windows.Forms.TextBox test;
    }
}