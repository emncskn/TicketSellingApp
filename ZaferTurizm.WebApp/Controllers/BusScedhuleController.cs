using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services.BusScedhuleManagers;
using ZaferTurizm.Business.Services.RouteManager;
using ZaferTurizm.Business.Services.VehicleManagers;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.WebApp.Controllers
{
    public class BusScedhuleController : Controller
    {
        private readonly IBusScedhuleService _busScedhuleService;
        private readonly IRouteService _routeService;
        private readonly IVehicleService _vehicleService;

        // Mediatr
        // CQRS
        public BusScedhuleController(
            IBusScedhuleService busScedhuleService,
            IRouteService routeService,
            IVehicleService vehicleService)
        {
            _busScedhuleService = busScedhuleService;
            _routeService = routeService;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            var busScedhuleSummaries = _busScedhuleService.GetSummaries();

            return View(busScedhuleSummaries);
        }

        public IActionResult Create()
        {
            FillRouteAndVehicleValues();

          

            return View();
        }

        private void FillRouteAndVehicleValues()
        {
            var routeSummaries = _routeService.GetSummaries();
            var vehicleSummaries = _vehicleService.GetSummaries();

            ViewBag.RouteSelectList = new SelectList(routeSummaries, "Id", "RouteName");
            ViewBag.VehicleSelectList = new SelectList(vehicleSummaries, "Id", "Description");
        }

        [HttpPost]
        public IActionResult Create(BusScedhuleDto dto)
        {
           
            var result = _busScedhuleService.Create(dto);

            if (result.IsSuccess)
            {
                //ViewBag.SuccessMessage = result.Message;
                TempData["SuccessMessage"] = result.Message;

                return RedirectToAction(nameof(Index));
            }
            else
            {
                FillRouteAndVehicleValues();

                ViewBag.ErrorMessage = result.Message.Replace("\n", "<br>");

                return View(dto);
            }
        }
    }
}
