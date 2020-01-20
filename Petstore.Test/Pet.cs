using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Petstore.Test
{
    [TestClass]
    public class Pet
    {
        [TestMethod]
        public void findByStatus()
        {
            Petstore.BL.PetBL petBL = new BL.PetBL();

            var list = petBL.findByStatus("https://petstore.swagger.io/v2/pet/findByStatus?status=available");

            Assert.IsTrue(list.Count > 10);
        }

        [TestMethod]
        public void findById()
        {
            Petstore.BL.PetBL petBL = new BL.PetBL();

            var petET = petBL.findById("https://petstore.swagger.io/v2/pet/9216678377732835059");

            Assert.AreEqual(9216678377732835059, petET.id);
        }
    }
}
