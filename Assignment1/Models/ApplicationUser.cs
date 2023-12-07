using Microsoft.AspNetCore.Identity;

namespace Assignment1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhotoPath { get; set; }

    }
}
