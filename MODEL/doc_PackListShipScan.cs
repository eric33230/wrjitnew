using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{

    /// <summary>
    /// doc_PackListShipScan:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doc_PackListShipScan
    {
        public doc_PackListShipScan()
        { }
        #region Model
        private Guid _guid;
        private string _cartonbarcode;
        private string _orderdate;
        private string _customstylecode;
        private int? _boxno;
        private int? _scancount;
        private string _part;
        private string _qa;
        private string _wh;
        private DateTime? _scantime;
        private string _scanbatch;
        private int? _scanout;
        /// <summary>
        /// 
        /// </summary>
        public Guid Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CartonBarcode
        {
            set { _cartonbarcode = value; }
            get { return _cartonbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomStyleCode
        {
            set { _customstylecode = value; }
            get { return _customstylecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BOXNO
        {
            set { _boxno = value; }
            get { return _boxno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ScanCount
        {
            set { _scancount = value; }
            get { return _scancount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Part
        {
            set { _part = value; }
            get { return _part; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QA
        {
            set { _qa = value; }
            get { return _qa; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WH
        {
            set { _wh = value; }
            get { return _wh; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ScanTime
        {
            set { _scantime = value; }
            get { return _scantime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ScanBatch
        {
            set { _scanbatch = value; }
            get { return _scanbatch; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? ScanOut
        {
            set { _scanout = value; }
            get { return _scanout; }
        }





        #endregion Model

    }
}








