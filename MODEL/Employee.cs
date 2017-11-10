using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// Employee:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Employee
    {
        public Employee()
        { }
        #region Model
        private int _accountno;
        private string _empid;
        private float _enrollno;
        private string _callname;
        private string _khname;
        private DateTime _hiredate;
        private int _deptid;
        private int _jobid;
        private int _nationalid;
        private string _address;
        private int _provinceid;
        private string _gender;
        private string _status;
        private int _shiftid;
        private DateTime? _birthdate;
        private string _nssf;
        private string _workbook;
        private string _education;
        private int _union1;
        private int _union2;
        private int _union3;
        private bool _iscontract;
        private string _cardno;
        private string _personalid;
        private bool _ispermanent;
        private string _resigntype;
        private DateTime? _resigndate;
        private string _resignreason;
        private bool _isresign = false;
        private string _pic;
        private int _union4;
        private int _union5;
        private int _union6;
        private int _union7;
        private int _union8;
        private int _union9;
        private int _union10;
        private int _union11;
        private int _union12;
        private DateTime? _createdate ;
        /// <summary>
        /// 
        /// </summary>
        public int Accountno
        {
            set { _accountno = value; }
            get { return _accountno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmpID
        {
            set { _empid = value; }
            get { return _empid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float EnrollNo
        {
            set { _enrollno = value; }
            get { return _enrollno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CallName
        {
            set { _callname = value; }
            get { return _callname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KhName
        {
            set { _khname = value; }
            get { return _khname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime HireDate
        {
            set { _hiredate = value; }
            get { return _hiredate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeptID
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int JobID
        {
            set { _jobid = value; }
            get { return _jobid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NationalID
        {
            set { _nationalid = value; }
            get { return _nationalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ShiftID
        {
            set { _shiftid = value; }
            get { return _shiftid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BirthDate
        {
            set { _birthdate = value; }
            get { return _birthdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NSSF
        {
            set { _nssf = value; }
            get { return _nssf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkBook
        {
            set { _workbook = value; }
            get { return _workbook; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union1
        {
            set { _union1 = value; }
            get { return _union1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union2
        {
            set { _union2 = value; }
            get { return _union2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union3
        {
            set { _union3 = value; }
            get { return _union3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsContract
        {
            set { _iscontract = value; }
            get { return _iscontract; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardNo
        {
            set { _cardno = value; }
            get { return _cardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonalID
        {
            set { _personalid = value; }
            get { return _personalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPermanent
        {
            set { _ispermanent = value; }
            get { return _ispermanent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResignType
        {
            set { _resigntype = value; }
            get { return _resigntype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ResignDate
        {
            set { _resigndate = value; }
            get { return _resigndate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResignReason
        {
            set { _resignreason = value; }
            get { return _resignreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsResign
        {
            set { _isresign = value; }
            get { return _isresign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union4
        {
            set { _union4 = value; }
            get { return _union4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union5
        {
            set { _union5 = value; }
            get { return _union5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union6
        {
            set { _union6 = value; }
            get { return _union6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union7
        {
            set { _union7 = value; }
            get { return _union7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union8
        {
            set { _union8 = value; }
            get { return _union8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union9
        {
            set { _union9 = value; }
            get { return _union9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union10
        {
            set { _union10 = value; }
            get { return _union10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union11
        {
            set { _union11 = value; }
            get { return _union11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Union12
        {
            set { _union12 = value; }
            get { return _union12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}

