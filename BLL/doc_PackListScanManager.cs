using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class doc_PackListScanManager
    {
        DAL.doc_PackListScanService plss = new DAL.doc_PackListScanService();
       

        #region 增加掃描訊息 -  int AddPackList(MODEL.doc_PackListScan packlistscan)
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddPackList(MODEL.doc_PackListScan packlistscan)
        {
            return  plss.AddPackList(packlistscan);
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
            return plss.GetPackListScan(cartonbarcode);
        }

        #endregion

        #region 获取掃描明細的訊息 - List<MODEL.doc_PackListScan> GetPackListScan(string cartonbarcode,int scanout)

        /// <summary>
        /// 获取該掃描明細的訊息 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListScan> GetPackListScan(string cartonbarcode,int scanout)
        {
            return plss.GetPackListScan(cartonbarcode,scanout);
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
            return plss.GetPackListScanInfo(customstylecode, cartonbarcode);
        }

        #endregion        


        public string GetErrorUserPWD()
        {
            return  plss.GetErrorUserPWD();
        }

        public int  UpdateErrorBox(string customstylecode, string cartonbarcode,string errorbarcode)
        {
            return plss.UpdateErrorBox( customstylecode,  cartonbarcode, errorbarcode);
        }
        public int UpdateErrorBox(string customstylecode, string cartonbarcode)
        {
            return plss.UpdateErrorBox(customstylecode, cartonbarcode);
        }


    }
}
