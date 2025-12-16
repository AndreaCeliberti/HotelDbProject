using System.ComponentModel.DataAnnotations;

namespace HotelDbProject.Models.Dto
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public required string Password { get; set; }
    }
}
