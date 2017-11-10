using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class doc_PackListShipService
    {

        #region 获取訂單年月裝箱編號信息  -    List<MODEL.doc_PackListShip> GetPacklistCarNo(string yyyymm,string buyer)
        /// <summary>
        /// 获取訂單年月裝箱編號信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetPacklistCarNo(string yyyymm,string buyer)
        {
            string mbuyer = buyer + "%";
            string sql = @"  
            select CustomBuyName,CustomStyleCode,CarNo,AimArea from doc_PackListShip
            where OrderDate=@OrderDate and CustomBuyName like @CustomBuyName 
            Group by CustomStyleCode,CarNo ,AimArea,CustomBuyName 
            order by CustomBuyName,CustomStyleCode
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm),
                               new SqlParameter("@CustomBuyName",mbuyer)

                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion


        #region 訂單號獲取訂單年月 string GetMOrderDate( string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetMOrderDate( string customstylecode)
        {
            string sql = @"
                select  OrderDate   from doc_Order  
                where  CustomStyleCode = @CustomStyleCode   
        ";

            SqlParameter[] ps = {
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExcuteScalar<string>(sql, ps);
        }
        #endregion

        #region 获取訂單年月裝箱編號信息  -    List<MODEL.doc_PackListShip> GetPacklistCarNo(string yyyymm,string buyer)
        /// <summary>
        /// 获取訂單年月裝箱編號信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetPacklistCarNo1(string yyyymm, string buyer, string od)
        {
            string mbuyer = buyer + "%";
            string morder = od + "%";
            string sql = @"  
            select CustomBuyName,CustomStyleCode,CarNo,AimArea from doc_PackListShip
            where OrderDate =@OrderDate and CustomBuyName like @CustomBuyName and CustomStyleCode like @CustomStyleCode
            Group by CustomStyleCode,CarNo ,AimArea,CustomBuyName 
            order by CustomBuyName,CustomStyleCode
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm),
                               new SqlParameter("@CustomBuyName",mbuyer),
                               new SqlParameter("@CustomStyleCode",morder)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion



        #region 获取已編號貨櫃號櫃裝箱編號信息  -    List<MODEL.doc_PackListShip> GetPacklistCarNoOK(string carno)
        /// 获取已編號貨櫃號櫃裝箱編號信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetPacklistCarNoOK(string carno)
        {
            string sql = @"  
            select CustomBuyName,CustomStyleCode,CarNo,AimArea from doc_PackListShip
            where CarNo=@CarNo
            Group by CustomStyleCode,CarNo ,AimArea,CustomBuyName 
			order by CustomBuyName,CustomStyleCode
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CarNo",carno)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion


        #region 加载行数据到对象--LoadDataToList(DataRow dr, MODEL.doc_PackListShip docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_PackListShip docpacklist)
        {
            //  docpacklist.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          // 不用抓, 前面產生
            // docpacklist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);//
            // docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);//
            // docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);//
            // docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);//
            //docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //  CustomStyleName
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            // docpacklist.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);  //  
           docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);//
            docpacklist.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]);//
            // docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
           // docpacklist.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);//
             // docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);//
            // docpacklist.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);//
              // docpacklist.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]);//   
            // docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
           // docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸
            docpacklist.CarNo = (string)SqlHelper.FromDbValue(dr["CarNo"]); // 
                // docpacklist.InvoiceNo = (string)SqlHelper.FromDbValue(dr["InvoiceNo"]); // 
            //docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]); // 
               // docpacklist.ScanIn = (int)SqlHelper.FromDbValue(dr["ScanIn"]); // 
              // docpacklist.ScanOut = (int)SqlHelper.FromDbValue(dr["ScanOut"]); // 
             // docpacklist.QAIn = (int)SqlHelper.FromDbValue(dr["QAIn"]); // 
           // docpacklist.QAOut = (int)SqlHelper.FromDbValue(dr["QAOut"]); // 
        }
        #endregion


        #region 获取裝箱信息  -    List<MODEL.doc_PackListShip> GetPacklistShipByCartonBarcode(string cartonbarcode)
        /// <summary>
        /// 获取裝箱信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetPacklistShipByCartonBarcode(string cartonbarcode)
        {

            string sql = @"  
  select CartonBarcode,Orderdate,CustomStyleCode,BOXNO,ScanIn,ScanOut,QAIn,QAOut,CustomBuyName from doc_PackListShip
where CartonBarCode=@CartonBarCode

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CartonBarCode",cartonbarcode)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象--LoadDataToList2(DataRow dr, MODEL.doc_PackListShip docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_PackListShip docpacklist)
        {
             docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
           docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
         docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]); // 
             docpacklist.ScanIn = (int)SqlHelper.FromDbValue(dr["ScanIn"]); // 
             docpacklist.ScanOut = (int)SqlHelper.FromDbValue(dr["ScanOut"]); // 
             docpacklist.QAIn = (int)SqlHelper.FromDbValue(dr["QAIn"]); // 
             docpacklist.QAOut = (int)SqlHelper.FromDbValue(dr["QAOut"]); // 
            docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]); // 
        }
        #endregion




        #region 获取訂單未入庫外箱號訊息  -     List<MODEL.doc_PackListShip> GetPacklistShipNoNotScanIn(string customstylecode, string mno)
        /// <summary>
        /// 获取貨櫃號箱信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        /// 


        public List<MODEL.doc_PackListShip> GetPacklistShipNoNotScanIn(string customstylecode, int mno)
        {
            
            string sql = @"  
  select BOXNO,CartonBarcode,OrderDate,ScanOut,ScanIn,QAout from doc_PackListShip 
  where CustomStyleCode=@CustomStyleCode and ScanOut=@ScanOut and ScanIn=@ScanIn
    order by QAout, BOXNO
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode),
                               new SqlParameter("@ScanOut",mno),
                               new SqlParameter("@ScanIn",mno)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList3(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象--LoadDataToList3(DataRow dr, MODEL.doc_PackListShip docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList3(DataRow dr, MODEL.doc_PackListShip docpacklist)
        {

            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]); // 
           docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]); // 
            docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]); // 
            docpacklist.ScanIn = (int)SqlHelper.FromDbValue(dr["ScanIn"]); // 
            docpacklist.ScanOut = (int)SqlHelper.FromDbValue(dr["ScanOut"]); // 
            docpacklist.QAOut = (int)SqlHelper.FromDbValue(dr["QAOut"]); // 

        }
        #endregion


        #region 获取訂單已入庫外箱號訊息  -   List<MODEL.doc_PackListShipScan> GetPacklistShipNoYesScanIn(string customstylecode, string mno)
        /// <summary>
        /// 获取訂單已入庫外箱號訊息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>        
        public List<MODEL.doc_PackListShipScan> GetPacklistShipNoYesScanIn(string customstylecode, string mno)
        {
     //       string mscanin = (int.Parse(mno) + 1).ToString();
            string sql = @"

  select a.BOXNO BOXNO,a.CartonBarcode CartonBarcode,OrderDate,a.CustomStyleCode CustomStyleCode,ScanTime,QA,a.ScanOut ScanOut, a.Part Part, WH,ScanBatch,ScanIn from doc_PackListShipScan  a		
  left join ( select ScanIn,ScanOut,BOXNO,CustomStyleCode from doc_PackListShip) b
  on b.BOXNO=a.BOXNO and b.CustomStyleCode=a.CustomStyleCode
  where a.CustomStyleCode=@CustomStyleCode  and a.ScanOut<=@ScanOut
  order by BOXNO,ScanOut,Part
";
            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode),
                               new SqlParameter("@ScanOut",mno)
                       //        new SqlParameter("@ScanIn",mno)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShipScan> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShipScan>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShipScan c = new MODEL.doc_PackListShipScan();
                    LoadDataToList4(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象- void LoadDataToList4(DataRow dr, MODEL.doc_PackListShipScan docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList4(DataRow dr, MODEL.doc_PackListShipScan docpacklist)
        {  

            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]); // 
            docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]); // 
            docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]); //         
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.ScanTime = (DateTime)SqlHelper.FromDbValue(dr["ScanTime"]);//
            docpacklist.QA = (string)SqlHelper.FromDbValue(dr["QA"]);//
            docpacklist.Part = (string)SqlHelper.FromDbValue(dr["Part"]);//
            docpacklist.ScanOut = (int)SqlHelper.FromDbValue(dr["ScanOut"]); // 
            docpacklist.WH = (string)SqlHelper.FromDbValue(dr["WH"]);//                                                    
            docpacklist.ScanBatch = (string)SqlHelper.FromDbValue(dr["ScanBatch"]);//       


        }
        #endregion








        #region 获取貨櫃號箱信息  -    List<MODEL.doc_PackListShip> GetPacklistShpByCarNo(string carno)
        /// <summary>
        /// 获取貨櫃號箱信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetPacklistShpByCarNo(string carno)
        {
            string sql = @"  
select   CarNo,CustomStyleCode,BOXNO,AimArea,CartonBarcode,ShipOut,ShipScanTime,BoxSize from doc_PackListShip
where CarNo=@CarNo
order by CustomStyleCode,BOXNO
                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CarNo",carno)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShip> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShip>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShip c = new MODEL.doc_PackListShip();
                    LoadDataToList5(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象--LoadDataToList5(DataRow dr, MODEL.doc_PackListShip docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList5(DataRow dr, MODEL.doc_PackListShip docpacklist)
        {
            docpacklist.CarNo = (string)SqlHelper.FromDbValue(dr["CarNo"]); // 
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
            docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]); // 
            docpacklist.AimArea = (string)SqlHelper.FromDbValue(dr["AimArea"]);//
            docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
           docpacklist.ShipOut = (string)SqlHelper.FromDbValue(dr["ShipOut"]);
            docpacklist.ShipScanTime = (string)SqlHelper.FromDbValue(dr["ShipScanTime"]);//
            docpacklist.BoxSize = (string)SqlHelper.FromDbValue(dr["BoxSize"]);  // 外箱的尺寸


            //  docpacklist.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          // 不用抓, 前面產生
            // docpacklist.Style = (string)SqlHelper.FromDbValue(dr["Style"]);//
            // docpacklist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);//
            // docpacklist.Color = (string)SqlHelper.FromDbValue(dr["Color"]);//
            // docpacklist.Code = (string)SqlHelper.FromDbValue(dr["Code"]);//
            //docpacklist.CustomStyleName = (string)SqlHelper.FromDbValue(dr["CustomStyleName"]);  //  CustomStyleName

           // docpacklist.CustomName = (string)SqlHelper.FromDbValue(dr["CustomName"]);  //  
           // docpacklist.CustomBuyName = (string)SqlHelper.FromDbValue(dr["CustomBuyName"]);//

             // docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
             // docpacklist.ShipMentDate = (DateTime)SqlHelper.FromDbValue(dr["ShipMentDate"]);//
             // docpacklist.CustomPO = (string)SqlHelper.FromDbValue(dr["CustomPO"]);//
           // docpacklist.ManufactureOrder = (string)SqlHelper.FromDbValue(dr["ManufactureOrder"]);//
             // docpacklist.CutNo = (string)SqlHelper.FromDbValue(dr["CutNo"]);//   



           // docpacklist.InvoiceNo = (string)SqlHelper.FromDbValue(dr["InvoiceNo"]); // 

            // docpacklist.ScanIn = (int)SqlHelper.FromDbValue(dr["ScanIn"]); // 
              // docpacklist.ScanOut = (int)SqlHelper.FromDbValue(dr["ScanOut"]); // 
            // docpacklist.QAIn = (int)SqlHelper.FromDbValue(dr["QAIn"]); // 
              // docpacklist.QAOut = (int)SqlHelper.FromDbValue(dr["QAOut"]); // 

        }
        #endregion










        #region 更新QA檢查  updatePackLisQAOut(string cartonbarcode,string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackLisQAOut(string cartonbarcode,string customstylecode)
        {
            string sql = @" 
  update doc_PackListShip set QAOut=QAOut+1
  where CartonBarcode=@CartonBarcode and CustomStyleCode=@CustomStyleCode     
                ";

            SqlParameter[] ps = {
                new SqlParameter("@CartonBarcode", cartonbarcode),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region  更新外箱掃描  updatePackListShipScanIn(string cartonbarcode, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackListShipScanIn( string cartonbarcode, string customstylecode)
        {
            string sql = @" 
             update doc_PackListShip set ScanIn=ScanIn+1
             where CartonBarcode=@CartonBarcode and CustomStyleCode=@CustomStyleCode     
                ";

            SqlParameter[] ps = {
               
                new SqlParameter("@CartonBarcode", cartonbarcode),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        public int updatePackListShipwh(string WH, string cartonbarcode, string customstylecode)
        {
            string sql = @" 
             update doc_PackListShip set wh=@wh
             where CartonBarcode=@CartonBarcode and CustomStyleCode=@CustomStyleCode     
                ";

            SqlParameter[] ps = {
                new SqlParameter("@wh", WH),
                new SqlParameter("@CartonBarcode", cartonbarcode),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion




        #region 查詢QAOut  string GetScanOut(string cartonbarcode,string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int? GetScanOut(string cartonbarcode, string customstylecode)
        {
            string sql = @"
                select   Top 1 ScanOut+1  from doc_PackListShip 
                where CartonBarcode = @CartonBarcode and CustomStyleCode = @CustomStyleCode   
        ";

            SqlParameter[] ps = {
                new SqlParameter("@CartonBarcode", cartonbarcode),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };        
            return SqlHelper.ExcuteScalar<int?>(sql, ps);
        }
        #endregion


        #region  更新外箱掃描出庫  updatePackListShipScanOut(string cartonbarcode, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackListShipScanOut(string cartonbarcode, string customstylecode)
        {
            string sql = @" 
             update doc_PackListShip set ScanOut=ScanOut+1
             where CartonBarcode=@CartonBarcode and CustomStyleCode=@CustomStyleCode     
                ";

            SqlParameter[] ps = {
                new SqlParameter("@CartonBarcode", cartonbarcode),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion









        #region  更新外箱掃描回復 int updatePackListShipScanInBACK(string cartonbarcode, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackListShipScanInBACK(string cartonbarcode, string customstylecode)
        {
            string sql = @" 
             update doc_PackListShip set ScanIn=ScanIn-1
             where CartonBarcode=@CartonBarcode and CustomStyleCode=@CustomStyleCode     
                ";

            SqlParameter[] ps = {
                new SqlParameter("@CartonBarcode", cartonbarcode),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion











        #region 更新貨櫃序號  int updatePackListShipNo(String carno, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackListShipNo(String carno, string customstylecode)
        {
              string sql = @" 
  update doc_PackListShip set CarNo=@CarNo
  where CustomStyleCode=@CustomStyleCode and CarNo is null     
                ";

            SqlParameter[] ps = {
                new SqlParameter("@CarNo", carno),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

        #region 更新CBM  int updatePackListBoxCBM(float cmb,string carno, string customstylecode)
        /// <summary>
        ///  更新CBM
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public int updatePackListBoxCBM(float cbm,string carno, string customstylecode)
        {
            string sql = @" 
            update doc_PackListShip set BoxCBM=@BoxCBM
            where CustomStyleCode=@CustomStyleCode and CarNo=@CarNo
                ";
            SqlParameter[] ps = {
                new SqlParameter("@BoxCBM", cbm),
                new SqlParameter("@CustomStyleCode", customstylecode),
                new SqlParameter("@CarNo", carno)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region 取消貨櫃序號  int cancelPackListShipNo(String carno, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int cancelPackListShipNo(String carno, string customstylecode)
        {
            string sql = @" 
    update doc_PackListShip set CarNo=NULL
  where CustomStyleCode=@CustomStyleCode and CarNo=@CarNo  
                ";

            SqlParameter[] ps = {
                new SqlParameter("@CarNo", carno),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

        #region 取消外箱貨櫃序號  int cancelCartonPackListShipNo(String boxno, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int cancelCartonPackListShipNo(String boxno, string customstylecode)
        {
            string sql = @" 
    update doc_PackListShip set CarNo=NULL
  where CustomStyleCode=@CustomStyleCode and BOXNO=@BOXNO  
                ";

            SqlParameter[] ps = {
                new SqlParameter("@BOXNO", boxno),
                new SqlParameter("@CustomStyleCode", customstylecode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion




    }
}
