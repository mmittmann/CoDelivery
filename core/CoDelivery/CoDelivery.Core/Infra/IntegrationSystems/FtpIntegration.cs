using System.Collections.Generic;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Core.Infra.IntegrationSystems
{
    public class FtpIntegration : IIntegrationSystem
    {
        private readonly FtpClient _ftpClient;

        public FtpIntegration(IReadOnlyDictionary<string, string> settings)
        {
            var user = settings["user"];
            var password = settings["password"];
            var host = settings["host"];
            var port = int.Parse(settings["port"]);
            _ftpClient = new FtpClient(host, user, password, port);
        }

        public List<string> GetFolders(string path)
        {
            
        }
    }
}
