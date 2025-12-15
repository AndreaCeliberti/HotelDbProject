using HotelDbProject.Data;
using HotelDbProject.Models;
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
        public async Task<Prenotazione?> GetPrenotazioneByIdAsync(Guid id)
        {
            return await _hotelDbContext.Prenotazioni
                .FirstOrDefaultAsync(p => p.PrenotazioneId == id);
        }

        public async Task<bool> UpdatePrenotazioneAsync(Prenotazione prenotazione)
        {
            _hotelDbContext.Prenotazioni.Update(prenotazione);
            return await _hotelDbContext.SaveAsync();
        }

        public async Task<bool> DeletePrenotazioneAsync(Guid id)
        {
            Prenotazione? prenotazione = await GetPrenotazioneByIdAsync(id);
            if (prenotazione == null) return false;

            _hotelDbContext.Prenotazioni.Remove(prenotazione);
            return await _hotelDbContext.SaveAsync();
        }

    }
}
