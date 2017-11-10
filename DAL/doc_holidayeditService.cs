using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
     public class doc_holidayeditService
    {

     DAL.doc_InnerBoxService ibs = new DAL.doc_InnerBoxService();

        #region 获取所有该年的所有假期  -  List<MODEL.doc_holidayedit> GetAllholiday(string year)
         /// <summary>
        /// 获取某年所有假期其訊息
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.doc_holidayedit> GetAllholiday(string year)
        {
            string sql = "select * from doc_holidayedit where date=@date and beover=0 order by time_f ";
            SqlParameter p = new SqlParameter("date", year);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.doc_holidayedit> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_holidayedit>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_holidayedit c = new MODEL.doc_holidayedit();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion
        
          #region 加载行数据到对象--集合  -void LoadDataToList(DataRow dr, MODEL.doc_holidayedit holiday)
                /// 加载行数据到对象--集合
                /// </summary>
                /// <param name="dr"></param>
                /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_holidayedit holiday)
        {
            holiday.id = dr["id"].ToString();
            if (dr["addTime"].ToString() != "")
            {          
                holiday.addTime = DateTime.Parse(dr["addTime"].ToString());
            }            
            holiday.date = dr["date"].ToString();
            holiday.explain = dr["explain"].ToString();
            holiday.time_f = dr["time_f"].ToString();
            holiday.time_t = dr["time_t"].ToString();
              holiday.beover =int.Parse(dr["beover"].ToString());
        
        }
        #endregion

        
        #region 增加假期信息  - int AddHoliday(MODEL.doc_holidayedit addHoliday)
        /// <summary>
        /// 增加假期信息
        /// </summary>
        /// <param name="addHoliday"></param>
        /// <returns></returns>
        public int AddHoliday(MODEL.doc_holidayedit addHoliday)
        {

            string sql = "";
            sql = "insert into doc_holidayedit(id,addTime,date,explain, time_f,time_t,beover) values(@id,@addTime,@date,@explain, @time_f,@time_t,@beover)";
            SqlParameter[] ps = {
                                new SqlParameter("id",addHoliday.id),
                                new SqlParameter("addTime",addHoliday.addTime),
                                new SqlParameter("date",addHoliday.date),
                                new SqlParameter("explain",addHoliday.explain),
                                new SqlParameter("time_f",addHoliday.time_f),
                                new SqlParameter("time_t",addHoliday.time_t),
                                new SqlParameter("beover",addHoliday.beover)             
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);

        }
        #endregion


        #region 软删除，只是将状态修改为已经删除-bool DeleteHolidaySoftly(int pid)
        /// <summary>
        /// 并不是真正的删除，只是将状态修改为已经删除 -bool DeletePersonSoftly(int pid)
        /// </summary>
        public int DeleteHolidaySoftly(string pid)
        {
            string sql = "update doc_holidayedit set beover=1 where id=@id";
            SqlParameter p = new SqlParameter("id", pid);
            return SqlHelper.ExecuteNonQuery(sql, p);
                        
        }
        #endregion

        #region 修改假期信息  -int UpdateHoliday(MODEL.doc_holidayedit addHoliday)
        /// <summary>
        /// 修改假期信息
        /// </summary>
        /// <param name="addHoliday"></param>
        /// <returns></returns>
        public int UpdateHoliday(MODEL.doc_holidayedit addHoliday)
        {
            string sql = "update doc_holidayedit set date=@date,explain=@explain,time_f=@time_f,time_t=@time_t  where id=@id ";
            SqlParameter[] ps = {

                                new SqlParameter("id",addHoliday.id),
                                new SqlParameter("date",addHoliday.date),
                                new SqlParameter("explain",addHoliday.explain),
                                new SqlParameter("time_f",addHoliday.time_f),
                                new SqlParameter("time_t",addHoliday.time_t)
                              
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion





    }

}

