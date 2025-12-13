using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDbProject.Models
{
    public class Prenotazione
    {
        [Key]
        public Guid PrenotazioneId { get; set; }
        [Required]
        public Guid ClienteId { get; set; }
        [Required]
        public Guid CameraId { get; set; }
        [Required]
        public DateTime DataInizio { get; set; }
        [Required]
        public DateTime DataFine { get; set; }
        [Required]
        public string StatoPrenotazione { get; set; }
        // Navigation properties
        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }
        [ForeignKey(nameof(CameraId))]
        public Camera Camera { get; set; }
    }
}
