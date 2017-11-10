using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DAL


{
     public class doc_StyleSizeService
    {



        #region 获取所有型体尺碼信息  - List<MODEL.doc_StyleSize> GetStyleSizefromOrder(string yyyymm)
        /// <summary>
        /// 從訂單資料抓出來型體尺碼訊息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleSize> GetStyleSizefromOrder(string yyyymm)
        {
            string sql = @"
  select   StyleBase, Style  , Size ,min(OrderDate) OrderDate  from
( 
  select  distinct  Style,StyleBase,a.Name,d.Size,d.SizeID, a.OrderDate from doc_StyleBase  a
  left join(     
	  select  b.Name ,c.Size,OrderDate,c.SizeID  from T_StyleCodeInfo  b
	  right join (
    select SizeID, Size, T_StyleCodeInfoGuid from T_Sizi  ) c on b.Guid = c.T_StyleCodeInfoGuid 	
		) d on a.Name=d.Name	
)g
where OrderDate>=@OrderDate
Group by StyleBase,Style,g.Size
                ";
                  SqlParameter p = new SqlParameter("OrderDate",yyyymm);
                 DataTable dt = SqlHelper.ExcuteTable(sql,p);
               List<MODEL.doc_StyleSize> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_StyleSize>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_StyleSize c = new MODEL.doc_StyleSize();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  void LoadDataToList(DataRow dr, MODEL.doc_Style style)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_StyleSize stylesize)
        {
   
            stylesize.Style = (String)SqlHelper.FromDbValue(dr["Style"]);         
            stylesize.StyleBase = (String)SqlHelper.FromDbValue(dr["StyleBase"]);
            stylesize.Size = (String)SqlHelper.FromDbValue(dr["Size"]);
            stylesize.OrderDate = (String)SqlHelper.FromDbValue(dr["OrderDate"]);

        }
        #endregion


        /// <summary>  string GetSBNewCodeToSS(string yyyymm, string style)
        /// 尺码只需要从型体中找出大于该订单年月(表示有)的,新型体配色对应的 新型体中 最小的日期,(后面的就变成旧尺码)
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public string GetSBNewCodeToSS(string yyyymm, string style)
        {
            string sql = @"
  select min(newcode)  NewCode,Style from doc_StyleBase 
  where NewCode>=@NewCode and Style=@Style 
  group by Style

            ";
            SqlParameter[] ps = {
                               new SqlParameter("@NewCode",yyyymm),
                               new SqlParameter("@Style",style)
                                };
            return SqlHelper.ExcuteScalar<string>(sql, ps);

        }




        #region 获取所有型体尺码信息  - List<MODEL.doc_StyleSize> GetAllStyleSize()
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleSize> GetAllStyleSize()
        {
            string sql = @"
                select * from  doc_StyleSize 
            ";
            //SqlParameter[] ps = {
            //                   new SqlParameter("@OrderDate",yyyymm)
            //                    };

            DataTable dt = SqlHelper.ExcuteTable(sql);
            List<MODEL.doc_StyleSize> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_StyleSize>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_StyleSize c = new MODEL.doc_StyleSize();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion


        #region 获取所有型体尺码信息  - List<MODEL.doc_StyleSize> GetAllStyleSize1(string yyyymm)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleSize> GetAllStyleSize1(string yyyymm)
        {
            string sql = @"
                select * from  doc_StyleSize where OrderDate=@OrderDate
            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_StyleSize> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_StyleSize>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_StyleSize c = new MODEL.doc_StyleSize();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion





        #region 加载行数据到对象--集合  void LoadDataToList(DataRow dr, MODEL.doc_StyleSize stylesize)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_StyleSize stylesize)
        {
            stylesize.Style = (String)SqlHelper.FromDbValue(dr["Style"]);
            stylesize.OrderDate = (String)SqlHelper.FromDbValue(dr["OrderDate"]);
            stylesize.Size = (String)SqlHelper.FromDbValue(dr["Size"]);
            stylesize.NewCode = (String)SqlHelper.FromDbValue(dr["NewCode"]);
        }
        #endregion


        #region 更新型體尺码newcode日期  - int updateStyleSizeNewCode(string style, string newcode)
        /// <summary>
        /// NewCode日期可能後續月份,表示此新型體,後續月份還有,以此判斷新型體會做多久
        /// </summary>
        /// <param name="style , newcode"></param>
        /// <returns></returns>

        public int updateStyleSizeNewCode(string style, string newcode)
        {
            string sql = @"
                                    update doc_StyleSize set NewCode=@NewCode  where Style=@Style
                                   ";
            SqlParameter[] ps = {
                             new SqlParameter("@Style",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(style) },
                             new SqlParameter("@NewCode", SqlDbType.NVarChar) { Value = SqlHelper.ToDbValue(newcode) }
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion






















        #region 增加型体尺碼 - int AddStyleSize(MODEL .doc_Style  addStyle)
        /// <summary>
        /// 增加人员信息
        /// </summary>
        /// <param name="addStyle"></param>
        /// <returns></returns>
        public int AddStyleSize(MODEL.doc_StyleSize addStyleSize)
        {
            string sql = "";

            sql = @"		insert into doc_StyleSize(Guid,Style,StyleBase,OrderDate,Section,Size,BoxSize,Weight,L,W,H ,Unit,NewCode) 
	            values(@Guid,@Style,@StyleBase,@OrderDate,@Section,@Size,@BoxSize,@Weight,@L,@W,@H ,@Unit,@NewCode) ";


            SqlParameter[] ps = {
                              new SqlParameter("@Guid",SqlDbType .UniqueIdentifier) {Value=SqlHelper.ToDbValue( addStyleSize.Guid) },
                                new SqlParameter("@Style",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.Style) },
                               new SqlParameter("@StyleBase",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.StyleBase) },
                               new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.OrderDate) },
                               new SqlParameter("@Section",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.Section) },
                                 new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.Size) },
                               new SqlParameter("@BoxSize",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.BoxSize) },
                              new SqlParameter("@Unit",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.Unit) },
                               new SqlParameter("@Weight",SqlDbType.Float) {Value=SqlHelper.ToDbValue( addStyleSize.Weight) },
                                new SqlParameter("@Range",SqlDbType.Float) {Value=SqlHelper.ToDbValue( addStyleSize.Range) },
                              new SqlParameter("@L",SqlDbType.Float) {Value=SqlHelper.ToDbValue( addStyleSize.L) },
                               new SqlParameter("@W",SqlDbType.Float) {Value=SqlHelper.ToDbValue( addStyleSize.W) },
                               new SqlParameter("@H",SqlDbType.Float) {Value=SqlHelper.ToDbValue( addStyleSize.H) },
                               new SqlParameter("@NewCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleSize.NewCode) }
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

        #region 验证型体尺碼是否存在 - int IsStyleSizeExisits(string style,string size)
         /// <summary>
        ///  形体大类 可能一个工厂型体会有多个客户型体 ,所以判断有没有客户型体Name
        /// </summary>
        /// <param name="style","size"></param>
        /// <returns></returns>
        public int IsStyleSizeExisits(string style,string size)
        {

            string sql = "select count(*) from doc_StyleSize  where Style=@Style and Size=@Size ";
            SqlParameter[] ps = {
                              new SqlParameter("@Style",SqlDbType .NVarChar) {Value=SqlHelper.ToDbValue( style) },
                              new SqlParameter("@Size",SqlDbType .NVarChar) {Value=SqlHelper.ToDbValue( size) },

                                            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
          

        }
        #endregion






    }
}
