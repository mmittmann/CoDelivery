using System.ComponentModel.DataAnnotations;

namespace CoDelivery.Web.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}