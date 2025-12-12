using HotelDbProject.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelDbProject.Services
{
    public class CameraService : ServiceBase
    {
        
        public CameraService(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {
        }
        
        public async Task<List<Models.Camera>> GetAllCamereAsync()
        {
            List<Models.Camera> camere = await _hotelDbContext.Camere.ToListAsync();
            return camere;
        }

        public async Task<bool> CreateCameraAsync(Models.Camera camera)
        {
            _hotelDbContext.Camere.Add(camera);
            return await _hotelDbContext.SaveAsync();
        }

    }
}
