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
        public Guid Guid { set; get; } //guid
        public String osmDocTreeID { set; get; } //鞋型库订单号
        public String DocTreeID { set; get; } //正式订单ID 
        public DateTime? DeliverDate { set; get; } //接單日期        
        public String doccode { set; get; } //订单合同号  
        public String OrderDate { set; get; }//订单年月
        public String SessionType { set; get; } //季节号
        public String CCount { set; get; } //订单总双数
        public String TotalCount { set; get; } //SIZI总数
        public String ExportPrice { set; get; }//单价
        public String MonetaryUnit { set; get; } //币种ID
        public string MonetaryUnitname { set; get; }//币种
        public String FactoryID { set; get; } //生产工厂ID
        public string FactoryName { set; get; }//生产工厂
        public String WarehouseID { set; get; }//仓库ID
        public string Warehouse { set; get; }//承接仓库
        public String CustomStyleCode { set; get; }//指令号
        public String CutNo { set; get; } //ORDER NO/PO NO
        public String CustomID { set; get; } //客户ID
        public string CustomName { set; get; }//客户
        public String CustomBuyer { set; get; } //客户买主ID
        public string CustomBuyName { set; get; }//客户买主
        public String StyleID { set; get; } //鞋型ID
        public String Code { set; get; } //工厂型体+配色
        public String Name { set; get; } //客户型体
        public String SingleTurn { set; get; }//客戶訂單號
        public String CustomPO { set; get; }  //客戶訂單號
        public String ManufactureOrder { set; get; } //LOTNO
        public String StyleNumber { set; get; } //客戶鞋名
        public String ColorID { set; get; } //颜色ID
        public string ColorName { set; get; }//颜色
        public String Editionhandle { set; get; }//楦头编号        
        public String ModelNo { set; get; }//大底编号
        public String CuttingNo { set; get; }//后跟编号
        public String RBcode { set; get; } //RB模号
        public String RBcolor { set; get; } //RB颜色
        public String MDcode { set; get; } //MD模号
        public String MDcolor { set; get; } //MD颜色
        public String ddlcode { set; get; } //大底飾片(內腰)
        public String ddwcode { set; get; } //大底飾片(外腰)
        public String ddqcode { set; get; } //大底飾片(前掌)
        public String ddhcode { set; get; } //大底飾片(後跟) 
        public String ddscode { set; get; } //大底射出片  
        public String aocode { set; get; } //凹槽
        public String towcode { set; get; } //二次工艺
        public DateTime? ShipMentDate { set; get; } //客户交期
        public String ExportArea { set; get; } //出货地
        public String AimArea { set; get; } //目的地
        public String ShipType { set; get; }//运输方式
        public String ShipTypeName { set; get; } //运输方式
        public String Memo { set; get; } //交期備注

        public String CustomClothBrand { set; get; } //LOGO      
        public String logocode { set; get; } //LOGO编码
        public String logoname { set; get; } //LOGO名称
        public String OrderDocType { set; get; } //订单类型          
        public String OrderDocTypeName { set; get; } //订单类型   

        public String DesignTypeID { set; get; } //鞋款做法ID
        public String DesignTypeName { set; get; } //鞋款做法
        public String GoodsType { set; get; } //产品类型ID
        public String GoodsTypeName { set; get; } //产品类型GoodsTypeName
        public String ID { set; get; }
        public String StyleNo { set; get; }
        //   public String LogoLibrary { set; get; }

        public String PriceItem { set; get; }
        public String PriceItemName { set; get; }//交易条件
        public String BalanceType { set; get; }
        public String BalanceTypeName { set; get; }//付款方式

        //  public String IsNeedQuote { set; get; }        
        // public String IsSinglePrice { set; get; }
        //  public String IsSingleCostPrice { set; get; }
        //  public String IsSingleShowPrice { set; get; }
        public String CountryName { set; get; }
        public String CountryNum { set; get; }
        //  public String ActualCustomPerCount { set; get; } //


        ///// <summary>
        /////  新增的目的地
        ///// </summary>
        //public string AimArea
        //{
        //        set { _aimarea = value; }
        //        get { return _aimarea; }
        //    }


        //        /// <summary>
        //        /// 
        //        /// </summary>

        //        public string OsmDocTreeID
        //        {
        //            set { _osmdoctreeid = value; }
        //            get { return _osmdoctreeid; }
        //        }



        //        /// <summary>
        //        /// 
        //        /// </summary>
        /////        public int  stylecount
        // ///       {
        // ///           set { _stylecount = value; }
        //  ///          get { return _stylecount; }
        //    ///    }




        //        /// <summary>
        //        /// 
        //        /// </summary>
        //public Guid Guid
        //{
        //    set { _guid = value; }
        //    get { return _guid; }
        //}
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string osmDocTreeID
        //            {
        //                set { _osmdoctreeid = value; }
        //                get { return _osmdoctreeid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string DocTreeID
        //            {
        //                set { _doctreeid = value; }
        //                get { return _doctreeid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public DateTime? DeliverDate
        //            {
        //                set { _deliverdate = value; }
        //                get { return _deliverdate; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string doccode
        //            {
        //                set { _doccode = value; }
        //                get { return _doccode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string OrderDate
        //            {
        //                set { _orderdate = value; }
        //                get { return _orderdate; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string SessionType
        //            {
        //                set { _sessiontype = value; }
        //                get { return _sessiontype; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CCount
        //            {
        //                set { _ccount = value; }
        //                get { return _ccount; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string TotalCount
        //            {
        //                set { _totalcount = value; }
        //                get { return _totalcount; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ExportPrice
        //            {
        //                set { _exportprice = value; }
        //                get { return _exportprice; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string MonetaryUnit
        //            {
        //                set { _monetaryunit = value; }
        //                get { return _monetaryunit; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string MonetaryUnitname
        //            {
        //                set { _monetaryunitname = value; }
        //                get { return _monetaryunitname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string FactoryID
        //            {
        //                set { _factoryid = value; }
        //                get { return _factoryid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string FactoryName
        //            {
        //                set { _factoryname = value; }
        //                get { return _factoryname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string WarehouseID
        //            {
        //                set { _warehouseid = value; }
        //                get { return _warehouseid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string Warehouse
        //            {
        //                set { _warehouse = value; }
        //                get { return _warehouse; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CustomStyleCode
        //            {
        //                set { _customstylecode = value; }
        //                get { return _customstylecode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CutNo
        //            {
        //                set { _cutno = value; }
        //                get { return _cutno; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CustomID
        //            {
        //                set { _customid = value; }
        //                get { return _customid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CustomName
        //            {
        //                set { _customname = value; }
        //                get { return _customname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CustomBuyer
        //            {
        //                set { _custombuyer = value; }
        //                get { return _custombuyer; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CustomBuyName
        //            {
        //                set { _custombuyname = value; }
        //                get { return _custombuyname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string StyleID
        //            {
        //                set { _styleid = value; }
        //                get { return _styleid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string Code
        //            {
        //                set { _code = value; }
        //                get { return _code; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string Name
        //            {
        //                set { _name = value; }
        //                get { return _name; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string SingleTurn
        //            {
        //                set { _singleturn = value; }
        //                get { return _singleturn; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CustomPO
        //            {
        //                set { _custompo = value; }
        //                get { return _custompo; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ManufactureOrder
        //            {
        //                set { _manufactureorder = value; }
        //                get { return _manufactureorder; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string StyleNumber
        //            {
        //                set { _stylenumber = value; }
        //                get { return _stylenumber; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ColorID
        //            {
        //                set { _colorid = value; }
        //                get { return _colorid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ColorName
        //            {
        //                set { _colorname = value; }
        //                get { return _colorname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string Editionhandle
        //            {
        //                set { _editionhandle = value; }
        //                get { return _editionhandle; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ModelNo
        //            {
        //                set { _modelno = value; }
        //                get { return _modelno; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CuttingNo
        //            {
        //                set { _cuttingno = value; }
        //                get { return _cuttingno; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string RBcode
        //            {
        //                set { _rbcode = value; }
        //                get { return _rbcode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string RBcolor
        //            {
        //                set { _rbcolor = value; }
        //                get { return _rbcolor; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string MDcode
        //            {
        //                set { _mdcode = value; }
        //                get { return _mdcode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string MDcolor
        //            {
        //                set { _mdcolor = value; }
        //                get { return _mdcolor; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ddlcode
        //            {
        //                set { _ddlcode = value; }
        //                get { return _ddlcode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ddwcode
        //            {
        //                set { _ddwcode = value; }
        //                get { return _ddwcode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ddqcode
        //            {
        //                set { _ddqcode = value; }
        //                get { return _ddqcode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ddhcode
        //            {
        //                set { _ddhcode = value; }
        //                get { return _ddhcode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ddscode
        //            {
        //                set { _ddscode = value; }
        //                get { return _ddscode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string aocode
        //            {
        //                set { _aocode = value; }
        //                get { return _aocode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string towcode
        //            {
        //                set { _towcode = value; }
        //                get { return _towcode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public DateTime? ShipMentDate
        //            {
        //                set { _shipmentdate = value; }
        //                get { return _shipmentdate; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ExportArea
        //            {
        //                set { _exportarea = value; }
        //                get { return _exportarea; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ShipType
        //            {
        //                set { _shiptype = value; }
        //                get { return _shiptype; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ShipTypeName
        //            {
        //                set { _shiptypename = value; }
        //                get { return _shiptypename; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string Memo
        //            {
        //                set { _memo = value; }
        //                get { return _memo; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CustomClothBrand
        //            {
        //                set { _customclothbrand = value; }
        //                get { return _customclothbrand; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string logocode
        //            {
        //                set { _logocode = value; }
        //                get { return _logocode; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string logoname
        //            {
        //                set { _logoname = value; }
        //                get { return _logoname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string OrderDocType
        //            {
        //                set { _orderdoctype = value; }
        //                get { return _orderdoctype; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string OrderDocTypeName
        //            {
        //                set { _orderdoctypename = value; }
        //                get { return _orderdoctypename; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string DesignTypeID
        //            {
        //                set { _designtypeid = value; }
        //                get { return _designtypeid; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string DesignTypeName
        //            {
        //                set { _designtypename = value; }
        //                get { return _designtypename; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string GoodsType
        //            {
        //                set { _goodstype = value; }
        //                get { return _goodstype; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string GoodsTypeName
        //            {
        //                set { _goodstypename = value; }
        //                get { return _goodstypename; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string ID
        //            {
        //                set { _id = value; }
        //                get { return _id; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string StyleNo
        //            {
        //                set { _styleno = value; }
        //                get { return _styleno; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string PriceItem
        //            {
        //                set { _priceitem = value; }
        //                get { return _priceitem; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string PriceItemName
        //            {
        //                set { _priceitemname = value; }
        //                get { return _priceitemname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string BalanceType
        //            {
        //                set { _balancetype = value; }
        //                get { return _balancetype; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string BalanceTypeName
        //            {
        //                set { _balancetypename = value; }
        //                get { return _balancetypename; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CountryName
        //            {
        //                set { _countryname = value; }
        //                get { return _countryname; }
        //            }
        //            /// <summary>
        //            /// 
        //            /// </summary>
        //            public string CountryNum
        //            {
        //                set { _countrynum = value; }
        //                get { return _countrynum; }
        //            }
        //            #endregion Model

        //        }
    }
}

