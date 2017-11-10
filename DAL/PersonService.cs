using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Person类的数据访问层类，实现对Person表的增加，删除，修改，查询操作
    /// </summary>
    public class PersonService
    {
        public List<string> Login(string userName,string PLoginPWD)
        {
            string sql = "select * from T_role where loginname='"+ userName + "' and userpwd='"+ PLoginPWD + "'";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                List<string> username = new List<string>();
                username.Add(dt.Rows[0][0].ToString());
                username.Add(dt.Rows[0][2].ToString());
                return username;
            }
            return null; 
        }
       

        #region 将某一行数据转换为类的对象  - void GetPerson(DataRow dr, MODEL.Person model)
        /// <summary>
        /// 将某一行数据转换为类的对象
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="model"></param>
        public void GetPerson(DataRow dr, MODEL.Person model)
        {
            if (dr["PID"].ToString() != "")
            {
                model.PID = int.Parse(dr["PID"].ToString());
            }
            if (dr["PCID"].ToString() != "")
            {
                model.PCID = int.Parse(dr["PCID"].ToString());
            }
            model.PClaName = dr["PClaName"].ToString();
            if (dr["PType"].ToString() != "")
            {
                model.PType = int.Parse(dr["PType"].ToString());
            }
            model.PLoginName = dr["PLoginName"].ToString();
            model.PCName = dr["PCName"].ToString();
            model.PPYName = dr["PPYName"].ToString();
            model.PPwd = dr["PPwd"].ToString();
            if (dr["PGender"].ToString() != "")
            {
                model.PGender = bool.Parse(dr["PGender"].ToString());
            }
            model.PEmail = dr["PEmail"].ToString();
            model.PAreas = dr["PAreas"].ToString();
            if (dr["PIsDel"].ToString() != "")
            {
                model.PIsDel = bool.Parse(dr["PIsDel"].ToString());
            }
            if (dr["PAddTime"].ToString() != "")
            {
                model.PAddTime = DateTime.Parse(dr["PAddTime"].ToString());
            }
        } 
        #endregion

        #region 获取所有人员信息 + List<Person> GetAllPersonList(bool isDel)
        /// <summary>
        /// 获取所有人员信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<Person> GetAllPersonList(bool isDel)
        {
            string sql = "select * from person where pisdel=@isdel";
            SqlParameter p1 = new SqlParameter("@isdel", isDel);
            DataTable dt = SqlHelper.ExcuteTable(sql, p1);
            List<Person> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<Person>();
                foreach (DataRow row in dt.Rows)
                {
                    Person pp = new Person();
                    GetPerson(row, pp);
                    lists.Add(pp);
                }
            }
            return lists;
        } 
        #endregion

        #region 增加人员信息 - int AddPerson(MODEL.Person addPerson)
        /// <summary>
        /// 增加人员信息
        /// </summary>
        /// <param name="addPerson"></param>
        /// <returns></returns>
        public int AddPerson(MODEL.Person addPerson)
        {
            string sql = "";
            if (string.IsNullOrEmpty(addPerson.PAreas))
            {
                sql = "insert into person(pcid,pclaname,ptype,ploginname,pcname,ppyname,ppwd,pgender,pemail) values(@pcid,@pclaname,@ptype,@ploginname,@pcname,@ppyname,@ppwd,@pgender,@pemail)";
            }
            else
            {
                sql = "insert into person(pcid,pclaname,ptype,ploginname,pcname,ppyname,ppwd,pgender,pemail,pareas) values(@pcid,@pclaname,@ptype,@ploginname,@pcname,@ppyname,@ppwd,@pgender,@pemail,@pareas)";
            }
            SqlParameter[] ps = { 
                                new SqlParameter("pcid",addPerson.PCID),
                                new SqlParameter("pclaname",addPerson.PClaName),
                                new SqlParameter("ptype",addPerson.PType),
                                new SqlParameter("ploginname",addPerson.PLoginName),
                                new SqlParameter("pcname",addPerson.PCName),
                                new SqlParameter("ppyname",addPerson.PPYName),
                                new SqlParameter("ppwd",addPerson.PPwd),
                                new SqlParameter("pgender",addPerson.PGender),
                                new SqlParameter("pemail",addPerson.PEmail),
                                new SqlParameter("pareas",addPerson.PAreas)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        } 
        #endregion

        #region 并不是真正的删除，只是将状态修改为已经删除 -bool DeletePersonSoftly(int pid)
        /// <summary>
        /// 并不是真正的删除，只是将状态修改为已经删除
        /// </summary>
        public int DeletePersonSoftly(int pid)
        {
            string sql = "update person set pisdel=1 where pid=@pid";
            SqlParameter p = new SqlParameter("pid", pid);
            return SqlHelper.ExecuteNonQuery(sql, p);
        } 
        #endregion

        #region 修改人员信息  -int UpdatePerson(MODEL.Person addPerson)
        /// <summary>
        /// 修改人员信息
        /// </summary>
        /// <param name="addPerson"></param>
        /// <returns></returns>
        public int UpdatePerson(MODEL.Person addPerson)
        {
            string sql = "update person set pclaname=@pclaname,ptype=@ptype,ploginname=@ploginname,pcname=@pcname,ppyname=@ppyname,ppwd=@ppwd,pgender=@pgender,pemail=@pemail,pareas=@pareas where pid=@pid";
            SqlParameter[] ps = { 
                                new SqlParameter("pclaname",addPerson.PClaName),
                                new SqlParameter("ptype",addPerson.PType),
                                new SqlParameter("ploginname",addPerson.PLoginName),
                                new SqlParameter("pcname",addPerson.PCName),
                                new SqlParameter("ppyname",addPerson.PPYName),
                                new SqlParameter("ppwd",addPerson.PPwd),
                                new SqlParameter("pgender",addPerson.PGender),
                                new SqlParameter("pemail",addPerson.PEmail),
                                new SqlParameter("pareas",addPerson.PAreas),
                                new SqlParameter("pid",addPerson.PID)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        } 
        #endregion

        #region 查询用户  - List<MODEL.Person> SearchPersonList(bool isdel, Dictionary<string, string> dics)
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="isdel"></param>
        /// <param name="dics"></param>
        /// <returns></returns>
        public List<MODEL.Person> SearchPersonList(bool isdel, Dictionary<string, string> dics)
        {
            StringBuilder sql = new StringBuilder("select * from person where pisdel=@isdel");
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("@isdel", isdel));
            foreach (string key in dics.Keys)
            {
                switch (key)
                {
                    case "classId":
                        sql.Append(" and pcid=@pcid");
                        ps.Add(new SqlParameter("@pcid", dics[key]));
                        break;
                    case "stuName":
                        sql.Append(" and pcname like @pcname");
                        ps.Add(new SqlParameter("@pcname", "%" + dics[key] + "%"));
                        break;
                    case "typeId":
                        sql.Append(" and ptype = @typeId");
                        ps.Add(new SqlParameter("@typeId", dics[key]));
                        break;
                    case "startDate":
                        sql.Append(" and pAddTime between @startDate and @endDate");
                        ps.Add(new SqlParameter("@startDate", dics[key]));
                        ps.Add(new SqlParameter("@endDate", dics["endDate"]));
                        break;
                }
            }
            DataTable dt = SqlHelper.ExcuteTable(sql.ToString(), ps.ToArray());
            List<Person> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<Person>();
                foreach (DataRow row in dt.Rows)
                {
                    Person pp = new Person();
                    GetPerson(row, pp);
                    lists.Add(pp);
                }
            }
            return lists;
        } 
        #endregion

        #region 验证登录名是否已经存在  -int IsLoginNameExisits(string loginName)
        /// <summary>
        /// 验证登录名是否已经存在 
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public int IsLoginNameExisits(string loginName)
        {
            string sql = "select count(*) from person where ploginname=@name";
            SqlParameter p1 = new SqlParameter("name", loginName);
            return SqlHelper.ExcuteScalar<int>(sql, p1);
        } 
        #endregion
    }
}
