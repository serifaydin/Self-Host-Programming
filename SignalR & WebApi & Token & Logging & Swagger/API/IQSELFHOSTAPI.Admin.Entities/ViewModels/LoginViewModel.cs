using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Admin.Entities.ViewModels
{
    public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
        public int AppID { get; set; }
        public int CompanyID { get; set; }
    }
}
