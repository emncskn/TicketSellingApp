using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations.SeedData
{
    internal class VehicleDefinitionData
    {
        public readonly static VehicleDefinition VehicleDefinition01 = new VehicleDefinition()
        {
            Id = 1,
            VehicleModelId = VehicleModelData.VehicleModel01.Id,
            Year = 2020,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true

        };
        public readonly static VehicleDefinition VehicleDefinition02 = new VehicleDefinition()
        {
            Id = 2,
            VehicleModelId = VehicleModelData.VehicleModel02.Id,
            Year = 2020,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true

        };
        public readonly static VehicleDefinition VehicleDefinition03 = new VehicleDefinition()
        {
            Id = 3,
            VehicleModelId = VehicleModelData.VehicleModel03.Id,
            Year = 2020,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true

        };
        public readonly static VehicleDefinition VehicleDefinition04 = new VehicleDefinition()
        {
            Id = 4,
            VehicleModelId = VehicleModelData.VehicleModel04.Id,
            Year = 2020,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true

        };
        public readonly static VehicleDefinition VehicleDefinition05 = new VehicleDefinition()
        {
            Id = 5,
            VehicleModelId = VehicleModelData.VehicleModel05.Id,
            Year = 2020,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true

        };
        public readonly static VehicleDefinition VehicleDefinition06 = new VehicleDefinition()
        {
            Id = 6,
            VehicleModelId = VehicleModelData.VehicleModel06.Id,
            Year = 2020,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true

        };

        //ctrl+rr rename


    }
}
