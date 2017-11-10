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
    public partial class frmAddUser : Form
    {
        static frmAddUser frm = null;
        public frmAddUser()
        {
            InitializeComponent();
        }
        RoleManager rmger = new RoleManager();
        public static frmAddUser GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            // if (frm == null)
            {
                frm = new frmAddUser();
            }
            frm.Activate();
            return frm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sysname = txtsysname.Text;
            string username = txtusername.Text;
            string userpwd = txtpwd.Text;
            sysname = sysname.Trim();
            username = username.Trim();
            userpwd = userpwd.Trim();
            if (sysname.Length <= 0 || username.Length <= 0 || userpwd.Length <= 0)
            {
                MessageBox.Show("用户姓名或系统登录名或密码为空");
                return;
            }
            //判断是否已有此用户
            DataTable td = rmger.getRoleBySysName(sysname);
            if (td.Rows.Count > 0)
            {
                MessageBox.Show("系统已有此用户名，请更改");
                txtsysname.Focus();
                txtsysname.SelectAll();

                return;
            }

            Guid rouid = Guid.NewGuid();
            int count = rmger.adduser(rouid, sysname, username, userpwd);
            if (count == 0)
            {
                MessageBox.Show("添加用户失败");
                return;
            }
            MessageBox.Show("添加用户成功");
            reset();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            reset();
        }
        public void reset()
        {
            txtsysname.Text = "";
            txtusername.Text = "";
            txtpwd.Text = "";
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
