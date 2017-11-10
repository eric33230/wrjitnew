using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
     public class doc_OrderService
    {

        #region 验证订单是否存在 -int IsCustomStyleCodeExisits(string customstylecode )
        /// <summary>
        /// 验证订单是否存在 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsCustomStyleCodeExisits(string  customstylecode)
        {
            string sql = "select count(*) from doc_Order  where CustomStyleCode=@CustomStyleCode";
            SqlParameter p1 = new SqlParameter("CustomStyleCode", customstylecode);
            return SqlHelper.ExcuteScalar<int>(sql, p1);
        }
        #endregion
        
        #region 增加订单 -  int AddOrder(MODEL.doc_Order  order)
        /// 增加订单
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddOrder(MODEL.doc_Order  order)
        {
            //string sql = "";

            string sql = @"
    insert into doc_Order(Guid, T_StyleCodeInfoGuid, AimArea,Name,Code,GoodsTypeName,CustomBuyName,CustomName,CustomStyleCode,ManufactureOrder,CustomPO, TotalCount,OrderDate,ProdDate,CutNo,ShipMentDate,Style,Color,CartonBarcodeNeed,Type)
        values(@Guid, @T_StyleCodeInfoGuid, @AimArea, @Name, @Code, @GoodsTypeName,@CustomBuyName,@CustomName, @CustomStyleCode,@ManufactureOrder,@CustomPO, @TotalCount, @OrderDate,@ProdDate, @CutNo,@ShipMentDate, @Style, @Color,@CartonBarcodeNeed,@Type)";
            SqlParameter[] ps = {
                        
                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(order.Guid)},
                                new SqlParameter("@T_StyleCodeInfoGuid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(order.T_StyleCodeInfoGuid)},
                               new SqlParameter("@AimArea",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.AimArea)},
                               new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.Name)},
                               new SqlParameter("@Code",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.Code)},
                               new SqlParameter("@GoodsTypeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.GoodsTypeName)},
                              new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.CustomBuyName)},
                               new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.CustomName)},
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.CustomStyleCode)},
                               new SqlParameter("@ManufactureOrder",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.ManufactureOrder)},
                               new SqlParameter("@CustomPO",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.CustomPO)},
                               new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.TotalCount)}                               ,
                              new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.OrderDate)},
                               new SqlParameter("@ProdDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.ProdDate)},
                              new SqlParameter("@CutNo",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.CutNo)},
                               new SqlParameter("@ShipMentDate",SqlDbType.DateTime) {Value=SqlHelper.ToDbValue(order.ShipMentDate)},
                               new SqlParameter("@Style",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.Style)},
                              new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.Color)},
                               new SqlParameter("@CartonBarcodeNeed",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.CartonBarcodeNeed)},
                               new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(order.Type)}

                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

        #region 获取訂單信息  - List<MODEL.doc_Order> GetOrderASICS(string yyyymm)
        /// <summary>
        /// 获取訂單信息
        /// </summary> ...................................and CustomName='ASICS' 
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrderASICS(string yyyymm)
        {

            string sql = @"
 select Guid, Code,Style,Name,Color,  customstylecode,CustomName,CustomBuyName,AimArea,GoodsTypeName,CutNo, TotalCount , Packlisttotalcount,OrderDate,ShipMentDate,ProdDate,CustomPO,ManufactureOrder,CartonBarcodeNeed,Type
from doc_Order
 where  OrderDate=@OrderDate  and CustomName='ASICS' 
  order by CustomStyleCode 
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_Order> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Order>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Order c = new MODEL.doc_Order();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 获取訂單信息  - List<MODEL.doc_Order> GetOrder(string yyyymm)
        /// <summary>
        /// 获取訂單信息
        /// </summary> ...................................and CustomName='ASICS' 
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrder(string  yyyymm)
        {            

            string sql = @"
 select Guid, Code,Style,Name,Color,  customstylecode,CustomName,CustomBuyName,AimArea,GoodsTypeName,CutNo, TotalCount , Packlisttotalcount,OrderDate,ShipMentDate,ProdDate,CustomPO,ManufactureOrder,CartonBarcodeNeed,Type
from doc_Order
 where  OrderDate=@OrderDate  
  order by CustomStyleCode 
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql,ps);
            List<MODEL.doc_Order> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Order>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Order c = new MODEL.doc_Order();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 获取訂單信息  -  List<MODEL.doc_Order> GetOrderOne(string customstylecode)
        /// <summary>
        /// 获取訂單信息
        /// </summary> ...................................and CustomName='ASICS' 
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrderOne(string customstylecode)
        {

            string sql = @"
 select Guid, Code,Style,Name,Color,  customstylecode,CustomName,CustomBuyName,AimArea,GoodsTypeName,CutNo, TotalCount , Packlisttotalcount,OrderDate,ShipMentDate,ProdDate,CustomPO,ManufactureOrder,CartonBarcodeNeed,Type
from doc_Order
 where  CustomStyleCode=@CustomStyleCode  
  
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_Order> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Order>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Order c = new MODEL.doc_Order();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion


        #region 加载行数据到对象--集合 void LoadDataToList(DataRow dr, MODEL.doc_Order order)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_Order order)
        {
            order.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          //GUiD
            order.Code= (string)SqlHelper.FromDbValue(dr["Code"]);
            order.Style = (string)SqlHelper.FromDbValue(dr["Style"]);
            order.Name = (string)SqlHelper.FromDbValue(dr["Name"]); //客户型体
            order.Color= (string)SqlHelper.FromDbValue(dr["Color"]);

            order.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);
            order.Packlisttotalcount = (string)SqlHelper.FromDbValue(dr["Packlisttotalcount"]);

            order.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]); //訂單
            order.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]); //客戶
            order.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]); //客戶買主
            order.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]); //目的地
            order.GoodsTypeName = (string)SqlHelper.FromDbValue(dr["GoodsTypeName"]);
            order.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]); // 客戶po

            order.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);
            order.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);
            order.ProdDate = (string)SqlHelper.FromDbValue(dr["ProdDate"]);  
            order.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);
            order.ManufactureOrder= (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);
            order.CartonBarcodeNeed = (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);
            order.Type = (string)SqlHelper.FromDbValue(dr["Type"]);



        }
        #endregion
        

        #region 获取訂單信息與裝箱明細數量不同的訂單  - List<MODEL.doc_Order> GetOrderW(string yyyymm)
        /// <summary>
        /// 获取訂單信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrderW(string yyyymm)
        {

            string sql = @"

   select customstylecode, totalcount , Packlisttotalcount,OrderDate from doc_Order
 where  OrderDate=@OrderDate   and  CustomName='ASICS'
  and  totalcount != Packlisttotalcount 
  order by CustomStyleCode
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_Order> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Order>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Order c = new MODEL.doc_Order();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合 void LoadDataToList1(DataRow dr, MODEL.doc_Order order)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_Order order)
        {
            order.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);
            order.Packlisttotalcount = (string)SqlHelper.FromDbValue(dr["Packlisttotalcount"]);
            order.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]); //訂單
        }
        #endregion


        #region  查询訂單- List<MODEL.doc_Order> SeeOrder(string orderdate, string customname, string name, string customstylecode)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        public List<MODEL.doc_Order> SeeOrder(string orderdate, string customname, string name, string customstylecode,string custombuyname)
        {
            string sql = @"
            select CustomName,Name,Color,Type,Style,TotalCount,Code,CustomStyleCode,CustomBuyName,CartonBarcodeNeed from doc_Order
            ";
            List<string> listWhere = new List<string>();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            if (orderdate != "")
            {
                listWhere.Add(" Orderdate=@Orderdate ");
                listParameters.Add(new SqlParameter("@Orderdate", orderdate));
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
            if (custombuyname != "")
            {
                listWhere.Add(" CustomBuyName like @CustomBuyName ");
                listParameters.Add(new SqlParameter("@CustomBuyName", "%" + custombuyname + "%"));
            }



            if (listWhere.Count > 0)
            {
                string sqlWhere = string.Join(" and ", listWhere.ToArray());
                sql = sql + " where   " + sqlWhere + " order by CustomStyleCode ";
            }

            DataTable dt = SqlHelper.ExcuteTable(sql, listParameters.ToArray());
            List<MODEL.doc_Order> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Order>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Order c = new MODEL.doc_Order();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  void LoadDataToList2(DataRow dr, MODEL.doc_Order order)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_Order order)
        {
            //  CustomName,Name,Color,Type,Style,TotalCount,Code,CustomStyleCode,CustomBuyName
            order.CustomName = dr["CustomName"].ToString();//客户名称
            order.Name = (string)SqlHelper.FromDbValue(dr["Name"]); //客户型体
            order.Color = (string)SqlHelper.FromDbValue(dr["Color"]);
            order.Type = (string)SqlHelper.FromDbValue(dr["Type"]);
            order.Style = (string)SqlHelper.FromDbValue(dr["Style"]);
            order.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);
            order.Code = (string)SqlHelper.FromDbValue(dr["Code"]);
            order.CartonBarcodeNeed= (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);
            order.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);
            order.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);
        }
        #endregion





        #region 更新裝箱明細總數   int updatePacklisttotalcount(string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        public int updatePacklisttotalcount(string customstylecode,string packlisttotalcount)
        {

            string sql = @" 
            update doc_Order set Packlisttotalcount =@Packlisttotalcount
              where CustomStyleCode=@CustomStyleCode
            ";

            SqlParameter[] ps = {
              new SqlParameter("@Packlisttotalcount",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( packlisttotalcount) },
              new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( customstylecode) }
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);

        }
        #endregion




        public int GetPacklisttotalcount(string customstylecode)
        {
            string sql = @"
            select  sum(convert(int,TotalCount)) Packlisttotalcount from doc_PackList  where CustomStyleCode=@CustomStyleCode

            ";
            SqlParameter[] ps =
                {
              new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( customstylecode) }
            };


            return SqlHelper.ExcuteScalar<int>(sql, ps);


        }






    }
}
