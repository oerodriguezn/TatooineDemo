using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using TatooineModel;
using TatooineRepository;
using Microsoft.Practices.Unity;
using TatooineDataAccess;

namespace TatooineServices.Tests
{
    [TestClass]
    public class TatooineCitizensUnityTests
    {
        private IUnityContainer unityContainer;
        private ITattoineCitizensRepository repository;
        [TestInitialize()]
        public void MyTestInitialize()
        {
            unityContainer = new UnityContainer();
            unityContainer
              .RegisterType<ITattoineCitizensRepository, TattoineCitizenReporitoryEF>(new HierarchicalLifetimeManager());
            repository = unityContainer.Resolve<ITattoineCitizensRepository>();
        }
        [TestMethod]
        public void TestGetCitizen()
        {
           
            ITatooineCitizens _Service = new TatooineCitizens(repository);
            var result = _Service.GetCitizen(repository.GetAllCitizens().FirstOrDefault().Id.ToString());
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetAllCitizens()
        {
           
            ITatooineCitizens _Service = new TatooineCitizens(repository);
            List<Citizens> citizens = _Service.GetAllCitizens();
            Assert.IsTrue(citizens.Count > 0);
        }
        [TestMethod]
        public void TestAddCitizen()
        {

            ITatooineCitizens _Service = new TatooineCitizens(repository);

            Citizens cit = new Citizens();
            cit.Name = "Test";
            cit.IdStatus = 1;
            cit.Specie = "test";
            Assert.IsTrue(_Service.AddCitizen(cit) > 0);
        }
         [TestMethod]
        public void TestUpdateCitizen()
        {
            ITatooineCitizens _Service = new TatooineCitizens(repository);
            Citizens cit = repository.GetAllCitizens().FirstOrDefault();
            cit.Name = "Test";
            cit.IdStatus = 1;
            cit.Specie = "Test 2";
            Assert.IsTrue(_Service.UpdateCitizen(cit));
        }
         [TestMethod]
         public void TestDeleteCitizen()
         {
             ITatooineCitizens _Service = new TatooineCitizens(repository);
             Citizens cit = repository.GetAllCitizens().LastOrDefault();
             Assert.IsTrue(_Service.DeleteCitizen(cit.Id.ToString()));
         }
    }
}
