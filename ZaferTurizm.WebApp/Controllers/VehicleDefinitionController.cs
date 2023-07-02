using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.DTOs;
using ZaferTurizm.WebApp.Models;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleDefinitionController : Controller
    {
        private readonly IVehicleDefinitionService _vehicleDefinitonService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;
        public VehicleDefinitionController(IVehicleDefinitionService vehicleDefinitonService, IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService) 
        {
            _vehicleDefinitonService = vehicleDefinitonService;
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
            
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var result = _vehicleDefinitonService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }


        }




        public IActionResult Index()
        {
            return View(_vehicleDefinitonService.GetSummaries());
        }
        public IActionResult Create() 
        {
            var makeList = _vehicleMakeService.GetAll();
            ViewBag.MakeList = new SelectList(makeList,"Id","Name");
            var modelList = _vehicleModelService.GetAll();
            ViewBag.ModelList = new SelectList(modelList, "Id", "Name");
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(VehicleDefinitonDto vehicleDefinitonDto)
        {
            var result = _vehicleDefinitonService.Create(vehicleDefinitonDto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new VehicleDefinitonDto());
            }
        }
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

        [HttpPost]
        public IActionResult Edit(VehicleDefinitonDto vehicleDefinitonDto)
        {
            var result = _vehicleDefinitonService.Update(vehicleDefinitonDto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Json(result.Message);
            }

        }
    }
}
