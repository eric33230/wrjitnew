using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class doc_PackListShipManager
    {
        DAL.doc_PackListShipService plship = new DAL.doc_PackListShipService();

        #region 获取訂單年月裝箱編號信息  -   List<MODEL.doc_PackListShip>  GetPacklistCarNo(string yyyymm, string buyer)
        /// <summary>
        /// 获取訂單年月裝箱編號信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip>  GetPacklistCarNo(string yyyymm, string buyer)
        {

            return plship.GetPacklistCarNo(yyyymm,buyer);

        }
        #endregion

        #region 获取訂單年月裝箱編號信息  -   List<MODEL.doc_PackListShip>  GetPacklistCarNo(string yyyymm, string buyer,string od)
        /// <summary>
        /// 获取訂單年月裝箱編號信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetPacklistCarNo1(string yyyymm, string buyer, string od)
        {

            return plship.GetPacklistCarNo1(yyyymm, buyer, od);

        }
        #endregion

        #region 訂單號獲取訂單年月 string GetMOrderDate( string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetMOrderDate(string customstylecode)
        {                                
            return plship.GetMOrderDate(customstylecode);
        }
        #endregion

        #region 获取已編號貨櫃號櫃裝箱編號信息  -    List<MODEL.doc_PackListShip> GetPacklistCarNoOK(string carno)
        /// 获取已編號貨櫃號櫃裝箱編號信息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShip> GetPacklistCarNoOK(string carno)
        {
            return plship.GetPacklistCarNoOK(carno);
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
            return plship.GetPacklistShipByCartonBarcode(cartonbarcode);
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
            return plship.GetPacklistShpByCarNo(carno);
        }

        #endregion

        #region 获取訂單未入庫外箱號訊息  -     List<MODEL.doc_PackListShip> GetPacklistShipNoNotScanIn(string customstylecode, string mno)
        /// <summary>
        /// 获取訂單未入庫外箱號訊息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        /// 
        public List<MODEL.doc_PackListShip> GetPacklistShipNoNotScanIn(string customstylecode, int  mno)
        {     
            return plship.GetPacklistShipNoNotScanIn(customstylecode, mno);
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
            return plship.GetPacklistShipNoYesScanIn(customstylecode, mno);            
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
            return plship.updatePackListShipNo(carno,customstylecode);
        }
        #endregion


        #region 更新CBM  int updatePackListBoxCBM(float cmb,string carno, string customstylecode)
        /// <summary>
        ///  更新CMB
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public int updatePackListBoxCBM(float cbm, string carno, string customstylecode)
        {
            return plship.updatePackListBoxCBM(cbm,carno, customstylecode);
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
            return plship.cancelPackListShipNo(carno, customstylecode);
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
            return plship.cancelCartonPackListShipNo(boxno, customstylecode);
        }
        #endregion

        #region 更新QA檢查  updatePackLisQAOut(string qaout,string cartonbarcode,string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updatePackLisQAOut(string cartonbarcode, string customstylecode)
        {
            return plship.updatePackLisQAOut(cartonbarcode, customstylecode);
        }

        #endregion

        #region  更新外箱掃描  updatePackListShipScanIn(string cartonbarcode, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public int updatePackListShipScanIn(string cartonbarcode, string customstylecode)
        {                          
            return plship.updatePackListShipScanIn(cartonbarcode, customstylecode);
        }
        public int updatePackListShipwh(string wh, string cartonbarcode, string customstylecode)
        {
            return plship.updatePackListShipwh(wh, cartonbarcode, customstylecode);
        }
        #endregion


        #region 查詢QAOut  int GetScanOut(string cartonbarcode,string customstylecode)
        /// 验证型体大类是否存在
        /// </summary> 
        /// <param name="code"></param>
        /// <returns></returns>
        public int? GetScanOut(string cartonbarcode, string customstylecode)
        {
            return plship.GetScanOut(cartonbarcode,customstylecode);
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
            return plship.updatePackListShipScanOut(cartonbarcode, customstylecode);
        }
        #endregion


        #region  更新外箱掃描回復  updatePackListShipScanInBACK(string cartonbarcode, string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public int updatePackListShipScanInBACK(string cartonbarcode, string customstylecode)
        {
            return plship.updatePackListShipScanInBACK(cartonbarcode, customstylecode);
        }
        #endregion











    }



}
