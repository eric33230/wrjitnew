using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// doc_OrderSize:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doc_OrderSize
    {
        public doc_OrderSize()
        { }
        #region Model
        private Guid _guid;
        private Guid _tsizeguid;
        private Guid _docorderguid;
        private string _customname;
        private string _customstylecode;
        private string _totalcount;
        private string _code;
        private string _name;
        private string _color;
        private string _orderdate;
        private string _size;
        private string _sizecount;
        private string _type;
        private string _innerbarcode;
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
        public Guid TsizeGuid
        {
            set { _tsizeguid = value; }
            get { return _tsizeguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid docOrderGuid
        {
            set { _docorderguid = value; }
            get { return _docorderguid; }
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
        public string CustomStyleCode
        {
            set { _customstylecode = value; }
            get { return _customstylecode; }
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
        public string Color
        {
            set { _color = value; }
            get { return _color; }
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
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeCount
        {
            set { _sizecount = value; }
            get { return _sizecount; }
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
        public string InnerBarcode
        {
            set { _innerbarcode = value; }
            get { return _innerbarcode; }
        }
        #endregion Model

    }
}












