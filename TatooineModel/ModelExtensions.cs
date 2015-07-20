using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatooineModel
{
    public partial class Citizens
    {
        public string RoleName
        {
            get
            {
                return Roles!=null ? Roles.RoleName : "";
            }
        }
        public string StatusName
        {
            get
            {
                return Status != null ? Status.Status : "";
            }
        }
    }
}
