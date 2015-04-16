using System.Collections.Generic;

namespace CoDelivery.Core.Infra.IntegrationSystems
{
    public interface IIntegrationSystem
    {
        List<string> GetFolders(string path);
    }
}
