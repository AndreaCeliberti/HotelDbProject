using HotelDbProject.Models;
using HotelDbProject.Services;
using HotelDbProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HotelDbProject.Controllers
{
    public class PrenotazioneController : Controller
    {
        private readonly PrenotazioneService _prenotazioneService;
        private readonly CameraService _cameraService;
        private readonly ClienteService _clienteService;
        public PrenotazioneController(PrenotazioneService prenotazioneService, CameraService cameraService, ClienteService clienteService)
        {
            _prenotazioneService = prenotazioneService;
            _cameraService = cameraService;
            _clienteService = clienteService;
        }
        public async Task<IActionResult> Index()
        {
            List<Prenotazione> prenotazioni = await _prenotazioneService.GetAllPrenotazioniAsync();

            List<PrenotazioneViewModel> prenotazioniViewModel = prenotazioni.Select(p => new PrenotazioneViewModel
            {
                PrenotazioneId = p.PrenotazioneId,
                ClienteId = p.ClienteId,
                CameraId = p.CameraId,
                DataInizio = p.DataInizio,
                DataFine = p.DataFine,
                StatoPrenotazione = p.StatoPrenotazione
            }).ToList();

            return View(prenotazioniViewModel);
        }

            public async Task<IActionResult> Create()
            {
            SelectList clientiList = new SelectList((await _clienteService.GetAllClientiAsync()).Select(static c => new {
                c.ClienteId,
                NomeCompleto = c.Nome + " " + c.Cognome
                }), "ClienteId", "NomeCompleto");
                SelectList camereList = new SelectList((await _cameraService.GetAllCamereAsync()).Select(static c => new
                {
                    c.CameraId,
                    NumeroTipoPrezzo = c.Numero + " " + c.Tipo + " " + c.Prezzo
                }), "CameraId", "NumeroTipoPrezzo");
                ViewBag.ClientiList = clientiList;
                ViewBag.CamereList = camereList;
                
            return View();
            }
            [HttpPost]
            public async Task<IActionResult> CreateSave(PrenotazioneViewModel prenotazioneViewModel)
            {
                Prenotazione prenotazione = new Prenotazione
                {
                    PrenotazioneId = Guid.NewGuid(),
                    ClienteId = prenotazioneViewModel.ClienteId,
                    CameraId = prenotazioneViewModel.CameraId,
                    DataInizio = prenotazioneViewModel.DataInizio,
                    DataFine = prenotazioneViewModel.DataFine,
                    StatoPrenotazione = prenotazioneViewModel.StatoPrenotazione
                };
                await _prenotazioneService.CreatePrenotazioneAsync(prenotazione);
                return RedirectToAction("Index");
            }
        // GET - Edit (MODAL)
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Prenotazione? prenotazione = await _prenotazioneService.GetPrenotazioneByIdAsync(id);
            if (prenotazione == null) return NotFound();

            ViewBag.ClientiList = new SelectList(
                await _clienteService.GetAllClientiAsync(),
                "ClienteId",
                "Nome"
            );

            ViewBag.CamereList = new SelectList(
                await _cameraService.GetAllCamereAsync(),
                "CameraId",
                "Numero"
            );

            PrenotazioneViewModel vm = new PrenotazioneViewModel
            {
                PrenotazioneId = prenotazione.PrenotazioneId,
                ClienteId = prenotazione.ClienteId,
                CameraId = prenotazione.CameraId,
                DataInizio = prenotazione.DataInizio,
                DataFine = prenotazione.DataFine,
                StatoPrenotazione = prenotazione.StatoPrenotazione
            };

            return PartialView("_EditModal", vm);
        }

        // POST - Edit
        [HttpPost]
        public async Task<IActionResult> EditSave(PrenotazioneViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ClientiList = new SelectList(await _clienteService.GetAllClientiAsync(), "ClienteId", "Nome");
                ViewBag.CamereList = new SelectList(await _cameraService.GetAllCamereAsync(), "CameraId", "Numero");
                return PartialView("_EditModal", vm);
            }

            Prenotazione prenotazione = new Prenotazione
            {
                PrenotazioneId = vm.PrenotazioneId,
                ClienteId = vm.ClienteId,
                CameraId = vm.CameraId,
                DataInizio = vm.DataInizio,
                DataFine = vm.DataFine,
                StatoPrenotazione = vm.StatoPrenotazione
            };

            await _prenotazioneService.UpdatePrenotazioneAsync(prenotazione);
            return RedirectToAction("Index");
        }

        // GET - Delete (MODAL)
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Prenotazione? prenotazione = await _prenotazioneService.GetPrenotazioneByIdAsync(id);
            if (prenotazione == null) return NotFound();

            return PartialView("_DeleteModal", prenotazione);
        }

        // POST - Delete
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _prenotazioneService.DeletePrenotazioneAsync(id);
            return RedirectToAction("Index");
        }

    }
}
