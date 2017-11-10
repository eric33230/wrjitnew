using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// doc_Buyer:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doc_Buyer
    {
        public doc_Buyer()
        { }
        #region Model
        private Guid _guid;
        private string _customname;
        private string _custombuyowner;
        private string _custombuyname;
        private string _forwarder;
        private string _type;
        private string _state;
        private string _country;
        private string _countrychinese;
        private string _destination;
        private string _cartonbarcodeneed;
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
        public string CustomName
        {
            set { _customname = value; }
            get { return _customname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomBuyOwner
        {
            set { _custombuyowner = value; }
            get { return _custombuyowner; }
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
        public string Forwarder
        {
            set { _forwarder = value; }
            get { return _forwarder; }
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
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }



        /// <summary>
        /// 
        /// </summary>
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryChinese
        {
            set { _countrychinese = value; }
            get { return _countrychinese; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Destination
        {
            set { _destination = value; }
            get { return _destination; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CartonBarcodeNeed
        {
            set { _cartonbarcodeneed = value; }
            get { return _cartonbarcodeneed; }
        }






        #endregion Model


    }

}