using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// doc_PackList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doc_PackList
    {
        public doc_PackList()
        { }
        #region Model
        private Guid _guid;
        private Guid _doc_orderguid;
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
        private string _ordercount;
        private Guid _t_packlistguid;
        private string _custompo;
        private string _manufactureorder;
        private string _cutno;
        private int? _boxno;
        private string _boxtono;
        private string _boxnototal;
        private string _percount;
        private string _cartonbarcode;
        private string _innerbarcode;
        private string _innerbarcode1;
        private string _cartonbarcodeneed;
        private string _sizename;
        private string _goodstypename;
        private string _sizeno;
        private string _type;
        private string _totalcount;
        private int? _barcodecount;
        private string _boxsize;
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
        public Guid doc_OrderGuid
        {
            set { _doc_orderguid = value; }
            get { return _doc_orderguid; }
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
        public string OrderCount
        {
            set { _ordercount = value; }
            get { return _ordercount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid T_PackListGuid
        {
            set { _t_packlistguid = value; }
            get { return _t_packlistguid; }
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
        public string BOXTONO
        {
            set { _boxtono = value; }
            get { return _boxtono; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BoxNoTotal
        {
            set { _boxnototal = value; }
            get { return _boxnototal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PerCount
        {
            set { _percount = value; }
            get { return _percount; }
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
        public string InnerBarcode
        {
            set { _innerbarcode = value; }
            get { return _innerbarcode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string InnerBarcode1
        {
            set { _innerbarcode1 = value; }
            get { return _innerbarcode1; }
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
        public string SizeName
        {
            set { _sizename = value; }
            get { return _sizename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsTypeName
        {
            set { _goodstypename = value; }
            get { return _goodstypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeNo
        {
            set { _sizeno = value; }
            get { return _sizeno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TotalCount
        {
            set { _totalcount = value; }
            get { return _totalcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BarcodeCount
        {
            set { _barcodecount = value; }
            get { return _barcodecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BoxSize
        {
            set { _boxsize = value; }
            get { return _boxsize; }
        }
        #endregion Model

    }
}




