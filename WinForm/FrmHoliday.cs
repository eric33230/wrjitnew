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
    public partial class FrmHoliday : Form
    {
        public FrmHoliday()
        {
            InitializeComponent();

            this.dgvHoloday.AutoGenerateColumns = false;
        }

        static FrmHoliday frm;
        public static FrmHoliday GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmHoliday();
            }
            return frm;
        }




        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtYear_ValueChanged(object sender, EventArgs e)
        {

        }

        BLL.doc_holidayeditManager ho = new BLL.doc_holidayeditManager();
        MODEL.doc_holidayedit holiday = new MODEL.doc_holidayedit();
        Common.myCommon comm = new Common.myCommon();

        //  int state = 1; //新增
        private void FrmHoliday_Load(object sender, EventArgs e)
        {

            this.dgvHoloday.DataSource = ho.GetAllholiday("2016");
            //this.dgvHoloday.DataSource = bindingSource1; 
            //bindingSource1.DataSource=ho.GetAllholiday("2016");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            holiday.id = comm.myGuid();
            holiday.date = dtYear.Text;
            MessageBox.Show(dtFrom.Text);
            holiday.explain = txtName.Text;
            holiday.time_f = dtFrom.Text;
            holiday.time_t = dtTo.Text;
            holiday.beover = 0;
            holiday.addTime = DateTime.Now;
            //    state =  1; //新增状态
            isEdit = false; //将修改状态重新置 为false

            if (ho.AddHoliday(holiday) == 1)
            {
                this.dgvHoloday.DataSource = ho.GetAllholiday(dtYear.Text);


            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmHoliday_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void btnDelHoliday_Click(object sender, EventArgs e)
        {
            //1.判断用户有没有选择一行 
            if (this.dgvHoloday.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("请问你是否真的需要删除?", "操作提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }
            //控件当前绑定的是集合，也就说明每一行数据都对应着集合中的某一个对象，可以通过这一行的DataBoundItem来获取这个对象
            MODEL.doc_holidayedit delHoliday = this.dgvHoloday.SelectedRows[0].DataBoundItem as MODEL.doc_holidayedit;
            if (ho.DeleteHolidaySoftly(delHoliday.id))
            {
                MessageBox.Show("删除成功");
                this.dgvHoloday.DataSource = ho.GetAllholiday(dtYear.Text);

            }
            else
            {
                MessageBox.Show("删除失败了！");
            }

        }

        private void btnEditHoliday_Click(object sender, EventArgs e)
        {

        }


        bool isEdit = false; //标识是否进入过编辑状态
        bool isShouldBeUpdate = false;
        MODEL.doc_holidayedit updateholiday; //得到当前正在被编辑的对象
        MODEL.doc_holidayedit temp = new MODEL.doc_holidayedit(); //存储修改之前的对象
        int index; //记住之前修改行的索引


        private void dgvHoloday_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isEdit = true; //标识已经进入编辑状态
            updateholiday = this.dgvHoloday.CurrentRow.DataBoundItem as MODEL.doc_holidayedit;
            //每切换一个单元格都去判断之前这个单元格有值有没有修改过，如果有，就说明从这一行切换到下一行就需要做提交修改，否则就不需要
            if (temp.date != updateholiday.date || temp.explain != updateholiday.explain || temp.time_f != updateholiday.time_f || temp.time_t != updateholiday.time_t)
            {
                isShouldBeUpdate = true;
            }
            temp.id = updateholiday.id;
            temp.date = updateholiday.date;//不能对象==对象，只能赋值=值
            temp.explain = updateholiday.explain;
            temp.time_f = updateholiday.time_f;
            temp.time_t = updateholiday.time_t;
            index = this.dgvHoloday.CurrentRow.Index; //得到当前操作行的索引
     //     MessageBox.Show("修改前" + updateholiday.date + "  " + updateholiday.time_f + "   " + updateholiday.time_t + "           " + index);


        }

        private void dgvHoloday_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvHoloday.BeginEdit(true);
        }

        private void dgvHoloday_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectionMode mode = dgvHoloday.SelectionMode;
            if (isEdit)
            {
                //MessageBox.Show("选择行发生了改变~~");
                //也可以直接通过下面
                updateholiday = this.dgvHoloday.Rows[index].DataBoundItem as MODEL.doc_holidayedit;
                //只有判断同之前的行数据有不一样的值的时候才需要修改
                if (isShouldBeUpdate)
                {
                    if (ho.UpdateHoliday(updateholiday) == 1)
                    {
                      //  MessageBox.Show("ok");
                        isEdit = false; //将修改状态重新置 为false
                        this.dgvHoloday.DataSource = ho.GetAllholiday(dtYear1.Text);
                    }
                    isShouldBeUpdate = false; //修改完这一条记录之后重置是否需要修改的值
                }
            }

        }

        private void dtYear1_ValueChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("改变了");
            isEdit = false; //将修改状态重新置 为false
            this.dgvHoloday.DataSource = ho.GetAllholiday(dtYear1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    string day = '01-01';
          //  string year ='2017'
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //List<MODEL.doc_holidayedit> holidaylist = new List<MODEL.doc_holidayedit>();
            //holidaylist = holbll.GetAllholiday("2016");
            //string c = holidaylist[3].time_f;
            //MessageBox.Show(c);
            //string[] arr = c.Split(new char[] { '-' });//将值排除逗号放入到String类型的数组
            //DateTime dt1 = new DateTime(2017, Convert.ToInt16(arr[0]), Convert.ToInt16(arr[1]));
            //MessageBox.Show(dt1.ToString());

            //   DateTime dt = new DateTime(myyear, 1, 1);


            List<MODEL.doc_holidayedit> holidaylist = new List<MODEL.doc_holidayedit>();
            holidaylist = ho.GetAllholiday("2016");
            string c = holidaylist[1].time_f;
            MessageBox.Show(c);
            string[] arr = c.Split(new char[] { '-' });//将值排除逗号放入到String类型的数组
            DateTime dt1 = new DateTime(2017, Convert.ToInt16(arr[0]), Convert.ToInt16(arr[1]));
            MessageBox.Show(dt1.ToString());
          
        }

        private void FrmHoliday_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
  