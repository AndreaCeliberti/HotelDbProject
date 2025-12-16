using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelDbProject.Data
{
    // Assicurati che ApplicationUser erediti da IdentityUser
    public class IdentityDbContextIdentityDbContext<ApplicationUser> : IdentityDbContext<ApplicationUser>
        where ApplicationUser : IdentityUser
    {
        public DbSet<ApplicationUser> IdentityUser { get; set; }

        public IdentityDbContextIdentityDbContext(DbContextOptions<IdentityDbContextIdentityDbContext<ApplicationUser>> options)
            : base(options)
        {
        }
    }
}
