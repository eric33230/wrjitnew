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
    public class doc_PackListShipScanService
    {


        #region 增加成品外箱掃描訊息 - int AddPackListShipScan(MODEL.doc_PackListShipScan packlist)
        /// </summary>
        /// <param>""></param>
        /// <returns></returns>
        public int AddPackListShipScan(MODEL.doc_PackListShipScan packlist)
        {
        string sql = @"
            insert into doc_PackListShipScan(Guid,CartonBarcode,BOXNO,OrderDate,CustomStyleCode,ScanCount,Part,QA,WH,ScanTime,ScanBatch,ScanOut)
            values(@Guid,@CartonBarcode,@BOXNO,@OrderDate,@CustomStyleCode,@ScanCount,@Part,@QA,@WH,@ScanTime,@ScanBatch,@ScanOut)
            ";
        SqlParameter[] ps = {

                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.Guid)},
                               new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CartonBarcode)},
                               new SqlParameter("@BOXNO",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.BOXNO)},
                               new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.OrderDate)},
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomStyleCode)},
                               new SqlParameter("@ScanCount",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.ScanCount)},
                               new SqlParameter("@Part",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Part)},
                              new SqlParameter("@QA",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.QA)},
                              new SqlParameter("@WH",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.WH)},
                              new SqlParameter("@ScanTime",SqlDbType.DateTime) {Value=SqlHelper.ToDbValue(packlist.ScanTime)},
                              new SqlParameter("@ScanBatch",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.ScanBatch)},
                               new SqlParameter("@ScanOut",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.ScanOut)}
                       };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region 获取入庫批號  -   List<MODEL.doc_PackListShipScan> GetScanBatch(string scanbatch,string  scanbatch1)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShipScan> GetScanBatch(string scanbatch, string scanbatch1)
        {

 // select ScanBatch from doc_PackListShipScan
 // WHERE ScanBatch >= @ScanBatch and ScanBatch < @ScanBatch1
//group by ScanBatch

            string sql = @"  
  select  a.ScanBatch,b.ScanCount from doc_PackListShipScan a
  left join (
 SELECT count(*) ScanCount,ScanBatch from doc_PackListShipScan group by ScanBatch) b on a.ScanBatch=b.ScanBatch  
   WHERE a.ScanBatch >= @ScanBatch  and a.ScanBatch < @ScanBatch1
  group by a.ScanBatch,b.ScanCount
  order by a.ScanBatch

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@ScanBatch",scanbatch),
                               new SqlParameter("@ScanBatch1",scanbatch1),
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShipScan> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShipScan>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShipScan c = new MODEL.doc_PackListShipScan();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象--void LoadDataToList(DataRow dr, MODEL.doc_PackListShipScan docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_PackListShipScan docpacklist)
        {

            docpacklist.ScanBatch = (string)SqlHelper.FromDbValue(dr["ScanBatch"]);//
            docpacklist.ScanCount=(int)SqlHelper.FromDbValue(dr["ScanCount"]);//

        }
        #endregion

        #region 获取該批次外箱掃描入庫明細  -  List<MODEL.doc_PackListShipScan> GetPackListShipScan(string scanbatch)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShipScan> GetPackListShipScan(string scanbatch)
        {
            string sql = @"  
 Select BOXNO,CartonBarcode,OrderDate,CustomStyleCode,ScanTime,QA,ScanOut,WH,ScanBatch,Part
FROM doc_PackListShipScan
Where ScanBatch=@ScanBatch
order by Scantime

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@ScanBatch",scanbatch)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShipScan> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShipScan>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShipScan c = new MODEL.doc_PackListShipScan();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 获取時間段所有批次外箱掃描入庫明細  -   List<MODEL.doc_PackListShipScan> GetPackListShipScanBatch((string scanbatch, string scanbatch1)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShipScan> GetPackListShipScanBatch(string scanbatch, string scanbatch1)
        {

            string sql = @"  
 Select BOXNO,CartonBarcode,OrderDate,CustomStyleCode,ScanTime,QA,ScanOut,WH,ScanBatch,Part
FROM doc_PackListShipScan
 WHERE ScanBatch >= @ScanBatch and ScanBatch < @ScanBatch1
 order by ScanBatch,Scantime

                            ";
            SqlParameter[] ps = {

                               new SqlParameter("@ScanBatch",scanbatch),
                               new SqlParameter("@ScanBatch1",scanbatch1),

                                };
            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.doc_PackListShipScan> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_PackListShipScan>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_PackListShipScan c = new MODEL.doc_PackListShipScan();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion




        #region 加载行数据到对象--void LoadDataToList(DataRow dr, MODEL.doc_PackListShipScan docpacklist)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_PackListShipScan docpacklist)
        {
        
           docpacklist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]); // 
           docpacklist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);   //
           docpacklist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
            docpacklist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]);  //   訂單號
           docpacklist.ScanTime = (DateTime)SqlHelper.FromDbValue(dr["ScanTime"]);//
            docpacklist.QA = (string)SqlHelper.FromDbValue(dr["QA"]);//
            docpacklist.Part = (string)SqlHelper.FromDbValue(dr["Part"]);//
            docpacklist.ScanOut = (int)SqlHelper.FromDbValue(dr["ScanOut"]); // 
            docpacklist.WH = (string)SqlHelper.FromDbValue(dr["WH"]);//                                                    
            docpacklist.ScanBatch = (string)SqlHelper.FromDbValue(dr["ScanBatch"]);//            


        }
        #endregion





    }
}
