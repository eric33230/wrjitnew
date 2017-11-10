using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MemuService
    {
        public DataTable InitMenuItem()
        {
            string sql = "select * from T_menu where fmuid = '0' ";
            //     SqlParameter p1 = new SqlParameter("rouid", rouid);
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;

        }
        public DataTable GetMenuByfm(String mname)
        {
            string sql = "select * from T_menu where fmname ='" + mname + "'";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
        public DataTable SetMenuItemByRole(string rouid)
        {
            string sql = "select * from T_menu where guid in" +
                      "(select meuid from T_rome where rouid='" + rouid + "') and fmuid= '0' ;";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }



        public DataTable SetSubMenuItemByRole(string mname, string RoleId)
        {
            string sql = @"select * from T_menu where fmname ='" + mname + @"'
                and guid in (select meuid from T_rome where rouid='" + RoleId + "')";

            DataTable dt = SqlHelper.ExcuteTable(sql);
            return dt;
        }
    }
}
