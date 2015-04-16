using System.Collections.Generic;
using CoDelivery.Core.Entities;

namespace CoDelivery.Core.Infra.IntegrationSystems
{
    public class IntegrationSystemFactory
    {
        public IIntegrationSystem Build(IntegrationSystem integrationSystem, Dictionary<string, string> config)
        {
            switch (integrationSystem)
            {
                case IntegrationSystem.DropBox:
                    return new DropBoxIntegration(config);
                case IntegrationSystem.Ftp:
                    return new FtpIntegration(config);
                case IntegrationSystem.GitHub:
                    return new GitHubIntegration(config);
                default: return null;
            }
        }
    }
}
