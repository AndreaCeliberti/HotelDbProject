using System.ComponentModel.DataAnnotations;

namespace HotelDbProject.ViewModels
{
    public class ClienteCreateViewModel
    {
        public string Nome { get; set; }
        
        public string Cognome { get; set; }
        
        public string Email { get; set; }
        
        public string Telefono { get; set; }
    }
}
