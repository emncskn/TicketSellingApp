using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DTOs
{
    public class BusScedhuleDetail
    {
        public int BusScedhuleId { get; set; }
        public int SeatCount { get; set; }
        public DateTime Date { get; set; }
        public decimal TicketPrice { get; set; }
        public string DepartureName { get; set; }
        public string ArrivalName { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public string PlateNumber { get; set; }

        public List<TicketDto> TicketList { get; set; }

        public string BusScedhuleName => $"{Date.ToString("dd.MM.yyyy HH:mm")} / {DepartureName} -> {ArrivalName}";
        public string VehicleInfo => $"{VehicleMakeName} {VehicleModelName} / {PlateNumber}";

        public IEnumerable<int> SoldSeatNumbers { get; }
    }
}
