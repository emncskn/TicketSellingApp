﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.PlateNumber).IsRequired().HasColumnType("varchar(20)");
            builder.HasOne(x => x.VehicleDefinition)
                    .WithMany()
                    .HasForeignKey(x => x.VehicleDefinitionId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(

                VehicleData.Data01,
                VehicleData.Data02, VehicleData.Data03
                );

            
        }
    }
}
