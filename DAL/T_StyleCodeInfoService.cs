using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DAL
{



    public class T_StyleCodeInfoService
    {


    
        #region 获取订单年月的所有订单  -   List<MODEL.T_StyleCodeInfo> GetAllorder(string yearrmonth)
        /// <summary>
        /// 获取订单年月的所有订单
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.T_StyleCodeInfo> GetAllorder(string yearrmonth)
      //  public List<MODEL.T_StyleCodeInfo> GetAllorder(string code)
        {
           string sql = " select  *  from T_StyleCodeInfo where OrderDate=@OrderDate  and CustomStyleCode like 'SW%' ";
     //     string sql = " select * from T_StyleCodeInfo where  code=@code order by OrderDate asc ";            
                    SqlParameter[] ps = {
                                new SqlParameter("OrderDate",yearrmonth)
                       //        new SqlParameter("code",code)
                                                      };
        DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.T_StyleCodeInfo> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.T_StyleCodeInfo>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.T_StyleCodeInfo    c = new MODEL.T_StyleCodeInfo();
                    LoadDataToList(row, c);
                   lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        

        #region 加载行数据到对象--集合  -void LoadDataToList(DataRow dr, MODEL.T_StyleCodeInfo  stylecode)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.T_StyleCodeInfo  stylecode)
        {
              stylecode.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          //GUiD
            stylecode.AimArea=(string)SqlHelper.FromDbValue(dr["AimArea"]); //目的地港口
            stylecode.Name = (string)SqlHelper.FromDbValue(dr["Name"]);  // 客户型体
            stylecode.Code = (string)SqlHelper.FromDbValue(dr["Code"]);     //工厂型体
            stylecode.GoodsTypeName = (string)SqlHelper.FromDbValue(dr["GoodsTypeName"]); //鞋型种类名称
            stylecode.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]); //客户买主
            stylecode.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]); //客户
            stylecode.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]); //订单号
            stylecode.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]); //订单数量
            stylecode.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]); //订单年月
            stylecode.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]); //PO 订单号
            stylecode.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]); //客户交期
            stylecode.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);
            stylecode.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);
        }
        #endregion



        #region  獲取工厂型体 List<MODEL.T_StyleCodeInfo> GetAllCode(string yearrmonth)
        /// <summary>
        /// 订单中 的工厂型体, 对应型体中的工厂型体,把 型体中 没有工厂型体的新配色抓出来 建立(新配色 可能也没有新型体在stylebase 中判断)
        /// 
        /// </summary>
        /// <param name="yearmonth"></param>
        /// <returns></returns>

        public List<MODEL.T_StyleCodeInfo> GetAllCode(string yearrmonth)
        {       
  
            string sql = @"
              select  Code, MIN(OrderDate) OrderDate from T_StyleCodeInfo   where OrderDate >=@OrderDate  group by Code  Order By OrderDate
                ";


            //select code, min(OrderDate) Orderdatemin from T_StyleCodeInfo  where OrderDate >=@OrderDate   group by code order by code ";
            SqlParameter p = new SqlParameter("OrderDate", yearrmonth);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.T_StyleCodeInfo> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.T_StyleCodeInfo>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.T_StyleCodeInfo c = new MODEL.T_StyleCodeInfo();
                    LoadDataToList1(row, c);
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
        public void LoadDataToList1(DataRow dr, MODEL.T_StyleCodeInfo stylecode)
        {
            stylecode.Code = dr["Code"].ToString();
            stylecode.OrderDate = dr["OrderDate"].ToString();
   //         stylecode.stylecount = (int)dr["stylecount"];       
        }
        #endregion






        #region  獲取型体  -string   GetOrdertoStyle(string yearmonth)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearmonth"></param>
        /// <returns></returns>

        public List<MODEL.doc_StyleBase> GetOrdertoStyle(string yearmonth)
        {
            // 从订单自动导入 形体大类的资料
            string sql = @"
      select Code,CustomName,GoodsTypeName,a.Name,ModelNo,RBcode,MDcode,Editionhandle ,b.OrderDate OrderDate  from  T_StyleCodeInfo a  
		       right join 
                (							              
				 select distinct MIN(OrderDate) OrderDate,Name,MAX(guid) Guid from T_StyleCodeInfo  group by name   		       
				 ) b  on b.guid=a.guid
				 where b.OrderDate>=@OrderDate      order By Name
                ";
            SqlParameter p = new SqlParameter("OrderDate", yearmonth);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL .doc_StyleBase> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_StyleBase>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_StyleBase c = new MODEL.doc_StyleBase();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  -void LoadDataToList2(DataRow dr, MODEL.doc_Style style)
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_StyleBase stylebase)
        {
            // stylebase. .Code = dr["Code"].ToString();                   //工厂型体
            //   ,ModelNo
         stylebase.CustomName = dr["CustomName"].ToString();//客户名称
            string[] mystyle = dr["Code"].ToString().Split('/');
            stylebase.Style= mystyle[0].ToString().Trim();
            stylebase.StyleBase= mystyle[0].ToString().Trim();
            // stylebase.Name = (string) SqlHelper.FromDbValue( dr["Name"]);
            stylebase.Name = dr["Name"].ToString(); //鞋型种类名称
            stylebase.GoodsTypeName = dr["GoodsTypeName"].ToString(); //鞋型种类名称
            stylebase.Editionhandle = dr["Editionhandle"].ToString();//楦头编号  
            stylebase.Innor = dr["Editionhandle"].ToString();//鞋垫编号  
            stylebase.RBcode = dr["RBcode"].ToString();//RB模号  
            stylebase.MDcode = dr["MDcode"].ToString();//MD模号  
            stylebase.ModelNo = dr["ModelNo"].ToString();//大底编号  
            stylebase.OrderDate = dr["OrderDate"].ToString();//新鞋型日期
            stylebase.NewCode = "0"; 



            //         stylecode.stylecount = (int)dr["stylecount"];       
        }
        #endregion





        #region PO 獲取客戶型體  -string   GetStyle(string CutNo)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cutno"></param>
        /// <returns></returns>

        public string GetStyle(string myCutNo)
        {
            string sql = "select  Name from T_StyleCodeinfo where CutNo=@cutno";
            SqlParameter p1 = new SqlParameter("CutNo", myCutNo);
            return SqlHelper.ExcuteScalar<string>(sql, p1);
        }
        #endregion


        #region PO 獲取色號  -string   GetColor(string CutNo)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cutno"></param>
        /// <returns></returns>

        public string GetColor(string myCutNo)
        {
            string sql = "select  Code from T_StyleCodeinfo where CutNo=@CutNo";
            SqlParameter p1 = new SqlParameter("CutNo", myCutNo);
            return SqlHelper.ExcuteScalar<string>(sql, p1);
        }
        #endregion




    }
}
