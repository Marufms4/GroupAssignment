using System.ComponentModel.DataAnnotations;

namespace Assignment1.ViewModels
{
    public class LoginViewModel
    {
        //[EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
