using HotelDbProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelDbProject.Controllers
{
    public class PrenotazioneController : Controller
    {
        private readonly PrenotazioneService _prenotazioneService;
        public PrenotazioneController(PrenotazioneService prenotazioneService)
        {
            _prenotazioneService = prenotazioneService;
        }
        public async Task<IActionResult> Index()
        {
            var prenotazioni = await _prenotazioneService.GetAllPrenotazioniAsync();
            return View();
        }
    }
}
