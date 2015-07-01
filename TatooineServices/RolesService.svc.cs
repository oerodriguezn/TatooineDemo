using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TatooineDataAccess;
using TatooineModel;
using Utils;

namespace TatooineServices
{
   
    public class RolesService : ITatooineRoles
    {
        public List<Roles> GetRoles()
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    return db.Roles.ToList();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("GetRoles", ex);
                throw new FaultException(ex.Message);
            }
        }

        public Roles GetRol(string Id)
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    return db.Roles.SingleOrDefault(p => p.Id == int.Parse(Id));
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("GetRol", ex);
                throw new FaultException(ex.Message);
            }
        }

        public int AddRole(Roles Rol)
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    db.Roles.Add(Rol);
                    db.SaveChanges();
                    return Rol.Id;
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("AddRole", ex);
                throw new FaultException(ex.Message);
            }
        }

        public bool UpdateRole(Roles Rol)
        {
            try
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
            catch (Exception ex)
            {
                LogUtil.Log("UpdateRole", ex);
                throw new FaultException(ex.Message);
            }
        }

        public bool DeleteRole(string Id)
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    var Rol = db.Roles.SingleOrDefault(p => p.Id == int.Parse(Id));
                    db.Roles.Remove(Rol);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("DeleteRole", ex);
                throw new FaultException(ex.Message);
            }
        }
    }
}
