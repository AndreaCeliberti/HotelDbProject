using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [InverseProperty(nameof(Prenotazione.Cliente))]
        public List<Prenotazione> Prenotazioni { get; set; }

    }
}
