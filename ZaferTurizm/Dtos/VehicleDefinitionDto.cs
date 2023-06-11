﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class VehicleDefinitionDto
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }
        public int Year { get; set; }
        public int SeatCount { get; set; }
        public bool HasToilet { get; set; }
        public bool HasWifi { get; set; }
       
    }     
}
