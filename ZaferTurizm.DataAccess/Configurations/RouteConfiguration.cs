﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable(nameof(Route));
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.DepartureCity)
                .WithMany()
                .HasForeignKey(x => x.DepartureCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ArrivalCity)
                .WithMany()
                .HasForeignKey(x=> x.ArrivalCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(

                RouteData.Data01_AnkaraIstanbul,
                RouteData.Data02_AnkaraErzincan,
                RouteData.Data03_RizeAntalya,
                RouteData.Data04_AnkaraSamsun);
        }
    }
}
