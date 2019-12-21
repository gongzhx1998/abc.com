using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Web;

namespace BLL
{
   public class sysAdminManager
    {
        sysAdminService sysAdminService = new sysAdminService();
        public string AdminLogin(sysAdmin objadmin)
        {
            objadmin = sysAdminService.AdminLogin(objadmin);
            if (objadmin != null)
            {
                HttpContext.Current.Session["CurrentAdmin"] = objadmin;
                return objadmin.AdminName;
            }
            return null;
        }
        public Boolean Register(sysAdmin objAdmin)
        {
            return sysAdminService.Register(objAdmin);
        }
    }
}
