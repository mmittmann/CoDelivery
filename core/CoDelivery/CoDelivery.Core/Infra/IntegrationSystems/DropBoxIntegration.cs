using System.Collections.Generic;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Core.Infra.IntegrationSystems
{
    public class DropBoxIntegration : IIntegrationSystem
    {
        private readonly DropBoxClient _dropBoxClient;

        public DropBoxIntegration(IReadOnlyDictionary<string, string> settings)
        {
            var secret = settings["apiSecret"];
            var accessToken = settings["accessToken"];
            _dropBoxClient = new DropBoxClient(secret, accessToken);
        }

        public List<string> GetFolders(string path)
        {
            return _dropBoxClient.GetFolderList(path);
        }

        public IDictionary<string, byte[]> GetFiles(string path)
        {
            return _dropBoxClient.GetFiles(path);
        }

        public void UploadFile(string fileName, string path, byte[] fileContent)
        {
            _dropBoxClient.UploadFile(path, fileName, fileContent);
        }
    }
}
