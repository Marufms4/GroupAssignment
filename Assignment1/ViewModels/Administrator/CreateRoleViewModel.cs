using System.ComponentModel.DataAnnotations;

namespace Assignment1.ViewModels.Administrator
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
