using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class doc_PackListScanService
    {


        #region 增加掃描訊息 -  int AddPackList(MODEL.doc_PackListScan packlist)
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddPackList(MODEL.doc_PackListScan packlist)
        {



            string sql = @"
              insert into doc_PackListScan(Guid,CartonBarcode,InnerBarcode,ScanTime,SizeName,CustomStyleCode,OrderDate,ScanCount,ScanNO,ScanOut,Part)
        values(@Guid,@CartonBarcode,@InnerBarcode,@ScanTime,@SizeName,@CustomStyleCode,@OrderDate,@ScanCount,@ScanNO,@ScanOut,@Part)";
            SqlParameter[] ps = {
                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.Guid)},
                               new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CartonBarcode)},
                               new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.InnerBarcode)},
                              new SqlParameter("@ScanTime",SqlDbType.DateTime) {Value=SqlHelper.ToDbValue(packlist.ScanTime)},
                               new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.SizeName)},
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomStyleCode)},
                               new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.OrderDate)},
                               new SqlParameter("@ScanCount",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.ScanCount)},
                               new SqlParameter("@ScanNO",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.ScanNO)},
                               new SqlParameter("@ScanOut",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.ScanOut)},
                               new SqlParameter("@Part",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Part)}
        };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 获取掃描明細的訊息 - List<MODEL.doc_PackListScan> GetPackListScan(string cartonbarcode)

        /// <summary>
        /// 获取該掃描明細的訊息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListScan> GetPackListScan(string cartonbarcode)
        {
            string sql = @"
        select  * 
        from doc_PackListScan
        where CartonBarcode=@CartonBarcode order by ScanNO

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CartonBarcode",cartonbarcode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListScan> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListScan>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListScan c = new MODEL.doc_PackListScan();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 获取掃描明細的訊息 - List<MODEL.doc_PackListScan> GetPackListScan(string cartonbarcode)

        /// <summary>
        /// 获取該掃描明細的訊息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListScan> GetPackListScan(string cartonbarcode, int scanout)
        {
            string sql = @"
        select  * 
        from doc_PackListScan
        where CartonBarcode=@CartonBarcode  and  ScanOut=@ScanOut  order by ScanNO

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CartonBarcode",cartonbarcode),
                               new SqlParameter("@ScanOut",scanout)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListScan> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListScan>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListScan c = new MODEL.doc_PackListScan();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion









        #region 加载行数据到对象-- void LoadDataToList(DataRow dr, MODEL.doc_PackListScan pscan)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_PackListScan pscan)
        {
            pscan.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);
            pscan.ScanNO = (int)SqlHelper.FromDbValue(dr["ScanNO"]);

        }
        #endregion


        #region 获取掃描明細的訊息 -  List<MODEL.doc_PackListScan> GetPackListScanInfo(string customstylecode,string cartonbarcode)

        /// <summary>
        /// 获取該掃描明細的訊息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListScan> GetPackListScanInfo(string customstylecode, string cartonbarcode)
        {
            string sql = @"
        select  * 
        from doc_PackListScan
        where  CustomStyleCode=@CustomStyleCode and CartonBarcode=@CartonBarcode order by ScanNO

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@CustomStyleCode",customstylecode),
                               new SqlParameter("@CartonBarcode",cartonbarcode)
                                };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListScan> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListScan>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListScan c = new MODEL.doc_PackListScan();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象-- void LoadDataToList(DataRow dr, MODEL.doc_PackListScan pscan)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_PackListScan pscan)
        {
            pscan.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);
            pscan.InnerBarcode = (string)SqlHelper.FromDbValue(dr["InnerBarcode"]);
            pscan.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);
            pscan.SizeName = (string)SqlHelper.FromDbValue(dr["SizeName"]);
            pscan.ScanTime = (DateTime)SqlHelper.FromDbValue(dr["ScanTime"]);
            pscan.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);
            pscan.ScanCount = (int)SqlHelper.FromDbValue(dr["ScanCount"]);
            pscan.ScanNO = (int)SqlHelper.FromDbValue(dr["ScanNO"]);
            pscan.Part = (string)SqlHelper.FromDbValue(dr["Part"]);


        }
        #endregion




        public string GetErrorUserPWD()
        {
            string sql = "select userpwd from T_role where loginname='Error' ";

            return SqlHelper.ExcuteScalar<string>(sql);
        }


        public int UpdateErrorBox(string customstylecode, string cartonbarcode, string errorbarcode)
        {
            string sql = @"UPDATE dbo.doc_PackList SET SizeNo=@errorbarcode WHERE CustomStyleCode=@customstylecode AND CartonBarcode=@cartonbarcode";
            SqlParameter[] ps = {
                                new SqlParameter("@customstylecode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)},
                               new SqlParameter("@cartonbarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)},
                                new SqlParameter("@errorbarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(errorbarcode)}

                                 };
            return SqlHelper.ExecuteNonQuery(sql, ps);

        }
        public int UpdateErrorBox(string customstylecode, string cartonbarcode)
        {
            string sql = @"UPDATE dbo.doc_PackList SET SizeNo=NULL,BarcodeCount=0 WHERE CustomStyleCode=@customstylecode AND CartonBarcode=@cartonbarcode";
            SqlParameter[] ps = {
                                new SqlParameter("@customstylecode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(customstylecode)},
                               new SqlParameter("@cartonbarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)}


                                 };
            SqlHelper.ExecuteNonQuery(sql, ps);
            sql = @"DELETE dbo.doc_PackListScan where CartonBarcode=@cartonbarcode";
            SqlParameter[] ps2 = {
                               new SqlParameter("@cartonbarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(cartonbarcode)}
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps2);



        }
    }
}
