using MODEL;
using System;
using System.Collections;
using System.Data;

namespace DAL
{
    public class RoleService
    {

        public DataTable getAllRole()
        {
            string sql = "select * from T_role";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public DataTable getRoleBySysName(string sysname)
        {
            string sql = "SELECT * FROM  T_role WHERE loginname ='" + sysname + "';";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public DataTable getBySysName(string sysname)
        {
            string sql = "SELECT * FROM  T_menu WHERE muenameen='" + sysname + "';";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
      //  ArrayList result = new ArrayList();
        public T_menu getByfguid(string fguid)
        {
            //string sql = "SELECT muenameen FROM  T_menu WHERE guid='" + fguid + "';";
            string sql = @"
                SELECT t1.muenameen,t2.countrows FROM  T_menu t1
LEFT JOIN  (
SELECT COUNT(muenameen) countrows, fmuid FROM T_menu  WHERE fmuid = '" + fguid + @"' GROUP BY fmuid
)  t2 ON t1.guid = t2.fmuid
WHERE guid = '" + fguid + @"';
                ";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            T_menu menu = new T_menu();
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
               
                // result.Add(dt.Rows[0]["muenameen"].ToString(), dt.Rows[0]["countrows"].ToString());
                menu.muenameen = dt.Rows[0]["muenameen"].ToString();
                menu.muenamech = dt.Rows[0]["countrows"].ToString();

            }
            return menu;

        }


        public T_role Torole(DataRow row)
        {
            T_role roles = new T_role();
            roles.guid = (Guid)SqlHelper.FromDbValue(row["guid"]);
            roles.loginname = (string)SqlHelper.FromDbValue(row["loginname"]);
            roles.username = (string)SqlHelper.FromDbValue(row["username"]);
            return roles;
        }

        public DataTable getRoleByRouid(string rouid)
        {

            string sql = "select * from T_role where guid= '" + rouid + "'";
            DataTable dt = SqlHelper.ExcuteTable(sql);

            return dt;
        }
        public DataTable getMenuBylogoguid(string logoguid)
        {

            string sql = "select * from t_rome  where rouid= '" + logoguid + "'";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public DataTable getMenuBymeuid(string meuid)
        {

            string sql = "select rouid from T_rome WHERE meuid='" + meuid + "' GROUP BY rouid";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public DataTable getMenuByNomeuid(string meuid)
        {

            string sql = @"	SELECT a.guid,loginname,username FROM T_role a
	RIGHT JOIN (
	select a.guid from T_role a
Except  select rouid from T_rome b WHERE meuid= '" + meuid + "')b ON a.guid=b.guid";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }

        public DataTable getAllMenus()
        {
            //string sql = "select * from T_menu WHERE fmuid='0' ORDER BY  orderno";
            string sql = "select * from T_menu ORDER BY  orderno";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public void addPermissionByMeuid(string rouid, string meuid)
        {
            string sql = @"INSERT dbo.T_rome
        (guid, rouid, meuid)
            VALUES(NEWID(),'" + rouid + "','" + meuid + "' )";
             SqlHelper.ExecuteNonQuery(sql);
            // return dt;
        }
        public void delPermissionByMeuid(string rouid, string meuid)
        {
            string sql = @"DELETE t_rome WHERE  
                           meuid ='" + meuid + @"'    
                           and rouid = '" + rouid + "'";
            SqlHelper.ExecuteNonQuery(sql);
            // return dt;
        }
        public DataTable getPermissionByMeuid(string meuid)
        {

            string sql = @"SELECT * FROM  T_rome WHERE  meuid= '" + meuid + "'";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public DataTable getAllMenus(string guid)
        {

            string sql = "select * from T_menu WHERE fmuid='" + guid + "' ORDER BY  orderno";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public T_menu Tomenu(DataRow row)
        {
            T_menu menus = new T_menu();
            menus.guid = (Guid)SqlHelper.FromDbValue(row["guid"]);
            menus.fmuid = (string)SqlHelper.FromDbValue(row["fmuid"]);
            menus.fmname = (string)SqlHelper.FromDbValue(row["fmname"]);
            menus.muenameen = (string)SqlHelper.FromDbValue(row["muenameen"]);
            menus.muenamech = (string)SqlHelper.FromDbValue(row["muenamech"]);
            return menus;
        }
        public T_menu[] getchmenu()
        {
            string sql = "select * from T_menu where fmuid <> '0'";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            T_menu[] menus = new T_menu[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    menus[i] = Tomenu(dt.Rows[i]);
                }
                return menus;
            }
            else
            {
                return null;
            }

        }
        public int adduser(Guid rouid, string sysname, string username,string userpwd)
        {
            string sql = @"INSERT T_role
        ( guid, loginname, username,userpwd )
VALUES  (  '" + rouid + @"',
          N'" + sysname + @"', 
          N'" + username + @"',
          N'"+userpwd+"');";
            // int count = cmd.ExecuteNonQuery();
            //  DataTable dt = SqlHelper.ExcuteTable(sql);
            int count = SqlHelper.ExecuteNonQuery(sql);
            return count;

        }

        public int addmune(Guid rouid, string fguid, string fmname, string muenameen, string muenamech, int orderno)
        {
            string sql = @"INSERT dbo.T_menu
		          ( guid ,
		            fmuid ,
		            fmname ,
		            muenameen ,
		            muenamech ,
		            orderno
		          )
		  VALUES  ( N'"+ rouid + @"', -- guid - uniqueidentifier
		            N'" + fguid + @"' , -- fmuid - nvarchar(50)
		            N'" + fmname + @"' , -- fmname - nvarchar(200)
		            N'" + muenameen + @"' , -- muenameen - nvarchar(200)
		            N'" + muenamech + @"' , -- muenamech - nvarchar(200)
		            "+ orderno + @"-- orderno - int
		          );";
            // int count = cmd.ExecuteNonQuery();
            //  DataTable dt = SqlHelper.ExcuteTable(sql);
            int count = SqlHelper.ExecuteNonQuery(sql);
            return count;

        }
        public int upmune(string guid, string ename)
        {
            string sql = @"UPDATE T_menu SET muenamech='" + ename + "' WHERE guid='" + guid + "';";
            int count = SqlHelper.ExecuteNonQuery(sql);
            return count;

        }
        public int delmune(string guid)
        {
            string sql = @"DELETE T_menu WHERE guid='" + guid + "';";
            int count = SqlHelper.ExecuteNonQuery(sql);
            return count;

        }
        public int changNO(string eguid, int orderno)
        {
            string sql = @"UPDATE  T_menu SET orderno="+ orderno + " WHERE guid='" + eguid + "';";
            int count = SqlHelper.ExecuteNonQuery(sql);
            return count;

        }
    }
}
