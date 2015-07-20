using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatooineRepository;

namespace TatooineDataAccess
{
    public class TatooineRolesRepositoryEF : ITatooineRolesRepository
    {
        public List<TatooineModel.Roles> GetRoles()
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                return db.Roles.ToList();
            }
        }

        public TatooineModel.Roles GetRol(string Id)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                int id = int.Parse(Id);
                return db.Roles.SingleOrDefault(p => p.Id == id);
            }
        }

        public int AddRole(TatooineModel.Roles Rol)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                db.Roles.Add(Rol);
                db.SaveChanges();
                return Rol.Id;
            }
        }

        public bool UpdateRole(TatooineModel.Roles Rol)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                var RolBD = db.Roles.SingleOrDefault(p => p.Id == Rol.Id);
                RolBD.RoleName = Rol.RoleName;
                RolBD.ParentId = Rol.ParentId;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteRole(string Id)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                int id = int.Parse(Id);
                var Rol = db.Roles.SingleOrDefault(p => p.Id == id);
                db.Roles.Remove(Rol);
                db.SaveChanges();
                return true;
            }
        }
    }
}
