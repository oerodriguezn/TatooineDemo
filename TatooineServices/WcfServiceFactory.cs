using Microsoft.Practices.Unity;
using TatooineDataAccess;
using TatooineRepository;
using Unity.Wcf;

namespace TatooineServices
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {

            container
               .RegisterType<ITatooineCitizens, TatooineCitizens>()
               .RegisterType<ITatooineRoles, RolesService>()
               .RegisterType<ITattoineCitizensRepository, TattoineCitizenReporitoryEF>(new HierarchicalLifetimeManager())
               .RegisterType<ITatooineRolesRepository, TatooineRolesRepositoryEF>(new HierarchicalLifetimeManager());
        }
    }    
}