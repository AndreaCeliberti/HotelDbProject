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
        // GET - Edit (per modal)
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Cliente? cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null) return NotFound();

            ClienteViewModel vm = new ClienteViewModel
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Cognome = cliente.Cognome,
                Email = cliente.Email,
                Telefono = cliente.Telefono
            };

            return PartialView("_EditModal", vm);
        }

        
        [HttpPost]
        public async Task<IActionResult> EditSave(ClienteViewModel vm)
        {
            if (!ModelState.IsValid)
                return PartialView("_EditModal", vm);

            Cliente cliente = new Cliente
            {
                ClienteId = vm.ClienteId,
                Nome = vm.Nome,
                Cognome = vm.Cognome,
                Email = vm.Email,
                Telefono = vm.Telefono
            };

            await _clienteService.UpdateClienteAsync(cliente);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Cliente? cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null) return NotFound();

            return PartialView("_DeleteModal", cliente);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
