using System;
using CoDelivery.Core.Infra.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoDelivery.IntegrationTests
{
    [TestClass]
    public class DropBoxIntegrationTest
    {
        private DropBoxClient _dropBoxClient;

        [TestInitialize]
        public void Init()
        {
            _dropBoxClient = new DropBoxClient("d2lskgojs7sboaor", "b774a8jxhikf7ri");
        }

        [TestMethod]
        public void ShouldGetAccessToken()
        {
            _dropBoxClient = new DropBoxClient();

            var url = _dropBoxClient.GetUrlToRequestToken();

            _dropBoxClient.GetAccessToken();
        }

        [TestMethod]
        public void ShouldListsAllFolders()
        {
            var contentFolder = _dropBoxClient.GetFolderContent("/");

            Assert.IsTrue(contentFolder.Count > 0);
        }
    }
}
