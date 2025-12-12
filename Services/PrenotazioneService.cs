using HotelDbProject.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelDbProject.Services
{
    public class PrenotazioneService : ServiceBase
    {
        
        public PrenotazioneService(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {
        }
       
        public async Task<List<Models.Prenotazione>> GetAllPrenotazioniAsync()
        {
            List<Models.Prenotazione> prenotazioni = await _hotelDbContext.Prenotazioni.ToListAsync();
            return prenotazioni;
        }

        public async Task<bool> CreatePrenotazioneAsync(Models.Prenotazione prenotazione)
        {
            _hotelDbContext.Prenotazioni.Add(prenotazione);
            return await _hotelDbContext.SaveAsync();
        }
    }
}
