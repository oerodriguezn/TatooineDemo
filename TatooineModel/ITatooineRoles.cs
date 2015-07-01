using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TatooineModel;

namespace TatooineServices
{

    [ServiceContract]
    public interface ITatooineRoles
    {
        [OperationContract]
        [WebGet(UriTemplate = "Roles")]
        List<Roles> GetRoles();

        [OperationContract]
        [WebGet(UriTemplate = "Roles/{id}")]
        Roles GetRol(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "Roles/Add", Method = "POST")]
        int AddRole(Roles Rol);

        [OperationContract]
        [WebInvoke(UriTemplate = "Roles/Update", Method = "POST")]
        bool UpdateRole(Roles Rol);

        [OperationContract]
        [WebInvoke(UriTemplate = "Roles/Delete/{id}", Method = "DELETE")]
        bool DeleteRole(string Id);
    }
}
