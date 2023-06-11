using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleDefinitionController : Controller
    {
        private readonly IVehicleDefinitonService _vehicleDefinitonService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;
        public VehicleDefinitionController(IVehicleDefinitonService vehicleDefinitonService, IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService) 
        {
            _vehicleDefinitonService = vehicleDefinitonService;
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
            
        }

        


        public IActionResult Index()
        {
            return View(_vehicleDefinitonService.GetAllSummaries());
        }
        public IActionResult Create() 
        {
            var makeList = _vehicleMakeService.GetAll();
            ViewBag.MakeList = new SelectList(makeList,"Id","Name");
            var modelList = _vehicleModelService.GetAll();
            ViewBag.ModelList = new SelectList(modelList, "Id", "Name");
            
            return View();
        }
        //[HttpPost]
        //public IActionResult Create() 
        //{
                     
        //}
        public IActionResult Edit(int id)
        {
            var vd = _vehicleDefinitonService.GetById(id);
            if (vd==null)
            {
                return NotFound();
            }

            var makeList = _vehicleMakeService.GetAll();
            ViewBag.MakeList = new SelectList(
                makeList, 
                "Id", 
                "Name",
                vd.VehicleMakeId);

            var models = _vehicleModelService.GetByMakeId(vd.VehicleMakeId);
            ViewBag.VehicleModelSelectList = new SelectList(models, "Id", "Name");




            return View(vd);
        }
    }
}
