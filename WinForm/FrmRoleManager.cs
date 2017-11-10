using BLL;
using MODEL;
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
    public partial class FrmRoleManager : Form
    {
        public FrmRoleManager()
        {
            InitializeComponent();
        }
        static FrmRoleManager frm = null;
        string meuid = "";
        string[] stroles = new string[3];

        public static FrmRoleManager GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            // if (frm == null)
            {
                frm = new FrmRoleManager();
            }
            return frm;
        }


        RoleManager rmger = new RoleManager();


        private void FrmRoleManager_Load(object sender, EventArgs e)
        {
            Loadmenu();//加载菜单

        }

        public void Loadroles(string meuid)
        {
            //查找有选定菜单权限的用户           
            DataTable roles = rmger.getMenuBymeuid(meuid);
            dgroles.Rows.Clear();
            dgnomeroles.Rows.Clear();
            for (int i = 0; i < roles.Rows.Count; i++)
            {
                string rouid = Convert.ToString(roles.Rows[i]["rouid"]);
                DataTable logodt = rmger.getRoleByRouid(rouid);
                if (logodt.Rows.Count > 0)
                {
                    for (int j = 0; j < logodt.Rows.Count; j++)
                    {
                        dgroles.Rows.Add();
                        dgroles.Rows[dgroles.Rows.Count - 1].Cells["roleGuid"].Value = Convert.ToString(logodt.Rows[j]["guid"]);
                        dgroles.Rows[dgroles.Rows.Count - 1].Cells["loginname"].Value = Convert.ToString(logodt.Rows[j]["loginname"]);
                        dgroles.Rows[dgroles.Rows.Count - 1].Cells["username"].Value = Convert.ToString(logodt.Rows[j]["username"]);
                    }

                }
            }

            //查找无选定菜单权限的用户  
            roles = rmger.getMenuByNomeuid(meuid);
            //if (roles.Rows.Count <= 0)
            //{
            //    roles = rmger.getAllRole();
            //}
            for (int i = 0; i < roles.Rows.Count; i++)
            {
                dgnomeroles.Rows.Add();
                dgnomeroles.Rows[i].Cells["noroleGuid"].Value = Convert.ToString(roles.Rows[i]["guid"]);
                dgnomeroles.Rows[i].Cells["nologinname"].Value = Convert.ToString(roles.Rows[i]["loginname"]);
                dgnomeroles.Rows[i].Cells["nousername"].Value = Convert.ToString(roles.Rows[i]["username"]);

            }

        }
        public void Loadmenu()
        {

            //***************************
            // 根节点ID值
            int fmuid = 0;
            this.treeView1.Nodes.Clear();
            AddTree(Convert.ToString(fmuid), (TreeNode)null);
            treeView1.HideSelection = true;
            treeView1.ShowLines = true;
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
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    Node.Text = Row[strName].ToString();
                    Node.Name = Row[strName].ToString();
                    Node.Tag = Row[strID].ToString();
                    Node.ImageIndex = 1;
                    this.treeView1.Nodes.Add(Node);
                    AddTree(Row[strID].ToString(), Node); //再次递归
                }
                else
                {
                    Node.Text = Row[strName].ToString();
                    Node.Name = Row[strName].ToString();
                    Node.Tag = Row[strID].ToString();
                    Node.ImageIndex = 1;
                    pNode.Nodes.Add(Node);
                    AddTree(Row[strID].ToString(), Node); //再次递归
                }
            }
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            meuid = Convert.ToString(e.Node.Tag);
            txemuname.Text = Convert.ToString(e.Node.Text);
            //MessageBox.Show(guid);
            //双击动作
            Loadroles(meuid);//查找有选定菜单权限的用户
        }
        private void dgnomeroles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            stroles[0] = this.dgnomeroles.Rows[e.RowIndex].Cells[0].Value.ToString();
            stroles[1] = this.dgnomeroles.Rows[e.RowIndex].Cells[1].Value.ToString();
            stroles[2] = this.dgnomeroles.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.dgnomeroles.Rows.RemoveAt(e.RowIndex);


            dgroles.Rows.Add();
            dgroles.Rows[dgroles.Rows.Count - 1].Cells["roleGuid"].Value = stroles[0];
            dgroles.Rows[dgroles.Rows.Count - 1].Cells["loginname"].Value = stroles[1];
            dgroles.Rows[dgroles.Rows.Count - 1].Cells["username"].Value = stroles[2];
            //  stroles = null;

            //MessageBox.Show(stroles[0]);
        }

        private void dgroles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            stroles[0] = this.dgroles.Rows[e.RowIndex].Cells[0].Value.ToString();
            stroles[1] = this.dgroles.Rows[e.RowIndex].Cells[1].Value.ToString();
            stroles[2] = this.dgroles.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.dgroles.Rows.RemoveAt(e.RowIndex);


            dgnomeroles.Rows.Add();
            dgnomeroles.Rows[dgnomeroles.Rows.Count - 1].Cells["noroleGuid"].Value = stroles[0];
            dgnomeroles.Rows[dgnomeroles.Rows.Count - 1].Cells["nologinname"].Value = stroles[1];
            dgnomeroles.Rows[dgnomeroles.Rows.Count - 1].Cells["nousername"].Value = stroles[2];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updatePermissionByMeuid(meuid);
        }
        public void updatePermissionByMeuid(string meuid)
        {
            //保存表格权限信息到数据库  
            //原有 现在有  不动
            //原没有  现在有  增加
            //原有 现在没有  删除
            DataTable tb = rmger.getPermissionByMeuid(meuid);//获取旧有权限表
            DataTable netptb = new DataTable();//新增权限用户（所有）
            DataTable deltb = new DataTable();//要删除的用户
                                              //if (dgroles.Rows.Count<=0)
                                              //{
                                              //    //全部删除用户
                                              //}
                                              //生成现在权限表
            DataColumn mguid = new DataColumn("rouid", typeof(Guid));
            DataColumn mrouid = new DataColumn("loginname", typeof(string));
            DataColumn mmeuid = new DataColumn("username", typeof(string));
            netptb.Columns.Add(mguid);
            netptb.Columns.Add(mrouid);
            netptb.Columns.Add(mmeuid);

            for (int i = 0; i < dgroles.Rows.Count; i++)
            {
                DataRow dr = netptb.NewRow();
                for (int countsub = 0; countsub < dgroles.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgroles.Rows[i].Cells[countsub].Value);
                }
                netptb.Rows.Add(dr);//
            }
            List<string> netptbuid = new List<string>();
            List<string> tbuid = new List<string>();

            if (tb.Rows.Count > 0)//比较 删除
            {

                for (int i = 0; i < tb.Rows.Count; i++) //原先没有  现在有 增加现在有的  原有权限不动
                {
                    string guid = Convert.ToString(tb.Rows[i]["rouid"]);
                    for (int j = 0; j < netptb.Rows.Count; j++)
                    {
                        string rouid = Convert.ToString(netptb.Rows[j]["rouid"]);
                        if (guid == rouid)
                        {
                            //记录要删的GUID
                            netptbuid.Add(Convert.ToString(netptb.Rows[j]["rouid"]));
                            tbuid.Add(Convert.ToString(tb.Rows[i]["rouid"]));
                          //  netptb.Rows.RemoveAt(j);//删除新表已有用户 剩下要增加的权限
                          //  tb.Rows.RemoveAt(i);//删除旧表已有用户 剩下要删除的权限
                           
                        }

                    }
                }
            }
            if (netptbuid.Count>0)
            {
                for (int i=0;i< netptbuid.Count;i++)
                {
                    string guid =netptbuid[i];
                    for (int j=0;j<netptb.Rows.Count;j++)
                    {
                        string rouid = Convert.ToString(netptb.Rows[j]["rouid"]);
                        if (guid == rouid)
                        {
                            netptb.Rows.RemoveAt(j);//删除新表已有用户 剩下要增加的权限                          
                            break;
                        }
                    }                    
                  //  netptb.Rows[i][""]
                 //   netptb.Rows.RemoveAt(i);
                }
                netptbuid.Clear();
            }
            if (tbuid.Count > 0)
            {
                for (int i = 0; i < tbuid.Count; i++)
                {
                    string guid = tbuid[i];
                    for (int j = 0; j < tb.Rows.Count; j++)
                    {
                        string rouid = Convert.ToString(tb.Rows[j]["rouid"]);
                        if (guid == rouid)
                        {
                            tb.Rows.RemoveAt(j);//删除新表已有用户 剩下要增加的权限                          
                            break;
                        }
                    }
                    //  netptb.Rows[i][""]
                    //   netptb.Rows.RemoveAt(i);
                }
                tbuid.Clear();

                //for (int i = 0; i < tbuid.Count; i++)
                //{
                //    tb.Rows.RemoveAt(i);
                //}
                //tbuid.Clear();
            }


            //更新用户权限进去
            //增加
            if (netptb.Rows.Count > 0)
            {
                for (int i = 0; i < netptb.Rows.Count; i++)
                {
                    if (meuid.Length <= 0)
                    {
                        MessageBox.Show("请先选择菜单");
                    }
                    rmger.addPermissionByMeuid(Convert.ToString(netptb.Rows[i]["rouid"]), meuid);
                }

            }
            //删除
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (meuid.Length <= 0)
                    {
                        MessageBox.Show("请先选择菜单");
                    }
                    rmger.delPermissionByMeuid(Convert.ToString(tb.Rows[i]["rouid"]), meuid);
                }

            }


            MessageBox.Show("用户菜单权限设置完成！");

        }

        private void btnadduser_Click(object sender, EventArgs e)
        {
            frmAddUser frm = frmAddUser.GetSingleton();
            frm.MdiParent = this.MdiParent;
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload();

        }
        public void reload()
        {
            Loadmenu();
            if (meuid.Length > 0)
            {
                Loadroles(meuid);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuManager_Click(object sender, EventArgs e)
        {
            FrmMenuManager frm = FrmMenuManager.GetSingleton();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void FrmRoleManager_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}