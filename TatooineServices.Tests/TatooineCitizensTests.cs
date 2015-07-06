using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using TatooineModel;

namespace TatooineServices.Tests
{
    [TestClass]
    public class TatooineCitizensTests
    {
        [TestMethod]
        public void TestGetCitizen()
        {
            var test = new TatooineCitizens();
            List<Citizens> citizens = test.GetAllCitizens();
            var result = test.GetCitizen(citizens.First().Id.ToString());
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetAllCitizens()
        {
            var test = new TatooineCitizens();
            List<Citizens> citizens = test.GetAllCitizens();
            Assert.IsTrue(citizens.Count > 0);
        }
        [TestMethod]
        public void TestAddCitizen()
        {
            var test = new TatooineCitizens();
            Citizens cit = new Citizens();
            cit.Name = "Test";
            cit.IdStatus = 1;
            cit.Specie = "test";
            Assert.IsTrue(test.AddCitizen(cit) > 0);
        }
         [TestMethod]
        public void TestUpdateCitizen()
        {
            var test = new TatooineCitizens();
            List<Citizens> citizens = test.GetAllCitizens();
            var result = citizens.FirstOrDefault();
            result.Specie = "Test 2";
            Assert.IsTrue(test.UpdateCitizen(result));
        }
         [TestMethod]
         public void TestDeleteCitizen()
         {
             var test = new TatooineCitizens();
             List<Citizens> citizens = test.GetAllCitizens();
             var result = citizens.FirstOrDefault();
             Assert.IsTrue(test.DeleteCitizen(result.Id.ToString()));
         }
    }
}
