using BLL;
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
    public partial class FrmTestNetwork : Form
    {
        public FrmTestNetwork()
        {
            InitializeComponent();
        }
        static FrmTestNetwork frm = null;
    　　TestLinManager testl = new TestLinManager();
        public static FrmTestNetwork GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            // if (frm == null)
            {
                frm = new FrmTestNetwork();
            }
            return frm;
        }

        private void btnlinkserver_Click(object sender, EventArgs e)
        {
            testLinServer();
        }

        private void btnlinkDB_Click(object sender, EventArgs e)
        {
            if (testLinServer()) {

                testOpenDB();
            }
        }
        private bool testLinServer()
        {
            string txtip = txtIP.Text.Trim();
            btnlinkserver.Enabled = false;
            btnlinkDB.Enabled = false;
            cbdbname.Enabled = false;
            txtdbuser.Enabled = false;
            txtdbpwd.Enabled = false;
            if (testl.LinServer(txtip))
            {
                btnlinkDB.Enabled = true;
                btnlinkserver.Enabled = true;                
                cbdbname.Enabled = true;
                txtdbuser.Enabled = true;
                txtdbpwd.Enabled = true;
                LabelTestLinServer.BackColor = Color.Lime;                
                LabelTestLinServer.Text = "连接服务器"+ txtip + "成功！";
                    return true;
            }
            else
            {
               
                for (int i = 1; i <= 5; i++)
                {
                    if (!testl.LinServer(txtip))
                    {
                        LabelTestLinServer.BackColor = Color.Red;
                        LabelTestLinServer.Text = "服务器连接失败！正在尝试重新连接，第 " + i.ToString() + " 次...";
                       
                    }
                    else
                    {
                        btnlinkDB.Enabled = true;
                        cbdbname.Enabled = true;
                        txtdbuser.Enabled = true;
                        txtdbpwd.Enabled = true;
                        LabelTestLinServer.BackColor = Color.Lime;
                        LabelTestLinServer.Text = "服务器已连接！";
                       
                        break;
                    }
                    
                }
                
                if (!testl.LinServer(txtip))
                {
                    LabelTestLinServer.BackColor = Color.Red;
                    LabelTestLinServer.Text = "服务器连接失败！请检查网络连接!";
                    //   btnlinkDB.Enabled = false;
                    btnlinkserver.Enabled = true;
                    // btnlinkDB.Visible = true;
                    return false;
                }
               
                return true;
            }
        }
        public void testOpenDB()
        {
            string txtip = txtIP.Text.Trim();
            string dbuser = txtdbuser.Text.Trim();
            string dbpwd = txtdbpwd.Text.Trim();
           // string txtip = txtIP.Text.Trim();
           // string connstr = "";
            string connstr = "Data Source="+ txtip + "; Initial Catalog=Master;User ID="+ dbuser + ";Password="+ dbpwd + ";Connect Timeout=0";
           List<string> list= testl.TestConnection(connstr);         

            cbdbname.Items.Clear();          
            
            for (int i=0;i< list.Count;i++)
            {
                cbdbname.Items.Add(list[i].ToString());
            }
            if (cbdbname.Items.Count>0)
            {
                    cbdbname.Focus();
                    cbdbname.DroppedDown = true;
            }
            //错误连接处理
            if (list[0].ToString() == "连接数据库错误")
            {
                LabelTestLinServer.BackColor = Color.Red;
                LabelTestLinServer.Text = "服务器连接成功，但数据库连接失败";
                cbdbname.Focus();
                cbdbname.DroppedDown = true;
                return;
            }
        }

        private void FrmTestNetwork_Load(object sender, EventArgs e)
        {

        }
    }
}
