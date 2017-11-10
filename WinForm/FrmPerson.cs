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
using Common;
using System.IO;
using System.Diagnostics;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace WinForm
{
    public partial class FrmPerson : Form
    {
        #region 构造函数，设置了不自动生成列 -public FrmPersonList()
        /// <summary>
        /// 构造函数
        /// </summary>
        private FrmPerson()
        {
            InitializeComponent();
            //设置不自动生列：没有绑定在Dgv 控件中的列不会显示出来           
            this.dgvEmployee.AutoGenerateColumns = false;

        }
        #endregion


        static FrmPerson frm = null;
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


        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;

        //创建存储地区信息的集合
        //    List<MODEL.HR_Department> lists = new List<MODEL.HR_Department>();
        List<MODEL.HR_Department> dept = null;
       List<MODEL.HR_Department> dept1= new List<MODEL.HR_Department>();
        List<MODEL.HR_Department> usedept2 = null;
        List<MODEL.HR_Department> usedept1 = null;
        BLL.HR_DepartmentManager dm = new BLL.HR_DepartmentManager();
        BLL.HR_EmployeeManager hrem = new BLL.HR_EmployeeManager();


        #region 窗体加载，显示用户信息和加载班级信息  -void FrmPerson_Load(object sender, EventArgs e)
        /// <summary>
        /// 窗体加载，显示用户信息和加载班级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPerson_Load(object sender, EventArgs e)
        {
            
            dept = dm.GetDapartment();
            LoadAreas(null, 10);
            tvList.ExpandAll();

           // tvList.SelectedNode("0").Expand();
      //      tvList.Nodes(des().
            //部門列表信息
            usedept1 = hrem.GetAllDept();
            usedept2 = hrem.GetAllDept();
         
            this.cboAID1Unit.DisplayMember = "Unit";
            this.cboAID1Unit.ValueMember = "AID";
            this.cboAID1Unit.DataSource = usedept1;

            this.cboAID1UnitName.DisplayMember = "UnitName";
            this.cboAID1UnitName.ValueMember = "AID";
            this.cboAID1UnitName.DataSource = usedept1;


            this.cboAID2UnitName.DisplayMember = "UnitName";
            this.cboAID2UnitName.ValueMember = "AID";
            this.cboAID2UnitName.DataSource = usedept2;
            this.cboAID2Unit.DisplayMember = "Unit";
            this.cboAID2Unit.ValueMember = "AID";
            this.cboAID2Unit.DataSource = usedept2;









        }
        #endregion

        #region 使用递归加载所有地区信息  -void LoadAreas(TreeNode parentNode, int id)
        /// <summary>
        /// 使用递归加载所有地区信息
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="id"></param>
        public void LoadAreas(TreeNode parentNode, decimal id)
        {
            for (int i = 0; i < dept.Count; i++)
            {
                if (id == dept[i].Apid) //当对象的APID值==某个对象的AID值的时候，说明是它就是某个对象的子节点
                {
                    TreeNode node;
                    if (dept[i].DeptID.ToString() == "0")
                    {
                        node = new TreeNode(dept[i].Unit + ":" + dept[i].EmpName);
                    }
                    else
                    {
                        node = new TreeNode(dept[i].Unit + ":" + dept[i].UnitName);
                    };
                    //因为在数据表中需要存储的值是地区所对应的AID值，所以需要将其存储起来，选择存储在TAG里面是比较方便的
                    node.Tag = dept[i].AID;
                    //node.Tag = lists[i]; //将对象存储到节点的tag里面，方便以后有不同的需要
                    if (parentNode == null)//判断是否添加给根节点
                    {
                        this.tvList.Nodes.Add(node);
                    }
                    else
                    {
                        parentNode.Nodes.Add(node); //添加给当前节点
                    }
                       
                    //递归的方式实现地区信息的添加
                    LoadAreas(node, dept[i].AID);
                }
            }
        }



        #endregion



        public void getcb()
        {
            tscbxCameras.Items.Clear();
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    throw new ApplicationException();
                }
                //       btnRgetcb.Visible = false;
                foreach (FilterInfo device in videoDevices)
                {
                    tscbxCameras.Items.Add(device.Name);
                }
                tscbxCameras.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                tscbxCameras.Items.Add("No local capture devices");
                MessageBox.Show("没有摄像头");
            //    btnRgetcb.Visible = true;
                videoDevices = null;
            }
        }

        public void getPhoto()
        {
            if (videoSource == null)
                return;
            Bitmap bitmap1 = videoSourcePlayer1.GetCurrentVideoFrame();
            pbPhoto.Image = bitmap1;



        }







        #region 删除操作 -void tsmiDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
   
        }
        #endregion

         string addoredit ;
        byte[] mphoto;
        #region 修改操作，得到对象的属性值填充在控件中
        /// <summary>
        /// 修改操作，得到对象的属性值填充在控件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            txtPhotopath.Text = "";
            this.gbEdit.Text = "修改ADD";
            addoredit = "EDIT";


            cbAID.Checked = false;

            if (this.dgvEmployee.SelectedRows.Count == 0)
            {
                return;
            }
            
            MODEL.HR_Employee upEmp = this.dgvEmployee.SelectedRows[0].DataBoundItem as MODEL.HR_Employee;
            txtGuid.Text = upEmp.Guid.ToString().Trim();

            //Detp
            txtAID1.Text = upEmp.AID.ToString();
            cboAID1Unit.SelectedValue = upEmp.AID;
            cboAID1UnitName.SelectedValue = upEmp.AID;
            //       cboJobID.SelectedValue = upEmp.JobID;
            //      int jobid = Convert.ToInt16(upEmp.JobID);
            //Title
            txtEmpID.Text = upEmp.EmpID.Trim();
            cboTitle.Text = upEmp.Title;
            cboSalary.Text = upEmp.Salary;
             cboJob.Text = upEmp.Job;
            
            //Name
            txtKhName.Text = upEmp.KhName;
            txtCallName.Text = upEmp.CallName;
            txtELName.Text = upEmp.ELName;
            txtEName.Text = upEmp.EName;
            txtKLName.Text = upEmp.KLName;
            txtKName.Text = upEmp.KName;


            txtEnrollNo.Text = upEmp.EnrollNo.ToString();
            txtPersonalID.Text = upEmp.PersonalID;
            txtNSSF.Text = upEmp.NSSF;
            txtWorkBook.Text = upEmp.WorkBook;


            cboNationalID.SelectedIndex =(int)upEmp.NationalID;
            cboShiftID.SelectedIndex = (int)upEmp.ShiftID;
            cboEducation.Text = upEmp.Education;
            cboStatus.Text = upEmp.Status;
            cboProvinceID.SelectedIndex =(int) upEmp.ProvinceID;
            txtAddress.Text = upEmp.Address;
            txtCardNo.Text = upEmp.CardNo.Trim();
             // txtAccountno  這個現在不用


            //    txtGender.Text = upEmp.Gender.ToString();
            if (upEmp.Gender.Trim() == "0")
            { rdFemale.Checked = true; }
            else if (upEmp.Gender.Trim() == "1")
            { rdMale.Checked = true; }
            else { }

            int mdel = Convert.ToInt16(upEmp.isDel);
            this.cboIsDel.SelectedIndex = mdel;
            DateTime mdate = Convert.ToDateTime("1800-01-01");
            if (upEmp.BirthDate > mdate)
            {
                dtpBirthDate.Format = DateTimePickerFormat.Custom;
                dtpBirthDate.CustomFormat = "yyyy-MM-dd";
                dtpBirthDate.Value = Convert.ToDateTime(upEmp.BirthDate);
            }
            else
            {
                // 日期格式初始為空設定
                dtpBirthDate.Format = DateTimePickerFormat.Custom;
                dtpBirthDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
            }

            if (upEmp.HireDate > mdate)
            {
                dtpHireDate.Format = DateTimePickerFormat.Custom;
                dtpHireDate.CustomFormat = "yyyy-MM-dd";
                dtpHireDate.Value = Convert.ToDateTime(upEmp.HireDate);
            }
            else
            {
                // 日期格式初始為空設定
                dtpHireDate.Format = DateTimePickerFormat.Custom;
                dtpHireDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
            }


            if (upEmp.ResignDate > mdate)
            {
                dtpResignDate.Format = DateTimePickerFormat.Custom;
                dtpResignDate.CustomFormat = "yyyy-MM-dd";
                dtpResignDate.Value = Convert.ToDateTime(upEmp.ResignDate);
            }
            else
            {
                // 日期格式初始為空設定
                dtpResignDate.Format = DateTimePickerFormat.Custom;
                dtpResignDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
            }

            if (upEmp.KeepFrom > mdate)
            {
                dtpKeepFrom.Format = DateTimePickerFormat.Custom;
                dtpKeepFrom.CustomFormat = "yyyy-MM-dd";
                dtpKeepFrom.Value = Convert.ToDateTime(upEmp.KeepFrom);
            }
            else
            {
                // 日期格式初始為空設定
                dtpKeepFrom.Format = DateTimePickerFormat.Custom;
                dtpKeepFrom.CustomFormat = " ";//这里是一个空格，否则无法生效的
            }

            if (upEmp.BackWork> mdate)
            {
                dtpBackWork.Format = DateTimePickerFormat.Custom;
                dtpBackWork.CustomFormat = "yyyy-MM-dd";
                dtpBackWork.Value = Convert.ToDateTime(upEmp.BackWork);
            }
            else
            {
                // 日期格式初始為空設定
                dtpBackWork.Format = DateTimePickerFormat.Custom;
                dtpBackWork.CustomFormat = " ";//这里是一个空格，否则无法生效的
            }

            // bool  
            cbPrePaid.Checked = Convert.ToBoolean(upEmp.PrePaid);
            cbPaid.Checked = Convert.ToBoolean(upEmp.Paid);
            cbIsContract.Checked = Convert.ToBoolean(upEmp.IsContract);
            cbIsPermanent.Checked = Convert.ToBoolean(upEmp.IsPermanent);
            cbIsResign.Checked = Convert.ToBoolean(upEmp.IsResign);
            //Union
            cbUnion1.Checked = Convert.ToBoolean(upEmp.Union1);
            cbUnion2.Checked = Convert.ToBoolean(upEmp.Union2);
            cbUnion3.Checked = Convert.ToBoolean(upEmp.Union3);
            cbUnion4.Checked = Convert.ToBoolean(upEmp.Union4);
            cbUnion5.Checked = Convert.ToBoolean(upEmp.Union5);
            cbUnion6.Checked = Convert.ToBoolean(upEmp.Union6);
            cbUnion7.Checked = Convert.ToBoolean(upEmp.Union7);
            cbUnion8.Checked = Convert.ToBoolean(upEmp.Union8);
            cbUnion9.Checked = Convert.ToBoolean(upEmp.Union9);
            cbUnion10.Checked = Convert.ToBoolean(upEmp.Union10);
            cbUnion11.Checked = Convert.ToBoolean(upEmp.Union11);
            cbUnion12.Checked = Convert.ToBoolean(upEmp.Union12);

            mphoto = upEmp.Photo;
            if (upEmp.Photo != null)
            {
                //byte 轉換成image 顯示圖片
                Image photo = null;
                using (MemoryStream ms = new MemoryStream(upEmp.Photo))
                {
                    ms.Write(upEmp.Photo, 0, upEmp.Photo.Length);

                    photo = Image.FromStream(ms, true);
                }
                pbPhoto.Image = photo;
                
            }
            else
            {
                pbPhoto.Image = null;
            }
            this.gbEdit.Visible = true;
            cbAID.Enabled = true;
            cbAID.Checked = false;


        }
        #endregion


        //新增
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            
            //初始直為空
            Empemployee();
            this.gbEdit.Visible = true;
            this.gbEdit.Text="新增ADD";
            addoredit = "ADD";
            dtpCreateDate.Format = DateTimePickerFormat.Custom;
            dtpCreateDate.CustomFormat = "yyyy-MM-dd";
            dtpCreateDate.Value = System.DateTime.Today;
            cbAID.Checked = true;
            cbAID.Enabled = false;
            txtGuid.Text = System.Guid.NewGuid().ToString();


        }


        private void Empemployee()
        {

            pbPhoto.Image = null;
            //Detp
            txtGuid.Text = "";
            txtAID1.Text = "";
            this.cboAID1Unit.SelectedIndex = -1;
            this.cboAID1UnitName.SelectedIndex = -1;
            txtAID2.Text = "";
            this.cboAID2Unit.SelectedIndex = -1;
            this.cboAID2UnitName.SelectedIndex = -1;

            //Title
            txtEmpID.Text = "";
            cboTitle.Text = "";
            cboSalary.Text = ""; 
            cboJob.Text = "";

            //Name
            txtKhName.Text = ""; 
            txtCallName.Text = "";
            txtELName.Text = "";
            txtEName.Text = "";
            txtKLName.Text = "";
            txtKName.Text = "";


            txtEnrollNo.Text = "";
            txtPersonalID.Text = "";
            txtNSSF.Text = "";
            txtWorkBook.Text = "";


            cboNationalID.SelectedIndex = -1;
            cboShiftID.SelectedIndex = -1;
            cboEducation.Text = "";
            cboStatus.Text = "";
            cboProvinceID.SelectedIndex = -1;
            txtAddress.Text = "";
            txtCardNo.Text = "";
            // txtAccountno  這個現在不用


            //    txtGender.Text = upEmp.Gender.ToString();
     
           rdFemale.Checked = false; 
            rdMale.Checked = true; 
            


            this.cboIsDel.SelectedIndex = -1;
                // 日期格式初始為空設定
                dtpBirthDate.Format = DateTimePickerFormat.Custom;
                dtpBirthDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
                dtpHireDate.Format = DateTimePickerFormat.Custom;
                dtpHireDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
                dtpResignDate.Format = DateTimePickerFormat.Custom;
                dtpResignDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
                dtpKeepFrom.Format = DateTimePickerFormat.Custom;
                dtpKeepFrom.CustomFormat = " ";//这里是一个空格，否则无法生效的
                dtpBackWork.Format = DateTimePickerFormat.Custom;
                dtpBackWork.CustomFormat = " ";//这里是一个空格，否则无法生效的

            // bool  
            cbPrePaid.Checked = false;
            cbPaid.Checked = false;
            cbIsContract.Checked = false;
            cbIsPermanent.Checked = false;
            cbIsResign.Checked = false;
            //Union
            cbUnion1.Checked = false;
            cbUnion2.Checked = false;
            cbUnion3.Checked = false;
            cbUnion4.Checked = false;
            cbUnion5.Checked = false;
            cbUnion6.Checked = false;
            cbUnion7.Checked = false;
            cbUnion8.Checked = false;
            cbUnion9.Checked = false;
            cbUnion10.Checked = false;
            cbUnion11.Checked = false;
            cbUnion12.Checked = false;

        }




        #region  查询操作，生成对应的条件参数  - void btnSearch_Click(object sender, EventArgs e)
        /// <summary>
        /// 查询操作，生成对应的条件参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Q0.Text = "";
            Q1.Text = "";
            Q6.Text = "";

            if (QEmpID.Text==""&&QEnrollNo.Text==""&&chkFAID.Checked==false)
            { MessageBox.Show("請選擇部門,工號,卡號或部門 "); return;  }
            if (QEmpID.Text == "" && QEnrollNo.Text == "" && chkFAID.Checked == true)
            {   if (txtAID.Text == "") { MessageBox.Show("請選擇部門 ");  return;  }     }


            string mempid = QEmpID.Text;
            string menorllno = QEnrollNo.Text;
            string mfaid="";
            if (chkFAID.Checked == true)
            {
                if(txtAID.Text=="")
                {
                 MessageBox.Show("請選擇部門 ");                   
                    return;
                }
                 mfaid = txtAID.Text;
            }
            string mtaid = "";
            if (chkTAID.Checked == true)
            {
                if (txtTAID.Text == "")
                {
                    MessageBox.Show("請選擇部門 ");
                    return;
                }
                mtaid = txtTAID.Text;
            }
            string mdel = QisDel.Text;

            this.dgvEmployee.DataSource = hrem.SeeHREmployee(mempid, menorllno, chkFAID.Checked, mfaid, chkTAID.Checked, mtaid, mdel);
            int P0 = 0;
            int P1 = 0;
            int P6 = 0;
            string chk;
                      
                if(dgvEmployee.Rows[0].Cells["Guid"].Value==null)
                {
                    
                    //MessageBox.Show("null");
                    return;
                }
               
           //  計算 在職 離職人數
            for (int i = 0; i < dgvEmployee.RowCount; i++)
            {
             chk=dgvEmployee.Rows[i].Cells["isDel"].Value.ToString();
              if( Convert.ToInt16(chk)==0)
                {
                    P0++;
                }
              if(Convert.ToInt16(chk) == 1)
                {
                    P1++;
                }
              if(Convert.ToInt16(chk) > 1)
                {
                    P6++;
                }                                       

            }
            Q0.Text = P0.ToString();
            Q1.Text = P1.ToString();
            Q6.Text = P6.ToString();

        }
        #endregion





       // string mDeptID;
        private void tvList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  if (txtAID.Text == "")
        //    {
               // MessageBox.Show("請選擇部門,點下面樹狀部門");
               // return;
          //  }
            if (cbDept.Checked)
            {
     
                decimal md1 = 10;// Convert.ToDecimal(txtAID.Text);
                tvList.Nodes.Clear();
              //  dept = dm.GetDapartment();
                LoadAreas(null, md1);
               tvList.ExpandAll();
            }
            else
            {

                //  tvList.Nodes.Clear();

                //      if (txtQDeptID.Text =="0")
                if(mqdeptid == "0")
                {
                    tvList.Nodes.Clear();
                    //    dept = dm.GetDapartment();
                    decimal md = Convert.ToDecimal(txtDeptAPID.Text);
                    LoadAreas(null, md);
                    tvList.ExpandAll();
                }
                
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void TOEXCEL_Click(object sender, EventArgs e)
        {
            string vg = "Emp";
            ImproExcel(vg);
        }

        public void ImproExcel(string VG)
        {

            SaveFileDialog sdfExport = new SaveFileDialog();
            sdfExport.Filter = "Excel 97-2003文件|*.xls|Excel 2007文件|*.xlsx";
            //   sdfExport.ShowDialog();

            if (sdfExport.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            String filename = sdfExport.FileName;
            myCommon.NPOIProgram NPOIexcel = new myCommon.NPOIProgram();
            DataTable tabl = new DataTable();
            if (VG == "Emp")
            {
                tabl = GetDgvToTable(dgvEmployee);
            }
            else if (VG == "No")
            {
                //    tabl = GetDgvToTable(dataGridViewSizeRun);
            }

            // DataTable dt = (StyleCodeInfodataGridView.DataSource as DataTable);
            NPOIexcel.ExcelWrite(filename, tabl);//excelhelper写出           
            if (MessageBox.Show("导出成功，文件保存在" + filename.ToString()
                   + ",是否打开此文件？", "提示", MessageBoxButtons.YesNo) ==
                   DialogResult.Yes)
            {
                if (File.Exists(filename))//文件是否存在
                {
                    Process.Start(filename);//执行打开导出的文件  
                }
                else
                {
                    MessageBox.Show("文件不存在！", "提示");
                }
            }
        }
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].HeaderText.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEmployee_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvEmployee.Rows[e.RowIndex].Selected == false)
                    {
                        dgvEmployee.ClearSelection();
                        dgvEmployee.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvEmployee.SelectedRows.Count == 1)
                    {
                        dgvEmployee.CurrentCell = dgvEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单

                    ctmsEmployee.Show(MousePosition.X, MousePosition.Y);
                    // MessageBox.Show("点右键了");
                }
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {

        }

        private void tsmiID_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gbEdit_Enter(object sender, EventArgs e)
        {

        }

        private void cbAID_CheckedChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("change");
            if (cbAID.Checked == true)
            {
                txtAID2.Visible = true;
                cboAID2Unit.Visible = true;
                cboAID2UnitName.Visible = true;
                txtAID2.Text = txtAID1.Text;
        //        cboAID2Unit.SelectedValue = Convert.ToDecimal(txtAID2.Text);
         //       cboAID2UnitName.SelectedValue = Convert.ToDecimal(txtAID2.Text);
            }
            else
            {
                txtAID2.Visible = false;
                txtAID2.Visible = false;
                cboAID2Unit.Visible = false;
                cboAID2UnitName.Visible = false;

            }
        }

        private void gbEdit_Enter_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPhotopath.Text = "";
            this.gbEdit.Visible = false;
        }

        private void dtpResignDate_ValueChanged(object sender, EventArgs e)
        {
            dtpResignDate.Format = DateTimePickerFormat.Custom;
            dtpResignDate.CustomFormat = "yyyy-MM-dd";
        }

        private void dtpHireDate_ValueChanged(object sender, EventArgs e)
        {
            dtpHireDate.Format = DateTimePickerFormat.Custom;
            dtpHireDate.CustomFormat = "yyyy-MM-dd";
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "yyyy-MM-dd";
        }

        MODEL.HR_Employee upEmp;
        private void btnUpdate_Click(object sender, EventArgs e)
        {


            if (addoredit == "EDIT")
            {
            upEmp = this.dgvEmployee.SelectedRows[0].DataBoundItem as MODEL.HR_Employee;

            }
            else if (addoredit == "ADD")
            {
            upEmp = new  MODEL.HR_Employee();
            }
            else
            {
                MessageBox.Show("出現其他狀況,請找IT");
            }


            //    MODEL.HR_Employee upEmp = this.dgvEmployee.SelectedRows[0].DataBoundItem as MODEL.HR_Employee;
            //   upEmp.isDel = this.cboIsDel.SelectedIndex;
            // hrem.UpdateHREmployee(upEmp);



            if (MessageBox.Show("OK please enter <確定>", "Employee", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
           {
              //// 
          ////      MODEL.HR_Employee upEmp = this.dgvEmployee.SelectedRows[0].DataBoundItem as MODEL.HR_Employee;
                //Dept
                //DeptID 舊的欄位先不用
                if (cbAID.Checked == true)
                {
                    if (!myCommon.IsWholeNumber((txtAID2.Text.Trim())))
                    {
                        MessageBox.Show("請選擇右邊部門代號, Please choice  in right Dept AID！", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            
                    upEmp.AID = Convert.ToDecimal(txtAID2.Text.Trim());
                }
                else
                {
                    upEmp.AID = Convert.ToDecimal(txtAID1.Text.Trim());
                }


                //Title 

                upEmp.EmpID = txtEmpID.Text;
                upEmp.Title = cboTitle.Text;
                upEmp.Salary = cboSalary.Text;
                upEmp.Job = cboJob.Text;

                //Name
                upEmp.KhName=txtKhName.Text;
                upEmp.CallName =txtCallName.Text;
                upEmp.KLName = txtKLName.Text;
                upEmp.KName = txtKName.Text;
                upEmp.ELName = txtELName.Text;
                upEmp.EName = txtEName.Text;


                // 
                if (!  myCommon.IsWholeNumber((txtEnrollNo.Text.Trim())))
                {
                    MessageBox.Show("卡號请输入数字,EnrollNo please type number！", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                upEmp.EnrollNo =Convert.ToInt32(txtEnrollNo.Text.Trim());
                upEmp.PersonalID=txtPersonalID.Text.Trim();
                upEmp.NSSF = txtNSSF.Text.Trim();
                upEmp.WorkBook = txtWorkBook.Text.Trim();

                upEmp.NationalID = this.cboNationalID.SelectedIndex;
                upEmp.ShiftID = this.cboShiftID.SelectedIndex;
                upEmp.Education = cboEducation.Text;
                upEmp.Status = cboStatus.Text;

                upEmp.ProvinceID = this.cboProvinceID.SelectedIndex;
                upEmp.Address = txtAddress.Text;
                upEmp.CardNo = txtCardNo.Text;
                //accountno 現在不用
                //性別Gender 
                if(rdFemale.Checked==true) {  upEmp.Gender ="0"; }
                else if (rdMale.Checked==true) { upEmp.Gender = "1"; }
                else { upEmp.Gender = "-1 "; }
                //日期 Date
                if (dtpBirthDate.CustomFormat == " " || dtpBirthDate.Value == null)
                   { upEmp.BirthDate = null;  } else  { upEmp.BirthDate = dtpBirthDate.Value; }
                if ( dtpHireDate.CustomFormat == " " || dtpHireDate.Value == null)
                   { upEmp.HireDate = null;} else { upEmp.HireDate = dtpHireDate.Value; }
                if (dtpCreateDate.CustomFormat == " " || dtpCreateDate.Value == null)
                   { upEmp.CreateDate = null; }  else { upEmp.CreateDate = dtpCreateDate.Value; }

                 //Keep 
                if (dtpKeepFrom.CustomFormat == " " || dtpKeepFrom.Value == null)
                   { upEmp.KeepFrom = null; }  else  { upEmp.KeepFrom = dtpKeepFrom.Value; }
                if (dtpBackWork.CustomFormat == " " || dtpBackWork.Value == null)
                  { upEmp.BackWork = null; }  else { upEmp.BackWork = dtpBackWork.Value;}
                   upEmp.isDel = this.cboIsDel.SelectedIndex;
                //bool 
                upEmp.PrePaid = cbPrePaid.Checked;
                upEmp.Paid = cbPaid.Checked;
                upEmp.IsPermanent = cbIsPermanent.Checked;
                upEmp.IsContract = cbIsContract.Checked;
                upEmp.IsResign = cbIsResign.Checked;
                // 離職Resign
                upEmp.ResignType = txtResignType.Text;
                upEmp.ResignReason = txtResignReason.Text;

                //公會 Union 
                upEmp.Union1 =Convert.ToInt16(cbUnion1.Checked);
                upEmp.Union2 = Convert.ToInt16(cbUnion2.Checked);
                upEmp.Union3 = Convert.ToInt16(cbUnion3.Checked);
                upEmp.Union4 = Convert.ToInt16(cbUnion4.Checked);
                upEmp.Union5 = Convert.ToInt16(cbUnion5.Checked);
                upEmp.Union6 = Convert.ToInt16(cbUnion6.Checked);
                upEmp.Union7 = Convert.ToInt16(cbUnion7.Checked);
                upEmp.Union8 = Convert.ToInt16(cbUnion8.Checked);
                upEmp.Union9 = Convert.ToInt16(cbUnion9.Checked);
                upEmp.Union10 = Convert.ToInt16(cbUnion10.Checked);
                upEmp.Union11 = Convert.ToInt16(cbUnion11.Checked);
                upEmp.Union12  = Convert.ToInt16(cbUnion12.Checked);

                // 
                if (txtPhotopath.Text !=null && txtPhotopath.Text!="")
                {
                    byte[] photo_byte = null;

           //         把图片转换为二进制保存
             //         创建FileStream对象
                    FileStream fs = new FileStream(txtPhotopath.Text, FileMode.Open, FileAccess.Read);
                //    声明Byte数组
                    photo_byte = new byte[fs.Length];
                  //  读取数据
                    fs.Read(photo_byte, 0, photo_byte.Length);
                    fs.Close();
                    upEmp.Photo = photo_byte;
                }
                else
                {
                    //修改原來的不用改
                    if (addoredit == "ADD")
                    {
                        upEmp.Photo = null;
                    }
                    else
                    {
                        upEmp.Photo = mphoto;
                    }
                }

                if (addoredit == "EDIT")
                {
                    upEmp.Guid = new Guid(txtGuid.Text);
                    hrem.UpdateHREmployee(upEmp);

                }
                else if (addoredit == "ADD")
                {
                    hrem.AddHREmployee(upEmp);
                }
                else
                {
                    MessageBox.Show("出現其他狀況,請找IT");
                }



                //   
            }
            else
            {
                MessageBox.Show("no");
            }

        }

    
   //     2.参数类型是Image对象，返回Byte[] 类型: 
public byte[] PhotoImageInsert(Image  imgPhoto)
        {
            //将Image转换成流数据，并保存为byte[] 
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void L0_Click(object sender, EventArgs e)
        {

        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtAID_TextChanged(object sender, EventArgs e)
        {

        }

        private void COPYCELL_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvEmployee.CurrentCell.Value.ToString());
        }

        string mqdeptid;
        private void tvList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {



            decimal maid = Convert.ToDecimal(e.Node.Tag);
            dept1.Clear();
            dept1 = dm.GetDapartment(maid);

      //       txtQDeptID.Text = dept1[0].DeptID.ToString();
            mqdeptid = dept1[0].DeptID.ToString();

            txtUnit.Text = dept1[0].Unit.ToString() + dept1[0].EmpName;


                txtDeptAPID.Text = "";
            //      if (txtQDeptID.Text=="0")
            if (mqdeptid == "0")
            {
                txtDeptAPID.Text = dept1[0].Apid.ToString();

                return;
            }
          


            txtAID2.Text = dept1[0].AID.ToString();
            cboAID2Unit.SelectedValue = dept1[0] .AID;
            cboAID2UnitName.SelectedValue = dept1[0].AID;

            if (chkTAID.Checked == true)
            {
                txtTAID.Text = dept1[0].AID.ToString();
            }
            else
            {
                txtTAID.Text = dept1[0].AID.ToString();
                txtAID.Text = dept1[0].AID.ToString();
            }                      
    
            this.dgvEmployee.DataSource = hrem.GetHREmployee(txtAID.Text);
            
        }

        private void dtpKeepFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpKeepFrom.Format = DateTimePickerFormat.Custom;
            dtpKeepFrom.CustomFormat = "yyyy-MM-dd";
        }

        private void dtpBackWork_ValueChanged(object sender, EventArgs e)
        {
            dtpBackWork.Format = DateTimePickerFormat.Custom;
            dtpBackWork.CustomFormat = "yyyy-MM-dd";
        }

        private void btnResignDate_Click(object sender, EventArgs e)
        {
            dtpResignDate.Format = DateTimePickerFormat.Custom;
            dtpResignDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
        }

        private void btnBackWork_Click(object sender, EventArgs e)
        {
            dtpBackWork.Format = DateTimePickerFormat.Custom;
            dtpBackWork.CustomFormat = " ";//这里是一个空格，否则无法生效的



            //dtpBackWork.Format = DateTimePickerFormat.Custom;
            //dtpBackWork.CustomFormat = " ";//这里是一个空格，否则无法生效的
        }

        private void btnKeepFrom_Click(object sender, EventArgs e)
        {
            dtpKeepFrom.Format = DateTimePickerFormat.Custom;
            dtpKeepFrom.CustomFormat = " ";//这里是一个空格，否则无法生效的
        }

        private void btnBirthDate_Click(object sender, EventArgs e)
        {
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = " ";//这里是一个空格，否则无法生效的
        }

        private void btnHireDate_Click(object sender, EventArgs e)
        {
            dtpHireDate.Format = DateTimePickerFormat.Custom;
            dtpHireDate.CustomFormat = " ";//这里是一个空格，否则无法生效的            
        }

        private void cboIsDel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboProvinceID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEnrollNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtWorkBook_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNSSF_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Keep_Enter(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void tscbxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            //打开摄像头
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //如果已经打开  则关闭
            if (videoSourcePlayer1.IsRunning)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
            }
            // selectedDeviceIndex =1; //镜头源
            //selectedDeviceIndex = tscbxCameras.SelectedIndex; //镜头源
            //    selectedDeviceIndex = tscbxCameras.Items.Count;// 1 2 
            if (tscbxCameras.Items.Count <= 0)
            {
                //  msgDiv.MsgDivShow("内盒条码没有对应型体数据", 60);
                MessageBox.Show("没有找到摄像头，请检查摄像头线路");
        //        btnRgetcb.Visible = true;
                return;
            }
            else
            {
                btnRgetcb.Visible = false;
                selectedDeviceIndex = 0;
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
                int i = videoSource.VideoCapabilities.Length;
                if (i >= 15)
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[15];//I取最大值卡 取16
                }
                else
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[i - 1];//I取最大值  最大
                }
                videoSourcePlayer1.VideoSource = videoSource;
                videoSourcePlayer1.Start();
            }


            //镜头2
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //如果已经打开  则关闭
      //      if (videoSourcePlayer2.IsRunning)
        //    {
          //      videoSourcePlayer2.SignalToStop();
            //    videoSourcePlayer2.WaitForStop();
           // }
            // selectedDeviceIndex =1; //镜头源
            //selectedDeviceIndex = tscbxCameras.SelectedIndex; //镜头源
            //selectedDeviceIndex = tscbxCameras.Items.Count;// 1 2 
            if (tscbxCameras.Items.Count <= 1)
            {
                //msgDiv.MsgDivShow("没有找到摄像头2，请检查摄像头线路", 60);
                MessageBox.Show("没有找到摄像头2，请检查摄像头线路");
                btnRgetcb.Visible = true;
                return;
            }
            else
            {
                selectedDeviceIndex = 1;
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
                int i = videoSource.VideoCapabilities.Length;
                if (i >= 15)
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[15];//I取最大值卡 取16
                }
                else
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[i - 1];//I取最大值  最大
                }
             //   videoSourcePlayer2.VideoSource = videoSource;
              //  videoSourcePlayer2.Start();
            }
        }

        private void btnRgetcb_Click(object sender, EventArgs e)
        {
            getcb();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            getcb();
        }
        string filename;
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog sdfExport = new OpenFileDialog();

            ///       sdfExport.Filter = "Excel 97-2003文件|*.jpg|Excel 2007文件|*.xlsx";
                sdfExport.Filter = "圖片文件|*.jpg";
            if (sdfExport.ShowDialog() != DialogResult.OK)
            {
                return;
            }

           filename = sdfExport.FileName;
            pbPhoto.Load(filename);
            txtPhotopath.Text = filename;
         //   getPhoto();
        }

        private void rdKeep_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void txtGuid_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmPerson_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
