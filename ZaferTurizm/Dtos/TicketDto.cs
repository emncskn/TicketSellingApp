using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZaferTurizm.DTOs
{
    public class TicketDto
    {
        
        public int Id { get; set; }
        public int BusScedhuleId { get; set; }
     
        public string PassengerIdentityNumber { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurname { get; set; }
        public Gender PassengerGender { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
