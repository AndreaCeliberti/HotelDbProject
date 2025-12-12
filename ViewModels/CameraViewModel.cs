using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelDbProject.ViewModels
{
    public class CameraViewModel
    {
        public Guid CameraId { get; set; }
        
        public int Numero { get; set; }
        
        public string Tipo { get; set; }
        
        public decimal Prezzo { get; set; }
    }
}
