using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class BusScedhule:IEntity
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int VehicleId { get; set; }
        public decimal Price { get; set; }
        public Route Route { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime Date { get; set; }
        public List<Ticket> Ticket { get; set; }
    }
}
