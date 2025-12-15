


using HotelDbProject.Data;
using HotelDbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDbProject.Services
{
    public class ClienteService :ServiceBase
    {
   
        public ClienteService(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {

        }
        
        public async Task<List<Models.Cliente>> GetAllClientiAsync()
        {
            List<Models.Cliente> clienti = await _hotelDbContext.Clienti.ToListAsync();
            return clienti;
        }

        public async Task<bool> CreateClienteAsync(Models.Cliente cliente)
        {
            _hotelDbContext.Clienti.Add(cliente);
            return await _hotelDbContext.SaveAsync();
        }
        public async Task<Cliente?> GetClienteByIdAsync(Guid id)
        {
            return await _hotelDbContext.Clienti
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            _hotelDbContext.Clienti.Update(cliente);
            return await _hotelDbContext.SaveAsync();
        }

        public async Task<bool> DeleteClienteAsync(Guid id)
        {
            Cliente? cliente = await GetClienteByIdAsync(id);
            if (cliente == null) return false;

            _hotelDbContext.Clienti.Remove(cliente);
            return await _hotelDbContext.SaveAsync();
        }

    }
}
