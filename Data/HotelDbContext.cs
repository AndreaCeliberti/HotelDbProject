using HotelDbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDbProject.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Camera> Camere { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }

        internal async Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}   
