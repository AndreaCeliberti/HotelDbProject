using Microsoft.EntityFrameworkCore;

namespace HotelDbProject.Services
{
    public class CameraService
    {
        private readonly Data.HotelDbContext _context;
        public CameraService(Data.HotelDbContext context)
        {
            _context = context;
        }
        public async Task<List<Models.Camera>> GetAllCamereAsync()
        {
            return await _context.Camere.ToListAsync();
        }

    }
}
