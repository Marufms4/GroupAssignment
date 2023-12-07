using System.ComponentModel.DataAnnotations;

namespace Assignment1.ViewModels.Administrator
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();

        }

        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? MobileNumber { get; set; }

        public IFormFile? Photo { get; set; }
        public string? ExistingPhotoPath { get; set; }
        public List<string> Roles { get; set; }
    }
}
