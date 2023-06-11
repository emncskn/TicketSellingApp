using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations.SeedData
{
    internal class VehicleDefinitionSeedData : IEntityTypeConfiguration<VehicleDefinition>
    {
        public void Configure(EntityTypeBuilder<VehicleDefinition> builder)
        {
            builder.HasData(
                VehicleDefinitionData.VehicleDefinition01,
                VehicleDefinitionData.VehicleDefinition02

                );
        }
    }
}
