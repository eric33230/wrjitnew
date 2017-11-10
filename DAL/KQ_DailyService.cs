using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
     public class KQ_DailyService
    {


        #region 查尋日考勤  - List<MODEL.KQ_Daily> SeeKQDaily(string kqdate)
        /// 查尋日考勤
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Daily> SeeKQDaily(string kqdate)
        {
            string sql = @"
  select * from KQ_Daily
  where KQDate=@KQDate and KQTime2 is not null and KQTime3 is not null and KQTime1 is not null
                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@KQDate",kqdate)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Daily> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Daily>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Daily c = new MODEL.KQ_Daily();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 查尋日考勤未打卡  -  List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate)
        /// 查尋日考勤
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate)
        {
            string sql = @"
  select * from KQ_Daily
  where KQDate=@KQDate
   and (KQTime2 is null or KQTime3 is  null or KQTime1 is null)

                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@KQDate",kqdate)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Daily> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Daily>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Daily c = new MODEL.KQ_Daily();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 查尋日部門考勤未打卡  -  List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate,string aidf ,string aidt)
        /// 查尋部門日考勤
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate,string aidf ,string aidt)
        {
            string sql = @"
  select * from KQ_Daily
  where KQDate=@KQDate
 and (AID>=@AIDF and AID<=@AIDT)
    and (KQTime2 is null or KQTime3 is  null or KQTime1 is null) 
	order by AID,EmpID

                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@KQDate",kqdate),
                               new SqlParameter("@AIDF",aidf),
                               new SqlParameter("@AIDT",aidt)

                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Daily> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Daily>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Daily c = new MODEL.KQ_Daily();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion


        #region 加载行数据到对象--  LoadDataToList(DataRow dr, MODEL.KQ_Daily kqdata)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.KQ_Daily kqdaily)
        {

            kqdaily.Machine = (string)SqlHelper.FromDbValue(dr["Machine"]);
            kqdaily.EmpID = (string)SqlHelper.FromDbValue(dr["EmpID"]);
            kqdaily.KhName = (string)SqlHelper.FromDbValue(dr["KhName"]);
            kqdaily.EnrollNo = (string)SqlHelper.FromDbValue(dr["EnrollNo"]);
            kqdaily.AID = (string)SqlHelper.FromDbValue(dr["AID"]);
            kqdaily.Unit = (string)SqlHelper.FromDbValue(dr["Unit"]);
            kqdaily.KQDate = (string)SqlHelper.FromDbValue(dr["KQDate"]);
            kqdaily.WHour = (string)SqlHelper.FromDbValue(dr["WHour"]);
            kqdaily.OHour = (string)SqlHelper.FromDbValue(dr["OHour"]);
            kqdaily.LMin1 = (string)SqlHelper.FromDbValue(dr["LMin1"]);
            kqdaily.EMin2 = (string)SqlHelper.FromDbValue(dr["EMin2"]);
            kqdaily.LMin2 = (string)SqlHelper.FromDbValue(dr["LMin2"]);
            kqdaily.EMin3 = (string)SqlHelper.FromDbValue(dr["EMin3"]);
            kqdaily.WS = (string)SqlHelper.FromDbValue(dr["WS"]); //忘記刷卡
            kqdaily.SJ = (string)SqlHelper.FromDbValue(dr["SJ"]); //事假
            kqdaily.KG = (string)SqlHelper.FromDbValue(dr["KG"]);//礦工
            kqdaily.WC = (string)SqlHelper.FromDbValue(dr["WC"]); //臨時外出
            kqdaily.BX= (string)SqlHelper.FromDbValue(dr["BX"]);//半薪
            kqdaily.BK = (string)SqlHelper.FromDbValue(dr["BK"]);//病假扣
            kqdaily.BG = (string)SqlHelper.FromDbValue(dr["BG"]);//病假給
            kqdaily.GK = (string)SqlHelper.FromDbValue(dr["GK"]);//工商扣
            kqdaily.GG = (string)SqlHelper.FromDbValue(dr["GG"]); //工商給
            kqdaily.HJ = (string)SqlHelper.FromDbValue(dr["HJ"]); //婚假
            kqdaily.DJ = (string)SqlHelper.FromDbValue(dr["DJ"]);//喪假
            kqdaily.Y3 = (string)SqlHelper.FromDbValue(dr["Y3"]);//三年多一天
            kqdaily.NJ = (string)SqlHelper.FromDbValue(dr["NJ"]);//年假
            kqdaily.KD = (string)SqlHelper.FromDbValue(dr["KD"]);//借假
            kqdaily.TB = (string)SqlHelper.FromDbValue(dr["TB"]);//特別假
            kqdaily.CC = (string)SqlHelper.FromDbValue(dr["CC"]);//產檢
            kqdaily.CJ = (string)SqlHelper.FromDbValue(dr["CJ"]); //產假
            kqdaily.PR = (string)SqlHelper.FromDbValue(dr["PR"]); //哺乳
            kqdaily.KQTime = (DateTime?)SqlHelper.FromDbValue(dr["KQTime"]);
            kqdaily.KQTime1= (DateTime?)SqlHelper.FromDbValue(dr["KQTime1"]);
            kqdaily.KQTime2 = (DateTime?)SqlHelper.FromDbValue(dr["KQTime2"]);
            kqdaily.KQTime3 = (DateTime?)SqlHelper.FromDbValue(dr["KQTime3"]);
            kqdaily.KQOut1= (DateTime?)SqlHelper.FromDbValue(dr["KQOut1"]);
            kqdaily.KQOut2 = (DateTime?)SqlHelper.FromDbValue(dr["KQOut2"]);
            kqdaily.KQOut3 = (DateTime?)SqlHelper.FromDbValue(dr["KQOut3"]);
            kqdaily.KQOut4 = (DateTime?)SqlHelper.FromDbValue(dr["KQOut4"]);
            kqdaily.KQOut5 = (DateTime?)SqlHelper.FromDbValue(dr["KQOut5"]);
            kqdaily.KQOut6 = (DateTime?)SqlHelper.FromDbValue(dr["KQOut6"]);
            kqdaily.KQOut7 = (DateTime?)SqlHelper.FromDbValue(dr["KQOut7"]);
            kqdaily.KQOut8 = (DateTime?)SqlHelper.FromDbValue(dr["KQOut8"]);
        }
        #endregion


        #region 更新日考勤 int updateKQDaily(string whout,string ohour, string lmin1,string emin2, string lmin2,string emin3)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateKQDaily(string whout, string ohour, string lmin1, string emin2, string lmin2, string emin3, Guid guid)
        {
            string sql = @" 
                update KQ_Daily  set   WHour=@WHour,OHour=@OHour,LMin1=@LMin1,LMin2=@LMin2,EMin2=@EMin2,EMin3=@EMin3  
                where Guid=@Guid       
                ";
            SqlParameter[] ps = {
                new SqlParameter("@WHour", whout),
                new SqlParameter("@OHour", ohour),
                new SqlParameter("@LMin1", lmin1),
                new SqlParameter("@EMin2", emin2),
                new SqlParameter("@LMin2", lmin2),
                new SqlParameter("@EMin3", emin3),
                new SqlParameter("@Guid", guid)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }



        #endregion





    }
}
