using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations.SeedData
{
    internal class VehicleModelData
    {
        public static readonly VehicleModel VehicleModel01 = new VehicleModel() { Id = 1, VehicleMakeId = 1, Name = "Travego" };
        public static readonly VehicleModel VehicleModel02 = new VehicleModel() { Id = 2, VehicleMakeId = 1, Name = "403" };
        public static readonly VehicleModel VehicleModel03 = new VehicleModel() { Id = 3, VehicleMakeId = 1, Name = "Tourismo" };
        public static readonly VehicleModel VehicleModel04 = new VehicleModel() { Id = 4, VehicleMakeId = 2, Name = "Lions" };
        public static readonly VehicleModel VehicleModel05 = new VehicleModel() { Id = 5, VehicleMakeId = 2, Name = "Fortuna" };
        public static readonly VehicleModel VehicleModel06 = new VehicleModel() { Id = 6, VehicleMakeId = 2, Name = "SL" };
    }
}
