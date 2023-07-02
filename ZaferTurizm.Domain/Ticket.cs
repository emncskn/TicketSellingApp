using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public BusScedhule BusScedhule { get; set; }

      
        public int BusScedhuleId { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
