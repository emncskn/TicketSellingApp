using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleModelSeedData : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasData(

                new VehicleModel() { Id = 1, VehicleMakeId = 1, Name = "Travego" },
                new VehicleModel() { Id = 2, VehicleMakeId = 1, Name = "403" },
                new VehicleModel() { Id = 3, VehicleMakeId = 1, Name = "Tourismo" },
                new VehicleModel() { Id = 4, VehicleMakeId = 2, Name = "Lions" },
                new VehicleModel() { Id = 5, VehicleMakeId = 2, Name = "Fortuna" },
                new VehicleModel() { Id = 6, VehicleMakeId = 2, Name = "SL" });
        }
    }
}
