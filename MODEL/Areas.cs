using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    /// <summary>
    /// 地区类
    /// </summary>
    public class Areas
    {
        public Areas()
        { }

        #region 字段们
        protected int _aID;
        protected string _aName;
        protected int _aPid;
        protected int _aSort;
        protected DateTime _aAddTime;
        protected bool _aDelFlag;
        #endregion

        #region 属性们
        /// <summary>
        ///  
        /// </summary>
        public int AID
        {
            set { _aID = value; }
            get { return _aID; }
        }

        /// <summary>
        ///  
        /// </summary>
        public string AName
        {
            set { _aName = value; }
            get { return _aName; }
        }

        /// <summary>
        ///  父级节点ID(-1为顶级节点)
        /// </summary>
        public int APid
        {
            set { _aPid = value; }
            get { return _aPid; }
        }

        /// <summary>
        ///  
        /// </summary>
        public int ASort
        {
            set { _aSort = value; }
            get { return _aSort; }
        }

        /// <summary>
        ///  
        /// </summary>
        public DateTime AAddTime
        {
            set { _aAddTime = value; }
            get { return _aAddTime; }
        }

        /// <summary>
        ///  
        /// </summary>
        public bool ADelFlag
        {
            set { _aDelFlag = value; }
            get { return _aDelFlag; }
        }
        #endregion
    }
}
