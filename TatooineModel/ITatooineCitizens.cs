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
    public interface ITatooineCitizens
    {

        [OperationContract]
        [WebGet(UriTemplate = "Citizens/{id}")]
        Citizens GetCitizen(string id);

        [OperationContract]
        [WebGet]
        List<Citizens> GetAllCitizens();

        [OperationContract]
        [WebInvoke(UriTemplate = "Citizens/Add", Method = "POST")]
        long AddCitizen(Citizens Citizen);

        [OperationContract]
        [WebInvoke(UriTemplate = "Citizens/Update", Method = "PUT")]
        bool UpdateCitizen(Citizens Citizen);

        [OperationContract]
        [WebInvoke(UriTemplate = "Citizens/Delete/{id}", Method = "DELETE")]
        bool DeleteCitizen(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "Rebels/Add", Method = "POST")]
        [MethodImpl(MethodImplOptions.Synchronized)]
        bool RegisterRebels(List<string> Rebels);

        [OperationContract]
        [WebGet(UriTemplate = "Status")]
        List<Statuses> GeStatus();

        [OperationContract]
        [WebGet(UriTemplate = "Roles")]
        List<Roles> GetRoles();

    }
       
}
