using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs
{
    public class TicketSummary
    {
        public int Id { get; set; }
        public int BusScedhuleId { get; set; }
        public int PassengerId { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
