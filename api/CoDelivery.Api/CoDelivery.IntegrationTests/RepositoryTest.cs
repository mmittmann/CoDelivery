using System;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoDelivery.IntegrationTests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestSaveInDb()
        {
            var rep = new UserRepository(new CoDeliveryContext());

            rep.Save(new UserEntity()
            {
                Password = "123qwe123qwe",
                UserName = "Teste"
            });
        }
    }
}
