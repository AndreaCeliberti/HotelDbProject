using Microsoft.EntityFrameworkCore;

namespace HotelDbProject.Services
{
    public class PrenotazioneService
    {
        private readonly Data.HotelDbContext _context;
        public PrenotazioneService(Data.HotelDbContext context)
        {
            _context = context;
        }
        public async Task<List<Models.Prenotazione>> GetAllPrenotazioniAsync()
        {
            return await _context.Prenotazioni.ToListAsync();
        }
    }
}
