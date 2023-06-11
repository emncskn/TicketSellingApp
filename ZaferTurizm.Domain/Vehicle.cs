using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int VehicleDefinitonId { get; set; }
        public string PlateNumber { get; set; }
        public VehicleDefinition VehicleDefinition { get; set; }
    }
}
