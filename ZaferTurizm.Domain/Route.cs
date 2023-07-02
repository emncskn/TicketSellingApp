using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Route:IEntity
    {
        public int Id { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public Location DepartureCity { get; set; }
        public Location ArrivalCity { get; set; }



    }
}
