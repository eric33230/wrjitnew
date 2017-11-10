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
    public partial class FrmCalendar : Form
    {
        public FrmCalendar()
        {
            InitializeComponent();
        }

        static FrmCalendar frm;
        public static FrmCalendar GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmCalendar();
            }
            return frm;
        }


        private void btn1_Click(object sender, EventArgs e)
        {
        }

        private void FrmCalendar_Load(object sender, EventArgs e)
        {

             

            dtYear.Format = DateTimePickerFormat.Custom;
            dgvHoliday.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtYear.CustomFormat = "yyyy";           
            dtYear.ShowUpDown = true;      
            this.dgvHoliday.Columns[0].HeaderText = "星期天";
            this.dgvHoliday.Columns[1].HeaderText = "星期一";
            this.dgvHoliday.Columns[2].HeaderText = "星期二";
            this.dgvHoliday.Columns[3].HeaderText = "星期三";
            this.dgvHoliday.Columns[4].HeaderText = "星期四";
            this.dgvHoliday.Columns[5].HeaderText = "星期五";
            this.dgvHoliday.Columns[6].HeaderText = "星期六";
            this.dgvHoliday.Columns[7].HeaderText = "計畫編號";

            ///改變列寬
            this.dgvHoliday.Columns["Column0"].Width = 80;
            this.dgvHoliday.Columns["Column1"].Width = 80;
            this.dgvHoliday.Columns["Column2"].Width = 80;
            this.dgvHoliday.Columns["Column3"].Width = 80;
            this.dgvHoliday.Columns["Column4"].Width = 80;
            this.dgvHoliday.Columns["Column5"].Width = 80;
            this.dgvHoliday.Columns["Column6"].Width = 80;
            this.dgvHoliday.Columns["Column7"].Width = 100;

            ///
            this.dgvHoliday.Rows.Add(11);




        }

        private void dataGridViewCustom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        BLL.doc_calendarManager cabll = new BLL.doc_calendarManager();
        BLL.doc_holidayeditManager hobll = new BLL.doc_holidayeditManager();
        MODEL.doc_calendar calendar = new MODEL.doc_calendar();
        MODEL.doc_holidayedit holiday = new MODEL.doc_holidayedit();
        int isEdit = 0;

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            int myyear = Convert.ToInt16(dtYear.Text);
            DateTime dt = new DateTime(myyear, 1, 1);
            DateTime dtyear = new DateTime(myyear + 1, 1, 1);
            dtyear = dtyear.AddDays(-1);
            int yday = dtyear.DayOfYear;

            if (cabll.IsDateExist(dt) >=1)   
            {
                MessageBox.Show(dt.Year.ToString() + "已经生成了");
                return;
            }


            pbar1.Maximum = yday;
            #region 年度基本资料更新
            for (int i = 0; i < yday; i++)
            {

                pbar1.Value = i;
                calendar.date = dt;
                calendar.year = dt.Year.ToString();
                calendar.month = dt.Month;
                calendar.day = dt.Day;
                calendar.weekday = (int)dt.DayOfWeek;     //星期几 
                calendar.week = ((dt.Day + 5 - (int)dt.DayOfWeek)) / 7 + 1;
                 calendar.planstr = Common.myCommon.GetDayofWeek(dt, calendar.year);
                //string test =getholiday(dt.Year, dt.Month, dt.Day);    // 节假日
                calendar.explain = getholiday(dt.Year, dt.Month, dt.Day);  // 节假日
            if (calendar.explain == "")
                { calendar.isholiday = 0; }   //1 =节假日 }
                
                else { calendar.isholiday = 1; }


                if ((dt.Day == 10 && (int)dt.DayOfWeek != 0) || (int)dt.DayOfWeek == 6)
                {
                    calendar.worktime = 8;   //工作时间
                    calendar.basetime = 8;   //标准工时
                }
                else
                {
                    if ((int)dt.DayOfWeek == 0)
                    {
                        calendar.worktime = 0;   //工作时间
                        calendar.basetime = 0;   //标准工时
                    }
                    else
                    {
                        calendar.worktime = 10;   //工作时间
                        calendar.basetime = 8;   //标准工时
                    }
                

                }
            if(calendar.isholiday == 1)
                    {
                        calendar.worktime = 0;   //工作时间
                        calendar.basetime = 0;   //标准工时
                    }

                if (cabll.IsDateExist(dt) < 1)
                //  if (cabll.AddCalendar(calendar) == 1)
                {
                   cabll.AddCalendar(calendar);
                
               //     MessageBox.Show("年度资料新增,准备更新节假日");
                }
                  
                dt = dt.AddDays(1);
            }
      
        #endregion



    }

    List<MODEL.doc_holidayedit> holists = new List<MODEL.doc_holidayedit>();


        #region 节假日取得
        
        private string getholiday(int year, int month, int day)
        {
           
            DateTime dtnow = new DateTime(year, month, day);
            holists = hobll.GetAllholiday(dtYear.Text);
            string holiday = "";


            /// 判断节假日开始结束时间内,节假日返回

            for (int j = 0; j < holists.Count; j++)

            {
                  string[] sstar = holists[j].time_f.Split('-');
                DateTime dtstar = new DateTime(Convert.ToInt16(dtYear.Text), Convert.ToInt16(sstar[0]), Convert.ToInt16(sstar[1]));
                string[] sto = holists[j].time_t.Split('-');
                DateTime dtto = new DateTime(Convert.ToInt16(dtYear.Text), Convert.ToInt16(sto[0]), Convert.ToInt16(sto[1]));

                if (dtnow >= dtstar && dtnow <= dtto)
                {
                    holiday = holists[j].explain;

                }
                else
                {
                   
                }

           }

            return holiday;
        }

      #endregion

        private void FrmCalendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void cleancalendar()
        {
            for (int a = 0; a < 12; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    this.dgvHoliday.Rows[a].Cells[b].Value = "";
                    this.dgvHoliday.Rows[a].Cells[b].Style.BackColor = Color.White;
                    this.dgvHoliday.Rows[a].Cells[b].ReadOnly = true;
                }
            }
        }

        private void dtYear_ValueChanged(object sender, EventArgs e)
        {

        }


        int i;
        private void dtMonth_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("哈哈");
         
            List<MODEL.doc_calendar> li = new List<MODEL.doc_calendar>();
            li = cabll.GetMonthCalendar(dtYear.Text, dtMonth.Text);

             cleancalendar();


            //// 先行计算总工时totalworktime,周工时weekworktime 
                     
            int totalworkhour = 0;
            int weekday = 0;
            int nomalday = 0;
            int w1 = 0; int w2 = 0;int w3 = 0;int w4 = 0;int w5 = 0; int w5have=0;int w6 = 0 ;int w6have = 0;
            for (i = 0; i < li.Count; i++)
             {
                //周末天数
                if (li[i].weekday==6 && li[i].worktime!=0)
                {
                    weekday = weekday + 1;
                }
                //平日天数
                if (li[i].weekday != 6 && li[i].worktime != 0)
                {
                                       nomalday = nomalday + 1;
                }


                // 月总工时     
                totalworkhour = li[i].worktime.Value + totalworkhour;


                this.dgvHoliday.Rows[2 * li[i].week - 2].Cells[li[i].weekday].Value = li[i].day.ToString() + "\r\n" + li[i].explain; //日期+假日
                this.dgvHoliday.Rows[2 * li[i].week - 2].Height = 50;
                this.dgvHoliday.Rows[2 * li[i].week - 2].Cells[li[i].weekday].ReadOnly = true;
                this.dgvHoliday.Rows[2 * li[i].week - 2].Cells[7].Value = li[i].planstr;// .ToString(); //计划编号
                this.dgvHoliday.Rows[2 * li[i].week - 2].Cells[0].Style.BackColor =Color.Orange; //节假日颜色
                this.dgvHoliday.Rows[10].Cells[6].Value= "周末天数";
               this.dgvHoliday.Rows[10].Cells[5].Value = "平日天数";
                this.dgvHoliday.Rows[10].Cells[4].Value = "工作天数";
                this.dgvHoliday.Rows[10].Cells[3].Value = "月份工时";
                this.dgvHoliday.Rows[2 * li[i].week - 1].Cells[li[i].weekday].Value = li[i].worktime;// .ToString();
                this.dgvHoliday.Rows[2 * li[i].week - 1].Height = 15;
                this.dgvHoliday.Rows[2 * li[i].week - 1].Cells[li[i].weekday].Style.BackColor = Color.LightGoldenrodYellow;
                this.dgvHoliday.Rows[2 * li[i].week - 1].Cells[li[i].weekday].ReadOnly = false;
                //this.dgvHoliday.Rows[2 * li[i].week - 1].Cells[7].Value = Convert.ToString(cabll.getweektime(li[i].week, Convert.ToInt16(dtMonth.Text),dtYear.Text)); //周总工时
                //不调用查询资料库,加快显示数度
                if (2*li[i].week-1 ==1)
                {
                    w1 = li[i].worktime.Value + w1;
                }
                if (2 * li[i].week - 1 == 3)
                {
                    w2 = li[i].worktime.Value + w2;
                }
                if (2 * li[i].week - 1 == 5)
                {
                    w3 = li[i].worktime.Value + w3;
                }
                if (2 * li[i].week - 1 == 7)
                {
                    w4 = li[i].worktime.Value + w4;
                }
                if (2 * li[i].week - 1 == 9)
                {
                    w5have = 1;
                    w5 = li[i].worktime.Value + w5;
                }
                if (2 * li[i].week - 1 == 11)
                {
                    w6have = 1;
                    w6 = li[i].worktime.Value + w6;
                }



                if (li[i].isholiday==1)
                {
                     this.dgvHoliday.Rows[2 * li[i].week - 2].Cells[li[i].weekday].Style.BackColor = Color.LightBlue; //日期有假日的颜色
                    this.dgvHoliday.Rows[2 * li[i].week - 1].Cells[li[i].weekday].Style.BackColor = Color.LightBlue; //日期有假日的颜色
                }

            }

            this.dgvHoliday.Rows[11].Cells[3].Value = totalworkhour; //月份工时
            this.dgvHoliday.Rows[11].Cells[6].Value = weekday ; //周末天数
            this.dgvHoliday.Rows[11].Cells[5].Value = nomalday; //"平日天树
            this.dgvHoliday.Rows[11].Cells[4].Value = nomalday+weekday; //"平日天树
            this.dgvHoliday.Rows[1].Cells[7].Value = w1;
            this.dgvHoliday.Rows[3].Cells[7].Value = w2;
            this.dgvHoliday.Rows[5].Cells[7].Value = w3;
            this.dgvHoliday.Rows[7].Cells[7].Value = w4;
            if (w5have == 1)
            {
                this.dgvHoliday.Rows[9].Cells[7].Value = w5;
            }
            if (w6have == 1)
            {
                this.dgvHoliday.Rows[11].Cells[7].Value = w6;
            }
        }

        private void pbar1_Click(object sender, EventArgs e)
        {

        }
       string oldworktime = "";
        private void dgvHoliday_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            oldworktime = this.dgvHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            isEdit = 1; //编辑模式开启
     
         //   cabll.updateCalendar(date, worktime, explain, isholiday);
        }

        private void dgvHoliday_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isEdit == 1)
            {
                string myear = dtYear.Text;
                string mmonth = dtMonth.Text; 
                string mday = (string)this.dgvHoliday.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value;
                string newworktime= (string)this.dgvHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (newworktime==null||newworktime.Length<=0)
                {
                    isEdit = 0; //不change
                    newworktime = oldworktime;
                    this.dgvHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldworktime;
                    
                }


                if (System.Text.RegularExpressions.Regex.IsMatch(newworktime, @"^[0-9]+(.[0-9]{1,2})?$"))
                {
                    MessageBox.Show(myear + "/" + mmonth + "/" + mday + "工作时间为" + newworktime+"小时");
                    cabll.updateCalendar(myear, mmonth, mday, newworktime);
                    dgvHoliday.Refresh();
                    isEdit = 0;
                        }
                else
                {
                    this.dgvHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex].Value=oldworktime;
                     isEdit = 0;
                }
          
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void FrmCalendar_Activated(object sender, EventArgs e)
        {
            //tb13.Focus();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void dgvHoliday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    } 
}
