using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmStylePhoto : Form
    {
        Image image;
        public FrmStylePhoto(Image image)
        {
            InitializeComponent();
            this.image = image;
        }

        private void FrmStylePhoto_Load(object sender, EventArgs e)
        {
            this.picStylePhotos.Image = image;
            this.AutoSize = true;
        }

        private void FrmStylePhoto_Activated(object sender, EventArgs e)
        {

        }
    }
}
