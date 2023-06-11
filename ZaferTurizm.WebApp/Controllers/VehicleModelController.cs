using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleModelController(
            IVehicleModelService vehicleModelService,
            IVehicleMakeService vehicleMakeService)
        {
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
        }

        public IActionResult Create()

        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            ViewBag.VehicleMakes = vehicleMakes;
            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(VehicleModelDto vmo)
        {
           var result = _vehicleModelService.Create(vmo);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new VehicleModelDto());
            }
        }
        public IActionResult Index()
        {
            
            return View(_vehicleModelService.GetAllSummaries());
        }
        public IActionResult Delete(int id) 
        {
            if (id==0)
            {
                return Ok();
            }
            var result = _vehicleModelService.Delete(id);
            //if (result.IsSuccess)  return RedirectToAction("Index");
            //else
            //{
            //    ViewBag.msg =result.Message; 
            //    return RedirectToAction("Index");
            //} 
            return Json(result.Message);

        }
        public IActionResult Edit(int id)
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            var vehModel = _vehicleModelService.GetById(id);
          

            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");

            return View(vehModel);
        }
        [HttpPost]
        public IActionResult Edit(VehicleModelDto vmo)
        {
            var result = _vehicleModelService.Update(vmo);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            else 
            {

                var vehicleMakes = _vehicleMakeService.GetAll();
                ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");
                return View(vmo);

            }

            
            
        }
        public IActionResult GetVehicleModelsById(int vehicleMakeId)
        {
            
            var modelsByVehiclesId = _vehicleModelService.GetByMakeId(vehicleMakeId);
            return Json(modelsByVehiclesId);
        }
    }
}
