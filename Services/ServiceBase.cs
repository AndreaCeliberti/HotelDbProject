using HotelDbProject.Data;

namespace HotelDbProject.Services
{
    public abstract class ServiceBase
    {
       
            protected readonly HotelDbContext _hotelDbContext;

            protected ServiceBase(HotelDbContext hotelDbContext)
            {
            _hotelDbContext = hotelDbContext;
            }

            protected async Task<bool> SaveAsync()
            {
                bool result = false;

                try
                {
                    result = await _hotelDbContext.SaveChangesAsync() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return result;
            }

        
    }
}
