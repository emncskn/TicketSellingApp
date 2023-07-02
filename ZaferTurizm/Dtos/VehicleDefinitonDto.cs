using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs
{
    public class VehicleDefinitonDto
    {
        public int Id { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string Year { get; set; }
        public bool HasToilet { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int SeatCount { get; set; }
        public bool HasWifi { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
