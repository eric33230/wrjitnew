using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RoleManager
    {
        RoleService rs = new RoleService();
        public DataTable getAllRole()
        {
            return rs.getAllRole();
        }
        public DataTable getRoleByRouid(string rouid)
        {
            return rs.getRoleByRouid(rouid);
        }
        public DataTable getMenuBylogoguid(string logoguid)
        {
            return rs.getMenuBylogoguid(logoguid);
        }
        public DataTable getMenuBymeuid(string meuid)
        {
            return rs.getMenuBymeuid(meuid);
        }
        public DataTable getMenuByNomeuid(string meuid)
        {
            return rs.getMenuByNomeuid(meuid);
        }
        public void addPermissionByMeuid(string rouid, string meuid)
        {
            rs.addPermissionByMeuid(rouid, meuid);
        }
        public void delPermissionByMeuid(string rouid, string meuid)
        {
            rs.delPermissionByMeuid(rouid, meuid);
        }
        public DataTable getPermissionByMeuid(string meuid)
        {
            return rs.getPermissionByMeuid(meuid);
        }

        public DataTable getAllMenus()
        {
            return rs.getAllMenus();
        }
        public DataTable getAllMenus(string guid)
        {
            return rs.getAllMenus(guid);
        }

        public T_menu[] getchmenu()
        {
            return rs.getchmenu();
        }
        public int adduser(Guid rouid, string sysname, string username,string userpwd)
        {
            return rs.adduser(rouid, sysname, username, userpwd);
        }
        public int addmune(Guid rouid, string fguid, string fmname, string muenameen, string muenamech, int orderno)
        {
            return rs.addmune(rouid, fguid, fmname, muenameen, muenamech, orderno);
        }

        public int upmune(string guid, string ename )
        {
            return rs.upmune(guid, ename);
        }
        public int delmune(string guid)
        {
            return rs.delmune(guid);
        }
        public int changNO(string eguid, int orderno)
        {
            return rs.changNO(eguid,orderno);
        }
        public DataTable getRoleBySysName(string sysname)
        {
            return rs.getRoleBySysName(sysname);
        }
        public DataTable getBySysName(string sysname)
        {
            return rs.getBySysName(sysname);
        }
        public T_menu getByfguid(string fguid)
        {
            return rs.getByfguid(fguid);
            
        }

    }

}
