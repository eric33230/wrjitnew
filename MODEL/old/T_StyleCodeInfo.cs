using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MODEL
{
    /// <summary>
    /// T_StyleCodeInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_StyleCodeInfo
    {
        public T_StyleCodeInfo()
        { }
        #region Model
        private Guid _guid;
        private string _osmdoctreeid;
        private string _doctreeid;
        private DateTime? _deliverdate;
        private string _doccode;
        private string _orderdate;
        private string _sessiontype;
        private string _ccount;
        private string _totalcount;
        private string _exportprice;
        private string _monetaryunit;
        private string _monetaryunitname;
        private string _factoryid;
        private string _factoryname;
        private string _warehouseid;
        private string _warehouse;
        private string _customstylecode;
        private string _cutno;
        private string _customid;
        private string _customname;
        private string _custombuyer;
        private string _custombuyname;
        private string _styleid;
        private string _code;
        private string _name;
        private string _singleturn;
        private string _custompo;
        private string _manufactureorder;
        private string _stylenumber;
        private string _colorid;
        private string _colorname;
        private string _editionhandle;
        private string _modelno;
        private string _cuttingno;
        private string _rbcode;
        private string _rbcolor;
        private string _mdcode;
        private string _mdcolor;
        private string _ddlcode;
        private string _ddwcode;
        private string _ddqcode;
        private string _ddhcode;
        private string _ddscode;
        private string _aocode;
        private string _towcode;
        private DateTime? _shipmentdate;
        private string _exportarea;
        private string _shiptype;
        private string _shiptypename;
        private string _memo;
        private string _customclothbrand;
        private string _logocode;
        private string _logoname;
        private string _orderdoctype;
        private string _orderdoctypename;
        private string _designtypeid;
        private string _designtypename;
        private string _goodstype;
        private string _goodstypename;
        private string _id;
        private string _styleno;
        private string _priceitem;
        private string _priceitemname;
        private string _balancetype;
        private string _balancetypename;
        private string _countryname;
        private string _countrynum;
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
        public string osmDocTreeID
        {
            set { _osmdoctreeid = value; }
            get { return _osmdoctreeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DocTreeID
        {
            set { _doctreeid = value; }
            get { return _doctreeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeliverDate
        {
            set { _deliverdate = value; }
            get { return _deliverdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doccode
        {
            set { _doccode = value; }
            get { return _doccode; }
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
        public string SessionType
        {
            set { _sessiontype = value; }
            get { return _sessiontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCount
        {
            set { _ccount = value; }
            get { return _ccount; }
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
        public string ExportPrice
        {
            set { _exportprice = value; }
            get { return _exportprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MonetaryUnit
        {
            set { _monetaryunit = value; }
            get { return _monetaryunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MonetaryUnitname
        {
            set { _monetaryunitname = value; }
            get { return _monetaryunitname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FactoryID
        {
            set { _factoryid = value; }
            get { return _factoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FactoryName
        {
            set { _factoryname = value; }
            get { return _factoryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WarehouseID
        {
            set { _warehouseid = value; }
            get { return _warehouseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Warehouse
        {
            set { _warehouse = value; }
            get { return _warehouse; }
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
        public string CutNo
        {
            set { _cutno = value; }
            get { return _cutno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomID
        {
            set { _customid = value; }
            get { return _customid; }
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
        public string CustomBuyer
        {
            set { _custombuyer = value; }
            get { return _custombuyer; }
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
        public string StyleID
        {
            set { _styleid = value; }
            get { return _styleid; }
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SingleTurn
        {
            set { _singleturn = value; }
            get { return _singleturn; }
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
        public string StyleNumber
        {
            set { _stylenumber = value; }
            get { return _stylenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColorID
        {
            set { _colorid = value; }
            get { return _colorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColorName
        {
            set { _colorname = value; }
            get { return _colorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Editionhandle
        {
            set { _editionhandle = value; }
            get { return _editionhandle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModelNo
        {
            set { _modelno = value; }
            get { return _modelno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CuttingNo
        {
            set { _cuttingno = value; }
            get { return _cuttingno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RBcode
        {
            set { _rbcode = value; }
            get { return _rbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RBcolor
        {
            set { _rbcolor = value; }
            get { return _rbcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MDcode
        {
            set { _mdcode = value; }
            get { return _mdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MDcolor
        {
            set { _mdcolor = value; }
            get { return _mdcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddlcode
        {
            set { _ddlcode = value; }
            get { return _ddlcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddwcode
        {
            set { _ddwcode = value; }
            get { return _ddwcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddqcode
        {
            set { _ddqcode = value; }
            get { return _ddqcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddhcode
        {
            set { _ddhcode = value; }
            get { return _ddhcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddscode
        {
            set { _ddscode = value; }
            get { return _ddscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aocode
        {
            set { _aocode = value; }
            get { return _aocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string towcode
        {
            set { _towcode = value; }
            get { return _towcode; }
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
        public string ExportArea
        {
            set { _exportarea = value; }
            get { return _exportarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShipType
        {
            set { _shiptype = value; }
            get { return _shiptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShipTypeName
        {
            set { _shiptypename = value; }
            get { return _shiptypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomClothBrand
        {
            set { _customclothbrand = value; }
            get { return _customclothbrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logocode
        {
            set { _logocode = value; }
            get { return _logocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logoname
        {
            set { _logoname = value; }
            get { return _logoname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderDocType
        {
            set { _orderdoctype = value; }
            get { return _orderdoctype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderDocTypeName
        {
            set { _orderdoctypename = value; }
            get { return _orderdoctypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DesignTypeID
        {
            set { _designtypeid = value; }
            get { return _designtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DesignTypeName
        {
            set { _designtypename = value; }
            get { return _designtypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsType
        {
            set { _goodstype = value; }
            get { return _goodstype; }
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
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StyleNo
        {
            set { _styleno = value; }
            get { return _styleno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PriceItem
        {
            set { _priceitem = value; }
            get { return _priceitem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PriceItemName
        {
            set { _priceitemname = value; }
            get { return _priceitemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BalanceType
        {
            set { _balancetype = value; }
            get { return _balancetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BalanceTypeName
        {
            set { _balancetypename = value; }
            get { return _balancetypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryName
        {
            set { _countryname = value; }
            get { return _countryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryNum
        {
            set { _countrynum = value; }
            get { return _countrynum; }
        }
        #endregion Model

    }
}

