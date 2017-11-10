using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmKQDaily : Form
    {
        public FrmKQDaily()
        {
            InitializeComponent();
            this.dgvDepartment.AutoGenerateColumns = false;
            this.dgvKQD.AutoGenerateColumns = false;
        }
        static FrmKQDaily frm;
        public static FrmKQDaily GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmKQDaily();
            }
            return frm;
        }


        BLL.KQ_DataManager dm = new BLL.KQ_DataManager();
        List<MODEL.KQ_Data> dml = new List<MODEL.KQ_Data>();
        List<MODEL.KQ_Data> dmlx = new List<MODEL.KQ_Data>();

        BLL.KQ_DailyManager dailym = new BLL.KQ_DailyManager();
        List<MODEL.KQ_Daily> dailyml = new List<MODEL.KQ_Daily>();
        List<MODEL.KQ_Section> sml = new List<MODEL.KQ_Section>();
        DateTime from1f;
        DateTime from1to;
        DateTime from1fstd;
        DateTime from1tostd;
        DateTime from2f;
        DateTime from2to;
        DateTime from2fstd;
        DateTime from2tostd;
        DateTime from3f;
        DateTime from3to;
        DateTime from3fstd;
        DateTime from3tostd;
        DateTime from4f;
        DateTime from4to;
        DateTime from5f;
        DateTime from5to;




        int myear;
        int mmonth;
        int mday;
        int mhour1f = 0; int mmin1f = 0; int mhour1to = 0; int mmin1to = 0; int mhour1fstd = 0; int mmin1fstd = 0; int mhour1tostd = 0; int mmin1tostd = 0;
        int mhour2f = 0; int mmin2f = 0; int mhour2to = 0; int mmin2to = 0; int mhour2fstd = 0; int mmin2fstd = 0; int mhour2tostd = 0; int mmin2tostd = 0;
        int mhour3f = 0; int mmin3f = 0; int mhour3to = 0; int mmin3to = 0; int mhour3fstd = 0; int mmin3fstd = 0; int mhour3tostd = 0; int mmin3tostd = 0;
        int mhour4f = 0; int mmin4f = 0; int mhour4to = 0; int mmin4to = 0;
        int mhour5f = 0; int mmin5f = 0; int mhour5to = 0; int mmin5to = 0;




        decimal aidf;
        decimal aidt;

        private void FrmKQDaily_Load(object sender, EventArgs e)
        {
            aidf = Convert.ToDecimal(17.11);
            aidt = Convert.ToDecimal(29.9);

            dgvDepartment.DataSource = dm.GetDapartment(aidf, aidt);
            ClassTime("1");

        }



        public void ClassTime(string mclass)
        {
            int myear = dtpToday.Value.Year;
            int mmonth = dtpToday.Value.Month;
            int mday = dtpToday.Value.Day;
            int mhour1 = 0; int mmin1 = 0; int mhour1to = 0; int mmin1to = 0;
            int mhour2 = 0; int mmin2 = 0; int mhour2to = 0; int mmin2to = 0;
            int mhour3 = 0; int mmin3 = 0; int mhour3to = 0; int mmin3to = 0;
            int mhour4 = 0; int mmin4 = 0; int mhour4to = 0; int mmin4to = 0;
            int mhour5 = 0; int mmin5 = 0; int mhour5to = 0; int mmin5to = 0;
            string mg = mclass;
            sml = dm.SeeKQSection(mg);
            for (int i = 0; i < sml.Count; i++)
            {
                if (sml[i].Section == "1") { mhour1 = sml[i].HourF; mmin1 = sml[i].MinF; mhour1to = sml[i].HourT; mmin1to = sml[i].MinT; }
                if (sml[i].Section == "2") { mhour2 = sml[i].HourF; mmin2 = sml[i].MinF; mhour2to = sml[i].HourT; mmin2to = sml[i].MinT; }
                if (sml[i].Section == "3") { mhour3 = sml[i].HourF; mmin3 = sml[i].MinF; mhour3to = sml[i].HourT; mmin3to = sml[i].MinT; }
                if (sml[i].Section == "4") { mhour4 = sml[i].HourF; mmin4 = sml[i].MinF; mhour4to = sml[i].HourT; mmin4to = sml[i].MinT; }
                if (sml[i].Section == "5") { mhour5 = sml[i].HourF; mmin5 = sml[i].MinF; mhour5to = sml[i].HourT; mmin5to = sml[i].MinT; }
            }

            // 設定各時段的時間段
            //早上上班 ,中午下班 ,晚上下班, 中間外出時間
            DateTime from1 = new DateTime(myear, mmonth, mday, mhour1, mmin1, 0);
            DateTime from1to = new DateTime(myear, mmonth, mday, mhour1to, mmin1to, 0);
            DateTime from2 = new DateTime(myear, mmonth, mday, mhour2, mmin2, 0);
            DateTime from2to = new DateTime(myear, mmonth, mday, mhour2to, mmin2to, 0);
            DateTime from3 = new DateTime(myear, mmonth, mday, mhour3, mmin3, 0);
            DateTime from3to = new DateTime(myear, mmonth, mday, mhour3to, mmin3to, 0);
            DateTime from4 = new DateTime(myear, mmonth, mday, mhour4, mmin4, 0);
            DateTime from4to = new DateTime(myear, mmonth, mday, mhour4to, mmin4to, 0);
            DateTime from5 = new DateTime(myear, mmonth, mday, mhour5, mmin5, 0);
            DateTime from5to = new DateTime(myear, mmonth, mday, mhour5to, mmin5to, 0);

        }

















        private void button1_Click(object sender, EventArgs e)
        {

            DateTime mtime = new DateTime(2105, 5, 5, 14, 9, 20);
            DateTime mtime1 = new DateTime(2105, 5, 5, 16, 9, 20);
            if (mtime1 > mtime)

                dtp1.Value = mtime;



        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbTo.Checked == true)
            {
                txtAIDTo.Text = this.dgvDepartment.Rows[e.RowIndex].Cells["AID"].Value.ToString();
            }
            else
            {
                txtAIDFrom.Text = this.dgvDepartment.Rows[e.RowIndex].Cells["AID"].Value.ToString();
            }
        }

        private void dgvKQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSeeDept_Click(object sender, EventArgs e)
        {
            if (txtAIDFrom.Text == "")
            {
                MessageBox.Show("部門代號不可以為空");
                return;
            }

            if (cbALL.Checked == true)
            {
                aidf = Convert.ToDecimal(17.11);
                aidt = Convert.ToDecimal(29.9);
            }
            else
            {
                if (txtAIDTo.Text == "")
                {
                    float num;
                    if (float.TryParse(txtAIDFrom.Text, out num) == false) //尝试转换为浮点数
                    {
                        MessageBox.Show("请输入数字");
                        txtAIDFrom.Text = "";
                        return;
                    }
                    aidf = Convert.ToDecimal(txtAIDFrom.Text);
                    aidt = Convert.ToDecimal(txtAIDFrom.Text);
                }
                else
                {
                    float num;
                    if (float.TryParse(txtAIDFrom.Text, out num) == false) //尝试转换为浮点数
                    {
                        MessageBox.Show("请输入数字");
                        txtAIDFrom.Text = "";
                        return;
                    }
                    if (float.TryParse(txtAIDTo.Text, out num) == false) //尝试转换为浮点数
                    {
                        MessageBox.Show("请输入数字");
                        txtAIDTo.Text = "";
                        return;
                    }

                    aidf = Convert.ToDecimal(txtAIDFrom.Text);
                    aidt = Convert.ToDecimal(txtAIDTo.Text);
                }

            }
            dgvDepartment.DataSource = dm.GetDapartment(aidf, aidt);

        }


        private void btnData_Click(object sender, EventArgs e)
        {
            string mg = "1";
            KQSection(mg);

            // 指定格式轉換 不然會連時間都轉換
            DateTime mdayfrom = dtpToday.Value;
            DateTime mdayto = mdayfrom.AddDays(1);
            dgvKQ.DataSource = dm.CheckKQData(mdayfrom.ToString("yyyy-MM-dd"), mdayto.ToString("yyyy-MM-dd"));
            if (dgvKQ.RowCount > 0)
            {
                test.Clear();
                test.Clear();
                test.AppendText(mdayfrom.ToString("yyyy-MM-dd") + "\r\n" + "卡號沒有對應工號與部門");
                MessageBox.Show("請回人事管理Employee,設定卡號EnrollNo");
                return;
            }
            //沒有考勤資料不能轉,這個要在CeeckKQData前面,否則 沒資料也會跑資料已經好了,不能再轉
            dml = dm.SeeKQData(mdayfrom.ToString("yyyy-MM-dd"), mdayto.ToString("yyyy-MM-dd"));
            if (dml == null)
            {
                test.Clear();
                test.AppendText(mdayfrom.ToString("yyyy-MM-dd") + "\r\n" + "沒有考勤資料" + "\r\n" + "請去接轉,小明的 該日打卡钟资料");
                return;
            }


            //資料轉OK了不用再轉
            if (dm.CheckKQData(mdayfrom.ToString("yyyy-MM-dd"), mdayto.ToString("yyyy-MM-dd")) == null)
            {
                test.Clear();
                test.AppendText(mdayfrom.ToString("yyyy-MM-dd") + "\r\n" + "OK" + "\r\n" + "已經接轉完畢");
                return;
            }

            //  dml = dm.SeeKQData(mdayfrom.ToString("yyyy-MM-dd"), mdayto.ToString("yyyy-MM-dd"));

            for (int i = 0; i < dml.Count; i++)
            {
                if (dml[i].KQTime >= from1f && dml[i].KQTime <= from1to)
                {
                    dml[i].TimeNO = "1";
                }
                if (dml[i].KQTime >= from2f && dml[i].KQTime <= from2to)
                {
                    dml[i].TimeNO = "2";
                }
                if (dml[i].KQTime >= from3f && dml[i].KQTime <= from3to)
                {
                    dml[i].TimeNO = "3";
                }
                if ((dml[i].KQTime > from4f && dml[i].KQTime < from4to) || (dml[i].KQTime > from5f && dml[i].KQTime < from5to))
                {
                    dml[i].TimeNO = "4";
                }

                dml[i].KQDate = dtpToday.Text;
                dm.updateKQData(dml[i].Guid, dml[i].TimeNO, dml[i].EmpID, dml[i].AID, dml[i].KhName, dml[i].KQDate);
                test.Clear();
                test.AppendText(dml[i].EmpID + "\r\n" + dml[i].KQTime.ToString() + "\r\n" + (i + 1).ToString() + " / " + dml.Count.ToString());
            }

            dgvKQ.DataSource = dml;


        }

        private void txt_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (IsNumeric(txt1.Text) == false)
            //{
            //    MessageBox.Show("請輸入數字");
            //    return;
            //}
            //if (IsUnsign(txt1.Text) == false)
            //{
            //    //-22 數字不能過
            //    MessageBox.Show("非符號");
            //}
            //if (IsInt(txt1.Text) == false)
            //{
            //    MessageBox.Show("非整數");
            //}



        }
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        public static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^\d*[.]?\d*$");
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            //if (IsNumeric(txt1.Text) == false)
            //{
            //    MessageBox.Show("請輸入數字");
            //    return;
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            test.Clear();
            DateTime mdayfrom = dtpToday.Value;
            DateTime mdayto = mdayfrom.AddDays(1);
            dgvKQ.DataSource = dm.CheckKQData(mdayfrom.ToString("yyyy-MM-dd"), mdayto.ToString("yyyy-MM-dd"));
            //检查考钟基本资料接转完毕没有
            if (dgvKQ.RowCount > 0)
            {
                test.Clear();
                test.AppendText(mdayfrom.ToString("yyyy-MM-dd") + "\r\n" + "打卡钟资料不完全,请接转");

                return;
            }

            //Table 定義數據類型
            DataTable daily = new DataTable();
            daily.Columns.Add("Machine");
            daily.Columns.Add("EmpID");
            daily.Columns.Add("KhName");
            daily.Columns.Add("EnrollNo");
            daily.Columns.Add("AID");
            daily.Columns.Add("Unit");
            daily.Columns.Add("KQDate");
            //      daily.Columns.Add("KQDate", typeof(SqlDateTime));
            //         daily.Columns.Add("KQTime", typeof(SqlDateTime));
            daily.Columns.Add("KQTime1", typeof(SqlDateTime));
            daily.Columns.Add("KQTime2", typeof(SqlDateTime));
            daily.Columns.Add("KQTime3", typeof(SqlDateTime));
            daily.Columns.Add("KQOut1", typeof(SqlDateTime));
            daily.Columns.Add("KQOut2", typeof(SqlDateTime));
            daily.Columns.Add("KQOut3", typeof(SqlDateTime));
            daily.Columns.Add("KQOut4", typeof(SqlDateTime));
            daily.Columns.Add("KQOut5", typeof(SqlDateTime));
            daily.Columns.Add("KQOut6", typeof(SqlDateTime));
            daily.Columns.Add("KQOut7", typeof(SqlDateTime));
            daily.Columns.Add("KQOut8", typeof(SqlDateTime));

            //沒有考勤資料不能轉,這個要在CeeckKQData前面,否則 沒資料也會跑資料已經好了,不能再轉

            //  dml = dm.SeeKQData(mdayfrom.ToString("yyyy-MM-dd"), mdayto.ToString("yyyy-MM-dd"));
            dml = dm.SeeKQDataEmpID(dtpToday.Text);
            if (dml == null)
            {
                test.Clear();
                test.AppendText(mdayfrom.ToString("yyyy-MM-dd") + "\r\n" + "沒有考勤資料" + "\r\n" + "請去接轉,該日打卡钟资料");
                return;
            }


            for (int k = 0; k < dml.Count; k++)
            {
                test.Clear();
                //  dml[i].EmpID
                test.AppendText(dml[k].EmpID + "\r\n" + (k + 1).ToString() + " / " + dml.Count.ToString());
                daily.Rows.Add();
                daily.Rows[k]["EmpID"] = dml[k].EmpID;
                daily.Rows[k]["AID"] = dml[k].AID;
                daily.Rows[k]["KQDate"] = dtpToday.Text;
                dmlx = dm.SeeKQDataByID(dml[k].EmpID, dtpToday.Text);
                int kk = 0;
                DateTime reparttime = Convert.ToDateTime("2017-01-01 13:00:00.000");
                for (int i = 0; i < dmlx.Count; i++)
                {
                    if (reparttime == dmlx[i].KQTime)
                    {
                        break; ;
                    }


                    daily.Rows[k]["Machine"] = dmlx[0].Machine;
                    daily.Rows[k]["KhName"] = dmlx[0].KhName;
                    daily.Rows[k]["Unit"] = "";
                    daily.Rows[k]["EnrollNo"] = dmlx[0].EnrollNo.ToString();
                    if (dmlx[i].TimeNO == "1") { daily.Rows[k]["KQTime1"] = dmlx[i].KQTime; };
                    if (dmlx[i].TimeNO == "2") { daily.Rows[k]["KQTime2"] = dmlx[i].KQTime; };
                    if (dmlx[i].TimeNO == "3") { daily.Rows[k]["KQTime3"] = dmlx[i].KQTime; };
                    if (dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5")
                    {
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 0) { daily.Rows[k]["KQOut1"] = dmlx[i].KQTime; };
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 1) { daily.Rows[k]["KQOut2"] = dmlx[i].KQTime; };
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 2) { daily.Rows[k]["KQOut3"] = dmlx[i].KQTime; };
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 3) { daily.Rows[k]["KQOut4"] = dmlx[i].KQTime; };
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 4) { daily.Rows[k]["KQOut5"] = dmlx[i].KQTime; };
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 5) { daily.Rows[k]["KQOut6"] = dmlx[i].KQTime; };
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 6) { daily.Rows[k]["KQOut7"] = dmlx[i].KQTime; };
                        if ((dmlx[i].TimeNO == "4" || dmlx[i].TimeNO == "5") && kk == 7) { daily.Rows[k]["KQOut8"] = dmlx[i].KQTime; };
                        kk++;
                    }
                    reparttime = (DateTime)dmlx[i].KQTime;

                }
                //        test.AppendText(daily.Rows[i]["EmpID"] + "\r\n" + (i + 1).ToString() + " / " + dml.Count.ToString());
                //       test.AppendText("Test" + "\r\n" + (i + 1).ToString() + " / " + dml.Count.ToString());

            }
            dm.InsertBulkKQDaily(daily);
            MessageBox.Show("OK");


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWHour_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txtWHour.Text) == false)
            { MessageBox.Show("請輸入數字"); txtWHour.Text = ""; return; }
            if (IsUnsign(txtWHour.Text) == false)
            { MessageBox.Show("數字不能為負"); txtWHour.Text = ""; return; }

        }

        private void txtOHour_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(txtOHour.Text) == false)
            { MessageBox.Show("請輸入數字"); txtOHour.Text = ""; return; }
            if (IsUnsign(txtWHour.Text) == false)
            { MessageBox.Show("數字不能為負"); txtOHour.Text = ""; return; }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            //test2
            //test
            string mg = "1";
            KQSection(mg);
            // MessageBox.Show("from1fstd:" + from1fstd.ToString());
            // MessageBox.Show("from1tostd:" + from1tostd.ToString());
            // MessageBox.Show("from2fstd:" + from2fstd.ToString());
            //MessageBox.Show("from2tostd:" + from2tostd.ToString());
            // MessageBox.Show("from3fstd:" + from3fstd.ToString());
            // MessageBox.Show("from3tostd:" + from3tostd.ToString());

            dailyml = dailym.SeeKQDaily(dtpToday.Text);
            //             dailyml = dailym.SeeKQDaily(dtpToday.Text);
            dgvKQD.DataSource = dailyml;
            //      dailyml = dailym.SeeKQDaily("2017-09-05");
            if (dailyml == null)
            { MessageBox.Show("沒有" + dtpToday.Text + "資料,請接轉"); return; }


            string mLMin1, mEMin2, mLMin2, mEmin3;
            int mOHour = 0, mWhour = 0;
            for (int i = 0; i < dailyml.Count; i++)
            {
                //早班遲到
                if (dailyml[i].KQTime1 < from1fstd)
                { TimeSpan ts = (TimeSpan)(from1fstd - dailyml[i].KQTime1); mLMin1 = ts.Minutes.ToString(); }
                else { mLMin1 = "0"; };
                //中班早退
                if (dailyml[i].KQTime2 < from2fstd)
                { TimeSpan ts1 = (TimeSpan)(from2fstd - dailyml[i].KQTime2); mEMin2 = ts1.Minutes.ToString(); }
                else { mEMin2 = "0"; };
                //中班遲到
                if (dailyml[i].KQTime2 > from2tostd)
                { TimeSpan ts2 = (TimeSpan)(dailyml[i].KQTime2 - from2tostd); mLMin2 = ts2.Minutes.ToString(); }
                else { mLMin2 = "0"; };
                //晚班早退
                if (dailyml[i].KQTime3 < from3fstd)
                { TimeSpan ts3 = (TimeSpan)(from3tostd - dailyml[i].KQTime3); mEmin3 = ts3.Minutes.ToString(); }
                else { mEmin3 = "0"; };
                // 加班
                if (dailyml[i].KQTime3 > from3fstd && dailyml[i].KQTime3 <= from3tostd)
                {
                    TimeSpan tso = (TimeSpan)(from3tostd - dailyml[i].KQTime3);
                    int mo = tso.Minutes;
                    if (mo > 30 && mo <= 60) { mOHour = 60; };
                    if (mo > 60 && mo <= 90) { mOHour = 90; };
                    if (mo > 90 && mo <= 180) { mOHour = 180; };
                }
                else { mOHour = 0; };
                mWhour = 8;

                dailym.updateKQDaily(mWhour.ToString(), mOHour.ToString(), mLMin1, mEMin2, mLMin2, mEmin3, dailyml[i].Guid);
                dailyml = dailym.SeeKQDaily(dtpToday.Text);
                dgvKQD.DataSource = dailyml;

            }



        }

        private void KQSection(string my)
        {
            myear = dtpToday.Value.Year;
            mmonth = dtpToday.Value.Month;
            mday = dtpToday.Value.Day;
            sml = dm.SeeKQSection(my);
            for (int i = 0; i < sml.Count; i++)
            {
                if (sml[i].Section == "1") { mhour1f = sml[i].HourF; mmin1f = sml[i].MinF; mhour1to = sml[i].HourT; mmin1to = sml[i].MinT; mhour1fstd = sml[i].HourFSTD; mmin1fstd = sml[i].MinFSTD; mhour1tostd = sml[i].HourTSTD; mmin1tostd = sml[i].MinTSTD; }
                if (sml[i].Section == "2") { mhour2f = sml[i].HourF; mmin2f = sml[i].MinF; mhour2to = sml[i].HourT; mmin2to = sml[i].MinT; mhour2fstd = sml[i].HourFSTD; mmin2fstd = sml[i].MinFSTD; mhour2tostd = sml[i].HourTSTD; mmin2tostd = sml[i].MinTSTD; }
                if (sml[i].Section == "3") { mhour3f = sml[i].HourF; mmin3f = sml[i].MinF; mhour3to = sml[i].HourT; mmin3to = sml[i].MinT; mhour3fstd = sml[i].HourFSTD; mmin3fstd = sml[i].MinFSTD; mhour3tostd = sml[i].HourTSTD; mmin3tostd = sml[i].MinTSTD; }
                if (sml[i].Section == "4") { mhour4f = sml[i].HourF; mmin4f = sml[i].MinF; mhour4to = sml[i].HourT; mmin4to = sml[i].MinT; }
                if (sml[i].Section == "5") { mhour5f = sml[i].HourF; mmin5f = sml[i].MinF; mhour5to = sml[i].HourT; mmin5to = sml[i].MinT; }
            }
            // 設定各時段的時間段
            //早上上班 ,中午下班 ,晚上下班, 中間外出時間
            from1f = new DateTime(myear, mmonth, mday, mhour1f, mmin1f, 0);
            from1to = new DateTime(myear, mmonth, mday, mhour1to, mmin1to, 0);
            from1fstd = new DateTime(myear, mmonth, mday, mhour1fstd, mmin1fstd, 0);
            from1tostd = new DateTime(myear, mmonth, mday, mhour1tostd, mmin1tostd, 0);

            from2f = new DateTime(myear, mmonth, mday, mhour2f, mmin2f, 0);
            from2to = new DateTime(myear, mmonth, mday, mhour2to, mmin2to, 0);
            from2fstd = new DateTime(myear, mmonth, mday, mhour2fstd, mmin2fstd, 0);
            from2tostd = new DateTime(myear, mmonth, mday, mhour2tostd, mmin2tostd, 0);

            from3f = new DateTime(myear, mmonth, mday, mhour3f, mmin3f, 0);
            from3to = new DateTime(myear, mmonth, mday, mhour3to, mmin3to, 0);
            from3fstd = new DateTime(myear, mmonth, mday, mhour3fstd, mmin3fstd, 0);
            from3tostd = new DateTime(myear, mmonth, mday, mhour3tostd, mmin3tostd, 0);

            from4f = new DateTime(myear, mmonth, mday, mhour4f, mmin4f, 0);
            from4to = new DateTime(myear, mmonth, mday, mhour4to, mmin4to, 0);
            from5f = new DateTime(myear, mmonth, mday, mhour5f, mmin5f, 0);
            from5to = new DateTime(myear, mmonth, mday, mhour5to, mmin5to, 0);


        }

        private void btnKQDataNo_Click(object sender, EventArgs e)
        {
            test.Text = "";
            string maidf = "17.11111";
            string maidt = "19.99003";
            //全選就是上面的所有部門,沒有全選,就是以下選擇的部門
            if (cbALL.Checked == false)
            {
               // MessageBox.Show("false");
                if (txtAIDFrom.Text == "")
                {
                    MessageBox.Show("部門代號不可以為空,或是選擇ALL打勾");
                    return;
                };

                if (cbTo.Checked == true)
                {
                    maidf = txtAIDFrom.Text;
                    maidt = txtAIDTo.Text;
                    if(txtAIDTo.Text=="")
                    {
                        MessageBox.Show("To部門代號不可以為空,請選擇");
                        return;
                    }
                }
                else
                {
                    maidf = txtAIDFrom.Text;
                    maidt = txtAIDFrom.Text;
                }
            }
            else
            {
                maidf = "17.11111";
                maidt = "19.99003";

            }

       //     MessageBox.Show(maidf + "--" + maidt);
                dailyml = dailym.SeeKQDailyNO(dtpToday.Text, maidf, maidt);
                if (dailyml == null)
                {
                    if (cbALL.Checked == false) 
                    {
                        if (Convert.ToDecimal(maidf) > Convert.ToDecimal(maidt))
                        {
                            MessageBox.Show("From部門代號>To部門代號 ,請重新選擇");
                            txtAIDTo.Text = "";
                            return;
                        };
                    }

                    MessageBox.Show(dtpToday.Text+" "+maidf+ "沒有資料");
                    return;
                }
            test.Text ="總共有"+ dailyml.Count.ToString()+"筆"; 
            dgvKQD.DataSource = dailyml;
            

           
        }

        private void cbALL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbTo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtAIDTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Departmnet_Click(object sender, EventArgs e)
        {

        }

        private void txtAIDFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmKQDaily_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}