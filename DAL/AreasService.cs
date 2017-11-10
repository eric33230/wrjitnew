using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AreasService
    {
        #region 获取所有地区信息 - List<MODEL.Areas> GetAllAreasList(bool isDel)
        /// <summary>
        /// 获取所有地区信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Areas> GetAllAreasList(bool isDel)
        {
            string sql = "select * from areas where adelFlag=@isdel";
            SqlParameter p1 = new SqlParameter("isdel", isDel);
            DataTable dt = SqlHelper.ExcuteTable(sql, p1);
            List<MODEL.Areas> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.Areas>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.Areas a = new MODEL.Areas();
                    //传递的是引用类型，有方法里面对引用类型的变量进行修改，原始值也会一起发生变化 ，因类传递的不是对象的值，而是对象的引用 ，方法和原始值指向同一个引用 。
                    LoadEntityData(a, row);
                    lists.Add(a);
                }
            }
            return lists;
        } 
        #endregion

        #region 将地区信息行对象转换为实体类对象 -void LoadEntityData(MODEL.Areas model, DataRow dr)
        /// <summary>
        /// 将地区信息行对象转换为实体类对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dr"></param>
        private void LoadEntityData(MODEL.Areas model, DataRow dr)
        {
            if (dr["AID"].ToString() != "")
            {
                model.AID = int.Parse(dr["AID"].ToString());
            }
            model.AName = dr["AName"].ToString();
            if (dr["APid"].ToString() != "")
            {
                model.APid = int.Parse(dr["APid"].ToString());
            }
            if (dr["ASort"].ToString() != "")
            {
                model.ASort = int.Parse(dr["ASort"].ToString());
            }
            if (dr["AAddTime"].ToString() != "")
            {
                model.AAddTime = DateTime.Parse(dr["AAddTime"].ToString());
            }
            if (dr["ADelFlag"].ToString() != "")
            {
                model.ADelFlag = bool.Parse(dr["ADelFlag"].ToString());
            }
        } 
        #endregion
    }
}
