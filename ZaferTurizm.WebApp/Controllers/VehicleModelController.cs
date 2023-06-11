using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;
        public VehicleModelController(IVehicleModelService vehicleModelService,
            IVehicleMakeService vehicleMakeService)
        {
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
        }
        public IActionResult Index()
        {
            var vehicleModelSummaries = _vehicleModelService.GetSummaries();

            return View(vehicleModelSummaries);
        }
        public IActionResult Create()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
           // ViewBag.VehicleMakes = vehicleMakes;
            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");
            return View();
        }

        public IActionResult Create(VehicleModelDto vehicleModel)
        {
            var result = _vehicleModelService.Create(vehicleModel);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vehicleModel);
            }

        }

        public IActionResult GetVehicleModelsById(int vehicleMakesId)
        {
            var allVehicleModels = _vehicleModelService.GetAll();
            var vehicleModelsofMake = allVehicleModels.Where(model => model.VehicleMakeId == vehicleMakesId);

            return Json(vehicleModelsofMake);
        }
    }
}
