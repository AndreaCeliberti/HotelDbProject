using System.ComponentModel.DataAnnotations;

namespace HotelDbProject.Models
{
    public class Cliente
    {
        [Key]
        public Guid ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefono { get; set; }

    }
}
