using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class doc_PackListManager
    {




        DAL.doc_PackListService  pls = new DAL.doc_PackListService();


        /// <summary>
        /// Sqlbulkcopies the specified SMS.批量插入到数据库
        /// </summary>
        /// <param name="data">list类型数据.</param>
        /// <param name="sqlconn">数据库连接字符串.</param>
        /// 
        public void GetPacklistBulk(List<MODEL.doc_PackList> mydata)
        {
             pls.GetPacklistBulk(mydata);
        }

        public void GetPacklistBulkPackList1(DataTable table)
        {
            pls.GetPacklistBulkPackList1(table);

        }
        public void GetPacklistBulkPackList(DataTable table)
        {
           pls.GetPacklistBulkPackList(table);

        }

        public void GetPacklistBulkPackListShip(DataTable table)
        {

            pls.GetPacklistBulkPackListShip(table);


        }











        #region 获取該訂單的裝箱明細信息(先行SQLJOIN)  -  List<MODEL.doc_PackList> GetToPacklist(string yyyymm)
        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetToPacklist(string yyyymm)
        {
                      return  pls.GetToPacklist(yyyymm);

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
          return  pls.GetToPacklistOrder(customstylecode);
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

            return pls.GetToPacklistShip(yyyymm);

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

            return pls.GetToPacklistShipUpdate(yyyymm);
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
            return pls.GetToPacklistShipOrder(customstylecode);
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
            return pls.GetToPacklistShipOrder1(customstylecode);
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
            return pls.GetInnerNeedASICS(yyyymm); 
        }

        #endregion


        #region 更新裝箱明細的內盒條碼   int updatePackListBarcode(String name,String color, String sizename,String tyle,string innerbarcode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>            
        public int updatePackListBarcode(String name, String color, String sizename, String type, string innerbarcode,string innerbarcode1)
        {
           return  pls.updatePackListBarcode(name, color, sizename, type, innerbarcode, innerbarcode1);
        }
        #endregion



        #region 查詢裝箱明細數量用於檢查是否接轉完畢  int GetPackListCount(string yyyymm)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListCount(string yyyymm)
        {
            return pls.GetPackListCount(yyyymm);
        }
        #endregion



        #region 查詢成品箱裝箱明細數量用於檢查是否接轉完畢  int GetPackListShipCount(string yyyymm)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListShipCount(string yyyymm)
        {

            return  pls.GetPackListShipCount(yyyymm);
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
            return pls.EXCEPTPacklistShip(yyyymm);
        }

        #endregion









        /// <summary>
        /// 获取該訂單的T_裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.T_PackList> GetTPacklist1(string yyyymm)
        {
            return pls.GetTPacklist1(yyyymm);
        }


        public List<MODEL.T_PackList> GetTPacklist(string customstylecode)
        {           
            return pls.GetTPacklist(customstylecode);
        }


        public string GetBuyerCartonBarcodeNeed(string custombuyname, string customname, string destination)
        {
            return pls.GetBuyerCartonBarcodeNeed(custombuyname, customname, destination);
        }
        public string GetBuyertype(string custombuyname, string customname, string destination)
        {
            return pls.GetBuyertype(custombuyname, customname, destination);
        }

        public string GetInnerBarcode(string name, string color, string size, string type)
        {                       
           return pls.GetInnerBarcode(name,color,size,type);
        }


        public string GetInnerBarcodeEAN(string name, string color, string size)
        {
            return pls.GetInnerBarcodeEAN(name, color, size);
        }



        #region 增加裝箱明細 - int AddPackList(MODEL.doc_PackList packlist)
        /// 增加裝箱明細
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddPackList1(MODEL.doc_PackList packlist)
        {
            return pls.AddPackList1(packlist);
        }


        #endregion


        #region 增加裝箱明細 - int AddPackList(MODEL.doc_PackList packlist)
        /// 增加裝箱明細
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddPackList(MODEL.doc_PackList packlist)
      {
                 return pls.AddPackList(packlist);
      }


        #endregion


        #region 验证型体大类是否存在  int IsPackListExisits(string customstylecode, string boxno)
        /// <summary>
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsPackListExisits(string customstylecode, int? boxno,string sizename)
        {
            return pls.IsPackListExisits(customstylecode, boxno,sizename);

        }

        #endregion

        #region 验证客戶買主是否為歐洲   int isBuyerExists(string custombuyname)
        /// 验证客戶買主是否為歐洲
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int isBuyerExists(string custombuyname)
        {
            return pls.isBuyerExists(custombuyname);
        }
        #endregion







        public List<MODEL.doc_PackList> GetCartonBarcode(string cattonbarcode)
        {            
            return  pls.GetCartonBarcode(cattonbarcode);
        }



        #region 获取該訂單的裝箱明細信息  -  List<MODEL.doc_PackList> GetInnerBarcode(string innerbarcode,string cartonbarcode)

        /// <summary>
        /// 获取該訂單的裝箱明細信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> GetInnerBarcode(string innerbarcode, string cartonbarcode)
        {

            return pls.GetInnerBarcode(innerbarcode,cartonbarcode);
        }

        #endregion

        #region 查詢該外箱條碼有多少內盒(混碼問題)  int GetPackListCartonCount(string cartonbarcode)
         /// 查詢該外箱條碼有多少內盒(混碼問題
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListCartonCount(string cartonbarcode)
        {

            return  pls.GetPackListCartonCount(cartonbarcode);
        }
        #endregion


        #region  多條件查詢裝箱明細 List<MODEL.doc_PackList> SeePackList(string orderdate, string customstylecode, string custombuyname, string name, string color, string type)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> SeePackList(bool chkorder , string orderdate, string customstylecode, string custombuyname, string name, string color, string type,bool chescan)
        {

            return pls.SeePackList(chkorder, orderdate, customstylecode, custombuyname, name, color, type,chescan);


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

            return pls.GetLeftOrder(customstylecode);
        }

        #endregion
        

        #region 更新裝箱明細刷條碼次數  int updatePackListBarcodeCount(Guid guid,String barcountcount)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackListBarcodeCount(Guid guid, int barcodecount)
        {
            return pls.updatePackListBarcodeCount(guid, barcodecount);
        }
        #endregion


        #region 查詢該成品內盒條碼是否滿足(滿足=1)  int GetPackListSizeMatch(string cartonbarcode, string innerbarcode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListSizeMatch(string cartonbarcode, string innerbarcode)
        { 
            return pls.GetPackListSizeMatch(cartonbarcode, innerbarcode);
        }
        #endregion

        #region 查詢該成品內盒條碼是否滿足(滿足=1)  int GetPackListSizeMatch(string cartonbarcode, string innerbarcode,int oaout)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListSizeMatch(string cartonbarcode, string innerbarcode,int qaout)
        {
            return pls.GetPackListSizeMatch(cartonbarcode, innerbarcode,qaout);
        }
        #endregion
        public int GetPackListSizeCount(string cartonbarcode, string innerbarcode)
        {
            return pls.GetPackListSizeCount(cartonbarcode, innerbarcode);
        }


        #region 验证外箱條碼是否存在   int IsCartonBarcodetExisits(string scan)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsCartonBarcodetExisits(string scan)
        {
            return  pls.IsCartonBarcodetExisits(scan);
        }
        #endregion

        #region 刪除整個裝箱明細   int DelPackListOrderALL(string orderdate)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListOrderALL(string orderdate)
        {
            return pls.DelPackListOrderALL(orderdate);
        }
        #endregion



        #region 刪除裝箱明細   int DelPackListOrder(string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListOrder(string customstylecode)
        {
            return pls.DelPackListOrder(customstylecode);
        }
        #endregion

        #region 刪除成倉裝箱明細    int DelPackListShiptOrder(string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListShiptOrder(string customstylecode)
        {
            return pls.DelPackListShiptOrder(customstylecode);
        }
        #endregion


        #region 刪除月份成倉裝箱明細   int DelPackListShiptMonth(string yyyymm)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelPackListShiptMonth(string yyyymm)
        {
            return pls.DelPackListShiptMonth(yyyymm);
        }
        #endregion



        #region 查詢該成品外箱的條碼之內盒刷的數量 int GetPackListInnerCount(string cartonbarcode, string orderdate,string sizename)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetPackListInnerCount(string cartonbarcode, string orderdate,string sizename)
        {
            return pls.GetPackListInnerCount(cartonbarcode, orderdate,sizename);
        }
        #endregion

        #region APL打印只标签(自己不需要产生)  int PrintAPL(string custombuyname)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int PrintAPL(string custombuyname)
        {
            return pls.PrintAPL(custombuyname);
        }
        #endregion


        #region 非混码装(单码 第一笔外箱(BOXNO=1) 时 只有一笔 int FirstBoxno(string customstylecode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int FirstBoxno(string customstylecode)
        {

            return  pls.FirstBoxno(customstylecode);

        }
        #endregion


       #region 非混码装并且是APL条码  List<MODEL.doc_PackList>  FirstBoxnoPrintAPL(string orderdate)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> FirstBoxnoPrintAPL(string orderdate)
        {
            return pls.FirstBoxnoPrintAPL(orderdate);

        }
        #endregion

        #region 非混码装并且是APL条码  List<MODEL.doc_PackList> LeftBoxno(string customstylecode,int boxno)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MODEL.doc_PackList> LeftBoxno(string customstylecode, int boxno)
        {
            return pls.LeftBoxno(customstylecode, boxno);
        }
        #endregion



        #region 尾数箱第一张单的箱号 int LeftBoxno(string customstylecode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int? LeftBoxno(string customstylecode)
        {
            return pls.LeftBoxno(customstylecode);

        }
        #endregion

        #region 尾数箱第一张单的箱号 int LeftBoxno1(string customstylecode)
        /// 
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int? LeftBoxno1(string customstylecode)
        {
            return pls.LeftBoxno1(customstylecode);

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
            return pls.updatePackListCartonBarcode(customstylecode, boxno, cartonbarcode);
            }
        #endregion










        }
}
