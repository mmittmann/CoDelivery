using CoDelivery.Core.Infra.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoDelivery.IntegrationTests
{
    [TestClass]
    public class FtpClientTest
    {
        FtpClient _ftpClient;

        [TestInitialize]
        public void Init()
        {
            const string user = "mittmann-me";
            const string pass = "m]9Uzo(a.>Ky_?Y";
            const string host = "mittmann-me.umbler.net";
            const int port = 990;


            _ftpClient = new FtpClient(host, user, pass, port);
        }

        [TestMethod]
        public void ShouldReturnMoreThanOneFolder()
        {
            var f = _ftpClient.GetFolders("/");

            Assert.IsTrue(f.Count > 0);
        }
    }
}
