using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using System.Net;

namespace WinForm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        //创建一个全局公共的person业务层管理类
        BLL.PersonManager pm = new BLL.PersonManager();
        string PLoginName = "";
        string PLoginPWD = "";
        string hname = Dns.GetHostName(); //得到本机的主机名  
        #region 登陆操作  +void btnLogin_Click(object sender, EventArgs e)
        /// <summary>
        /// 登陆操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
             PLoginName = txtUserName.Text.Trim();
             PLoginPWD = txtUserPassword.Text.Trim();
            login(PLoginName, PLoginPWD);

        } 
        #endregion
        public void login(string PLoginName, string PLoginPWD)
        {
            if (pm.Login(PLoginName, PLoginPWD) == null)
            {
                MessageBox.Show("用户名或密码错误");
                return;
            }
            List<string> uname = pm.Login(PLoginName, PLoginPWD);
            string louid = uname[0].ToString();
            string loname = uname[1].ToString();
            msgDiv.MsgDivShow("登陆成功", 5, UpDia);
            FrmMain frm = new FrmMain(louid, loname);
            frm.Show();
            this.Hide();
        }

        public void UpDia()
        {
            this.DialogResult = DialogResult.Yes; //系统就认为这个对话框你点击了其中的一个按钮
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //條碼有帶回車健
            if (e.KeyCode == Keys.Enter)
            {
                 PLoginName = txtUserName.Text.Trim();
                 PLoginPWD = txtUserPassword.Text.Trim();
                // invoke
                this.Invoke(new Action(
                  delegate
                  {
                      login(PLoginName,PLoginPWD);
                    

                  }));
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if(hname=="ERIC")
            {
                txtUserName.Text="ERIC";
                txtUserPassword.Text = "1";
            }
            if (hname.Equals("IT-XIAOMING") || hname.Equals("IT-PC"))
            {
                txtUserName.Text = "xiaoming   ";
                txtUserPassword.Text = "1";
            }

        }
    }
}
