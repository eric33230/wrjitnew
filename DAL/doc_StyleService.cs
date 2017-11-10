using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
     public  class doc_StyleService
    {


        #region 增加型体 - int AddStyle(MODEL.doc_Style  addStyle)
        /// <summary>
        /// 增加人员信息
        /// </summary>
        /// <param name="addStyle"></param>
        /// <returns></returns>
        public int AddStyle(MODEL.doc_Style  addStyle)
        {
            string sql = "";
       
   sql = " insert into doc_Style(Guid, Code, Style, OrderDate, Color) values(NEWID(), @Code,@Style, @OrderDate, @Color)";

            SqlParameter[] ps = {
        //                        new SqlParameter("Guid",addStyle.Code),
                                new SqlParameter("Code",addStyle.Code),
                                new SqlParameter("Style",addStyle.Style),
                                new SqlParameter("OrderDate",addStyle.OrderDate),
                                new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyle.Color) }
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region 验证工厂型体是否存在 -int IsCodeExisits(string code)
        /// <summary>
        /// 验证登录名是否已经存在 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsCodeExisits(string code)
        {
            string sql = "select count(*) from doc_Style  where Code=@Code";
            SqlParameter p1 = new SqlParameter("Code", code);
            return SqlHelper.ExcuteScalar<int>(sql, p1);
        }
        #endregion





        #region 获取所有型体尺码信息  - List<MODEL.doc_Style> GetAllStyle()
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Style> GetAllStyle()
        {
            string sql = "select * from  doc_Style ";
            //      SqlParameter p = new SqlParameter("", );
            DataTable dt = SqlHelper.ExcuteTable(sql);
            List<MODEL.doc_Style> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Style>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Style d = new MODEL.doc_Style();
                    LoadDataToList2(row, d);
                    lists.Add(d);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  void LoadDataToLis1t(DataRow dr, MODEL.doc_Style style)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_Style style)
        {
            style.Style = (String)SqlHelper.FromDbValue(dr["Style"]);
            style.Code = (String)SqlHelper.FromDbValue(dr["Code"]);
            style.Color = (String)SqlHelper.FromDbValue(dr["Color"]);
            style.OrderDate = (String)SqlHelper.FromDbValue(dr["OrderDate"]);
            style.Image= (Byte[])SqlHelper.FromDbValue(dr["Image"]);
            style.NewCode = (String)SqlHelper.FromDbValue(dr["NewCode"]);
        }
        #endregion


        

        #region 根據訂單年月获取型體年月的信息  -  string GetSNewCode(string yyyymm, string code)
        /// <summary>
        /// 比較OrderDate and NewCode 就可以知道是否為新型體        /
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public string GetSNewCode(string yyyymm, string code)
        {
            string sql = @"
	      select distinct NewCode=(select distinct OrderDate+' ' from T_StyleCodeInfo  b
            where OrderDate>=@OrderDate
		    and b.Name=a.Name for XML PATH('') ) ,Code
            from T_StyleCodeInfo a
            where OrderDate>=@OrderDate
			and Code=@Code
            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm),
                               new SqlParameter("@Code",code)
                                };
            return SqlHelper.ExcuteScalar<string>(sql, ps);
              }
        
        #endregion




        #region 更新型體配色的newcode日期  - int updateStyleNewCode(string code, string newcode)
        /// <summary>
        /// NewCode日期可能後續月份,表示此新型體配色,後續月份還有,以此判斷新型體會做多久
        /// </summary>
        /// <param name="name , newcode"></param>
        /// <returns></returns>

        public int updateStyleNewCode(string code, string newcode)
        {
            string sql = @"
                                    update doc_Style set NewCode=@NewCode  where Code=@Code
                                   ";
            SqlParameter[] ps = {
                             new SqlParameter("@Code",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( code) },
                             new SqlParameter("@NewCode", SqlDbType.NVarChar) { Value = SqlHelper.ToDbValue(newcode) }
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion
                
        








    }
}
