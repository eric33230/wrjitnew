using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
     public class doc_calendarService
    {

        MODEL.doc_calendar calendar = new MODEL.doc_calendar();
        string sql = "";
        #region 验证工作日历日期是否存在  -int IsDateExist(string date)
        /// <summary>
        /// 验证日期其是否已经存在 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int IsDateExist(DateTime date)
        {
            string sql = "select count(*) from doc_calendar where  date=@date";
            SqlParameter p1 = new SqlParameter("date", date);
            return SqlHelper.ExcuteScalar<int>(sql, p1);
        }
        #endregion


#region 增加工作日历  - int AddCalendar(MODEL.doc_calendar addCalendar)
/// <summary>
/// 增加工作日历
/// </summary>
/// <param name="addCalendar"></param>
/// <returns></returns>
public int AddCalendar(MODEL.doc_calendar addCalendar)
        {

         
            sql = "insert into doc_calendar(date,year,month,day,weekday,week,worktime,basetime,explain,planstr,isholiday)  values(@date,@year,@month, @day,@weekday,@week,@worktime, @basetime,@explain,@planstr,@isholiday)";
            SqlParameter[] ps = {
                                new SqlParameter("date",addCalendar.date),
                                new SqlParameter("year",addCalendar.year),
                                new SqlParameter("month",addCalendar.month),
                                new SqlParameter("day",addCalendar.day),
                                new SqlParameter("weekday",addCalendar.weekday),
                                new SqlParameter("week",addCalendar.week),
                               new SqlParameter("worktime",addCalendar.worktime),
                                new SqlParameter("basetime",addCalendar.basetime),
                                new SqlParameter("explain",addCalendar.explain),
                                new SqlParameter("planstr",addCalendar.planstr),
                                new SqlParameter("isholiday",addCalendar.isholiday)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);



        }
        #endregion



        #region 更新工作日历  - int UpdateCalendar(MODEL.doc_calendar updateCalendar)
        /// <summary>
        /// 更新工作日历
        /// </summary>
        /// <param name="updateCalendar"></param>
        /// <returns></returns>

        public int updateCalendar(string myear, string mmonth,string  mday, string newworktime)
        {

            
            sql = "update doc_calendar  set worktime=@worktime where  year=@year and month=@month and day=@day ";
            SqlParameter[] ps = {

                                new SqlParameter("worktime",Convert.ToInt16(newworktime)),
                                new SqlParameter("year",myear),
                                new SqlParameter("month",Convert.ToInt16(mmonth)),
                                new SqlParameter("day",Convert.ToInt16(mday))
                                 };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 获取某年某月所有的工作日历  -  List<MODEL.doc_holidayedit> GetAllholiday(string year)
        /// <summary>
        /// 获取某年所有假期其訊息
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.doc_calendar> GetMonthCalendar(string year,string month)
        {
            string sql = "select * from doc_calendar where year=@year and  month=@month ";
            SqlParameter[] ps = {
                                new SqlParameter("year",year),
                               new SqlParameter("month",month)    
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_calendar> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_calendar>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_calendar c = new MODEL .doc_calendar();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }
        #endregion

        /*
                SELECT sum(worktime) FROM doc_calendar where week = 1 and month = 1  and year = '2017'
            SELECT sum(worktime) FROM doc_calendar where month = 1  and year = '2017'
            SELECT count(*) FROM doc_calendar where   worktime<>0 and weekday = 6 and  month = 1  and year = '2017' 
             SELECT count(*) FROM doc_calendar where  worktime<>0 and weekday<>6 and   month = 1  and year = '2017' 


                       */
        #region 计算某周的工时  -int getweektime(int week, int month, string year)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="></param>
        /// <returns></returns>
        public int getweektime(int week, int month, string year)
        {
            string sql = "select sum(worktime) from doc_calendar where week =@week  and month = @month   and year =@year";
            SqlParameter[] ps =
                {
                new SqlParameter("week", week),
                new SqlParameter("month", month),
              new SqlParameter("year", year)
              };
            return  SqlHelper.ExcuteScalar<int>(sql, ps);
            
        }        
        #endregion



        #region 计算每月的总工时  -int getmonthtime(int week, int month, string year)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="></param>
        /// <returns></returns>
        public int getmonthtime(int month, string year)
        {
            string sql = "select sum(worktime) from doc_calendar where month = @month   and year =@year";
            SqlParameter[] ps =
                {
             new SqlParameter("month", month),
              new SqlParameter("year", year)
              };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }

        #endregion



        #region 计算多少个周末  int getweekenday(int month, string year)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="></param>
        /// <returns></returns>
        public int getweekenday(int month, string year)
        {
            string sql = "select count(*) from doc_calendar where worktime <> 0 and weekday = 6 and  month =@month  and year =@year";
            SqlParameter[] ps =
                {
             new SqlParameter("month", month),
              new SqlParameter("year", year)
              };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }

        #endregion

        #region 计算平日多少天  int getnormalday(int month, string year)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="></param>
        /// <returns></returns>
        public int getnormalday(int month, string year)
        {
            string sql = "select count(*) from doc_calendar where worktime <> 0 and weekday <>6 and  month =@month  and year =@year";
            SqlParameter[] ps =
                {
             new SqlParameter("month", month),
              new SqlParameter("year", year)
              };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }

        #endregion






        #region 加载行数据到对象--集合  -void LoadDataToList(DataRow dr, MODEL.doc_calendar calendar)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_calendar calendar)
        {

             calendar.date =DateTime.Parse( dr["date"].ToString());
            calendar.year = dr["year"].ToString(); 
           calendar.month =int.Parse(dr["month"].ToString());
           calendar.day =int.Parse(dr["day"].ToString());
            calendar.weekday =int.Parse(dr["weekday"].ToString());
            calendar.isholiday =int.Parse(dr["isholiday"].ToString());
            calendar.week = int.Parse(dr["week"].ToString());
            

            if (dr["worktime"].ToString() != "")
            {
                calendar.worktime = int.Parse(dr["worktime"].ToString());
            }
            if (dr["basetime"].ToString() != "")
            {
                calendar.basetime = int.Parse(dr["basetime"].ToString());
            }
            if (dr["explain"].ToString() != "")
            {
                calendar.explain = dr["explain"].ToString();
            }
            if (dr["planstr"].ToString() != "")
            {
                calendar.planstr = int.Parse(dr["planstr"].ToString());
            }

        }


        #endregion



    }
}
