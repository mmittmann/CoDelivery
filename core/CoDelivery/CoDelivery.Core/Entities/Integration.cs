using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CoDelivery.Core.Infra.IntegrationSystems;
using Newtonsoft.Json;

namespace CoDelivery.Core.Entities
{
    public class Integration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual IntegrationSystem IntegrationSystem { get; set; }

        public virtual User User { get; set; }
        public virtual List<IntegrationRecipe> IntegrationRecipes{ get; set; }

        [NotMapped]
        public Dictionary<string, string> Settings { get; set; }

        public string SettingsJson
        {
            get { return JsonConvert.SerializeObject(Settings); }
            set { Settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(value); }
        }

        public List<string> GetFolders(IIntegrationSystem integrationSystem, string path)
        {
            return integrationSystem.GetFolders(path);
        }
    }
}