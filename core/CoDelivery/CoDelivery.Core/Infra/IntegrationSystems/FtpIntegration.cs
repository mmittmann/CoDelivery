using System.Collections.Generic;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Core.Infra.IntegrationSystems
{
    public class FtpIntegration : IIntegrationSystem
    {
        private readonly FtpClient _ftpClient;

        public FtpIntegration(IReadOnlyDictionary<string, string> settings)
        {
            var user = settings["User"];
            var password = settings["Password"];
            var host = settings["Host"];
            var port = int.Parse(settings["Port"]);
            _ftpClient = new FtpClient(host, user, password, port);
        }

        public List<string> GetFolders(string path)
        {
            return _ftpClient.GetFolders(path);
        }
    }
}
