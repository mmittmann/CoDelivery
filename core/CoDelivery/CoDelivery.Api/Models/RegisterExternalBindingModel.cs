using System.ComponentModel.DataAnnotations;

namespace CoDelivery.Api.Models
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}