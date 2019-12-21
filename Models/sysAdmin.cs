using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
   public class sysAdmin
    {
        public int? LoginId { get; set; }
        public string  AdminName { get; set; }
        public string  LoginPwd { get; set; }
    }
}
