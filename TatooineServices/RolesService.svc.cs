using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TatooineDataAccess;
using TatooineModel;
using TatooineRepository;
using Utils;

namespace TatooineServices
{
   
    public class RolesService : ITatooineRoles
    {
         private readonly ITatooineRolesRepository repository =  null;

         public RolesService(ITatooineRolesRepository ConcreteRepository)
        {
            repository = ConcreteRepository;
        }

        public List<Roles> GetRoles()
        {
            try
            {
               return repository.GetRoles();
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
                return repository.GetRol(Id);
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
                return repository.AddRole(Rol);
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
                return repository.UpdateRole(Rol);
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
                return repository.DeleteRole(Id);
            }
            catch (Exception ex)
            {
                LogUtil.Log("DeleteRole", ex);
                throw new FaultException(ex.Message);
            }
        }
    }
}
