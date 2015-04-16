using System.ComponentModel.DataAnnotations;

namespace CoDelivery.Web.Models
{
    public class SignUpModel : UserModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}