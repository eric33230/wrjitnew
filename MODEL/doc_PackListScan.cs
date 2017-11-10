using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
	/// <summary>
	/// doc_PackListScan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class doc_PackListScan
	{
		public doc_PackListScan()
		{}
		#region Model
		private Guid _guid;
		private string _cartonbarcode;
		private string _innerbarcode;
		private DateTime? _scantime;
		private string _sizename;
		private string _customstylecode;
        private string _orderdate;
        private int? _scancount;
		private int? _scanno;
        private int? _scanout;

        private string _part;
		/// <summary>
		/// 
		/// </summary>
		public Guid Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CartonBarcode
		{
			set{ _cartonbarcode=value;}
			get{return _cartonbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InnerBarcode
		{
			set{ _innerbarcode=value;}
			get{return _innerbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ScanTime
		{
			set{ _scantime=value;}
			get{return _scantime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SizeName
		{
			set{ _sizename=value;}
			get{return _sizename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomStyleCode
		{
			set{ _customstylecode=value;}
			get{return _customstylecode;}
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
        public int? ScanCount
		{
			set{ _scancount=value;}
			get{return _scancount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ScanNO
		{
			set{ _scanno=value;}
			get{return _scanno;}
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
        public string Part
		{
			set{ _part=value;}
			get{return _part;}
		}
		#endregion Model

	}
}






