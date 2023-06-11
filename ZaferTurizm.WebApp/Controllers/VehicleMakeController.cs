using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using ZaferTurizm.WebApp.Models;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        // /VehicleMake/Index
        // /VehicleMake url leri ile erişilebilir.

        private readonly IVehicleMakeService _vehicleMakeService;
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }
        public IActionResult Index()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();

            return View(vehicleMakes);
        }
        public IActionResult Create()
        { 
             return View();
        }

        //http get tipindeki requestler de veriler; url nin devamında Query String olarak sunucuya iletilir.
        //query stringle veri taşıdığında gereksiz ekleme yaşanabilir ve güvensizdir.(http get)
        //http post (hatta PUT ve DELETE Dahil) tipindeki requestlerde veriler requestin body bölümünde
        //(yani gömülü şekilde) sunucuya iletilir.

        //public IActionResult CreateSubmit(IFormCollection formCollection) //2.yola ait 

        //bir action metodu [HttpPost],[HttpGet] şeklindeki attributelerden bir tanesini eklemek,
        //o action metodun yalnızca o http metodu ile çalışacağını bildirmek olur.
        //yani diğer http metotları ile aynı adrese açılmış requestlere cevap verme anlamına gelir.

        //kısacası, createsubmit action ını yalnızca post requestlere cevap ver şeklinde kısıtladık.
        [HttpPost]


        //dom tamamen yüklendikten sonra script kodları okunur o yüzden sayfa sonuna js kodları eklenir.
        //elementi bulamama gibi bir durum yaşanmaması için...
        //public IActionResult CreateSubmit(string marka_adi)
        public IActionResult CreateSubmit(MarkaViewModel viewModel)
        {
            //  string vehicleMakeName = HttpContext.Request.Form["marka_adi"];
            //input name ile bu kısım key-value ikilisini oluşturuyor. Trick burda.


            // string vehicleMakeName = formCollection["marka_adi"]; //2. bir yol

            string vehicleMakeName = viewModel.Marka_Adi;
            var vehicleMakeDto = new VehicleMakeDto()
            {
                Name = vehicleMakeName
            };

            var result = _vehicleMakeService.Create(vehicleMakeDto);
            if (result.IsSuccess)
            {
              return  RedirectToAction("Index");
            }
            else
            {
                return Ok();
            }
        }

        public IActionResult Edit(int id)
        {

            var vehicleMakeDto = _vehicleMakeService.GetById(id);
            if (vehicleMakeDto != null)
            {
                return View(vehicleMakeDto);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(VehicleMakeDto model)
        {
            var result = _vehicleMakeService.Update(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _vehicleMakeService.Delete(id);
            if (result.IsSuccess)
            {
              return  RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
       

    }
}
