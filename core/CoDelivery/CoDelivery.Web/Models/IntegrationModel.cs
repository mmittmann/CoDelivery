using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoDelivery.Web.Models
{
    public class IntegrationModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public Dictionary<string, string> Configurations { get; set; }
    }
}