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
                SelectList clientiList = new SelectList(await _clienteService.GetAllClientiAsync(), "ClienteId", "Nome","Cognome");
                SelectList camereList = new SelectList(await _cameraService.GetAllCamereAsync(), "CameraId", "NumeroCamera","Tipo", "Prezzo");
                ViewBag.CamereList = camereList;
                ViewBag.ClientiList = clientiList;
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
    }
}
