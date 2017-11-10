using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{



    public class base_cpbh_data_main
    {



    // MODEL.base_cpbh_data_main mystyleno = new MODEL.base_cpbh_data_main();
        #region  獲取工厂型体  -string   GetAllCode(string yearmonth)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearmonth"></param>
        /// <returns></returns>
        public List<MODEL.base_cpbh_data_main> GetOldStyle(string yearmonth)
        {
            string[] olddays = yearmonth.Split('-');
            string days = olddays[0].Substring(2, 2) + olddays[1];
          //  string days1 = "1201";
           
            string sql = "   select cpbh,days from base_cpbh_data_main where days >@days";
            SqlParameter p = new SqlParameter("days", days);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.base_cpbh_data_main> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.base_cpbh_data_main>();
               
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.base_cpbh_data_main c = new MODEL.base_cpbh_data_main();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion




        #region 加载行数据到对象--集合  -void LoadDataToList1(DataRow dr, MODEL.T_StyleCodeInfo  stylecode)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.base_cpbh_data_main mycode)
        {
            mycode.cpbh = dr["cpbh"].ToString();
            mycode.days = dr["days"].ToString();

        }


        #endregion


    }





}







