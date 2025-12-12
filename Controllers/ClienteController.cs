using HotelDbProject.Models;
using HotelDbProject.Services;
using HotelDbProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelDbProject.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public async Task<IActionResult> Index()
        {
            //var clienti = await _clienteService.GetAllClientiAsync();


            List<Cliente> clienti = await _clienteService.GetAllClientiAsync();

            List<ClienteViewModel> clienteViewModels = clienti.Select(c => new ClienteViewModel
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                Cognome = c.Cognome,
                Email = c.Email,
                Telefono = c.Telefono
            }).ToList();

            return View(clienteViewModels);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSave(ClienteViewModel clienteViewModel)
        {

            Cliente cliente = new Cliente
            {
                ClienteId = Guid.NewGuid(),
                Nome = clienteViewModel.Nome,
                Cognome = clienteViewModel.Cognome,
                Email = clienteViewModel.Email,
                Telefono = clienteViewModel.Telefono
            };
            await _clienteService.CreateClienteAsync(cliente);

            return RedirectToAction("Index");
        }
    }
}
