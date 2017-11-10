using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace DAL
{
    public class doc_PackListService
    {



        /// <summary>
        /// Sqlbulkcopies the specified SMS.批量插入到数据库
        /// </summary>
        /// <param name="data">list类型数据.</param>
        /// <param name="sqlconn">数据库连接字符串.</param>
        /// 
        public void GetPacklistBulk(List<MODEL.doc_PackList> mydata)
        {
            SqlHelper.SqlbulkcopyPackList<MODEL.doc_PackList>(mydata);

        }

        #region 私有的静态的只读的连接字符串  -private static readonly string connStr
        /// <summary>
        /// 私有的静态的只读的连接字符串
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        #endregion


        public void GetPacklistBulkPackList1(DataTable table)
        {

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr))
            {


                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "doc_PackList";
                //--------- from T_PackList
                bulkcopy.ColumnMappings.Add("T_PackListGuid", "T_PackListGuid");
                bulkcopy.ColumnMappings.Add("CustomStyleName", "CustomStyleName");
                bulkcopy.ColumnMappings.Add("CustomStyleCode", "CustomStyleCode");
                bulkcopy.ColumnMappings.Add("CustomName", "CustomName");
                bulkcopy.ColumnMappings.Add("OrderDate", "OrderDate");
                bulkcopy.ColumnMappings.Add("CustomPO", "CustomPO");
                bulkcopy.ColumnMappings.Add("ManufactureOrder", "ManufactureOrder");
                bulkcopy.ColumnMappings.Add("CutNo", "CutNo");
                bulkcopy.ColumnMappings.Add("BOXNO", "BOXNO");
                bulkcopy.ColumnMappings.Add("BOXTONO", "BOXTONO");
                bulkcopy.ColumnMappings.Add("BoxNoTotal", "BoxNoTotal");
                bulkcopy.ColumnMappings.Add("PerCount", "PerCount");
                bulkcopy.ColumnMappings.Add("SizeName", "SizeName");
                bulkcopy.ColumnMappings.Add("TotalCount", "TotalCount");
                bulkcopy.ColumnMappings.Add("BoxSize", "BoxSize");
                //------ from doc_Order
                bulkcopy.ColumnMappings.Add("doc_OrderGuid", "doc_OrderGuid");
                bulkcopy.ColumnMappings.Add("Style", "Style");
                bulkcopy.ColumnMappings.Add("Name", "Name");
                bulkcopy.ColumnMappings.Add("Color", "Color");
                bulkcopy.ColumnMappings.Add("Code", "Code");
                bulkcopy.ColumnMappings.Add("CustomBuyName", "CustomBuyName");
                bulkcopy.ColumnMappings.Add("AimArea", "AimArea");
                bulkcopy.ColumnMappings.Add("ShipMentDate", "ShipMentDate");
                bulkcopy.ColumnMappings.Add("CartonBarcodeNeed", "CartonBarcodeNeed");
                bulkcopy.ColumnMappings.Add("GoodsTypeName", "GoodsTypeName");
                bulkcopy.ColumnMappings.Add("Type", "Type");

                //---  --Guid(doc_packlist), OrderCount,CartonBarcode,InnerBarcode,SizeNo,BarcodeCount
                bulkcopy.ColumnMappings.Add("Guid", "Guid");
                bulkcopy.ColumnMappings.Add("BarcodeCount", "BarcodeCount");
                bulkcopy.ColumnMappings.Add("CartonBarcode", "CartonBarcode");
                bulkcopy.ColumnMappings.Add("InnerBarcode", "InnerBarcode");
                bulkcopy.ColumnMappings.Add("InnerBarcode1", "InnerBarcode1");
                //              bulkcopy.ColumnMappings.Add("OrderCount", "OrderCount");
                //            bulkcopy.ColumnMappings.Add("SizeNo", "SizeNo");

                try
                {

                    bulkcopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }


        }
        public void GetPacklistBulkPackList(DataTable table)
        {

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr))
            {


                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "doc_PackList";
                //--------- from T_PackList
                bulkcopy.ColumnMappings.Add("T_PackListGuid", "T_PackListGuid");
                bulkcopy.ColumnMappings.Add("CustomStyleName", "CustomStyleName");
                bulkcopy.ColumnMappings.Add("CustomStyleCode", "CustomStyleCode");
                bulkcopy.ColumnMappings.Add("CustomName", "CustomName");
                bulkcopy.ColumnMappings.Add("OrderDate", "OrderDate");
                bulkcopy.ColumnMappings.Add("CustomPO", "CustomPO");
                bulkcopy.ColumnMappings.Add("ManufactureOrder", "ManufactureOrder");
                bulkcopy.ColumnMappings.Add("CutNo", "CutNo");
                bulkcopy.ColumnMappings.Add("BOXNO", "BOXNO");
                bulkcopy.ColumnMappings.Add("BOXTONO", "BOXTONO");
                bulkcopy.ColumnMappings.Add("BoxNoTotal", "BoxNoTotal");
                bulkcopy.ColumnMappings.Add("PerCount", "PerCount");
                bulkcopy.ColumnMappings.Add("SizeName", "SizeName");
                bulkcopy.ColumnMappings.Add("TotalCount", "TotalCount");
                bulkcopy.ColumnMappings.Add("BoxSize", "BoxSize");
                //------ from doc_Order
                bulkcopy.ColumnMappings.Add("doc_OrderGuid", "doc_OrderGuid");
                bulkcopy.ColumnMappings.Add("Style", "Style");
                bulkcopy.ColumnMappings.Add("Name", "Name");
                bulkcopy.ColumnMappings.Add("Color", "Color");
                bulkcopy.ColumnMappings.Add("Code", "Code");
                bulkcopy.ColumnMappings.Add("CustomBuyName", "CustomBuyName");
                bulkcopy.ColumnMappings.Add("AimArea", "AimArea");
                bulkcopy.ColumnMappings.Add("ShipMentDate", "ShipMentDate");
                bulkcopy.ColumnMappings.Add("CartonBarcodeNeed", "CartonBarcodeNeed");
                bulkcopy.ColumnMappings.Add("GoodsTypeName", "GoodsTypeName");
                bulkcopy.ColumnMappings.Add("Type", "Type");

                //---  --Guid(doc_packlist), OrderCount,CartonBarcode,InnerBarcode,SizeNo,BarcodeCount
                bulkcopy.ColumnMappings.Add("Guid", "Guid");
                bulkcopy.ColumnMappings.Add("BarcodeCount", "BarcodeCount");
                bulkcopy.ColumnMappings.Add("CartonBarcode", "CartonBarcode");
                //              bulkcopy.ColumnMappings.Add("InnerBarcode", "InnerBarcode");
                //            bulkcopy.ColumnMappings.Add("InnerBarcode1", "InnerBarcode1");
                //              bulkcopy.ColumnMappings.Add("OrderCount", "OrderCount");
                //            bulkcopy.ColumnMappings.Add("SizeNo", "SizeNo");

                try
                {

                    bulkcopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }


        }

        public void GetPacklistBulkPackListShip(DataTable table)
        {

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr))
            {

                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "doc_PackListShip";
                //--------- from T_PackList
                bulkcopy.ColumnMappings.Add("Guid", "Guid");
                bulkcopy.ColumnMappings.Add("Style", "Style");
                bulkcopy.ColumnMappings.Add("Name", "Name");
                bulkcopy.ColumnMappings.Add("Color", "Color");
                bulkcopy.ColumnMappings.Add("Code", "Code");

                bulkcopy.ColumnMappings.Add("CustomStyleName", "CustomStyleName");
                bulkcopy.ColumnMappings.Add("CustomStyleCode", "CustomStyleCode");
                bulkcopy.ColumnMappings.Add("CustomName", "CustomName");
                bulkcopy.ColumnMappings.Add("CustomBuyName", "CustomBuyName");

                bulkcopy.ColumnMappings.Add("AimArea", "AimArea");
                bulkcopy.ColumnMappings.Add("OrderDate", "OrderDate");
                bulkcopy.ColumnMappings.Add("ShipMentDate", "ShipMentDate");
                bulkcopy.ColumnMappings.Add("CustomPO", "CustomPO");

                bulkcopy.ColumnMappings.Add("ManufactureOrder", "ManufactureOrder");
                bulkcopy.ColumnMappings.Add("CutNo", "CutNo");
                bulkcopy.ColumnMappings.Add("BOXNO", "BOXNO");
                bulkcopy.ColumnMappings.Add("CartonBarcode", "CartonBarcode");
                bulkcopy.ColumnMappings.Add("CartonBarcodeNeed", "CartonBarcodeNeed");

                bulkcopy.ColumnMappings.Add("BoxSize", "BoxSize");
                bulkcopy.ColumnMappings.Add("ScanIn", "ScanIn");
                bulkcopy.ColumnMappings.Add("ScanOut", "ScanOut");
                bulkcopy.ColumnMappings.Add("QAIn", "QAIn");
                bulkcopy.ColumnMappings.Add("QAOut", "QAOut");
                bulkcopy.ColumnMappings.Add("ShipOut", "ShipOut");
                bulkcopy.ColumnMappings.Add("ShipScanTime", "ShipScanTime");
                bulkcopy.ColumnMappings.Add("CarNo", "CarNo");
                try
                {

                    bulkcopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }


        }




        #region 获取該訂單的裝箱明細信息 (sql left join 先) -  List<MODEL.doc_PackList> GetToPacklist(string yyyymm)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetToPacklist(string yyyymm)
        {
            string sql = @"
  select  a.guid T_PackListGuid,a.CustomStyleName, a.CustomStyleCode,a.CustomName,a.OrderDate,a.CustomPO
  ,a.ManufactureOrder,a.CutNo,a.BOXNO,a.BOXTONO,a.BoxNoTotal,a.PerCount,a.SizeName,a.TotalCount,a.BoxSize
  ,b.doc_OrderGuid ,b.Style,b.Name,b.Color,b.Code,b.CustomBuyName,b.AimArea,b.ShipMentDate,b.CartonBarcodeNeed,b.GoodsTypeName,b.Type
   from T_PackList a
  left join 
  (  select Guid doc_OrderGuid, Style,Name,Color,Code, CustomStyleCode ,ShipMentDate,CustomBuyName,AimArea,CartonBarcodeNeed,GoodsTypeName,Type  from doc_Order
  )b on a.CustomStyleCode=b.CustomStyleCode
  where a.OrderDate=@OrderDate   Order by a.CustomStyleCode,a.BOXNO

                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@Orderdate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }

        #endregion

        #region 获取某一張訂單的裝箱明細信息  -  c List<MODEL.doc_PackList> GetToPacklistOrder(string customstylecode)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetToPacklistOrder(string customstylecode)
        {
            string sql = @"
  select  a.guid T_PackListGuid,a.CustomStyleName, a.CustomStyleCode,a.CustomName,a.OrderDate,a.CustomPO
  ,a.ManufactureOrder,a.CutNo,a.BOXNO,a.BOXTONO,a.BoxNoTotal,a.PerCount,a.SizeName,a.TotalCount,a.BoxSize
  ,b.doc_OrderGuid ,b.Style,b.Name,b.Color,b.Code,b.CustomBuyName,b.AimArea,b.ShipMentDate,b.CartonBarcodeNeed,b.GoodsTypeName,b.Type
   from T_PackList a
  left join 
  (  select Guid doc_OrderGuid, Style,Name,Color,Code, CustomStyleCode ,ShipMentDate,CustomBuyName,AimArea,CartonBarcodeNeed,GoodsTypeName,Type  from doc_Order
  )b on a.CustomStyleCode=b.CustomStyleCode
  where a.CustomStyleCode=@CustomStyleCode order by BOXNO

                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }

        #endregion


        #region 加载行数据到对象-- LoadDataToList2(DataRow dr, MODEL.doc_PackList  docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_PackList docpacklist)
        {
            //---  --Guid(doc_packlist), OrderCount,CartonBarcode,InnerBarcode,SizeNo,BarcodeCount

            //       docpacklist.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          // 不用抓, 前面產生
            //        docpacklist.OrderCount = (string)SqlHelper.FromDbValue(dr["OrderCount"]);   //
            //  docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
            //  docpacklist.InnerBarcode = (string)SqlHelper.FromDbValue(dr["InnerBarcode"]);   //
            //     docpacklist.BarcodeCount = (int)SqlHelper.FromDbValue(dr["BarcodeCount"]);   //
            //   docpacklist.SizeNo = (string)SqlHelper.FromDbValue(dr["SizeNo"]);   //  尺碼排順序,以後用到再說

            //--------- from T_PackList
            docpacklist.T_PackListGuid = (Guid)SqlHelper.FromDbValue(dr["T_PackListGuid"]);          //T_PackListGuid
            docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //  CustomStyleName
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);  //  
            docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
            docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);//
            docpacklist.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);//
            docpacklist.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]);//
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號
            docpacklist.BOXTONO = (string)SqlHelper.FromDbValue(dr["BOXTONO"]);  //  相同裝箱方式的起始箱號
            docpacklist.BoxNoTotal = (string)SqlHelper.FromDbValue(dr["BoxNoTotal"]);  //   BOXTONO 的箱子數量
            docpacklist.PerCount = (string)SqlHelper.FromDbValue(dr["PerCount"]);  //   BOXNO 這一箱的數量裝幾雙   BOXNOPerCount      
            docpacklist.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);  //   尺碼           
            docpacklist.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);  //   BOXNO 這一箱的 尺碼 裝幾雙 BOXNOSizeCount*** 單碼裝則與BOXNOPerCount 數量相同
            docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸
                                                                                 //--- from  doc_Order
            docpacklist.doc_OrderGuid = (Guid)SqlHelper.FromDbValue(dr["doc_OrderGuid"]);//
            docpacklist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);//
            docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);//
            docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);//
            docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);//
            docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);//
            docpacklist.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]);//
            docpacklist.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);//
            docpacklist.CartonBarcodeNeed = (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);//
            docpacklist.GoodsTypeName = (string)SqlHelper.FromDbValue(dr["GoodsTypeName"]);//
            docpacklist.Type = (string)SqlHelper.FromDbValue(dr["Type"]);//



        }
        #endregion


        #region 获取裝箱明細內盒需求訊息  -  List<MODEL.doc_PackList> GetInnerNeedASICS(string yyyymm)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetInnerNeedASICS(string yyyymm)
        {
            string sql = @"

  select Name,Color,SizeName,Type from doc_PackList
  where OrderDate=@OrderDate and CustomName='ASICS'  
  group by Name,Color,SizeName,Type
  order by Name,Color,SizeName,Type

                            ";
            //and InnerBarcode is null

            SqlParameter[] ps = {
                               new SqlParameter("@Orderdate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList3(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }

        #endregion

        #region 加载行数据到对象-- LoadDataToList3(DataRow dr, MODEL.doc_PackList  docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList3(DataRow dr, MODEL.doc_PackList docpacklist)
        {
            //---  --Guid(doc_packlist), OrderCount,CartonBarcode,InnerBarcode,SizeNo,BarcodeCount

            //       docpacklist.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          // 不用抓, 前面產生
            //        docpacklist.OrderCount = (string)SqlHelper.FromDbValue(dr["OrderCount"]);   //
            //  docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
            //  docpacklist.InnerBarcode = (string)SqlHelper.FromDbValue(dr["InnerBarcode"]);   //
            //     docpacklist.BarcodeCount = (int)SqlHelper.FromDbValue(dr["BarcodeCount"]);   //
            //   docpacklist.SizeNo = (string)SqlHelper.FromDbValue(dr["SizeNo"]);   //  尺碼排順序,以後用到再說

            //--------- from T_PackList
            //docpacklist.T_PackListGuid = (Guid)SqlHelper.FromDbValue(dr["T_PackListGuid"]);          //T_PackListGuid
            //docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //  CustomStyleName
            //docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            //docpacklist.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);  //  
            //docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
            //docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);//
            //docpacklist.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);//
            //docpacklist.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]);//
            //docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號
            //docpacklist.BOXTONO = (string)SqlHelper.FromDbValue(dr["BOXTONO"]);  //  相同裝箱方式的起始箱號
            //docpacklist.BoxNoTotal = (string)SqlHelper.FromDbValue(dr["BoxNoTotal"]);  //   BOXTONO 的箱子數量
            //docpacklist.PerCount = (string)SqlHelper.FromDbValue(dr["PerCount"]);  //   BOXNO 這一箱的數量裝幾雙   BOXNOPerCount      
            docpacklist.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);  //   尺碼           
                                                                                   //docpacklist.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);  //   BOXNO 這一箱的 尺碼 裝幾雙 BOXNOSizeCount*** 單碼裝則與BOXNOPerCount 數量相同
                                                                                   //docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸
                                                                                   //--- from  doc_Order
                                                                                   //   docpacklist.doc_OrderGuid = (Guid)SqlHelper.FromDbValue(dr["doc_OrderGuid"]);//
                                                                                   //         docpacklist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);//
            docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);//
            docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);//
                                                                           // docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);//
                                                                           //docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);//
                                                                           //docpacklist.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]);//
                                                                           //docpacklist.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);//
                                                                           //docpacklist.CartonBarcodeNeed = (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);//
                                                                           //docpacklist.GoodsTypeName = (string)SqlHelper.FromDbValue(dr["GoodsTypeName"]);//
            docpacklist.Type = (string)SqlHelper.FromDbValue(dr["Type"]);//



        }
        #endregion




        #region 获取該訂單年月的成品箱明細信息更新保留一些資料 - List<MODEL.doc_PackListShip> GetToPacklistShipUpdate(string yyyymm)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetToPacklistShipUpdate(string yyyymm)
        {
            string sql = @"
 select 
 c.Style, c.Name, c.Color,c.Code,c.CustomStyleName,c.CustomStyleCode,c.CustomName
, c.CustomBuyName,c.AimArea, c.OrderDate, c.ShipMentDate,c.customPO, c.ManufactureOrder
 ,c.CutNo,c.BOXNO, c.CartonBarcode,c.BoxSize,c.CartonBarcodeNeed
 ,ShipOut, ShipScantime, ScanIn, ScanOut, QAIn,QAOut,CarNo
from doc_PackListShip  a
   right join(
     select Style, Name, Color, Code, CustomStyleName, CustomStyleCode, CustomName
, CustomBuyName, AimArea, OrderDate, ShipMentDate, CustomPO, ManufactureOrder
 , CutNo, BOXNO, CartonBarcode,BoxSize,CartonBarcodeNeed
    from doc_PackList 
   where OrderDate =@Orderdate  and CustomName = 'ASICS'
   group by Style, Name, Color, Code, CustomStyleName, CustomStyleCode, CustomName
  , CustomBuyName, AimArea, OrderDate, ShipMentDate, CustomPO, ManufactureOrder
   , CutNo, BOXNO, CartonBarcode, BoxSize, CartonBarcodeNeed
   )c on c.CartonBarcode=a.CartonBarcode
   where c.OrderDate =@OrderDate1  and c.CustomName = 'ASICS'
  order by CustomStyleCode, BOXNO

                            ";




            SqlParameter[] ps = {
                               new SqlParameter("@Orderdate",yyyymm),
                               new SqlParameter("@Orderdate1",yyyymm)
            };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList6(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象-- LoadDataToList6(DataRow dr, MODEL.doc_PackList  docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList6(DataRow dr, MODEL.doc_PackListShip docpacklist)
        {

            docpacklist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);//
            docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);//
            docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);//
            docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);//
            docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //  CustomStyleName
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);  //  
            docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);//
            docpacklist.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]);//
            docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
            docpacklist.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);//
            docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);//
            docpacklist.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);//
            docpacklist.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]);//
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號
            docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);//
            docpacklist.CartonBarcodeNeed = (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);//
            docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸
            docpacklist.ShipOut = (string)SqlHelper.FromDbValue(dr["ShipOut"]);
            docpacklist.ShipScanTime = (string)SqlHelper.FromDbValue(dr["ShipScanTime"]);
            docpacklist.CarNo = (string)SqlHelper.FromDbValue(dr["CarNo"]);
            docpacklist.QAIn = (int?)SqlHelper.FromDbValue(dr["QAIn"]);
            docpacklist.QAOut = (int?)SqlHelper.FromDbValue(dr["QAOut"]);
            docpacklist.ScanIn = (int?)SqlHelper.FromDbValue(dr["ScanIn"]);
            docpacklist.ScanOut = (int?)SqlHelper.FromDbValue(dr["ScanOut"]);

        }
        #endregion




















        #region 获取該訂單年月的成品箱明細信息 (sql left join 先) - List<MODEL.doc_PackList> GetToPacklistShip(string yyyymm)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetToPacklistShip(string yyyymm)
        {
            string sql = @"

  select  Style,Name,Color,Code,CustomStyleName,CustomStyleCode,CustomName
  ,CustomBuyName,AimArea,OrderDate,ShipMentDate,CustomPO,ManufactureOrder
   ,CutNo,BOXNO,CartonBarcode,BoxSize,CartonBarcodeNeed
   from doc_PackList 
   where OrderDate=@Orderdate  and CustomName='ASICS'
   group by Style,Name,Color,Code,CustomStyleName,CustomStyleCode,CustomName
  ,CustomBuyName,AimArea,OrderDate,ShipMentDate,CustomPO,ManufactureOrder
   ,CutNo,BOXNO,CartonBarcode,BoxSize,CartonBarcodeNeed
   order by CustomStyleCode,BOXNO

                            ";

            /*

            select Style, Name, Color, Code, CustomStyleName, CustomStyleCode, CustomName
, CustomBuyName, AimArea, OrderDate, ShipMentDate, CustomPO, ManufactureOrder
 , CutNo, BOXNO, a.CartonBarcode,BoxSize,CartonBarcodeNeed,ShipOut,ShipScantime,ScanIn,ScanOut,QAIn,QAOut
    from doc_PackList a
   left join(select ShipOut, ShipScantime, ScanIn, ScanOut, QAIn, QAOut, CartonBarcode from doc_PackListShip)c
   on c.CartonBarcode = a.Cartonbarcode

   where OrderDate = '2017-07'  and CustomName = 'ASICS'
   group by Style, Name, Color, Code, CustomStyleName, CustomStyleCode, CustomName
  , CustomBuyName, AimArea, OrderDate, ShipMentDate, CustomPO, ManufactureOrder
   , CutNo, BOXNO, a.CartonBarcode, BoxSize, CartonBarcodeNeed, shipOut, SHipScantime, ScanIn, ScanOut, QAIn, QAOut
  order by CustomStyleCode, BOXNO
  */






            SqlParameter[] ps = {
                               new SqlParameter("@Orderdate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList4(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion


        #region 获取該訂單的成品箱明細信息 (sql left join 先) -  List<MODEL.doc_PackList> GetToPacklistShipOrder1(string customstylecode)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetToPacklistShipOrder1(string customstylecode)
        {
            string sql = @"
    select 
 c.Style, c.Name, c.Color,c.Code,c.CustomStyleName,c.CustomStyleCode,c.CustomName
, c.CustomBuyName,c.AimArea, c.OrderDate, c.ShipMentDate,c.customPO, c.ManufactureOrder
 ,c.CutNo,c.BOXNO, c.CartonBarcode,c.BoxSize,c.CartonBarcodeNeed
 ,ShipOut, ShipScantime, ScanIn, ScanOut, QAIn,QAOut,CarNo
from doc_PackListShip  a
   right join(
     select Style, Name, Color, Code, CustomStyleName, CustomStyleCode, CustomName
, CustomBuyName, AimArea, OrderDate, ShipMentDate, CustomPO, ManufactureOrder
 , CutNo, BOXNO, CartonBarcode,BoxSize,CartonBarcodeNeed
    from doc_PackList 
   where CustomStyleCode=@CustomStyleCode  and CustomName = 'ASICS'
   group by Style, Name, Color, Code, CustomStyleName, CustomStyleCode, CustomName
  , CustomBuyName, AimArea, OrderDate, ShipMentDate, CustomPO, ManufactureOrder
   , CutNo, BOXNO, CartonBarcode, BoxSize, CartonBarcodeNeed
   )c on c.CartonBarcode=a.CartonBarcode
   where c.CustomStyleCode=@CustomStyleCode1  and c.CustomName = 'ASICS'
  order by CustomStyleCode, BOXNO


                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode),
                               new SqlParameter("@CustomStyleCode1",customstylecode)
            };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList6(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }

        #endregion


        #region 加载行数据到对象-- LoadDataToList7(DataRow dr, MODEL.doc_PackList  docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList7(DataRow dr, MODEL.doc_PackListShip docpacklist)
        {

            docpacklist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);//
            docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);//
            docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);//
            docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);//
            docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //  CustomStyleName
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);  //  
            docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);//
            docpacklist.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]);//
            docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
            docpacklist.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);//
            docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);//
            docpacklist.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);//
            docpacklist.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]);//
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號
            docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);//
            docpacklist.CartonBarcodeNeed = (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);//
            docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸

            docpacklist.ShipOut = (string)SqlHelper.FromDbValue(dr["ShipOut"]);
            docpacklist.ShipScanTime = (string)SqlHelper.FromDbValue(dr["ShipScanTime"]);
            docpacklist.CarNo = (string)SqlHelper.FromDbValue(dr["CarNo"]);
            docpacklist.QAIn = (int?)SqlHelper.FromDbValue(dr["QAIn"]);
            docpacklist.QAOut = (int?)SqlHelper.FromDbValue(dr["QAOut"]);
            docpacklist.ScanIn = (int?)SqlHelper.FromDbValue(dr["ScanIn"]);
            docpacklist.ScanOut = (int?)SqlHelper.FromDbValue(dr["ScanOut"]);












        }
        #endregion









        #region 获取該訂單的成品箱明細信息 (sql left join 先) -  List<MODEL.doc_PackList> GetToPacklistShipOrder(string customstylecode)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetToPacklistShipOrder(string customstylecode)
        {
            string sql = @"

  select  Style,Name,Color,Code,CustomStyleName,CustomStyleCode,CustomName
  ,CustomBuyName,AimArea,OrderDate,ShipMentDate,CustomPO,ManufactureOrder
   ,CutNo,BOXNO,CartonBarcode,BoxSize,CartonBarcodeNeed
   from doc_PackList 
   where CustomStyleCode=@CustomStyleCode  and CustomName='ASICS'
   group by Style,Name,Color,Code,CustomStyleName,CustomStyleCode,CustomName
  ,CustomBuyName,AimArea,OrderDate,ShipMentDate,CustomPO,ManufactureOrder
   ,CutNo,BOXNO,CartonBarcode,BoxSize,CartonBarcodeNeed

   order by CustomStyleCode,BOXNO

                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList4(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }

        #endregion


        #region 加载行数据到对象-- LoadDataToList4(DataRow dr, MODEL.doc_PackList  docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList4(DataRow dr, MODEL.doc_PackList docpacklist)
        {

            docpacklist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);//
            docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);//
            docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);//
            docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);//
            docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //  CustomStyleName
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);  //  
            docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);//
            docpacklist.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]);//
            docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
            docpacklist.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);//
            docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);//
            docpacklist.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);//
            docpacklist.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]);//
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號
            docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);//
            docpacklist.CartonBarcodeNeed = (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);//
            docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸



        }
        #endregion



        #region 對比該訂單年月的成品箱明細信息 (sql left join 先) -  List<MODEL.doc_PackList> EXCEPTPacklistShip(string yyyymm)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> EXCEPTPacklistShip(string yyyymm)
        {
            string sql = @"

  select CustomStyleCode,BOXNO from doc_PackList where OrderDate=@Orderdate  and CustomName='ASICS'
  Group by  CustomStyleCode,BOXNO 
  EXCEPT
  select CustomStyleCode,BOXNO from doc_PackListShip where OrderDate=@Orderdate1 and CustomName='ASICS' 
  order by CustomStyleCode,BOXNO

                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@Orderdate",yyyymm),
                               new SqlParameter("@Orderdate1",yyyymm),
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList5(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }

        #endregion

        #region 加载行数据到对象-- LoadDataToList5(DataRow dr, MODEL.doc_PackList  docpacklist

        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList5(DataRow dr, MODEL.doc_PackList docpacklist)
        {
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號

        }
        #endregion








        #region 获取該訂單的裝箱明細信息  - List<MODEL.T_PackList> GetTPacklist1( )

        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.T_PackList> GetTPacklist1(string yyyymm)
        {
            string sql = @"
            select  * 
            from T_PackList
           where OrderDate=@Orderdate
            order by CustomStylecode,BOXNO
                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@Orderdate",yyyymm)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.T_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.T_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.T_PackList c = new MODEL.T_PackList();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;

        }

        #endregion


        #region 获取該訂單的裝箱明細信息  - List<MODEL.T_PackList> GetTPacklist(string customstylecode )

        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.T_PackList> GetTPacklist(string customstylecode)
        {
            string sql = @"
            select  * 
            from T_PackList
            where  CustomStyleCode=@CustomStyleCode
            order by BOXNO
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.T_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.T_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.T_PackList c = new MODEL.T_PackList();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象--void LoadDataToList(DataRow dr, MODEL.T_PackList tpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.T_PackList tpacklist)
        {
            tpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            tpacklist.guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          //GUiD
            tpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸

            tpacklist.BOXTONO = (string)SqlHelper.FromDbValue(dr["BOXTONO"]);  //  相同裝箱方式的起始箱號
            tpacklist.BoxNoTotal = (string)SqlHelper.FromDbValue(dr["BoxNoTotal"]);  //   BOXTONO 的箱子數量
            tpacklist.perCountTotal = (string)SqlHelper.FromDbValue(dr["perCountTotal"]);  //   BOXTONO  鞋子數量
                                                                                           //  tpacklist.Boxsumcount = (int)SqlHelper.FromDbValue(dr["Boxsumcount"]);  //   BOXTONO  總共幾箱

            tpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號
            tpacklist.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);  //   尺碼           
            tpacklist.PerCount = (string)SqlHelper.FromDbValue(dr["PerCount"]);  //   BOXNO 這一箱的數量裝幾雙   BOXNOPerCount      
            tpacklist.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);  //   BOXNO 這一箱的 尺碼 裝幾雙 BOXNOSizeCount*** 單碼裝則與BOXNOPerCount 數量相同
            tpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);
            ///          ----BOXNOSizeAdd 刷條碼的累計數量
            ///		----xxxx BOXNOSizeAddTemp 刷條碼的暫存累計數量
            ///		---- sum(BOXNOSizeCount) 整個訂單加起來 就是裝箱明細已分配的訂單總數
            tpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //   外箱上的STYLE 為 Name(客戶型體)+StyleNumer(客戶名稱)+ 



        }
        #endregion





        #region 获取該訂單的裝箱明細信息  -  List<MODEL.doc_PackList> GetInnerBarcode(string innerbarcode,string cattonbarcode)

        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetInnerBarcode(string innerbarcode, string cartonbarcode)
        {
            string sql = @"
            select  * 
            from doc_PackList
            where  CartonBarcode=@CartonBarcode and (InnerBarcode=@InnerBarcode  or   InnerBarcode1=@InnerBarcode1)
            order by SizeName";
            SqlParameter[] ps = {
              new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( cartonbarcode) },
              new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( innerbarcode) },
              new SqlParameter("@InnerBarcode1",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( innerbarcode) }
            };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 获取該訂單的裝箱明細信息  - List<MODEL.doc_PackList> GetCartonBarcode(string cartonbarcode)

        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetCartonBarcode(string cartonbarcode)
        {
            string sql = @"
            select  * 
            from doc_PackList
            where  CartonBarcode=@CartonBarcode
            order by SizeName
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CartonBarcode",cartonbarcode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 获取該訂單的剩餘裝箱明細信息  -List<MODEL.doc_PackList> GetLeftOrder(string customstylecode)

        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetLeftOrder(string customstylecode)
        {
            string sql = @"
        select  Top 20 * 
        from doc_PackList
        where CustomStyleCode=@CustomStyleCode
        and totalcount != barcodecount
        order by  SizeName,BOXNO
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象--void LoadDataToList1(DataRow dr, MODEL.T_PackList tpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_PackList packlist)
        {
            packlist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            packlist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   箱號
            packlist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);
            packlist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);
            packlist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);
            packlist.InnerBarcode = (string)SqlHelper.FromDbValue(dr["InnerBarcode"]);
            packlist.InnerBarcode1 = (string)SqlHelper.FromDbValue(dr["InnerBarcode1"]);
            packlist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);
            packlist.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);
            packlist.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);
            packlist.BarcodeCount = (int)SqlHelper.FromDbValue(dr["BarcodeCount"]);
            packlist.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          //GUiD
            packlist.PerCount = (string)SqlHelper.FromDbValue(dr["PerCount"]);  //   BOXNO 這一箱的數量裝幾雙   BOXNOPerCount    
            packlist.SizeNo = (string)SqlHelper.FromDbValue(dr["SizeNo"]);  //  是否有刷错的箱 号码                                                                  //     packlist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸

            // packlist.BOXTONO = (string)SqlHelper.FromDbValue(dr["BOXTONO"]);  //  相同裝箱方式的起始箱號
            // packlist.BoxNoTotal = (string)SqlHelper.FromDbValue(dr["BoxNoTotal"]);  //   BOXTONO 的箱子數量
            //packlist.perCountTotal = (string)SqlHelper.FromDbValue(dr["perCountTotal"]);  //   BOXTONO  鞋子數量
            //  tpacklist.Boxsumcount = (int)SqlHelper.FromDbValue(dr["Boxsumcount"]);  //   BOXTONO  總共幾箱


            // packlist.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);  //   尺碼           

            // packlist.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);  //   BOXNO 這一箱的 尺碼 裝幾雙 BOXNOSizeCount*** 單碼裝則與BOXNOPerCount 數量相同

            ///          ----BOXNOSizeAdd 刷條碼的累計數量
            ///		----xxxx BOXNOSizeAddTemp 刷條碼的暫存累計數量
            ///		---- sum(BOXNOSizeCount) 整個訂單加起來 就是裝箱明細已分配的訂單總數
            ///tpacklist.CustoStyleName = (string)SqlHelper.FromDbValue(dr["CustoStyleName"]);  //   外箱上的STYLE 為 Name(客戶型體)+StyleNumer(客戶名稱)+ 



        }
        #endregion



        #region 更新裝箱明細刷條碼次數  int updatePackListBarcodeCount(Guid guid,String barcodecount)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackListBarcodeCount(Guid guid, int barcodecount)
        {

            string sql = @" 
                update doc_PackList set BarcodeCount=@BarcodeCount    where Guid=@Guid                
                ";

            SqlParameter[] ps = {
                new SqlParameter("@Guid", guid),
                new SqlParameter("@BarcodeCount", barcodecount)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

        #region 更新裝箱明細的內盒條碼   int updatePackListBarcode(String name,String color, String sizename,String tyle,string innerbarcode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>            
        public int updatePackListBarcode(String name, String color, String sizename, String type, string innerbarcode, string innerbarcode1)
        {
            string sql = @" 
                update doc_PackList set InnerBarcode=@InnerBarcode ,InnerBarcode1=@InnerBarcode1
                where Name=@Name and Color=@Color and SizeName=@SizeName and Type=@Type                
                ";

            SqlParameter[] ps = {

                new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(name)},
                new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(color)},
                new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(sizename)},
                new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(type)},
                new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(innerbarcode)},
                new SqlParameter("@InnerBarcode1",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(innerbarcode1)}
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        public string GetBuyerCartonBarcodeNeed(string custombuyname, string customname, string destination)
        {
            string sql = @"
            select CartonBarcodeNeed from doc_Buyer  where  CustomBuyName=@CustomBuyName
            and CustomName=@CustomName and Destination=@Destination
            ";
            SqlParameter[] ps =
                {
              new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( custombuyname) },
              new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( customname) },
              new SqlParameter("@Destination",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( destination) }

                   };
            return SqlHelper.ExcuteScalar<string>(sql, ps);
        }


        public string GetBuyertype(string custombuyname, string customname, string destination)
        {
            string sql = @"
            select Type from doc_Buyer  where  CustomBuyName=@CustomBuyName
            and CustomName=@CustomName and Destination=@Destination
            ";
            SqlParameter[] ps =
                {
              new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( custombuyname) },
              new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( customname) },
              new SqlParameter("@Destination",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( destination) }

                   };
            return SqlHelper.ExcuteScalar<string>(sql, ps);
        }




        public string GetInnerBarcode(string name, string color, string size, string type)
        {
            string sql = @"
            select InnerBarcode from doc_InnerBox  where  Name=@Name
            and Color=@Color and Size=@Size and  Type=@Type
            ";
            SqlParameter[] ps =
                {
                //new SqlParameter("CustomBuyName", custombuyname),
                //new SqlParameter("CustomName", customname),
                //new SqlParameter("Destination", destination)
              new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( name) },
              new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( color) },
              new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( size) },
             new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( type) }
            };
            return SqlHelper.ExcuteScalar<string>(sql, ps);
        }





        public string GetInnerBarcodeEAN(string name, string color, string size)
        {
            string sql = @"
            select InnerBarcode from doc_InnerBox  where  Name=@Name
            and Color=@Color and Size=@Size and  Type='EAN'
            ";
            SqlParameter[] ps =
                {
                //new SqlParameter("CustomBuyName", custombuyname),
                //new SqlParameter("CustomName", customname),
                //new SqlParameter("Destination", destination)
              new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( name) },
              new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( color) },
              new SqlParameter("@Size",SqlDbType.NVarChar) {Value=SqlHelper.FromDbValue( size) }
            };
            return SqlHelper.ExcuteScalar<string>(sql, ps);
        }




        #region 增加裝箱明細 - int AddPackList1(MODEL.doc_PackList packlist)
        /// 增加裝箱明細
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddPackList1(MODEL.doc_PackList packlist)
        {

            string sql = @"
              insert into doc_PackList(Guid,CustomStyleCode,TotalCount,T_PackListGuid,BoxSize,BOXTONO,BoxNoTotal,BOXNO,SizeName,PerCount)
        values(@Guid, @CustomStyleCode ,@TotalCount,@T_PackListGuid,@BoxSize,@BOXTONO,@BoxNoTotal,@BOXNO,@SizeName,@PerCount)";
            SqlParameter[] ps = {
                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.Guid)},
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomStyleCode)},
                               new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.TotalCount)},



                                new SqlParameter("@T_PackListGuid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.T_PackListGuid)},
                              new SqlParameter("@BoxSize",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.BoxSize)},
                               new SqlParameter("@BOXTONO",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.BOXTONO)},
                               new SqlParameter("@BoxNoTotal",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.BoxNoTotal)},
                               new SqlParameter("@BOXNO",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.BOXNO)},
                               new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.SizeName)},
                               new SqlParameter("@PerCount",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.PerCount)}


        };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region 增加裝箱明細 - int AddPackList(MODEL.doc_PackList packlist)
        /// 增加裝箱明細
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddPackList(MODEL.doc_PackList packlist)
        {

            string sql = @"
              insert into doc_PackList(Guid, doc_OrderGuid, Code,Style,Name,Color,CustomStyleCode,CustomName,AimArea,CustomBuyName,GoodsTypeName,TotalCount,OrderDate,ShipMentDate,ManufactureOrder,CustomPO,CutNo,T_PackListGuid,BoxSize,BOXTONO,BoxNoTotal,BOXNO,SizeName,PerCount,CustomStyleName,CartonBarcode,CartonBarcodeNeed,Type,InnerBarcode,BarcodeCount)
        values(@Guid, @doc_OrderGuid, @Code, @Style, @Name, @Color,@CustomStyleCode,@CustomName, @AimArea,@CustomBuyName,@GoodsTypeName, @TotalCount, @OrderDate,@ShipMentDate, @ManufactureOrder,@CustomPO, @CutNo,@T_PackListGuid,@BoxSize,@BOXTONO,@BoxNoTotal,@BOXNO,@SizeName,@PerCount,@CustomStyleName,@CartonBarcode,@CartonBarcodeNeed,@Type,@InnerBarcode,@BarcodeCount)";
            SqlParameter[] ps = {
                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.Guid)},
                                new SqlParameter("@doc_OrderGuid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.doc_OrderGuid)},
                               new SqlParameter("@Code",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Code)},
                               new SqlParameter("@Style",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Style)},
                               new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Name)},
                              new SqlParameter("@Color",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Color)},
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomStyleCode)},
                               new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomName)},
                               new SqlParameter("@AimArea",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.AimArea)},
                              new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomBuyName)},
                               new SqlParameter("@GoodsTypeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.GoodsTypeName)},
                               new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.TotalCount)},
                              new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.OrderDate)},
                               new SqlParameter("@ShipMentDate",SqlDbType.DateTime) {Value=SqlHelper.ToDbValue(packlist.ShipMentDate)},
                               new SqlParameter("@ManufactureOrder",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.ManufactureOrder)},
                               new SqlParameter("@CustomPO",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomPO)},
                               new SqlParameter("@CutNo",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CutNo)},


                                new SqlParameter("@T_PackListGuid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.T_PackListGuid)},
                               new SqlParameter("@BoxSize",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.BoxSize)},
                               new SqlParameter("@BOXTONO",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.BOXTONO)},
                               new SqlParameter("@BoxNoTotal",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.BoxNoTotal)},
                               new SqlParameter("@BOXNO",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.BOXNO)},
                               new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.SizeName)},
                               new SqlParameter("@PerCount",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.PerCount)},
                               new SqlParameter("@CustomStyleName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomStyleName)},
                               new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CartonBarcode)},
                               new SqlParameter("@CartonBarcodeNeed",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CartonBarcodeNeed)},
                               new SqlParameter("@Type",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Type)},
                               new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.InnerBarcode)},
                               new SqlParameter("@BarcodeCount",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.BarcodeCount)}
        };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 验证型体大类是否存在  int IsPackListExisits(string customstylecode, string boxno,string sizename)
        /// <summary>
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsPackListExisits(string customstylecode, int? boxno, string sizename)
        {

            string sql = "select count(*) from doc_PackList  where CustomStyleCode=@CustomStyleCode and BOXNO=@BOXNO and SizeName=@SizeName   ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)},
                                new SqlParameter("@BOXNO",SqlDbType.Int) {Value=SqlHelper.ToDbValue(boxno)},
                                new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(sizename)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion




        #region 验证外箱條碼是否存在   int IsCartonBarcodetExisits(string scan)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsCartonBarcodetExisits(string scan)
        {

            string sql = "select count(*) from doc_PackList  where CartonBarcode=@CartonBarcode  ";
            SqlParameter[] ps = {
                                new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(scan)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion

        #region 验证客戶買主是否為歐洲   int isBuyerExists(string custombuyname)
        /// 验证客戶買主是否為歐洲
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int isBuyerExists(string custombuyname)
        {
            string sql = @"
                select count(*) from doc_Buyer  
              where CustomBuyName=@CustomBuyName  and State = 'EU' and Type='JAN'
                                ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(custombuyname)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion



        #region 查詢裝箱明細數量用於檢查是否接轉完畢  int GetPackListCount(string yyyymm)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListCount(string yyyymm)
        {
            string sql = "select count(*) from doc_PackList  where OrderDate=@OrderDate  ";
            SqlParameter[] ps = {
                                new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(yyyymm)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion

        #region 查詢該外箱條碼有多少內盒(混碼問題)  int GetPackListCartonCount(string cartonbarcode)
        /// 查詢該外箱條碼有多少內盒(混碼問題
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListCartonCount(string cartonbarcode)
        {
            string sql = "select sum(Convert(int,TotalCount)) from doc_PackList where  CartonBarcode=@CartonBarcode  ";
            SqlParameter[] ps = {
                                new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion





        #region 查詢成品箱裝箱明細數量用於檢查是否接轉完畢  int GetPackListShipCount(string yyyymm)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListShipCount(string yyyymm)
        {
            string sql = "select count(*) from doc_PackListShip  where OrderDate=@OrderDate  ";
            SqlParameter[] ps = {
                                new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(yyyymm)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion


        #region 刪除整個裝箱明細   int DelPackListOrderALL(string orderdate)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListOrderALL(string orderdate)
        {
            string sql = " delete from doc_PackList  where OrderDate=@OrderDate  ";
            SqlParameter[] ps = {
                                new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(orderdate)}
            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 刪除裝箱明細   int DelPackListOrder(string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListOrder(string customstylecode)
        {
            string sql = " delete from doc_PackList  where CustomStyleCode=@CustomStyleCode  ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)}
            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region 刪除成倉裝箱明細    int DelPackListShiptOrder(string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListShiptOrder(string customstylecode)
        {
            string sql = " delete from doc_PackListShip  where CustomStyleCode=@CustomStyleCode  ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)}
            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

        #region 刪除月份成倉裝箱明細   int DelPackListShiptMonth(string yyyymm)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListShiptMonth(string yyyymm)
        {
            string sql = " delete from doc_PackListShip  where OrderDate=@OrderDate  ";
            SqlParameter[] ps = {
                                new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(yyyymm)}
            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region 查詢該成品外箱的條碼之內盒刷的數量   int GetPackListInnerCount(string cartonbarcode,string orderdate )
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListInnerCount(string cartonbarcode, string orderdate, string sizename)
        {
            string sql = @"
       select sum(ScanCount)  from doc_PackListScan 
where CartonBarcode=@CartonBarcode and OrderDate=@OrderDate and SizeName=@SizeName
                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)},
                                new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(orderdate)},
                                new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(sizename)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion

        #region 查詢該成品內盒條碼是否滿足(滿足=1)  int GetPackListSizeMatch(string cartonbarcode, string innerbarcode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListSizeMatch(string cartonbarcode, string innerbarcode)
        {
            string sql = @"
 select count(*) from doc_PackList
  where CartonBarcode=@CartonBarcode and (InnerBarcode=@InnerBarcode or InnerBarcode1=@InnerBarcode) and TotalCount <= BarcodeCount
                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)},
                                new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(innerbarcode)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion


        #region 查詢該成品內盒條碼是否滿足(滿足=1)  int GetPackListSizeMatch(string cartonbarcode, string innerbarcode,string oaout)
        /// 
        /// </summary> 
        /// <param name="code">已满不能增加</param>
        /// <returns></returns>
        public int GetPackListSizeMatch(string cartonbarcode, string innerbarcode, int scanout)
        {
            string sql = @"
 select count(*) from doc_PackList
  where CartonBarcode=@CartonBarcode and (InnerBarcode=@InnerBarcode or InnerBarcode1=@InnerBarcode) and TotalCount <= (BarcodeCount/@Scanout)
                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)},
                                new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(innerbarcode)},
                                new SqlParameter("@Scanout",SqlDbType.Int) {Value=SqlHelper.ToDbValue(scanout)}
            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);
        }
        #endregion

        public int GetPackListSizeCount(string cartonbarcode, string innerbarcode)
        {
            string sql = @"
 select totalcount from doc_PackList
  where CartonBarcode=@CartonBarcode and (InnerBarcode=@InnerBarcode or InnerBarcode1=@InnerBarcode) ";
            SqlParameter[] ps = {
                                new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)},
                                new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(innerbarcode)}
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dt.Rows[0]["totalcount"].ToString());
            }

        }





        #region APL打印标签(自己不需要产生)  int PrintAPL(string custombuyname)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int PrintAPL(string custombuyname)
        {
            string sql = @"
              select count(*) from doc_Buyer where 
CustomBuyName=@CustomBuyName and Forwarder = 'APL' and CartonBarcodeNeed = 'No'
                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(custombuyname)}
                                            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);

        }
        #endregion

        #region 非混码装(单码 第一笔外箱(BOXNO=1) 时 只有一笔 int FirstBoxno(string customstylecode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int FirstBoxno(string customstylecode)
        {
            string sql = @"
 select count(*) from doc_PackList 
where CustomStyleCode=@CustomStyleCode and BOXNO=1
                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomStyleCode",customstylecode)
                                            };
            return SqlHelper.ExcuteScalar<int>(sql, ps);

        }
        #endregion

        #region 非混码装并且是APL条码  List<MODEL.doc_PackList>  FirstBoxnoPrintAPL(string orderdate)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> FirstBoxnoPrintAPL(string orderdate)
        {
            string sql = @"
  select * from (
  select  BOXNO ,CustomStyleCode,OrderDate ,a.CustomBuyName, Forwarder,b.CartonBarcodeNeed,count(*) mycount  from doc_PackList a
  left join 
  (select  Forwarder,CartonBarcodeNeed,CustomBuyName,Destination from doc_Buyer)
  b on b.CustomBuyName=a.CustomBuyName  and Destination=AimArea
  where OrderDate=@OrderDate and Forwarder='APL' and b.CartonBarcodeNeed='NO'   and BOXNO=1 
  group by  BOXNO ,CustomStyleCode,OrderDate ,a.CustomBuyName, Forwarder,b.CartonBarcodeNeed  )c 
  where c.mycount=1  
  order by CustomStyleCode ,BOXNO
                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@OrderDate",orderdate)
                                            };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadStylecode(row, c);
                    lists.Add(c);
                }
            }
            return lists;


        }
        #endregion

        #region 加载行数据到对象--void LoadStylecode(DataRow dr, MODEL.doc_PackList docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadStylecode(DataRow dr, MODEL.doc_PackList docpacklist)
        {
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   




        }
        #endregion


        #region 非混码装并且是APL条码  List<MODEL.doc_PackList> LeftBoxno(string customstylecode,int boxno)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> LeftBoxno(string customstylecode, int boxno)
        {
            string sql = @" 
  select CartonBarcode,BOXNO,CustomStyleCode from doc_PackList 
where CustomStyleCode=@CustomStyleCode and BOXNO>=@BOXNO order by BOXNO
                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomStyleCode",customstylecode),
                                new SqlParameter("@BOXNO",boxno),
                                            };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadStylecode1(row, c);
                    lists.Add(c);
                }
            }
            return lists;


        }
        #endregion

        #region 加载行数据到对象--void LoadStylecode(DataRow dr, MODEL.doc_PackList docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadStylecode1(DataRow dr, MODEL.doc_PackList docpacklist)
        {
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   
            docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
        }
        #endregion


        #region  多條件查詢裝箱明細  List<MODEL.doc_PackList> SeePackList(string customstylecode,int boxno)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> SeePackList(bool chkorder, string orderdate, string customstylecode, string custombuyname, string name, string color, string type, bool chksacn)
        {
            string sql = @" 
  SELECT CustomName,CustomBuyName,CustomStyleCode,BOXNO,SizeName,TotalCount,
  BarcodeCount,CartonBarcode,Type,InnerBarcode,InnerBarcode1, 
  CartonBarcodeNeed,Code,Name,Color,CustomPO,CustomStyleName,BoxSize 
  from doc_PackList 
                                     ";

            List<string> listWhere = new List<string>();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listWhere.Add(" CustomName='ASICS'  ");
            if (chkorder == true)
            {
                if (orderdate != "")
                {
                    listWhere.Add(" Orderdate=@Orderdate ");
                    listParameters.Add(new SqlParameter("@Orderdate", orderdate));
                }
            };
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
            if (name != "")
            {
                listWhere.Add(" Name like @Name ");
                listParameters.Add(new SqlParameter("@Name", "%" + name + "%"));
            }

            if (color != "")
            {
                listWhere.Add(" Color like @Color ");
                listParameters.Add(new SqlParameter("@Color", "%" + color + "%"));
            }

            if (type != "")
            {
                listWhere.Add(" Type like @Typer ");
                listParameters.Add(new SqlParameter("@Type", "%" + type + "%"));
            }
            if (type != "")
            {
                listWhere.Add(" Type like @Typer ");
                listParameters.Add(new SqlParameter("@Type", "%" + type + "%"));
            }
            if (chksacn == true)
            {
                listWhere.Add("  BarcodeCount < TotalCount  ");

            }




            if (listWhere.Count > 0)
            {
                string sqlWhere = string.Join(" and ", listWhere.ToArray());
                sql = sql + " where   " + sqlWhere + " order by CustomStyleCode,BOXNO ";
            }




            DataTable dt = SqlHelper.ExcuteTable(sql, listParameters.ToArray());
            List<MODEL.doc_PackList> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackList>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackList c = new MODEL.doc_PackList();
                    LoadPackList(row, c);
                    lists.Add(c);
                }
            }
            return lists;


        }
        #endregion

        #region 加载行数据到对象--void LoadPackList(DataRow dr, MODEL.doc_PackList docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadPackList(DataRow dr, MODEL.doc_PackList docpacklist)
        {

            docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);  //  
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);  //   
            docpacklist.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);  //  
            docpacklist.TotalCount = (string)SqlHelper.FromDbValue(dr["TotalCount"]);  //  
            docpacklist.BarcodeCount = (int)SqlHelper.FromDbValue(dr["BarcodeCount"]);  //  
            docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
            docpacklist.Type = (string)SqlHelper.FromDbValue(dr["Type"]);   //
            docpacklist.InnerBarcode = (string)SqlHelper.FromDbValue(dr["InnerBarcode"]);   //
            docpacklist.InnerBarcode1 = (string)SqlHelper.FromDbValue(dr["InnerBarcode1"]);   //
            docpacklist.CartonBarcodeNeed = (string)SqlHelper.FromDbValue(dr["CartonBarcodeNeed"]);   //           
            docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);   //        
            docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);   //                
            docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);   //        
            docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);   //             
            docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);   //        
            docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);   //                                  



        }
        #endregion






        #region 尾数箱第一张单的箱号 int LeftBoxno(string customstylecode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int? LeftBoxno(string customstylecode)
        {
            string sql = @"

  select top 1 BOXNO  from (
  SELECT count(*) kk,CustomStyleCode,BOXNO from doc_packlist
  where CustomName='ASICS' and CustomStyleCode=@CustomStyleCode
       group by  customstylecode,boxno
	    )a where a.kk>1  
		 order by CustomStyleCode,BOXNO

                                     ";
            SqlParameter[] ps = {
                                new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)}
                                            };
            return SqlHelper.ExcuteScalar<int?>(sql, ps);

        }
        #endregion

        #region 尾数箱第一张单的箱号 int LeftBoxno1(string customstylecode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int? LeftBoxno1(string customstylecode)
        {
            string sql = @"

select top 1 BOXNO from 
(
select a.customstylecode,a.BOXNO,sum(convert(int,a.PerCount)) PerCount1,b.Percount  from doc_PackList a  
   left join (
   select  top 1 PerCount Percount,CustomStyleCode from doc_PackList where CustomStyleCode=@CustomStyleCode  order by BOXNO
   )b on  b.CustomStyleCode=a.CustomStyleCode    where a.CustomStyleCode=@CustomStyleCode group by a.CustomStyleCode,a.BOXNO,b.Percount    
)c where PerCount1<PerCount  order by BOXNO


                                     ";
            //select top 1 BOXNO from 
            //(
            //select a.customstylecode,a.BOXNO,a.PerCount,b.perCount1 from doc_PackList a
            //left join(
            //select  top 1 perCount PerCount1,CustomStyleCode from doc_PackList where CustomStyleCode=@CustomStyleCode
            //)b on b.CustomStyleCode=a.CustomStyleCode  where a.CustomStyleCode=@CustomStyleCode1
            //)c where PerCount1<PerCount  order by BOXNO






            SqlParameter[] ps = {
                                new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)},
                                new SqlParameter("@CustomStyleCode1",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)},
                                            };
            return SqlHelper.ExcuteScalar<int?>(sql, ps);

        }
        #endregion

        #region 更新裝箱明細尾数外箱条码 int updatePackListCartonBarcode(string  customstylecode, int boxno,string cartonbarcode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackListCartonBarcode(string customstylecode, int boxno, string cartonbarcode)
        {
            string sql = @" 
                update doc_PackList set CartonBarcode=@CartonBarcode  
                where CustomStyleCode=@CustomStyleCode and BOXNO=@BOXNO                
                ";
            SqlParameter[] ps = {
                new SqlParameter("@CustomStyleCode", customstylecode),
                new SqlParameter("@BOXNO", boxno),
                new SqlParameter("@CartonBarcode", cartonbarcode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



    }

}
