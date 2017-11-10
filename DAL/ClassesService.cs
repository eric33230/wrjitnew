using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 班级表数据访问层类
    /// </summary>
    public class ClassesService
    {
        #region 获取所有班级信息  - List<MODEL.Classes> GetAllClass(bool isDel)
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Classes> GetAllClass(bool isDel)
        {
            string sql = "select * from classes where cisdel=@isdel";
            SqlParameter p = new SqlParameter("@isdel", isDel);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.Classes> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.Classes>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.Classes c = new MODEL.Classes();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        } 
        #endregion

        #region 加载行数据到对象--集合  -void LoadDataToList(DataRow dr, MODEL.Classes classes)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.Classes classes)
        {
            classes.CID = Convert.ToInt32(dr["CID"]);
            if (dr["CName"] != null && dr["CName"].ToString() != "")
            {
                classes.CName = dr["CName"].ToString();
            }
            classes.CCount = Convert.ToInt32(dr["CCount"]);
            classes.CImg = dr["CImg"].ToString();
            classes.CIsDel = Convert.ToInt32(dr["CIsDel"]) == 1 ? true : false;
            classes.CAddTime = Convert.ToDateTime(dr["CAddTime"]);
        } 
        #endregion

    }
}
