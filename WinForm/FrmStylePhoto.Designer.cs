namespace WinForm
{
    partial class FrmStylePhoto
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
            this.picStylePhotos = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStylePhotos)).BeginInit();
            this.SuspendLayout();
            // 
            // picStylePhotos
            // 
            this.picStylePhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picStylePhotos.Location = new System.Drawing.Point(0, 0);
            this.picStylePhotos.Name = "picStylePhotos";
            this.picStylePhotos.Size = new System.Drawing.Size(988, 604);
            this.picStylePhotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStylePhotos.TabIndex = 1;
            this.picStylePhotos.TabStop = false;
            // 
            // FrmStylePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 604);
            this.Controls.Add(this.picStylePhotos);
            this.Name = "FrmStylePhoto";
            this.Text = "鞋型查看";
            this.Activated += new System.EventHandler(this.FrmStylePhoto_Activated);
            this.Load += new System.EventHandler(this.FrmStylePhoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStylePhotos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picStylePhotos;
    }
}