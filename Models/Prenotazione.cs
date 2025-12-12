using System.ComponentModel.DataAnnotations;

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
        public Cliente Cliente { get; set; }
        public Camera Camera { get; set; }
    }
}
