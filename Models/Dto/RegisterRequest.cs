using System.ComponentModel.DataAnnotations;

namespace HotelDbProject.Models.Dto
{
    public class RegisterRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
