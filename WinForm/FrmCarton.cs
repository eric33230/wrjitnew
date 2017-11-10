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
    public partial class FrmCarton : Form
    {
        public FrmCarton()
        {
            InitializeComponent();
        }

        static FrmCarton frm;
        public static FrmCarton GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmCarton();
            }
            return frm;
        }




        private void FrmCarton_Load(object sender, EventArgs e)
        {

        }
    }
}
