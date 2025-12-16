using HotelDbProject.Data;
using HotelDbProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<HotelDbContext>()
.AddDefaultTokenProviders();

// Cookie (SOLO configurazione)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/AspNetUser/Login";
    options.AccessDeniedPath = "/AspNetUser/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

// Altri servizi
builder.Services.AddScoped<HotelDbProject.Services.ClienteService>();
builder.Services.AddScoped<HotelDbProject.Services.CameraService>();
builder.Services.AddScoped<HotelDbProject.Services.PrenotazioneService>();

// ===== BUILD =====
var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
