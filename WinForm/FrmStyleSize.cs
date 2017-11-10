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
    public partial class FrmStyleSize : Form
    {
        public FrmStyleSize()
        {
            InitializeComponent();
        }
        static FrmStyleSize frm;
        public static FrmStyleSize GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmStyleSize();
            }
            return frm;
        }



        private void FrmStyleSize_Load(object sender, EventArgs e)
        {

        }

        private void FrmStyleSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }


        List<MODEL.doc_StyleSize> sslist = new List<MODEL.doc_StyleSize>();


        BLL.doc_StyleSIzeManager ssm = new BLL.doc_StyleSIzeManager();


        private void button1_Click(object sender, EventArgs e)
        {
            sslist = ssm.GetAllStyleSize1(YearMounth.Text);
            this.dgvStyleSIze.DataSource = sslist;
        }

        private void dgvStyleSIze_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmStyleSize_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
