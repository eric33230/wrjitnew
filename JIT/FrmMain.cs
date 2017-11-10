using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JIT

{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 打开人员管理窗体  -void tsmiPersonManager_Click(object sender, EventArgs e)
        /// <summary>
        /// 打开人员管理窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPersonManager_Click(object sender, EventArgs e)
        {
            //FrmPerson frm = FrmPerson.GetSingleton();
            //frm.MdiParent = this; //指定打开的子窗体的父容器为当前主窗体
            //frm.Show();
        } 
        #endregion

        #region 打开班级管理窗体  -void tsmiClassManager_Click(object sender, EventArgs e)
        /// <summary>
        /// 打开班级管理窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiClassManager_Click(object sender, EventArgs e)
        {
            //FrmClasses frm = FrmClasses.GetSingleton();
            //frm.MdiParent = this;
            //frm.Show();
        } 
        #endregion

        #region 使用集合的方法完成不重复打开窗体  -void tsmiUpdatePwd_Click(object sender, EventArgs e)
        /// <summary>
        /// 使用集合的方法完成不重复打开窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiUpdatePwd_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void 地區ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (Application.OpenForms["FrmArea"] != null)
            //{
            //    Application.OpenForms["FrmArea"].Show();
            //}
            //else
            //{
            //    FrmArea frm = new FrmArea();
            //    frm.MdiParent = this;
            //    frm.Show();
            //}
        }

        private void ArearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (Application.OpenForms["FrmArea"] != null)
            //{
            //    Application.OpenForms["FrmArea"].Show();
            //}
            //else
            //{
            //    FrmArea frm = new FrmArea();
            //    frm.MdiParent = this;
            //    frm.Show();
            //}
        }

        private void 班級管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmClasses frm = FrmClasses.GetSingleton();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 學員管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
       

            //FrmPerson frm = FrmPerson.GetSingleton();
            //frm.MdiParent = this; //指定打开的子窗体的父容器为当前主窗体
            //frm.Show();
        }

        private void tsmiPersonManager1_Click(object sender, EventArgs e)
        {

        }

        private void tsmiUpUserName_Click(object sender, EventArgs e)
        {

        }

        private void tsmiClassManager_Click_1(object sender, EventArgs e)
        {
            //FrmClasses frm = FrmClasses.GetSingleton();
            //frm.MdiParent = this;
            //frm.Show();


        }

        private void tsmiFeedBackManager_Click(object sender, EventArgs e)
        {

        }
    }
}
