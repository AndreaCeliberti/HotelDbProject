using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelDbProject.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string Password { get; internal set; }
    }
}
