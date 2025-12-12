using HotelDbProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelDbProject.Controllers
{
    public class PrenotazineController : Controller
    {
        private readonly PrenotazioneService _prenotazioneService;
        public PrenotazineController(PrenotazioneService prenotazioneService)
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
