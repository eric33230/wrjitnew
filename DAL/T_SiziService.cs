using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class T_SiziService
    {


        #region 获取订单的尺碼明細  -    List<MODEL.T_Sizi> GetTSize(string comstomstylecode)
        /// 获取订单的尺碼明細
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.T_Sizi> GetTSize(string comstomstylecode)
        {
            string sql = "   select  Guid,CustomStyleCode,Size,Ccount   from T_Sizi where CustomStyleCode=@CustomStyleCode  ";  
            SqlParameter[] ps = {
                                new SqlParameter("CustomStyleCode",comstomstylecode)
                                                      };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.T_Sizi> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.T_Sizi>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.T_Sizi c = new MODEL.T_Sizi();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion



        #region 加载行数据到对象--集合  -void  LoadDataToList(DataRow dr, MODEL.T_Sizi tsize)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.T_Sizi tsize)
        {
            tsize.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          //GUiD
            tsize.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]); //订单号
            tsize.Size = (string)SqlHelper.FromDbValue(dr["Size"]);
            tsize.Ccount = (string)SqlHelper.FromDbValue(dr["Ccount"]);


        }
        #endregion







    }
}
