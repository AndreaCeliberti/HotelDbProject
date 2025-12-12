using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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


    }
}
