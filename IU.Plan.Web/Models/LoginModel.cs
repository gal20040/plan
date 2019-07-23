using System.ComponentModel.DataAnnotations;

namespace IU.Plan.Web.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}