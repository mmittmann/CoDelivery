using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Api.Tests.DropBoxClient
{
    [TestClass]
    public class DropBoxClientTest
    {
        private Core.Infra.Clients.DropBoxClient _client;

        [TestInitialize]
        public void Init()
        {
            _client = new Core.Infra.Clients.DropBoxClient();

            try
            {
                _client.GetAccessToken();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [TestMethod]
        public void ShouldReturnAFile()
        {
            var file = _client.GetFile("/");

            Assert.IsNotNull(file);
        }

        [TestMethod]
        public void ShouldReturnPathContent()
        {
            _client.GetAccessToken();
            var result = _client.GetFolderContent("home/Apps/Mittmann");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldReturnPathContent2()
        {
            var result = _client.GetFolderContent("Chrysanthemum.jpg");

            Assert.IsNotNull(result);
        }
    }


}
