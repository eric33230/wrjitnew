using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// T_PackList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_PackList
    {
        public T_PackList()
        { }
        #region Model
        private Guid _guid;
        private string _customname;
        private string _goodstypeenname;
        private string _customstylename;
        private string _customstylecode;
        private string _sizename;
        private string _totalcount;
        private string _cutno;
        private string _manufactureorder;
        private string _custompo;
        private string _colorgroupname;
        private string _boxsize;
        private string _boxnototal;
        private string _percount;
        private string _percounttotal;
        private decimal? _nw;
        private decimal? _tnw;
        private decimal? _gw;
        private decimal? _tgw;
        private string _boxvolume;
        private string _mt;
        private string _boxtono;
        private int? _boxno;
        private int? _totsumcount;
        private int? _boxsumcount;
        private string _orderdate;

        /// <summary>
        /// 
        /// </summary>
        public Guid guid
        {
            set { _guid = value; }
            get { return _guid; }
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
        public string GoodsTypeEnName
        {
            set { _goodstypeenname = value; }
            get { return _goodstypeenname; }
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
        public string SizeName
        {
            set { _sizename = value; }
            get { return _sizename; }
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
        public string CutNo
        {
            set { _cutno = value; }
            get { return _cutno; }
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
        public string CustomPO
        {
            set { _custompo = value; }
            get { return _custompo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColorGroupName
        {
            set { _colorgroupname = value; }
            get { return _colorgroupname; }
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
        public string perCountTotal
        {
            set { _percounttotal = value; }
            get { return _percounttotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NW
        {
            set { _nw = value; }
            get { return _nw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TNW
        {
            set { _tnw = value; }
            get { return _tnw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GW
        {
            set { _gw = value; }
            get { return _gw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TGW
        {
            set { _tgw = value; }
            get { return _tgw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BoxVolume
        {
            set { _boxvolume = value; }
            get { return _boxvolume; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MT
        {
            set { _mt = value; }
            get { return _mt; }
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
        public int? BOXNO
        {
            set { _boxno = value; }
            get { return _boxno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Totsumcount
        {
            set { _totsumcount = value; }
            get { return _totsumcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Boxsumcount
        {
            set { _boxsumcount = value; }
            get { return _boxsumcount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }













        #endregion Model

    }












}


