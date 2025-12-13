using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDbProject.Models
{
    public class Camera
    {
        [Key]
        public Guid CameraId { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Prezzo { get; set; }
        [InverseProperty(nameof(Prenotazione.Camera))]
        public List<Prenotazione> Prenotazioni { get; set; }


    }
}
