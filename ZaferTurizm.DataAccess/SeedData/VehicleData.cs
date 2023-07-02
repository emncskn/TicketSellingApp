using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public class VehicleData
    {
        public static readonly Vehicle Data01 = new Vehicle()
        {
            Id = 1,
            PlateNumber = "34 ZD 258",
            VehicleDefinitionId = VehicleDefinitionModelData.VehicleDefinition01.Id

        };
        public static readonly Vehicle Data02 = new Vehicle()
        {
            Id = 2,
            PlateNumber = "34 ZDK 758",
            VehicleDefinitionId = VehicleDefinitionModelData.VehicleDefinition02.Id

        };
        public static readonly Vehicle Data03 = new Vehicle()
        {
            Id = 3,
            PlateNumber = "34 RZD 258",
            VehicleDefinitionId = VehicleDefinitionModelData.VehicleDefinition03.Id

        }; 
   

    }
}
