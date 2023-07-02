using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Business.Services.LocationManager;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.WebApp.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public IActionResult Index()
        {
            var locations = _locationService.GetAll();
            return View(locations);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLocation(LocationDto locationDto)
        {
         
            var result = _locationService.Create(locationDto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new LocationDto());
            }

        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return Ok();
            }
            var result = _locationService.Delete(id);
            return Json(result.Message);
        }


    }
}
