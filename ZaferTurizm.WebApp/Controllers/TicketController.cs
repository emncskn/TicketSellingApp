using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services.BusScedhuleManagers;
using ZaferTurizm.Business.Services.PassengerManager;
using ZaferTurizm.Business.Services.TicketManager;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.WebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly IBusScedhuleService _busScedhuleService;
        private readonly ITicketService _ticketService;
        private readonly IPassengerService _passengerService;

        public TicketController(IBusScedhuleService busScedhuleService, ITicketService ticketService, IPassengerService passengerService)
        {
            _busScedhuleService = busScedhuleService;
            _ticketService = ticketService; 
            _passengerService = passengerService;
        }

        public IActionResult TicketsOfBusScedhule(int busScedhuleId)
        {

            var busScedhuleDetails = _busScedhuleService.GetBusScedhuleDetails(busScedhuleId);
            busScedhuleDetails.TicketList = _ticketService.GetByBusScedhule(busScedhuleId).ToList();
            List<BusSeat> seats = new List<BusSeat>();
            for (int i = 1; i <= busScedhuleDetails.SeatCount; i++)
            {
                TicketDto? ticket = busScedhuleDetails.TicketList.Find(x => x.SeatNumber.Equals(i.ToString()));
                
                BusSeat? seat = null;
                if (ticket == null)
                {
                  seat =   new BusSeat(i, false, Gender.None);
                }
                else
                {
                    PassengerDto passenger = _passengerService.GetByNationalNumber(ticket.PassengerIdentityNumber);
                    seat = new BusSeat(i, true, passenger.Gender);
                }
                seats.Add(seat);
            }
            ViewBag.seats = seats;

            if (busScedhuleDetails == null)
            {
                TempData["ErrorMessage"] = "Seyahat bulunamadı";
                return RedirectToAction("Index", "BusTrip");
            }

            return View(busScedhuleDetails);
        }

        [HttpPost]
        public IActionResult Create(TicketDto ticket)
        {
            var result = _ticketService.Create(ticket);

            return Json(result);
        }
    }
}

