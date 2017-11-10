using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class doc_OrderSizeService
    {


        #region 验证订单明細是否存在 -nt IsOrderSizeExisits(string customstylecode,string size)
        /// <summary>
        /// 验证订单是否存在 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsOrderSizeExisits(string customstylecode,string size)
        {
            string sql = @"
            select count(*) from doc_OrderSize  where CustomStyleCode=@CustomStyleCode  and Size=@Size
                ";
            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)},
                               new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(size)}
                                };

            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion

        #region 增加订单明細 -  int AddOrderSize(MODEL.doc_Order  order)
        /// 增加订单
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddOrderSize(MODEL.doc_OrderSize ordersize)
        {
            //string sql = "";

            string sql = @"
    insert into doc_OrderSize(Guid, TsizeGuid, docOrderGuid,CustomName,CustomStyleCode,TotalCount,Code,Name,Color,OrderDate,Size,SizeCount, Type,InnerBarcode)
        values(@Guid, @TsizeGuid, @docOrderGuid,@CustomName,@CustomStyleCode, @TotalCount, @Code,@Name,@Color, @OrderDate,@Size,@SizeCount, @Type, @InnerBarcode)";
            SqlParameter[] ps = {
                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(ordersize.Guid)},
                                new SqlParameter("@TsizeGuid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(ordersize.TsizeGuid)},
                                new SqlParameter("@docOrderGuid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(ordersize.docOrderGuid)},
                              new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.CustomName)},
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.CustomStyleCode)},
                               new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.TotalCount)},
                               new SqlParameter("@Code",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.Code)},
                               new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.Name)},
                              new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.Color)},
                              new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.OrderDate)},
                              new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.Size)},
                              new SqlParameter("@SizeCount",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.SizeCount)},
                               new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.Type)},
                               new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(ordersize.InnerBarcode)}



            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region  查询訂單尺碼- List<MODEL.doc_OrderSize> SeeOrderSize(string orderdate, string customname, string name, string customstylecode)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        public List<MODEL.doc_OrderSize> SeeOrderSize(string orderdate, string customname, string name, string customstylecode)
        {
            string sql = @"
            select CustomName,Name,Color,Type,Size,Sizecount,Code,CustomStyleCode from doc_OrderSize
            ";
            List<string> listWhere = new List<string>();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            if (orderdate != "")
            {
                listWhere.Add(" Orderdate=@Orderdate ");
                listParameters.Add(new SqlParameter("@Orderdate",  orderdate ));
            }
            if (customname != "")
            {
                listWhere.Add(" CustomName like @CustomName ");
                listParameters.Add(new SqlParameter("@CustomName", "%" + customname + "%"));
            }
            if (name != "")
            {
                listWhere.Add(" Name like @Name ");
                listParameters.Add(new SqlParameter("@Name", "%" + name + "%"));
            }
            if (customstylecode != "")
            {
                listWhere.Add(" CustomStyleCode like @CustomStyleCode ");
                listParameters.Add(new SqlParameter("@CustomStyleCode", "%" + customstylecode + "%"));
            }



            if (listWhere.Count > 0)
            {
                string sqlWhere = string.Join(" and ", listWhere.ToArray());
                sql = sql + " where   " + sqlWhere +" order by CustomStyleCode,Size ";
            }

            DataTable dt = SqlHelper.ExcuteTable(sql, listParameters.ToArray());
            List<MODEL.doc_OrderSize> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_OrderSize>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_OrderSize c = new MODEL.doc_OrderSize();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  void LoadDataToList(DataRow dr, MODEL.doc_OrderSize ordersize)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_OrderSize ordersize)
        {
           // --customName,Name,Color,Type,Size,Sizecount,Code,CustomStyleCode
            ordersize.CustomName = dr["CustomName"].ToString();//客户名称
            ordersize.Name = (string)SqlHelper.FromDbValue(dr["Name"]); //客户型体
            ordersize.Color = (string)SqlHelper.FromDbValue(dr["Color"]);
            ordersize.Type = (string)SqlHelper.FromDbValue(dr["Type"]);
            ordersize.Size = (string)SqlHelper.FromDbValue(dr["Size"]);
            ordersize.SizeCount = (string)SqlHelper.FromDbValue(dr["SizeCount"]);
            ordersize.Code = (string)SqlHelper.FromDbValue(dr["Code"]);
            ordersize.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);

        }
        #endregion






        #region 获取訂單尺碼沒有內盒條碼的訊息  -  List<MODEL.doc_OrderSize> GetNoInnerBarcode(string yyyymm)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_OrderSize> GetNoInnerBarcode(string yyyymm)
        {

            string sql = @"
            select CustomName,Name,Color,Size,Type from doc_OrderSize
             where InnerBarcode is  null and OrderDate=@OrderDate and CustomName='ASICS'
             Group by CustomName,Name,Color,Size,Type
             Order by CustomName,Name ,Color,Size, Type 
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_OrderSize> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_OrderSize>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_OrderSize c = new MODEL.doc_OrderSize();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合 void LoadDataToList2(DataRow dr, MODEL.doc_OrderSize order)        
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_OrderSize order)
        {
            order.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);
            order.Name = (string)SqlHelper.FromDbValue(dr["Name"]);
            order.Color = (string)SqlHelper.FromDbValue(dr["Color"]);
            order.Type  = (string)SqlHelper.FromDbValue(dr["Type"]);
          order.Size = (string)SqlHelper.FromDbValue(dr["Size"]);
        }
        #endregion



        #region 更新訂單尺碼內盒條碼   int updateOrderSizeInnerBarcode(string name,string color,string size)
        /// <summary>
        ///    使用類型 更新比較快
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        public int updateOrderSizeInnerBarcode(string innbarcode,string name,string color,string size,string type)
        {

            string sql = @" 
            update doc_OrderSize  set InnerBarcode=@InnerBarcode
             where  Name=@Name and Color=@Color and Size=@Size and Type=@Type and InnerBarcode is null

            ";

            SqlParameter[] ps = {
                               new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(innbarcode)},
                               new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(name)},
                               new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(color)},
                               new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(size)},
                               new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(type)}
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region 獲取內盒條碼  string GetInnerBarcode(string name, string color, string size, string type)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cutno"></param>
        /// <returns></returns>

        public string GetInnerBarcode(string name, string color, string size, string type)
        {

            string sql = @" 
           select InnerBarcode from  doc_InnerBox
             where  Name=@Name and Color=@Color and Size=@Size and Type=@Type 
            ";

            SqlParameter[] ps = {
                               new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(name)},
                               new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(color)},
                               new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(size)},
                               new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(type)}
                                };
            return SqlHelper.ExcuteScalar<string>(sql, ps);
        }
        #endregion


    }
}
