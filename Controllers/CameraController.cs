using HotelDbProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelDbProject.Controllers
{
    public class CameraController : Controller
    {
        private readonly CameraService _cameraService;
        public CameraController(CameraService cameraService)
        {
            _cameraService = cameraService;
        }
        public async Task<IActionResult> Index()
        {
            var camere = await _cameraService.GetAllCamereAsync();
            return View();
        }
    }
}
