using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSIM
{
    public partial class FrmArea : Form
    {
        
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frm"></param>
        public FrmArea()
        {
            InitializeComponent();
        } 
        #endregion
        FrmPerson frm;
        public FrmArea(FrmPerson frm)
        {
            InitializeComponent();//一定要记得调用初始化窗体控件的方法 
            //MessageBox.Show("1234567890");
            this.frm = frm;
        }
        IGetAreas frmInterface;
        public FrmArea(IGetAreas frmInterface)
        {
            InitializeComponent();//一定要记得调用初始化窗体控件的方法 
            //MessageBox.Show("aaaaaaaaaaaa");
            this.frmInterface = frmInterface;
        }
        FillData fd;
        public FrmArea(FillData fd)
        {
            InitializeComponent();//一定要记得调用初始化窗体控件的方法 
            //MessageBox.Show("4567sdfgh67");
            this.fd = fd;
        }
        #region 创建地区数据访问层对象  -BLL.AreasManager am
        /// <summary>
        /// 创建地区数据访问层对象
        /// </summary>
        BLL.AreasManager am = new BLL.AreasManager(); 
        #endregion

        //创建存储地区信息的集合
        List<MODEL.Areas> lists = null;

        #region 窗体加载，获取所有地区信息  -void FrmArea_Load(object sender, EventArgs e)
        /// <summary>
        /// 窗体加载，获取所有地区信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmArea_Load(object sender, EventArgs e)
        {
            lists = am.GetAllAreasList(false);
            LoadAreas(null, 0);
        } 
        #endregion

        #region 使用递归加载所有地区信息  -void LoadAreas(TreeNode parentNode, int id)
        /// <summary>
        /// 使用递归加载所有地区信息
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="id"></param>
        public void LoadAreas(TreeNode parentNode, int id)
        {
            for (int i = 0; i < lists.Count; i++)
            {
                if (id == lists[i].APid) //当对象的APID值==某个对象的AID值的时候，说明是它就是某个对象的子节点
                {
                    TreeNode node = new TreeNode(lists[i].AName);
                    //因为在数据表中需要存储的值是地区所对应的AID值，所以需要将其存储起来，选择存储在TAG里面是比较方便的
                    node.Tag = lists[i]; //将对象存储到节点的tag里面，方便以后有不同的需要
                    if (parentNode == null)//判断是否添加给根节点
                    {
                        this.tvList.Nodes.Add(node);
                    }
                    else
                    {
                        parentNode.Nodes.Add(node); //添加给当前节点
                    }
                    //递归的方式实现地区信息的添加
                    LoadAreas(node, lists[i].AID);
                }
            }
        } 
        #endregion

        #region 取消操作  -void btnCancel_Click(object sender, EventArgs e)
        /// <summary>
        /// 取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 确定，选择地区，得到地区的名称和ID值  - void btnOk_Click(object sender, EventArgs e)
        /// <summary>
        /// 确定，选择地区，得到地区的名称和ID值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //1.得到字符串值和所对应的AID值
            //string path = this.tvList.SelectedNode.FullPath; //只能得到一个字符串全路径，ID得不到
            TreeNode node = this.tvList.SelectedNode;
            StringBuilder sname = new StringBuilder();
            StringBuilder sid = new StringBuilder();
            if (node != null)
            {
                GetNameAndId(sname, sid, node);
            }
            //2.将值回传
            //传递窗体对象
            //this.frm.txtDistrict.Text = sname.ToString().Substring(0,sname.ToString().Length-1);
            //this.frm.txtDistrict.Tag = sid;
            //传递接口
            //frmInterface.GetValue(sname.ToString(), sid.ToString());
            //传递委托 
            fd(sname.ToString(), sid.ToString());
            this.Close(); //得到地区，关闭当前窗体
        } 
        #endregion

        #region 得到地区的组成名称和组成AID值
        /// <summary>
        /// 得到地区的组成名称和组成AID值
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="Sid"></param>
        /// <param name="node"></param>
        private void GetNameAndId(StringBuilder sName, StringBuilder Sid, TreeNode node)
        {
            MODEL.Areas ar = node.Tag as MODEL.Areas; //as做类型转换如果转换不成功，不会报错。只是返回null
            //if(ar ==null)
            //{
            //    return;
            //}            
            //如果有父节点，就继续得到父节点的值，这也是一个递归
            if (node.Parent != null)
            {
                GetNameAndId(sName, Sid, node.Parent);
            }
            sName.Append(ar.AName + "|");
            Sid.Append(ar.AID + "|");
        } 
        #endregion

        #region 翻转字符串，复习字符串的常用方法
        /// <summary>
        /// 翻转字符串，复习字符串的常用方法
        /// </summary>
        private string ConverseString(StringBuilder sb)
        {
            string str = sb.ToString();
            string[] splitStr = str.Split('|');
            splitStr.Reverse();
            return string.Join("|", splitStr);
        } 
        #endregion
    }
}
