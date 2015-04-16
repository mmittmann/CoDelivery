using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoDelivery.Web.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        public Dictionary<int, string> IntegrationSettings { get; set; }
    }
}