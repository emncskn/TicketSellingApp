using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs
{
    public class VehicleSummary
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public int VehicleSeatCount { get; set; }
        public string VehicleWifiStatus { get; set; }
        public string VehicleToiletStatus { get; set; }
        public string VehicleYear { get; set; }
        
    }
}
