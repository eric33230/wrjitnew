using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SimpleSIM
{
    public partial class FrmPerson : Form,IGetAreas
    {
        #region 构造函数，设置了不自动生成列 -public FrmPersonList()
        /// <summary>
        /// 构造函数
        /// </summary>
        private FrmPerson()
        {
            InitializeComponent();
            //设置不自动生列：没有绑定在Dgv 控件中的列不会显示出来
            this.dgvList.AutoGenerateColumns = false;
            this.cboSearchType.SelectedIndex = 0;
        } 
        #endregion        

        #region 创建人员管理业务层类对象  - BLL.PersonManager pm 
        /// <summary>
        /// 创建人员管理业务层类对象
        /// </summary>
        BLL.PersonManager pm = new BLL.PersonManager(); 
        #endregion

        #region 创建班级管理类对象 -BLL.ClassesManager cm
        /// <summary>
        /// 创建班级管理类对象
        /// </summary>
        BLL.ClassesManager cm = new BLL.ClassesManager(); 
        #endregion

        #region 单例窗体对象  -static FrmPerson frm
        /// <summary>
        /// 单例窗体对象
        /// </summary>
        static FrmPerson frm = null; 
        #endregion

        #region 单例模式，返回单个窗体对象  -static FrmPerson GetSingleton()
        /// <summary>
        /// 单例模式，返回单个窗体对象
        /// </summary>
        /// <returns></returns>
        public static FrmPerson GetSingleton()
        {
            //if(frm==null || frm.IsDisposed)
            if (frm == null)
            {
                frm = new FrmPerson();
            }
            return frm;
        } 
        #endregion

        #region 打开选择地区窗体  -void btnChoice_Click(object sender, EventArgs e)
        /// <summary>
        /// 打开选择地区窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoice_Click(object sender, EventArgs e)
        {
            FillData fd = new FillData(GetValue);
            //FrmArea frm = new FrmArea((IGetAreas)this);
            FrmArea frm = new FrmArea(fd);
            //frm.MdiParent = this.MdiParent;
            frm.ShowDialog();
        } 
        #endregion

        #region 窗体关闭的时候释放对象 -void FrmPerson_FormClosing(object sender, FormClosingEventArgs e)
        /// <summary>
        /// 窗体关闭的时候释放对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        } 
        #endregion

        #region 增加学员信息  - void tsmiAddStudent_Click(object sender, EventArgs e)
        /// <summary>
        /// 增加学员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            state = 1;
            this.gpAdd.Visible = true;
            this.cboIdentity.SelectedIndex = 0;
        } 
        #endregion


        int state = 1; //标识它默认是作新增操作，如果这个值是0.那就做修改操作

        #region 确认新增或者修改 - void btnOk_Click(object sender, EventArgs e)
        /// <summary>
        /// 确认新增或者修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            #region 做验证  不管是新增还是修改都需要做验证
            if (Regex.IsMatch(txtName.Text,@"[0-9a-zA-Z_]|\W"))
            {
                MessageBox.Show("你输入的有非中文，请遵守中国法律");
                return;
            }
            //没有做非空验证
            if(string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("请输入密码");
                txtPwd.Focus();//获取光标
                return;
            }
            if(txtPwd.Text!=txtPwd2.Text)
            {
                MessageBox.Show("请输入正确的确认密码");
                txtPwd2.Focus();//获取光标
                return;
            }
            #endregion

            #region   获取一个对象，不管是新增还是修改都需要得到所有控件的值封装在一个对象里面
            MODEL.Person newPerson=null ;           
            if(state==1)
            {
                newPerson = new MODEL.Person(); //新增需要重新创建一个对象 
                newPerson.PAreas = "";
            }
            else if(state==0)
            {
                //如果是修改，就得到所选择的当前对象
                newPerson=this.dgvList.SelectedRows[0].DataBoundItem as MODEL.Person; //修改已经存在 的对象    
                //点击修改的时候已经得到了Tag值，将这个值赋值给对象，以防止用户修改地区的时候没有正确的赋值
                newPerson.PAreas = txtDistrict.Tag.ToString();               
            }
            newPerson.PCID = Convert.ToInt32(cboClasses.SelectedValue); //获取班级ID
            newPerson.PClaName = cboClasses.Text; //获取班级名称
            newPerson.PLoginName = txtLoginName.Text.Trim(); //获取登录名称
            newPerson.PCName = txtName.Text.Trim(); //获取用户名
            newPerson.PPYName = ""; //拼音以后再处理
            newPerson.PPwd = txtPwd2.Text.Trim();
            newPerson.PGender = rdoMale.Checked ? true : false; //获取性别
            newPerson.PEmail = txtEmail.Text.Trim();//如果文本框的值没有填写，那么获取之后就是""
            //当地区文本框中有用户选择的值且是在做新增的时候，才需要重要修改地区的值
            if(!string.IsNullOrEmpty(txtDistrict.Text) && state==1)
            {
                newPerson.PAreas = txtDistrict.Tag.ToString();
            }
            #endregion

            #region  新增操作
            if (state == 1) //新增
            {
                if (pm.AddPerson(newPerson) == 1)
                {
                    MessageBox.Show("ok");
                    this.dgvList.DataSource = pm.GetAllPersonList(false);
                }
                else
                {
                    MessageBox.Show("no ok");
                }
            }
            #endregion

            #region  修改操作
            else if(state==0)//修改
            {
                if (pm.UpdatePerson(newPerson) == 1)
                {
                    MessageBox.Show("ok");
                    this.dgvList.DataSource = pm.GetAllPersonList(false);
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            this.gpAdd.Visible = false;
            #endregion
        } 
        #endregion

        #region 取消操作，关闭面板 -- void btnCancel_Click(object sender, EventArgs e)
        /// <summary>
        /// 取消操作，关闭面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.gpAdd.Visible = false;
        } 
        #endregion

        #region 窗体加载，显示用户信息和加载班级信息  -void FrmPerson_Load(object sender, EventArgs e)
        /// <summary>
        /// 窗体加载，显示用户信息和加载班级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPerson_Load(object sender, EventArgs e)
        {
            //加载所有人员信息  如果数据源是集合， 那么dgv控件生成的列的数量不再是以sql语句查询到的数量为准，而是参照类的属性 
            DataGridViewComboBoxColumn c = (DataGridViewComboBoxColumn)this.dgvList.Columns["PClaName"];
            c.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            c.DisplayMember = "CName";
            c.ValueMember = "CID";
            c.DataSource = cm.GetAllClass(false);
            this.dgvList.DataSource = pm.GetAllPersonList(false);
            //加载班级列表
            this.cboSearchClass.DisplayMember = "CName";
            this.cboSearchClass.ValueMember="CID";
            List<MODEL.Classes> lists=cm.GetAllClass(false);
            lists.Insert(0, new MODEL.Classes() {CID=-1,CName="请选择" });
            this.cboSearchClass.DataSource = lists;

            //加载新增和修改时的班级列表信息
            this.cboClasses.DisplayMember = "CName";
            this.cboClasses.ValueMember = "CID";
            this.cboClasses.DataSource = cm.GetAllClass(false);

            
            //this.dgvList.Columns[1].CellType = d;
        } 
        #endregion

        #region 获取地区数据 - void GetValue(string name, string sid)
        /// <summary>
        /// 获取地区数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sid"></param>
        public void GetValue(string name, string sid)
        {
            this.txtDistrict.Text = name;
            this.txtDistrict.Tag = sid;
        } 
        #endregion

        #region 删除操作 -void tsmiDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            //1.判断用户有没有选择一行 
            if (this.dgvList.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult result= MessageBox.Show("请问你是否真的需要删除?", "操作提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result!=DialogResult.Yes)
            {
                return;
            }
            //控件当前绑定的是集合，也就说明每一行数据都对应着集合中的某一个对象，可以通过这一行的DataBoundItem来获取这个对象
            MODEL.Person delPer = this.dgvList.SelectedRows[0].DataBoundItem as MODEL.Person;
            if (pm.DeletePersonSoftly(delPer.PID))
            {
                MessageBox.Show("删除成功");
                this.dgvList.DataSource = pm.GetAllPersonList(false);
            }
            else
            {
                MessageBox.Show("删除失败了！");
            }
        } 
        #endregion

        #region 修改操作，得到对象的属性值填充在控件中
        /// <summary>
        /// 修改操作，得到对象的属性值填充在控件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                return;
            }
            state = 0;
            this.gpAdd.Visible = true;
            MODEL.Person upPer = this.dgvList.SelectedRows[0].DataBoundItem as MODEL.Person;
            //开始将选择对象的属性值赋值到控件中
            txtDistrict.Text = upPer.PAreas.ToString(); //得到的只是ID号
            txtDistrict.Tag = upPer.PAreas.ToString(); //得到的只是ID号
            txtEmail.Text = upPer.PEmail;
            txtLoginName.Text = upPer.PLoginName;
            txtName.Text = upPer.PCName;
            txtPwd.Text = txtPwd2.Text = upPer.PPwd; //赋值是右边赋值给左边
            //下拉列表选项变化有三个方式
            //this.cboIdentity.Text=(upPer.PType==1?"教员":"学员");
            this.cboIdentity.SelectedIndex = upPer.PType - 1;
            //如果下拉列表有数据绑定，那么就可以通过SelectValue值来修改其选项值
            this.cboClasses.SelectedValue = upPer.PCID;
            if (upPer.PGender == false)
            {
                rdoFemale.Checked = true;
            }
            else
            {
                rdoMale.Checked = true;
            }
        } 
        #endregion

        #region 从当前选择行切换到下一行发生  -void dgvList_SelectionChanged(object sender, EventArgs e)
        /// <summary>
        /// 从当前选择行切换到下一行发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectionMode mode = dgvList.SelectionMode;
            if (isEdit)
            {
                //MessageBox.Show("选择行发生了改变~~");
                //也可以直接通过下面
                updateperson = this.dgvList.Rows[index].DataBoundItem as MODEL.Person;
                //只有判断同之前的行数据有不一样的值的时候才需要修改
                if (isShouldBeUpdate)
               {
                    if (pm.UpdatePerson(updateperson) == 1)
                    {
                        MessageBox.Show("ok");
                        isEdit = false; //将修改状态重新置 为false
                        this.dgvList.DataSource = pm.GetAllPersonList(false);
                    }
                    isShouldBeUpdate = false; //修改完这一条记录之后重置是否需要修改的值
                }
            }
            //DataGridViewElementStates i= this.dgvList.SelectedRows[0].State;            
        } 
        #endregion
        bool isShouldBeUpdate = false;
        bool isEdit = false; //标识是否进入过编辑状态
        MODEL.Person updateperson; //得到当前正在被编辑的对象
        MODEL.Person temp=new MODEL.Person(); //存储修改之前的对象
        int index; //记住之前修改行的索引

        #region 当单元格进入编辑状态触发  -void dgvList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        /// <summary>
        /// 当单元格进入编辑状态触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isEdit = true; //标识已经进入编辑状态
            updateperson = this.dgvList.CurrentRow.DataBoundItem as MODEL.Person;
            //每切换一个单元格都去判断之前这个单元格有值有没有修改过，如果有，就说明从这一行切换到下一行就需要做提交修改，否则就不需要
            if (temp.PCName != updateperson.PCName || temp.PCID != updateperson.PCID || temp.PGender != updateperson.PGender || temp.PEmail != updateperson.PEmail || temp.PType != updateperson.PType)
            {
                isShouldBeUpdate = true;
            }
            temp.PCName = updateperson.PCName;//不能对象==对象，只能赋值=值
            temp.PCID = updateperson.PCID;
            temp.PGender = updateperson.PGender;
            temp.PEmail = updateperson.PEmail;
            temp.PType = updateperson.PType;
            index = this.dgvList.CurrentRow.Index; //得到当前操作行的索引
            //MessageBox.Show("修改前" + updateperson.PClaName + "  " + updateperson.PCName + "   " + updateperson.PID + "           " + index);
        } 
        #endregion

        #region 点击单元格进入到编辑状态  -void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 点击单元格进入到编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvList.BeginEdit(true);
        } 
        #endregion

        #region 鼠标上移到控件的列时，显示的提示文本 -void dgvList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        /// <summary>
        /// 鼠标上移到控件的列时，显示的提示文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            //this.dgvList.SelectedRows[0].Cells[0].ToolTipText = "aaaa";
            if (e.ColumnIndex == 0)
            {
                e.ToolTipText = "不能修改";
            }
        } 
        #endregion

        #region  查询操作，生成对应的条件参数  - void btnSearch_Click(object sender, EventArgs e)
        /// <summary>
        /// 查询操作，生成对应的条件参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //将用户所选择的条件存储在一个字典中
            Dictionary<string, string> dics = new Dictionary<string, string>();
            if (cboSearchClass.Text != "请选择")
            {
                dics.Add("classId", cboSearchClass.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(txtSearchName.Text))
            {
                dics.Add("stuName", txtSearchName.Text.Trim());
            }
            if (cboSearchType.Text != "请选择")
            {
                dics.Add("typeId", cboSearchType.SelectedIndex.ToString());
            }
            if (chkDate.Checked)
            {
                if (dtpStart.Value > dtpEnd.Value)
                {
                    MessageBox.Show("时间选择错误了");
                    return;
                }
                dics.Add("startDate", dtpStart.Value.ToString());
                dics.Add("endDate", dtpEnd.Value.ToString());
            }
            this.dgvList.DataSource = pm.SearchPersonList(false, dics);
        } 
        #endregion

        #region 发送电子邮件  - void tsmiEmail_Click(object sender, EventArgs e)
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiEmail_Click(object sender, EventArgs e)
        {
            MailMessage mailMsg = new MailMessage();//两个类，别混了 引入System.Web这个Assembly
            mailMsg.Priority = MailPriority.High;//设置邮件优先级
            mailMsg.From = new MailAddress("wuhu@itcast.com", "广州");//设置发件邮箱("邮箱地址","用户名")
            mailMsg.To.Add(new MailAddress("qiqiban@itcast.com", "qiqiban"));//目的邮件地址("收件地址","收件人名称")
            mailMsg.Subject = "how old are you";//发送邮件的标题 
            mailMsg.Body = "i love you..";//发送邮件的
            //设置发送服务器
            SmtpClient client = new SmtpClient("127.0.0.1");//;("127.0.0.1");//smtp.126.com
            //设置发送服务器登录 的用户名和密码
            client.Credentials = new NetworkCredential("wuhu", "123456");//这里的用户名必须是From发件人的用户
            //有的邮箱的用户名需要“yzk@rupeng.com”，有的只需要“yzk”
            client.Send(mailMsg);//发送
            MessageBox.Show("ok");
        } 
        #endregion

        #region  获取用户输入的登录名，查询登录名是否已经存在   - void txtLoginName_Leave(object sender, EventArgs e)
        /// <summary>
        /// 获取用户输入的登录名，查询登录名是否已经存在 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoginName_Leave(object sender, EventArgs e)
        {
            if (pm.IsLoginNameExisits(txtLoginName.Text.Trim()))
            {
                MessageBox.Show("已经存在同名的登录名了，请重新输入一个");
                txtLoginName.Text = "";
                txtLoginName.Focus();
            }
        } 
        #endregion

        #region 用户输入的时候，验证输入了非法字符  -void txtName_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// 用户输入的时候，验证输入了非法字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtName.Text.Trim();
            if (inputText.Length > 0)
            {
                if (Regex.IsMatch(inputText.Substring(inputText.Length - 1), @"\W"))
                {
                    inputText = inputText.Substring(0, inputText.Length - 1);
                }
                this.txtName.Text = inputText;
                //将文本框的光标点设置在当前文本值的最后
                txtName.SelectionStart = inputText.Length;
            }
        } 
        #endregion
    }
}
