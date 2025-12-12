


using HotelDbProject.Data;
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
    }
}
