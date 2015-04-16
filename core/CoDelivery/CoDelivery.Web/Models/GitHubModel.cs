using System.ComponentModel.DataAnnotations;

namespace CoDelivery.Web.Models
{
    public class GitHubModel : IntegrationModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Chave SSH")]
        public string SshKey { get; set; }
    }
}