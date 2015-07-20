using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using TatooineModel;
using TatooineRepository;

namespace TatooineServices.Tests
{
    [TestClass]
    public class TatooineCitizensFakeRepositoryTests
    {
      
        [TestMethod]
        public void TestGetCitizen()
        {
            var repository = new TatooineRepository.Fakes.StubITattoineCitizensRepository()
            {
                GetCitizenString = (citizen) => { return new Citizens(); }
            };
            ITatooineCitizens _Service = new TatooineCitizens(repository);
            var result = _Service.GetCitizen("1");
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetAllCitizens()
        {
            var repository = new TatooineRepository.Fakes.StubITattoineCitizensRepository()
            {
                GetAllCitizens= ()=> { 
                    List<Citizens> list = new List<Citizens>();
                    list.Add(new Citizens());
                    return list;
                    }
            };
            ITatooineCitizens _Service = new TatooineCitizens(repository);
            List<Citizens> citizens = _Service.GetAllCitizens();
            Assert.IsTrue(citizens.Count > 0);
        }
        [TestMethod]
        public void TestAddCitizen()
        {
           
            
            var repository = new TatooineRepository.Fakes.StubITattoineCitizensRepository()
            {
                AddCitizenCitizens = (Citizens) =>
                {
                    return 1;
                }
            };
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

            var repository = new TatooineRepository.Fakes.StubITattoineCitizensRepository()
            {
                UpdateCitizenCitizens = (Citizens) =>
                {
                    return true;
                }
            };
            ITatooineCitizens _Service = new TatooineCitizens(repository);

            Citizens cit = new Citizens();
            cit.Name = "Test";
            cit.IdStatus = 1;
            cit.Specie = "Test 2";
            Assert.IsTrue(_Service.UpdateCitizen(cit));
        }
         [TestMethod]
         public void TestDeleteCitizen()
         {
             var repository = new TatooineRepository.Fakes.StubITattoineCitizensRepository()
             {
                 DeleteCitizenString = (Citizens) =>
                 {
                     return true;
                 }
             };
             ITatooineCitizens _Service = new TatooineCitizens(repository);

             Citizens cit = new Citizens();
             cit.Id  = 1;

             Assert.IsTrue(_Service.DeleteCitizen(cit.Id.ToString()));
         }
    }
}
