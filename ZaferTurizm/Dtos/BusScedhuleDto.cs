﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs
{
    public class BusScedhuleDto
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int VehicleId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
