using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MemuManager
    {
        MemuService ms = new MemuService();
        public DataTable InitMenuItem()
        {
            return ms.InitMenuItem();
        }
        public DataTable GetMenuByfm(String mname)
        {
            return ms.GetMenuByfm(mname);

        }
        public DataTable SetMenuItemByRole(string rouid)
        {
            return ms.SetMenuItemByRole(rouid);

        }

        public DataTable SetSubMenuItemByRole(string mname, string RoleId)
        {
            return ms.SetSubMenuItemByRole(mname, RoleId);

        }
    }
}
