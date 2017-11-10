using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    

    public class doc_PackListShipScanManager
    {

     DAL.doc_PackListShipScanService plsss = new DAL.doc_PackListShipScanService();

        #region 增加成品外箱掃描訊息 - int AddPackListShipScan(MODEL.doc_PackListShipScan packlist)
        /// </summary>
        /// <param>""></param>
        /// <returns></returns>
        public int AddPackListShipScan(MODEL.doc_PackListShipScan packlist)
        {
            return plsss.AddPackListShipScan(packlist);
        }
        #endregion

        #region 获取入庫批號  -   List<MODEL.doc_PackListShipScan> GetScanBatch(string scanbatch,string  scanbatch1)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShipScan> GetScanBatch(string scanbatch,string  scanbatch1)
    {
            return plsss.GetScanBatch(scanbatch, scanbatch1);  
    }

        #endregion

        #region 获取外箱掃描入庫明細  -  List<MODEL.doc_PackListShipScan> GetPackListShipScan(string scanbatch)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_PackListShipScan> GetPackListShipScan(string scanbatch)
        {
            return plsss.GetPackListShipScan(scanbatch);
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

            return plsss.GetPackListShipScanBatch(scanbatch,scanbatch1);
        }

        #endregion

    }
}
