using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WinForm
{

    public partial class FrmDepartment : Form
    {
        
        public FrmDepartment()
        {
            InitializeComponent();
            this.dgvEmployee.AutoGenerateColumns = false;
        }

        static FrmDepartment frm;
        public static FrmDepartment GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmDepartment();
            }
            return frm;
        }

        //创建存储地区信息的集合
            List<MODEL.HR_Department> lists = new List<MODEL.HR_Department>();
        //     List<MODEL.HR_Department> lists = null;
        
        BLL.HR_DepartmentManager dm = new BLL.HR_DepartmentManager();
        string hname = Dns.GetHostName(); //得到本机的主机名  
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            
              if (hname == "ERIC")
                { gb1.Visible = true; }
            else { gb1.Visible = false;  }
      
            lists = dm.GetDapartment();
            LoadAreas(null, 10);
        //    tvList.ExpandAll();
        }

        #region 使用递归加载所有地区信息  -void LoadAreas(TreeNode parentNode, int id)
        /// <summary>
        /// 使用递归加载所有地区信息
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="id"></param>
        public void LoadAreas(TreeNode parentNode, decimal id)
        {
            for (int i = 0; i < lists.Count; i++)
            {
                if (id == lists[i].Apid) //当对象的APID值==某个对象的AID值的时候，说明是它就是某个对象的子节点
                {
                    TreeNode node ;
                    if (lists[i].DeptID.ToString() == "0")
                    {
                         node = new TreeNode(lists[i].Unit + ":"  + lists[i].EmpName);
                    }
                    else
                    {
                        node = new TreeNode(lists[i].Unit + ":" + lists[i].UnitName );
                    };
                    //因为在数据表中需要存储的值是地区所对应的AID值，所以需要将其存储起来，选择存储在TAG里面是比较方便的
                    node.Tag = lists[i].AID;
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
                    LoadAreas(node, lists[i].AID);
                }
            }
        }



        #endregion
        MODEL.HR_Department dp = new MODEL.HR_Department();

        private void tvList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          decimal maid =Convert.ToDecimal( e.Node.Tag);
           string snote= tvList.SelectedNode.ToString();
            string etag = e.Node.Name.ToString();
            string  mindex  = tvList.SelectedNode.Index.ToString();
            lists.Clear();            
            lists = dm.GetDapartment(maid);
            if (cbDept.Checked == false)
            {
                
                txtAID.Text = lists[0].AID.ToString();
                txtDeptID.Text = lists[0].DeptID.ToString();
                txtUnit.Text = lists[0].Unit.ToString();
                txtEMPName.Text = lists[0].EmpName;
                txtUnitName.Text = lists[0].UnitName;
                txtAPid.Text = lists[0].Apid.ToString();
                //上層部門清空
                txtAIDTOP.Text = "";
                txtUnitTOP.Text = "";
                txtEMPNameTOP.Text = "";
                txtUnitNameTOP.Text = "";

            }
            else
            {
                txtAIDTOP.Text = lists[0].AID.ToString();
           //     txtDeptIDTOP.Text = lists[0].DeptID.ToString();
                txtUnitTOP.Text = lists[0].Unit.ToString();
                txtEMPNameTOP.Text = lists[0].EmpName;
                txtUnitNameTOP.Text = lists[0].UnitName;
               // txtAPid.Text = lists[0].Apid.ToString();
            }
      //      MessageBox.Show(e.Node.Name.ToString()+"--"+e.Node.Nodes.ToString()+"-TAG-"+e.Node.Tag.ToString()+"--"+ snote +"--"+mindex+etag);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtAID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(txtAIDTOP.Text=="")
            {
                MessageBox.Show("請選擇轉換至那一上層部門底下");
                return;
            }
            if(txtAID.Text=="")
                {
                MessageBox.Show("請選擇部門,點左邊樹狀部門");
                return;
            }
            if(txtAID.Text==txtAIDTOP.Text)
            {
                MessageBox.Show("請選擇非本部門為上層部門");
                return;
            }
            
            
                
             decimal maid =Convert .ToDecimal(txtAID.Text);
             decimal mapid = Convert.ToDecimal(txtAIDTOP.Text);
              dm.updateDeptAPid(maid, mapid);
            tvList.Nodes.Clear();
            lists = null;            
            lists = dm.GetDapartment();
            LoadAreas(null, 10);
            tvList.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtAID.Text == "")
            {
                MessageBox.Show("請選擇部門,點左邊樹狀部門");
                return;
            }
            decimal maid = Convert.ToDecimal(txtAID.Text);
            string munitname = txtUnitName.Text.Trim();
            string mempname = txtEMPName.Text.Trim();
            dm.updateDept(maid, munitname, mempname);
            tvList.Nodes.Clear();
            lists = null;
            lists = dm.GetDapartment();
            LoadAreas(null, 10);
            tvList.Refresh();

        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            float maid = Convert.ToSingle(e.Node.Tag);
    //        MessageBox.Show(e.Node.Tag.ToString());
        }

        private void tvList_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

        }

            TreeNode myNode = null;
        private void tvList_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;

            myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));

        }

        private void tvList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private Point Position = new Point(0, 0);
        private void tvList_DragDrop(object sender, DragEventArgs e)
        {

            /*
            TreeNode myNode = null;
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            }
            else
            {
                MessageBox.Show("error");
            }
            
            Position.X = e.X;
            Position.Y = e.Y;
            Position = tvList.PointToClient(Position);
            TreeNode DropNode = this.tvList.GetNodeAt(Position);
            // 1.目标节点不是空。2.目标节点不是被拖拽接点的字节点。3.目标节点不是被拖拽节点本身
            if (DropNode != null && DropNode.Parent != myNode && DropNode != myNode)
            {
                TreeNode DragNode = myNode;
                // 将被拖拽节点从原来位置删除。
                myNode.Remove();
                // 在目标节点下增加被拖拽节点
                DropNode.Nodes.Add(DragNode);
               
            }
            if (DropNode == null)
            {
             //    TreeNode DragNode = myNode;
             //   myNode.Remove();
              //  tvList.Nodes.Add(DragNode);
            }


            */
            //................
          //  double maid = Convert.ToDouble(myNode.Tag.ToString());
           // double mapid = Convert.ToDouble(DropNode.Tag.ToString());
           //       dm.updateDeptAPid(maid, mapid);




      //      tvList.Nodes.Clear();
        //    lists = null;
         //   lists = dm.GetDapartment();
       //     LoadAreas(null, 11);
           // tvList.Refresh();
        //  tvList.ExpandAll();


        }

        BLL.HR_EmployeeManager empm = new BLL.HR_EmployeeManager();

        List<MODEL.HR_Employee> hremplist = new List<MODEL.HR_Employee>();

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            List<MODEL.Employee> emplist = new List<MODEL.Employee>();

            float menrollno = Convert.ToSingle(txtEnrollNo.Text);
            emplist= empm.GetEmployee(menrollno);
             //    this.dgvEmployee.DataSource = emplist;
        //    MODEL.HR_Employee hremp = new MODEL.HR_Employee();
      //      MODEL.HR_Employee hremp1 = new MODEL.HR_Employee();
            for (int i = 0; i < emplist.Count; i++)
            {

                test.Clear();
                test.AppendText("人員資料" + "\r\n" + "轉換" + "\r\n" + (i + 1).ToString() + "/ " + emplist.Count.ToString());
                MODEL.HR_Employee hremp = new MODEL.HR_Employee();
                //      ,[X]
                //     ,[Y]
                //    ,[Photo]
                hremp.Guid = System.Guid.NewGuid();
                hremp.DeptID = emplist[i].DeptID;
                int mdept = Convert.ToInt16(emplist[i].DeptID);
               double? maid= empm.GetAID(mdept);
                hremp.AID =  Convert.ToDecimal(maid);
                hremp.EmpID = emplist[i].EmpID; //工號
                hremp.EnrollNo= emplist[i].EnrollNo; //指紋機編號
                hremp.Accountno = emplist[i].Accountno;
                hremp.NationalID = emplist[i].NationalID;
                hremp.JobID = emplist[i].JobID;
                hremp.ProvinceID = emplist[i].ProvinceID;
                hremp.ShiftID = emplist[i].ShiftID;
                hremp.CallName = emplist[i].CallName;//別名
                hremp.KhName = emplist[i].KhName; //柬埔寨名
                hremp.Gender = emplist[i].Gender;
                hremp.Status = emplist[i].Status;
                hremp.PersonalID = emplist[i].PersonalID;
                hremp.NSSF = emplist[i].NSSF;
                hremp.Education = emplist[i].Education;
                hremp.WorkBook = emplist[i].WorkBook;
                hremp.CardNo = emplist[i].CardNo;
                hremp.Address = emplist[i].Address;
                hremp.IsPermanent = emplist[i].IsPermanent;
                hremp.IsContract = emplist[i].IsContract;
                hremp.IsResign = emplist[i].IsResign;
                hremp.ResignType = emplist[i].ResignType;
                hremp.ResignReason = emplist[i].ResignReason;
                hremp.ResignDate = emplist[i].ResignDate;
                hremp.BirthDate =emplist[i].BirthDate;
                hremp.CreateDate = emplist[i].CreateDate;
                hremp.Union1 = emplist[i].Union1;
                hremp.Union2 = emplist[i].Union2;
                hremp.Union3 = emplist[i].Union3;
                hremp.Union4 = emplist[i].Union4;
                hremp.Union5 = emplist[i].Union5;
                hremp.Union6 = emplist[i].Union6;
                hremp.Union7 = emplist[i].Union7;
                hremp.Union8 = emplist[i].Union8;
                hremp.Union9 = emplist[i].Union9;
                hremp.Union10 = emplist[i].Union10;
                hremp.Union11= emplist[i].Union11;
                hremp.Union12= emplist[i].Union12;
                //     empm.TransEmp(hremp);

                hremplist.Add(hremp);
                
            }
            this.dgvEmployee.DataSource = null;
                this.dgvEmployee.DataSource = hremplist;




        }

        private void ctmsShipScan_Opening(object sender, CancelEventArgs e)
        {

        }

        private void TOEXCEL_Click(object sender, EventArgs e)
        {
            string vg = "EmpOld";
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
            if (VG == "EmpOld")
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

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            loadExcel();
            Cursor = Cursors.Default;



        }
        myCommon.NPOIProgram NPOIexcel = new myCommon.NPOIProgram();

        //    DataTable hremp = null;
        //        MODEL.HR_Employee[] hremp1 = null;
            List< MODEL.HR_Employee>  hremp1 = null;

        private void loadExcel()
        {
            if (txtfilename.Text.Length <= 0)
            {
                MessageBox.Show("请选择文件！");
                Cursor = Cursors.Default;
                return;
            }
            if (comsheetname.SelectedIndex == -1)
            {
                MessageBox.Show("请选择表名！");
                comsheetname.DroppedDown = true;
                Cursor = Cursors.Default;
                return;
            }
            string sheetname = comsheetname.SelectedItem.ToString();
                        
            int headno = 0;
           hremp1 = NPOIexcel.ExcelReadEmp(filename, sheetname, headno);
  //          hremp = NPOIexcel.ExcelReadEmpTable(filename, sheetname, headno);
            if (hremp1 != null)
            {
               this.dgvEmployee.DataSource = hremp1;
            //    this.dataGridView1.DataSource = hremp;
            }

            
            for (int i = 0; i < hremp1.Count; i++)
            {
                MODEL.HR_Employee emp = new MODEL.HR_Employee();
                emp.AID = hremp1[i].AID;
                emp.DeptID = hremp1[i].DeptID;
                emp.EmpID = hremp1[i].EmpID;
                emp.EnrollNo = hremp1[i].EnrollNo;
                emp.Accountno = hremp1[i].Accountno;
                emp.NationalID = hremp1[i].NationalID;
                emp.JobID = hremp1[i].JobID;
                emp.ProvinceID = hremp1[i].ProvinceID;
                emp.ShiftID = hremp1[i].ShiftID;
                emp.CallName = hremp1[i].CallName;
                emp.KhName = hremp1[i].KhName;
                emp.Gender = hremp1[i].Gender;
                emp.Status = hremp1[i].Status;
                emp.PersonalID = hremp1[i].PersonalID;
                emp.NSSF = hremp1[i].NSSF;
                emp.Education = hremp1[i].Education;
                emp.WorkBook = hremp1[i].WorkBook;
                emp.CardNo = hremp1[i].CardNo;
                emp.Address = hremp1[i].Address;
                emp.IsPermanent = hremp1[i].IsPermanent;
                emp.IsContract = hremp1[i].IsContract;
                emp.IsResign = hremp1[i].IsResign;
                emp.ResignType = hremp1[i].ResignType;
                emp.ResignReason = hremp1[i].ResignReason;
                emp.ResignDate = hremp1[i].ResignDate;
                emp.BirthDate = hremp1[i].BirthDate;
                emp.CreateDate = hremp1[i].CreateDate;
                emp.Union1 = hremp1[i].Union1;
                emp.Union2 = hremp1[i].Union2;
                emp.Union3 = hremp1[i].Union3;
                emp.Union4 = hremp1[i].Union4;
                emp.Union5 = hremp1[i].Union5;
                emp.Union6 = hremp1[i].Union6;
                emp.Union7 = hremp1[i].Union7;
                emp.Union8 = hremp1[i].Union8;
                emp.Union9 = hremp1[i].Union9;
                emp.Union10 = hremp1[i].Union10;
                emp.Union11 = hremp1[i].Union11;
                emp.Union12 = hremp1[i].Union12;
                emp.isDel = 0; //false 在職
  //              empm.AddHREmployee(emp);

            }
            
            
                 
        }
        String filename = null;
        private void btnInterBoxImpro_Click(object sender, EventArgs e)
        {
            comsheetname.Items.Clear();
        //    dvgInnerBox.DataSource = null;
            OpenFileDialog sdfExport = new OpenFileDialog();

            sdfExport.Filter = "Excel 97-2003文件|*.xls|Excel 2007文件|*.xlsx";
            if (sdfExport.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            filename = sdfExport.FileName;
            string excelName = System.IO.Path.GetFileName(filename);//文件名   

            txtfilename.Text = excelName;

            string[] sheetnames = Common.myCommon.getExcelSheetSum(filename);


            for (int t = 0; t < sheetnames.Length; t++)
            {
                comsheetname.Items.Add(sheetnames[t]);//添加表名
            }

            // if(comsheetname.SelectedItem == null)
            //   {

            MessageBox.Show("请选择工作表!");
            comsheetname.DroppedDown = true;
            //  comsheetname.SelectedIndex = 0;
            //     return;
            //    }
            //  loadExcel()

            btnLoadExcel.Enabled = true;

        }

        private void COPYCELL_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmDepartment_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
