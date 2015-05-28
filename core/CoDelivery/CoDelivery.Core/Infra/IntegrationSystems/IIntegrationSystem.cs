using System.Collections.Generic;

namespace CoDelivery.Core.Infra.IntegrationSystems
{
    public interface IIntegrationSystem
    {
        List<string> GetFolders(string path);
        IDictionary<string, byte[]> GetFiles(string path);
        void UploadFile(string fileName, string path, byte[] fileContent);
    }
}
