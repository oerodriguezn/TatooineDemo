using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatooineModel;

namespace TatooineRepository
{
    public interface ITatooineRolesRepository
    {
        List<Roles> GetRoles();
        Roles GetRol(string Id);

        int AddRole(Roles Rol);

        bool UpdateRole(Roles Rol);

        bool DeleteRole(string Id);
    }
}
