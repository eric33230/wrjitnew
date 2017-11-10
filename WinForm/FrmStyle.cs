using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Management;
using System.Net.Sockets;
using System.IO;

namespace WinForm
{
    public partial class FrmStyle : Form
    {
        public FrmStyle()
        {
            InitializeComponent();
        }



        static FrmStyle frm;
        public static FrmStyle GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmStyle();
            }
            return frm;
        }


        private void FrmStyle_Load(object sender, EventArgs e)
        {

        }

 
        List<MODEL.doc_Style> slist = new List<MODEL.doc_Style>();

        BLL.doc_StyleManager sm = new BLL.doc_StyleManager();





        private void button1_Click(object sender, EventArgs e)
        {
            //         slist = sm.GetAllStyle();
            //           this.dgvStyle.DataSource = slist;
          //  string ip = "";
            string hname = Dns.GetHostName(); //得到本机的主机名  
            MessageBox.Show(hname);
            //System.Net.IPHostEntry entry = System.Net.Dns.GetHostEntry (System.Net.Dns.GetHostName());
           // string ipAddress = entry.AddressList[0].ToString();
            //string mip = GetSelfIpv4List();
           // string mip1 = GetIPAddress();
           // MessageBox.Show(mip1);






        }

        private void dgvStyleSIze_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmStyle_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
