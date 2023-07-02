using Microsoft.EntityFrameworkCore;
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
    internal class LocationConfiguration:IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable(nameof(Location));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");

            builder.HasData(

                LocationData.Data01_Istanbul,
                LocationData.Data02_Ankara,
                LocationData.Data03_Erzincan,
                LocationData.Data04_Antalya,
                LocationData.Data05_Rize,
                LocationData.Data06_Samsun);
        }
    }
}
