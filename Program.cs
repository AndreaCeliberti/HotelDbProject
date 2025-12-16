using HotelDbProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// configuro il db context per la DI
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//configuro l'identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option => {
option.SignIn.RequireConfirmedPhoneNumber = false;  // disabilito la conferma via telefono per rendere l'account attivo
option.SignIn.RequireConfirmedEmail = false; // disabilito la conferma via email per rendere l'account attivo
option.SignIn.RequireConfirmedAccount = false; // disabilito la conferma dell'account per il login
option.Password.RequiredLength = 8; // la password deve essere di almeno 8 caratteri
option.Password.RequireDigit = false; // non è obbligatorio un numero nella password
option.Password.RequireUppercase = true; // è obbligatoria una lettera maiuscola nella password
option.Password.RequireLowercase = true; // è obbligatoria una lettera minuscola nella password
option.Password.RequireNonAlphanumeric = false; // non è obbligatorio un carattere speciale nella password   
}).
AddEntityFrameworkStores<IdentityDbContext>(). // configuro l'identity per usare EF Core.
AddDefaultTokenProviders(); // aggiungo il provider per la generazione dei token.

// configuro per la DI user manager, signIn manager, role manager
builder.Services.AddScoped<UserManager<ApplicationUser>>(); // servizio per la gestioen degli utenti (fornito dal framework)
builder.Services.AddScoped<SignInManager<ApplicationUser>>(); // servizio per la gestione del login (fornito dal framework)
builder.Services.AddScoped<RoleManager<IdentityRole>>(); // servizio per la gestione dei ruoli (fornito dal framework)


// aggiunta alla DI l'autenticazione con cookie
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies");

// configurata l'autenticazione con i cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/AspNetUser/Login"; // pagina di login
    options.AccessDeniedPath = "/AspNetUser/AccessDenied"; // pagina di accesso negato
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // durata del cookie

    builder.Services.AddDbContext<HotelDbProject.Data.HotelDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'SchoolDbContext' not found.")));

    builder.Services.AddScoped<HotelDbProject.Services.ClienteService>();
    builder.Services.AddScoped<HotelDbProject.Services.CameraService>();
    builder.Services.AddScoped<HotelDbProject.Services.PrenotazioneService>();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
});
