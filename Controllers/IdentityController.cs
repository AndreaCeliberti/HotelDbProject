using HotelDbProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelDbProject.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // effettuo il login

                    // verifico se esiste l'utente e lo carico
                    ApplicationUser user = await this._userManager.FindByNameAsync(loginRequest.Email); // l'email corrisponde all'username

                    if (user is not null)
                    {
                        // posso provare a fare il login
                        Microsoft.AspNetCore.Identity.SignInResult result = await this._signInManager.PasswordSignInAsync(
                            user,
                            loginRequest.Password,
                            isPersistent: false,
                            lockoutOnFailure: false

                            );
                        if (result.Succeeded)
                        {
                            // login ok
                            return RedirectToAction("Index", "Home");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return View("Login");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            string username = User.Identity.Name;
            return Content($"Ciao {username}, questa pagina è solo solo per Admin");
        }

        [Authorize(Roles = "User")]
        public IActionResult Index2()
        {

            string username = User.Identity.Name;
            return Content($"Ciao {username}, questa pagina è solo solo per User");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            // pagina di registrazione di un nuovo utente
            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(RegisterRequest registerRequest)
        {
            try
            {
                // verifico la validità del modello
                if (ModelState.IsValid)
                {
                    // effettuo la registrazione
                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName = registerRequest.Email,
                        Email = registerRequest.Email,
                        Password = registerRequest.Password,
                        Id = Guid.NewGuid().ToString(),
                        
                    };
                    // aggiungo tramite il "service" UserManager l'utente al database
                    IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);
                    if (result.Succeeded)
                    {
                        // assegno un ruolo di default

                        // verifico se il ruolo esiste
                        var roleExist = await this._roleManager.RoleExistsAsync("User");


                        if (!roleExist)
                        {
                            // se non esiste lo creo
                            await this._roleManager.CreateAsync(new IdentityRole("User"));

                        }
                        // setto il ruolo all'utente appena creato
                        await this._userManager.AddToRoleAsync(user, "User");

                        return RedirectToAction("Login");

                    }
                }
            }
            catch (Exception ex)
            {
            }
            return View("Register");
        }
    }
}
