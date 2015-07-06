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
        [WebGet(RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
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
        [WebInvoke(UriTemplate = "Rebels/Add", Method = "POST", RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        bool RegisterRebels(string[] Rebels);

        [OperationContract]
        [WebGet(UriTemplate = "Status")]
        List<Statuses> GeStatus();

        [OperationContract]
        [WebGet(UriTemplate = "CitizensInRole/{id}")]
        List<Citizens> CitizensInRole(string Id);

    }
       
}
