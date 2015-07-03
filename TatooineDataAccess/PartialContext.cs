using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatooineDataAccess
{
    public partial class TatooineCitizensRegistryEntities : DbContext
    {
        public TatooineCitizensRegistryEntities()
            : base("name=TatooineCitizensRegistryEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
    }
}
