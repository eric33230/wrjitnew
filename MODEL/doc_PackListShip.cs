using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL

{
    /// <summary>
    /// doc_PackListShip:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doc_PackListShip
    {
        public doc_PackListShip()
        { }
        #region Model
        private Guid _guid;
        private string _style;
        private string _name;
        private string _color;
        private string _code;
        private string _customstylename;
        private string _customstylecode;
        private string _customname;
        private string _custombuyname;
        private string _aimarea;
        private string _orderdate;
        private DateTime? _shipmentdate;
        private string _custompo;
        private string _manufactureorder;
        private string _cutno;
        private int? _boxno;
        private string _cartonbarcode;
        private string _boxsize;
        private string _carno;
      //  private string _invoiceno;
        private int? _scanin;
        private int? _scanout;
        private  int? _qain;
        private int? _qaout;
        private string _cartonbarcodeneed;
        private string _shipout;
        private string _shipscantime;
        private decimal? _boxcbm;


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
        public string Style
        {
            set { _style = value; }
            get { return _style; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomStyleName
        {
            set { _customstylename = value; }
            get { return _customstylename; }
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
        public string CustomName
        {
            set { _customname = value; }
            get { return _customname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomBuyName
        {
            set { _custombuyname = value; }
            get { return _custombuyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AimArea
        {
            set { _aimarea = value; }
            get { return _aimarea; }
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
        public DateTime? ShipMentDate
        {
            set { _shipmentdate = value; }
            get { return _shipmentdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomPO
        {
            set { _custompo = value; }
            get { return _custompo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManufactureOrder
        {
            set { _manufactureorder = value; }
            get { return _manufactureorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CutNo
        {
            set { _cutno = value; }
            get { return _cutno; }
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
        public string CartonBarcode
        {
            set { _cartonbarcode = value; }
            get { return _cartonbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BoxSize
        {
            set { _boxsize = value; }
            get { return _boxsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CarNo
        {
            set { _carno = value; }
            get { return _carno; }
        }
        /// <summary>
        /// 
        /// </summary>
        //public string InvoiceNo
        //{
        //    set { InvoiceNo = value; }
        //    get { return InvoiceNo; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public int? ScanIn
        {
            set { _scanin = value; }
            get { return _scanin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ScanOut
        {
            set { _scanout = value; }
            get { return _scanout; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? QAIn
        {
            set { _qain = value; }
            get { return _qain; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? QAOut
        {
            set { _qaout = value; }
            get { return _qaout; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CartonBarcodeNeed
        {
            set { _cartonbarcodeneed = value; }
            get { return _cartonbarcodeneed; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ShipOut
        {
            set { _shipout = value; }
            get { return _shipout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShipScanTime
        {
            set { _shipscantime = value; }
            get { return _shipscantime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BoxCBM
        {
            set { _boxcbm = value; }
            get { return _boxcbm; }
        }








        #endregion Model








    }
}








