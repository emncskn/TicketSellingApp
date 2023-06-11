using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleDefinitionController : Controller
    {
        private readonly IVehicleDefinitionService _vehicleDefinitionService;
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleDefinitionController(IVehicleDefinitionService vehicleDefinitionService,
            IVehicleMakeService vehicleMakeService,
            IVehicleModelService vehicleModelService)
        {
            _vehicleDefinitionService = vehicleDefinitionService;
            _vehicleMakeService = vehicleMakeService;
            _vehicleModelService = vehicleModelService;
        }

        public IActionResult Index()
        {
            var summaries = _vehicleDefinitionService.GetSummaries();
            return View(summaries);
        }
        public IActionResult Create()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");
           
            return View();
        }

        public IActionResult Update(int id)
        {
            var vehicleDefinition = _vehicleDefinitionService.GetById(id);
                
            if (vehicleDefinition == null)
            {
                return NotFound();
            }

            var allVehicleMakes = _vehicleMakeService.GetAll();
            ViewBag.VehicleMakeSelectList = new SelectList(
                allVehicleMakes,
                "Id",
                "Name"
                );

            var vehicleModelsOfMake = _vehicleModelService.GetByMakeId(vehicleDefinition.VehicleMakeId);
            ViewBag.VehicleModelSelectList =
                new SelectList(vehicleModelsOfMake, "Id", "Name");

            //var allVehicleModels = _vehicleModelService.GetAll();
            //ViewBag.VehicleModelsSelectList = new SelectList(allVehicleModels, "Id", "Name");

            return View(vehicleDefinition); 
        }

    }
}
