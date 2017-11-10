using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
      public class doc_InnerBoxService
    {

        
        #region 获取所有班级信息List<MODEL.doc_InnerBox> GetEmptyBox(string yyyymm)
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.doc_InnerBox> GetEmptyBox(string yyyymm)
        {
            string sql = " select * from doc_innerBox where NewCode=@NewCode  and ( InnerBarcode='' or InnerBarcode is null )   ";
            SqlParameter p = new SqlParameter("NewCode", yyyymm);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.doc_InnerBox> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_InnerBox>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_InnerBox c = new MODEL.doc_InnerBox();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion


        #region 加载行数据到对象--集合  - void LoadDataToList1(DataRow dr, MODEL.doc_InnerBox innerbox)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_InnerBox innerbox)
        {
            innerbox.InnerBarcode = (String)SqlHelper.FromDbValue(dr["InnerBarcode"]);
          innerbox.Name = (String)SqlHelper.FromDbValue(dr["Name"]);
            innerbox.Style = (String)SqlHelper.FromDbValue(dr["Style"]);
            innerbox.Color = (String)SqlHelper.FromDbValue(dr["Color"]);
            innerbox.Size = (String)SqlHelper.FromDbValue(dr["Size"]);
            innerbox.Type = (String)SqlHelper.FromDbValue(dr["Type"]);
            innerbox.NewCode = (String)SqlHelper.FromDbValue(dr["NewCode"]);
        }
        #endregion


        

        #region 获取所有内盒信息List<MODEL.doc_InnerBox> GetAllInneBox(string innerbarcode)
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.doc_InnerBox> GetAllInneBox(string innerbarcode)
        {
            string sql = "select * from  doc_innerBox where InnerBarcode=@InnerBarcode ";
            SqlParameter p = new SqlParameter("InnerBarcode", innerbarcode);
            DataTable dt = SqlHelper.ExcuteTable(sql,p);
            List<MODEL.doc_InnerBox> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_InnerBox>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_InnerBox c = new MODEL.doc_InnerBox();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  - void LoadDataToList(DataRow dr, MODEL.doc_InnerBox innerbox)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_InnerBox innerbox)
        {
            innerbox.InnerBarcode = dr["InnerBarcode"].ToString();
            innerbox.StyleCode = dr["StyleCode"].ToString();
            innerbox.Style = dr["Style"].ToString();
            innerbox.Name = dr["Name"].ToString();
            innerbox.Color = dr["Color"].ToString();
            innerbox.Size = dr["Size"].ToString();
                }
        #endregion
        

        #region 增加內盒條碼資料 int AddInnerBox(MODEL.doc_InnerBox addInnerBox)
        /// <summary>
        /// 增加內盒條碼資料 , 內盒條碼使用掃描後 更新
        /// </summary>
        /// <param name="addInnerBox"></param>
        /// <returns></returns>
        public int AddInnerBox(MODEL.doc_InnerBox addInnerBox)
        {
            string sql = "";

            sql = @"	
                      insert into doc_InnerBox(Guid,InnerBarcode,StyleCode,Name,Style,Color,Size,Type,NewCode,CustomName)
	                values(@Guid,@InnerBarcode,@StyleCode,@Name,@Style,@Color,@Size,@Type,@NewCode,@CustomName) 
                ";
            SqlParameter[] ps = {
                              new SqlParameter("@Guid",SqlDbType .UniqueIdentifier) {Value=SqlHelper.ToDbValue( addInnerBox.Guid) },
                                new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.InnerBarcode) },
                               new SqlParameter("@StyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.StyleCode) },
                               new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.Name) },
                               new SqlParameter("@Style",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.Style) },
                               new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.Color) },
                               new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.Size) },
                               new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.Type) },
                               new SqlParameter("@NewCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.NewCode) },
                              new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addInnerBox.CustomName) }
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 验证內盒條碼基本資料是否存在 -int IsInnerBoxExisits(string name, string color ,string size)
        /// <summary>
        /// 验证內盒條碼基本資料是否存在 
        /// </summary>
        /// <param name="name,color,size"></param>
        /// <returns></returns>
        public int IsInnerBoxExisits(string name, string color, string size)
        {
            string sql =@"
                select count(*) from doc_InnerBox  where Name=@Name and Color=@Color and Size=@Size
                ";
            SqlParameter[] ps = {
                                          //      new SqlParameter("@Name",name),
                                          //   new SqlParameter("@Color",color),
                                          //new SqlParameter("@Size",size)

                                 new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(name) },
                                            new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(color) },
                                          new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(size) }
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion



        #region 获取所有該月訂單型体信息  - List<MODEL.doc_Style> GetIInnerfromOrder(string yyyymm)
        /// <summary>
        /// 用來確認內盒條碼 ,內盒尺碼,型體,配色 基本資料有沒有.... MARK NewCode
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_InnerBox> GetInnerfromOrder(string yyyymm)
        {
            string sql = @"
                select distinct  Style,Color, b.Name Name, Size,CustomName  from T_StyleCodeInfo b
                left join (
                select SizeID, Size, T_StyleCodeInfoGuid from T_Sizi) c on b.Guid = c.T_StyleCodeInfoGuid
                left join(
                select style, code, NewCode,Color  from doc_Style
                )e on e.Code = b.Code 
                where b.OrderDate >=@OrderDate  and size is not null  and style is not null and color is not null   order by b.Name, e.Color
                    ";
            SqlParameter p = new SqlParameter("OrderDate", yyyymm);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.doc_InnerBox> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_InnerBox>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_InnerBox c = new MODEL.doc_InnerBox();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  void LoadDataToList1(DataRow dr, MODEL.doc_Style style)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_InnerBox style)
        {
            style.Style = (String)SqlHelper.FromDbValue(dr["Style"]);
            style.Color = (String)SqlHelper.FromDbValue(dr["Color"]);
            style.Name = (String)SqlHelper.FromDbValue(dr["Name"]);
            style.Size = (String)SqlHelper.FromDbValue(dr["Size"]);
            style.CustomName = (String)SqlHelper.FromDbValue(dr["CustomName"]);
        }
        #endregion


        //---- 小明

        public void sqlbulkcopy(DataTable table)
        {
            SqlHelper.SqlBulkCopy(table);
        }

        public int getInnerBoxByGuid(string guid)
        {
            String sql = @"select * from doc_InnerBox where guid='" + guid + "'";
            DataTable table = SqlHelper.ExecuteReader(sql);
            int i = table.Rows.Count;
            return i;


        }
        public int CleanRe()
        {
            String sql = @"exec InnerBoxRepeatDel";
            int i = SqlHelper.ExecuteNonQuery(sql);
            return i;
        }








    }
}
