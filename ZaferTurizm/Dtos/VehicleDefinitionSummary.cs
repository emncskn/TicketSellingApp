using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class VehicleDefinitionSummary
    {
        public int Id { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public int Year { get; set; }
        public bool HasToilet { get; set; }
        public int SeatCount { get; set; }
        public string HasToiletString
        {
            get
            {
                return HasToilet ? "Var" : "Yok";
            }
        }

        //arrow function ile readonly property yazma 
        public string HasWifiString => HasWifi ? "Var" : "Yok";
        public bool HasWifi { get; set; }
    }
}
