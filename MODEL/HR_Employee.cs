using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MODEL
{
    /// <summary>
    /// HR_Employee:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class HR_Employee
    {
        public HR_Employee()
        { }
        #region Model
        private Guid _guid;
        private decimal? _aid;
        private int? _deptid;
        private string _empid;
        private string _title;
        private string _salary;
        private string _job;
        private float? _enrollno;
        private int? _accountno;
        private int? _nationalid;
        private int? _jobid;
        private int? _provinceid;
        private int? _x;
        private int? _y;
        private int? _shiftid;
        private byte[] _photo;
        private string _callname;
        private string _khname;

        private string _klname;
        private string _kname;
        private string _elname;
        private string _ename;


        private string _gender;
        private string _status;
        private string _personalid;
        private string _nssf;
        private string _education;
        private string _workbook;
        private string _cardno;
        private string _address;
        private bool? _ispermanent;
        private bool? _iscontract;
        private bool? _isresign;
        private bool? _paid;
        private bool? _prepaid;
        private string _resigntype;
        private string _resignreason;
        private DateTime?  _hiredate;

        private DateTime? _resigndate;
        private DateTime? _birthdate;
        private DateTime? _createdate;


        private int? _union1;
        private int? _union2;
        private int? _union3;
        private int? _union4;
        private int? _union5;
        private int? _union6;
        private int? _union7;
        private int? _union8;
        private int? _union9;
        private int? _union10;
        private int? _union11;
        private int? _union12;
        private int? _isdel;
        private DateTime? _keepfrom;
        private DateTime? _backwork;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? KeepFrom
        {
            set { _keepfrom = value; }
            get { return _keepfrom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BackWork
        {
            set { _backwork = value; }
            get { return _backwork; }
        }










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
        public decimal? AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DeptID
        {
            set { _deptid = value; }
            get { return _deptid; }
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Salary
        {
            set { _salary = value; }
            get { return _salary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Job
        {
            set { _job = value; }
            get { return _job; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float? EnrollNo
        {
            set { _enrollno = value; }
            get { return _enrollno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Accountno
        {
            set { _accountno = value; }
            get { return _accountno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? NationalID
        {
            set { _nationalid = value; }
            get { return _nationalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? JobID
        {
            set { _jobid = value; }
            get { return _jobid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? X
        {
            set { _x = value; }
            get { return _x; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Y
        {
            set { _y = value; }
            get { return _y; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ShiftID
        {
            set { _shiftid = value; }
            get { return _shiftid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Photo
        {
            set { _photo = value; }
            get { return _photo; }
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
        public string KLName
        {
            set { _klname = value; }
            get { return _klname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KName
        {
            set { _kname = value; }
            get { return _kname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ELName
        {
            set { _elname = value; }
            get { return _elname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EName
        {
            set { _ename = value; }
            get { return _ename; }
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
        public string PersonalID
        {
            set { _personalid = value; }
            get { return _personalid; }
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
        public string Education
        {
            set { _education = value; }
            get { return _education; }
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
        public string CardNo
        {
            set { _cardno = value; }
            get { return _cardno; }
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
        public bool? IsPermanent
        {
            set { _ispermanent = value; }
            get { return _ispermanent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? IsContract
        {
            set { _iscontract = value; }
            get { return _iscontract; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? IsResign
        {
            set { _isresign = value; }
            get { return _isresign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? Paid
        {
            set { _paid = value; }
            get { return _paid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? PrePaid
        {
            set { _prepaid = value; }
            get { return _prepaid; }
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
        public string ResignReason
        {
            set { _resignreason = value; }
            get { return _resignreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? HireDate
        {
            set { _hiredate = value; }
            get { return _hiredate; }
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
        public DateTime? BirthDate
        {
            set { _birthdate = value; }
            get { return _birthdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union1
        {
            set { _union1 = value; }
            get { return _union1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union2
        {
            set { _union2 = value; }
            get { return _union2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union3
        {
            set { _union3 = value; }
            get { return _union3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union4
        {
            set { _union4 = value; }
            get { return _union4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union5
        {
            set { _union5 = value; }
            get { return _union5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union6
        {
            set { _union6 = value; }
            get { return _union6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union7
        {
            set { _union7 = value; }
            get { return _union7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union8
        {
            set { _union8 = value; }
            get { return _union8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union9
        {
            set { _union9 = value; }
            get { return _union9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union10
        {
            set { _union10 = value; }
            get { return _union10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union11
        {
            set { _union11 = value; }
            get { return _union11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Union12
        {
            set { _union12 = value; }
            get { return _union12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }





        #endregion Model

    }
}




