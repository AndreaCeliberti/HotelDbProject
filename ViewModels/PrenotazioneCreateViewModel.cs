using System.ComponentModel.DataAnnotations;

namespace HotelDbProject.ViewModels
{
    public class PrenotazioneCreateViewModel
    {
        public Guid PrenotazioneId { get; set; }
        
        public Guid ClienteId { get; set; }
        
        public Guid CameraId { get; set; }
        
        public DateTime DataInizio { get; set; }
        
        public DateTime DataFine { get; set; }
        
        public string StatoPrenotazione { get; set; }
    }
}
