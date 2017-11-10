using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class doc_BuyerService
    {

        #region 获取所有客户买主  -  List<MODEL.doc_Buyer> GetAllBuyer()
        /// <summary>
        /// 获取某年所有假期其訊息
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.doc_Buyer> GetAllBuyer()
        {
            string sql = "select * from doc_Buyer order by CustomName,CustomBuyOwner,CustomBuyName,Destination   ";
       
            DataTable dt = SqlHelper.ExcuteTable(sql);
            List<MODEL.doc_Buyer> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Buyer>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Buyer c = new MODEL.doc_Buyer();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        public List<MODEL.doc_Buyer> GetAllBuyer(List<string> codes, List<string> values)
        {
            if(codes.Count>0)
            {
                codes.Distinct().ToList();

            }
            if (values.Count > 0)
            {
                values.Distinct().ToList();

            }
            string sqlstr = "";
            if (codes.Count>0)
            {
                for (int i = 0; i < codes.Count; i++)
                {
                    sqlstr = sqlstr + codes[i] + " like '%" + values[i] + "%' and ";
                }
            }
            string sql = @"select * from doc_Buyer WHERE "+ sqlstr + 
                @" 1=1 order by CustomName,CustomBuyOwner,CustomBuyName,Destination";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            List<MODEL.doc_Buyer> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_Buyer>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Buyer c = new MODEL.doc_Buyer();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #region 加载行数据到对象--集合  -void LoadDataToList(DataRow dr, MODEL.doc_Buyer buyer)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_Buyer buyer)
        {
            buyer.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          //GUiD
            buyer.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);
            buyer.CustomBuyOwner = (string)SqlHelper.FromDbValue(dr["CustomBuyOwner"]);
            buyer.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);
            buyer.CartonBarcodeNeed= (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);
            buyer.Forwarder = (string)SqlHelper.FromDbValue(dr["Forwarder"]);
            buyer.Type = (string)SqlHelper.FromDbValue(dr["Type"]);
            buyer.State = (string)SqlHelper.FromDbValue(dr["State"]);
            buyer.Country = (string)SqlHelper.FromDbValue(dr["Country"]);
            buyer.CountryChinese = (string)SqlHelper.FromDbValue(dr["CountryChinese"]);
            buyer.Destination = (string)SqlHelper.FromDbValue(dr["Destination"]);
 

        }
        #endregion

        #region 获取订单年月目的地  -  List<MODEL.doc_Buyer> GetABuyerE(string yyyymm)
        /// <summary>
        /// 获取某年所有假期其訊息
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.doc_Buyer> GetlBuyerE(string yyyymm)
        {
            string sql = @"

  select CustomName,CustomBuyName,AimArea Destination  from T_StyleCodeInfo
  where OrderDate >=@OrderDate and AimArea is not null 
  Group by CustomName,CustomBuyName,AimArea
  except
  select CustomName,CustomBuyName,Destination from doc_Buyer
            ";

             SqlParameter p = new SqlParameter("@OrderDate",yyyymm);
            DataTable dt = SqlHelper.ExcuteTable(sql,p);
            List<MODEL.doc_Buyer> listbuyere = null;
            if (dt.Rows.Count > 0)
            {
                listbuyere = new List<MODEL.doc_Buyer>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_Buyer c = new MODEL.doc_Buyer();
                    LoadDataToList1(row, c);
                    listbuyere.Add(c);
                }
            }
            return listbuyere;
        }
        #endregion

        #region 加载行数据到对象--集合  -void LoadDataToList1(DataRow dr, MODEL.doc_Buyer buyer)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_Buyer buyer)
        {
   
            buyer.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);
            string ds= (string)SqlHelper.FromDbValue(dr["Destination"]);
            buyer.Destination = ds.Trim();
            buyer.CustomBuyName= (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);

        }
        #endregion


        #region 新增客户买主目的地 - int newtDestination(string customname, string destination)
        /// <summary>
        ///  只增加客户跟目的地两栏位增加一笔资料 其余使用更新
        /// </summary>
        /// <param name="name , newcode"></param>
        /// <returns></returns>

        public int newtDestination(string customname, string destination,string custombuyname)
        {
            string sql = @"
            insert into doc_Buyer(Guid,CustomName,Destination,CustomBuyName)
            values(@Guid, @CustomName, @Destination,@CustomBuyName)";
            SqlParameter[] ps = {
                                new SqlParameter("Guid",SqlDbType.UniqueIdentifier) {Value=Guid.NewGuid()}, 
                                new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customname)},
                               new SqlParameter("@Destination",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( destination)},
                               new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( custombuyname)}
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);

        }
        #endregion


        #region 更新客户买主  - int updateBuyer(string colname, string colvalue, string guid)
        /// <summary>
        ///  传入要更新的栏位名称,栏位值,与唯一的GUID
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateBuyer(string colname, string colvalue, string guid)
        {

            string sql = @" update doc_Buyer set " + colname + "=@" + colname + "  where Guid=@Guid";

            SqlParameter[] ps = {
                             new SqlParameter("@"+colname,colvalue) ,
                             new SqlParameter("@Guid", guid)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion






    }
}
