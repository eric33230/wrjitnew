using BLL;
using MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static WinForm.AboutMenu;

namespace WinForm
{
    public partial class FrmMenuManager : Form
    {
        static FrmMenuManager frm = null;
        public FrmMenuManager()
        {
            InitializeComponent();
        }

        ArrayList al = new ArrayList();
        RoleManager rmger = new RoleManager();

        public static FrmMenuManager GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            // if (frm == null)
            {
                frm = new FrmMenuManager();
            }
            frm.Activate();
            return frm;
        }

        private void FrmMemuManager_Load(object sender, EventArgs e)
        {
            Loadmenu();
        }

        public void Loadmenu()
        {

            //***************************
            // 根节点ID值
            int fmuid = 0;
            this.tvList.Nodes.Clear();
            this.cbfmune.DataSource = null;
            this.cbfmune.Items.Clear();
            if (al.Count > 0)
            {
                al.Clear();
            }
            //  this.cbmune.Items.Clear();
            //  this.cbdelmune.Items.Clear();
            AddTree(Convert.ToString(fmuid), (TreeNode)null);
            tvList.HideSelection = true;
            tvList.ShowLines = true;
            //***************************

        }

        public void AddTree(string ParentID, TreeNode pNode)
        {
            // 数据库名字字段
            string strName = "muenamech";
            // 数据库ID字段
            string strID = "GUID";
            // 数据库父级ID字段
            string strParentID = "fmuid";
            DataTable dt = rmger.getAllMenus();
            DataView dvTree = new DataView(dt);
            dvTree.RowFilter = strParentID + "  = '" + ParentID + "'";

            cbfmune.DataSource = null;


            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                //添加一个数组
                if (pNode == null)
                {
                    Node.Text = Row[strName].ToString();
                    Node.Name = Row[strName].ToString();
                    Node.Tag = Row[strID].ToString();
                    Node.ImageIndex = 1;
                    this.tvList.Nodes.Add(Node);
                    //  cbfmune.Items.Add(Node.Text);
                    al.Add(new TextAndValue(Row[strName].ToString(), Row[strID].ToString()));
                    AddTree(Row[strID].ToString(), Node); //再次递归
                }
                else
                {
                    Node.Text = Row[strName].ToString();
                    Node.Name = Row[strName].ToString();
                    Node.Tag = Row[strID].ToString();
                    Node.ImageIndex = 1;
                    pNode.Nodes.Add(Node);
                    //  cbmune.Items.Add(Node.Text);
                    //al.Add(new TextAndValue(Row[strName].ToString(), Row[strID].ToString()));
                    //  cbdelmune.Items.Add(Node.Text);
                    AddTree(Row[strID].ToString(), Node); //再次递归
                }

            }
            cbfmune.DataSource = al;
            cbfmune.DisplayMember = "DisplayText";
            //cbfmune.ValueMember = "RealValue";
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            reload();
        }
        public void reload()
        {
            Loadmenu();

        }

        private void cbfmune_MouseClick(object sender, MouseEventArgs e)
        {

            // MessageBox.Show("1");
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            string muenamech = txtmunnamech.Text;
            string muenameen = txtmunnameen.Text;


            muenamech = muenamech.Trim();
            muenameen = muenameen.Trim();

            if (muenameen.Length <= 0 || muenamech.Length <= 0)
            {
                MessageBox.Show("显示菜单名与系统菜单名都不能为空");
                return;
            }
            //判断是否已有此菜单
            DataTable td = rmger.getBySysName(muenameen);
            if (td.Rows.Count > 0)
            {
                MessageBox.Show("系统已有此菜单，无需再添加一个");
                txtmunnameen.Text = "";
                txtmunnamech.Text = "";

                return;
            }
            //查找父GUID，名称
            string fguid = cbfmune.SelectedValue.ToString();
            T_menu menu = new T_menu();
            menu = rmger.getByfguid(fguid);
            if (menu != null)
            {
                Guid rouid = Guid.NewGuid();
                string fmname = menu.muenameen;
                string ordernos = menu.muenamech;
                if(ordernos.Length<=0)
                {
                    ordernos = "0";
                }
                
                int orderno = Convert.ToInt32(ordernos) + 1;

                int count = rmger.addmune(rouid, fguid, fmname, muenameen, muenamech, orderno);

                if (count == 0)
                {
                    MessageBox.Show("添加菜单失败");
                    return;
                }
                MessageBox.Show("添加菜单成功");
                //  reset();

            }


        }

        string eguid = "";

        private void tvList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            eguid = e.Node.Tag.ToString(); //点选的菜单GUID
            string ename = e.Node.Name.ToString(); //点选的菜单名
            txtckmune.Text = ename;
            labmune.Text = ename;
            labckmune.Text = ename;
        }

        private void btnchangmune_Click(object sender, EventArgs e)
        {
            if (eguid.Length<=0 || txtckmune.Text.Trim().Length<=0)
            {
                MessageBox.Show("菜单名不能为空");
                return;
            }
            string ename = txtckmune.Text.Trim();
            int result = 0;
            result=rmger.upmune(eguid, ename);
            if (result != 0)
            {
                MessageBox.Show("更新菜單名成功!");
                reload();
                txtckmune.Text = "";
            }
            else
            {
                MessageBox.Show("更新菜單名失敗!");
                reload();
                txtckmune.Text = "";
            }
        }

        private void btndeletemune_Click(object sender, EventArgs e)
        {
            if (eguid.Length <= 0 )
            {
                MessageBox.Show("請先雙擊要刪除的菜单名");
                return;
            }
          //  string ename = txtckmune.Text.Trim();
            int result = 0;
            result = rmger.delmune(eguid);
            if (result != 0)
            {
                MessageBox.Show("刪除完成!");
                reload();
                txtckmune.Text = "";
            }
            else
            {
                MessageBox.Show("刪除失敗!");
                reload();
                txtckmune.Text = "";
            }
        }

        private void btnchangNO_Click(object sender, EventArgs e)
        {
            if (eguid.Length <= 0)
            {
                MessageBox.Show("請先雙擊要更改順序的菜单名");
                return;
            }
            string orderno = txtorderno.Text;
            orderno = orderno.Trim();
            if (orderno.Length <= 0)
            {
                MessageBox.Show("請輸入順序號");
                return;
            }
           if(!isint(orderno))
            {
                MessageBox.Show("輸入有誤，請輸入正數字");
                return;
            }

            int neworderno = Convert.ToInt32(orderno);
           int result = rmger.changNO(eguid, neworderno);
            if (result != 0)
            {
                MessageBox.Show("更新完成!");
                reload();
                txtckmune.Text = "";
            }

        }
        public bool isint(string value)
        {
            return Regex.IsMatch(value, @"^[1-9]\d*$");
            　
             
        }
    }
}
