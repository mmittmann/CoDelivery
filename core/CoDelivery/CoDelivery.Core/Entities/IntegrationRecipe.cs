using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CoDelivery.Core.Entities
{
    public class IntegrationRecipe
    {
        public int Id { get; set; }
        public Integration Integration { get; set; }
        public Recipe Recipe { get; set; }
        
        [NotMapped]
        public Dictionary<string, string> Configurations { get; set; }

        public string ConfigurationsJson
        {
            get { return JsonConvert.SerializeObject(Configurations); }
            set { Configurations = JsonConvert.DeserializeObject<Dictionary<string, string>>(value); }
        }

    }
}
