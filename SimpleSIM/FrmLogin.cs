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

namespace SimpleSIM
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        //创建一个全局公共的person业务层管理类
        BLL.PersonManager pm = new BLL.PersonManager();

        #region 登陆操作  +void btnLogin_Click(object sender, EventArgs e)
        /// <summary>
        /// 登陆操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Person per = new Person() { PLoginName = txtUserName.Text.Trim(), PPwd = txtUserPassword.Text.Trim() };
            string msg = "";
            //UI层不可以自己完成登录验证，它只有业务层有关联，所以将获取的值传递给业务层进行处理
            //在业务层有没有相应的处理方法？
            if (pm.Login(per, ref msg))
            {
                msgDiv.MsgDivShow("登陆成功", 1, UpDia);               
                //FrmMain frm = new FrmMain();
                //frm.Show();
                //this.Close(); //关闭第一个打开的窗体，就相当于Application.Exit()
                //this.Hide();
                //this.Visible = false;
            }
            else
            {
                msgDiv.MsgDivShow("登陆失败");
            }
        } 
        #endregion

        public void UpDia()
        {
            this.DialogResult = DialogResult.Yes; //系统就认为这个对话框你点击了其中的一个按钮
        }
    }
}
