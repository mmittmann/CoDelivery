using System.Collections.Generic;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Core.Infra.IntegrationSystems
{
    public class GitHubIntegration : IIntegrationSystem
    {
        private readonly DropBoxClient _dropBoxClient;

        public GitHubIntegration(IReadOnlyDictionary<string, string> settings)
        {
            var secret = settings["apiSecret"];
            var accessToken = settings["accessToken"];
            _dropBoxClient = new DropBoxClient(secret, accessToken);
        }

        public List<string> GetFolders(string path)
        {
            return _dropBoxClient.GetFolderContent(path);
        }
    }
}
