using System.ComponentModel.DataAnnotations;

namespace CoDelivery.Web.Models
{
    public class FtpModel : IntegrationModel
    {
        [Required]
        [Display(Name = "Host")]
        public string Host { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Porta")]
        public string Port { get; set; }
    }
}