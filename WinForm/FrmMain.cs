using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm

{
    public partial class FrmMain : Form
    {
        string RoleId;
        string loname;
        const string FILENAME = "update.config";
        private zengzhouming.Update.UpdateConfig config = null;
        string lastver = "";
        public FrmMain(string RoleId, string loname)
        {
            InitializeComponent();
            this.RoleId = RoleId;
            this.loname = loname;
        }
        MemuManager mm = new MemuManager();
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
            FrmPerson frm = FrmPerson.GetSingleton();
            frm.MdiParent = this; //指定打开的子窗体的父容器为当前主窗体
            frm.Show();
            frm.Activate();
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
            //frm.Activate();
        } 
        #endregion


        private void tsmiUpUserName_Click(object sender, EventArgs e)
        {

        }



        private void tsmiFeedBackManager_Click(object sender, EventArgs e)
        {

        }

        private void tsmiOrderIn_Click(object sender, EventArgs e)
        {
            FrmOrder frm = FrmOrder.GetSingleton();
            frm.MdiParent = this;
            
            frm.Show();
            frm.Activate();
        }



        private void tsmiHR_Click(object sender, EventArgs e)
        {


        }

        private void tsmiArea_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["FrmArea"] != null)
            //{
            //    Application.OpenForms["FrmArea"].Show();
            //}
            //else
            //{
            //FrmArea frm = new FrmArea();
            //frm.MdiParent = this;
            //frm.Show();
            //frm.Activate();
            //}

        }



        private void tsmiWorkCalendar_Click(object sender, EventArgs e)
        {

            //{
            //    if (Application.OpenForms["FrmCalendar"] != null)
            //    {
            //        Application.OpenForms["FrmCalendar"].Show();
            //    }
            //    else
            //    {
            //        FrmCalendar frm = new FrmCalendar();
            //        frm.MdiParent = this;
            //        frm.Show();
            //    }
            //}
            FrmCalendar frm = FrmCalendar.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();


        }

        private void tsmiHoliday_Click(object sender, EventArgs e)
        {
            FrmHoliday frm = FrmHoliday.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiQAcheck_Click(object sender, EventArgs e)
        {
            
            FrmBarcodeRecord frm = FrmBarcodeRecord.GetSingleton();
            frm.MdiParent = this;
//            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            frm.Activate();
        }

        private void tsmiInnerboxIn_Click(object sender, EventArgs e)
        {
            FrmInnerboxOld frm = FrmInnerboxOld.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiSize_Click(object sender, EventArgs e)
        {
            FrmStyleSize frm = FrmStyleSize.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

        }

        private void tsmiInnerbox_Click(object sender, EventArgs e)
        {
            FrmInnerboxOld frm = FrmInnerboxOld.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiStyle_Click(object sender, EventArgs e)
        {
            FrmStyle frm = FrmStyle.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           // this.Text = this.Text + " 欢迎您： " + loname;
            InitMenuItem();//设置所有菜单项
            SetMenuItemByRole();
            notifyIcon1.Visible = false;

            config = zengzhouming.Update.UpdateConfig.LoadConfig(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
            if (config != null && config.UpdateFileList.Count > 0)
            {
                lastver = config.UpdateFileList[0].LastVer.ToString();
            }
            this.Text = this.Text + " 欢迎您： " + loname + "   版本号:" + lastver;


        }
        private void InitMenuItem()
        {
            DataTable dt = mm.InitMenuItem();
            foreach (DataRow dr in dt.Rows)
            {

                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = dr[3].ToString(); //menuname
                if (menuStrip1.Items[item.Name]!=null)
                {
                    menuStrip1.Items[item.Name].Enabled = false;
                    InitSubMenuItem(menuStrip1.Items[item.Name]);
                }
               
               
            }
        }
        private void InitSubMenuItem(ToolStripItem item)
        {
            string mname = item.Name;

            ToolStripMenuItem pItem = (ToolStripMenuItem)item;
            DataTable dt = mm.GetMenuByfm(mname);
            //根据父菜单项加载子菜单 
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();
                    subItem.Name = dr[3].ToString();
                    try
                    {
                        if (pItem.DropDownItems[subItem.Name] == null)
                        {

                        }else
                        {
                            pItem.DropDownItems[subItem.Name].Enabled = false;
                        }

                       

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                      //没有菜单 的项  
                    }
                }
            }
        }
        private void SetMenuItemByRole()
        {

            DataTable dt = mm.SetMenuItemByRole(RoleId);
            // dt = null;
            foreach (DataRow dr in dt.Rows)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = dr[3].ToString();//一级菜单的menuname
                                             //menuStrip1.Items[item.Name]
                if (menuStrip1.Items[item.Name] != null)
                {
                    menuStrip1.Items[item.Name].Enabled = true;//各一级菜单是主菜单menuStrip2集合的项
                    SetSubMenuItemByRole(menuStrip1.Items[item.Name]);//将一级菜单对应主菜单menuStrip2集合的项传给子菜单设置函数
                }
                

            }
        }
        private void SetSubMenuItemByRole(ToolStripItem item)
        {
            string mname = item.Name;

            ToolStripMenuItem pItem = (ToolStripMenuItem)item;

            //根据父菜单项加载子菜单


            DataTable dt = mm.SetSubMenuItemByRole(mname, RoleId);


            if (dt.Rows.Count != 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();
                    subItem.Name = dr[3].ToString();

                    try
                    {
                        if (pItem.DropDownItems[subItem.Name] != null)
                        {
                            pItem.DropDownItems[subItem.Name].Enabled = true;
                        }
                       

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            else
            {

            }

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void tsmiStyleOrder_Click(object sender, EventArgs e)
        {
            FrmOrder frm = FrmOrder.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiStyleBase_Click(object sender, EventArgs e)
        {
            FrmStyleBase frm = FrmStyleBase.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiBuyer_Click(object sender, EventArgs e)
        {
            FrmBuyer frm = FrmBuyer.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiInnerBox_Click(object sender, EventArgs e)
        {
            FrmInnerBox frm = FrmInnerBox.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();


            //FrmInnerBoxin frm = FrmInnerBoxin.GetSingleton();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void tsmiCarton_Click(object sender, EventArgs e)
        {
            FrmCarton frm = FrmCarton.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void 主計畫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// 接转考虑短交期的注释,
        }

        private void tsmiPacklist_Click(object sender, EventArgs e)
        {
            FrmPacklist frm = FrmPacklist.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiOrder_Click(object sender, EventArgs e)
        {
            FrmOrder frm = FrmOrder.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();


        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

    //        FrmBarcode frm = FrmBarcode.GetSingleton();
      //      frm.MdiParent = this;
           //             frm.WindowState = FormWindowState.Maximized;
       //     frm.Show();
        }

        private void tsmiWHin_Click(object sender, EventArgs e)
        {
            FrmWHin frm = FrmWHin.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiRoleManager_Click(object sender, EventArgs e)
        {
            FrmRoleManager frm = FrmRoleManager.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //测试分支合并
                e.Cancel = true;    //取消"关闭窗口"事件
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(30, "颖强鞋业", "我在这,单击可以恢复哦!", ToolTipIcon.Info);//最小化到托盘后用气泡形式提示  
                this.Hide();
                return;
            }
        }

        private void tsmicolseallwind_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)   //当子窗体个数大于0的时候遍历所有子窗体
            {
                foreach (Form myForm in this.MdiChildren)// 遍历所有子窗体

                    myForm.Close(); //关闭子窗体
            }
        }

        private void tsmiTestNetwork_Click(object sender, EventArgs e)
        {
            FrmTestNetwork frm = FrmTestNetwork.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiScanSee_Click(object sender, EventArgs e)
        {
            FrmScanSee frm = FrmScanSee.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();


        }
         
        private void tsmiDepartment_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = FrmDepartment.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

             
        }

        private void tsmiOrderIn_Click_1(object sender, EventArgs e)
        {

            frmOrderInFromERPDB frm = frmOrderInFromERPDB.GetSingleton();
            frm.MdiParent = this;
            // frm.ShowDialog();
            frm.Show();
            frm.Activate();
        }

        private void tsmiPackListers_Click(object sender, EventArgs e)
        {

            PackingList frm = PackingList.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiwxbarPrints_Click(object sender, EventArgs e)
        {
            FrmOutsideBarCodePrint frm = new FrmOutsideBarCodePrint();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmiMuneManager_Click(object sender, EventArgs e)
        {
            FrmMenuManager frm = FrmMenuManager.GetSingleton();
            frm.MdiParent = this;
            frm.Show();

            frm.Activate();
        }

        private void tsmifingerprintManager_Click(object sender, EventArgs e)
        {
            FrmFingerprintManager frm = FrmFingerprintManager.GetSingleton();
            frm.MdiParent = this;
            frm.Show();

            frm.Activate();
        }

        private void tsmiKQDaily_Click(object sender, EventArgs e)
        {
            FrmKQDaily frm = FrmKQDaily.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
           frm.Activate();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(30, "颖强鞋业", "我在这,单击可以恢复哦!", ToolTipIcon.Info);//最小化到托盘后用气泡形式提示  
                this.Hide();
                //notifyIcon1.Visible = true;    //显示托盘图标
                // this.Hide();    //隐藏窗口

            }
        }
        
       

        private void tsmiQAREcheck_Click(object sender, EventArgs e)
        {
            FrmReBarcodeScan frm = FrmReBarcodeScan.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;//显示窗体  
            this.WindowState = FormWindowState.Maximized;
            this.notifyIcon1.Visible = false;//隐藏系统托盘图标 
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void tsmipdinventory_Click(object sender, EventArgs e)
        {
            Frmpdinventory frm = Frmpdinventory.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tsmipdMaterial_Click(object sender, EventArgs e)
        {
            FrmPDMaterial frm = FrmPDMaterial.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
    }
}
