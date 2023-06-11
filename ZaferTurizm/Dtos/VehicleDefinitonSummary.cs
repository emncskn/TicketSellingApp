using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs
{
    public class VehicleDefinitonSummary
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public bool HasToilet { get; set; }
        public string HasToiletString => HasToilet ? "Var" : "Yok"; //Sadece arrow function varsa readonlydir...
        public int SeatCount { get; set; }
        public bool HasWifi { get; set; }
        public string HasWifiString
        {
            get
            {
                return HasToilet ? "Var" : "Yok";
            }
        }
        public string VehicleModelName { get; set; }
        public string VehicleMakeName { get; set; }
    }
}
