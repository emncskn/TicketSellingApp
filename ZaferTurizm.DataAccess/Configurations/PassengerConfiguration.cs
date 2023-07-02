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
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.NationalNumber).IsRequired().HasColumnType("varchar(15)");



            builder.HasData(
                PassengerData.Data01,
                PassengerData.Data02,
                PassengerData.Data03,
                PassengerData.Data04,
                PassengerData.Data05,
                PassengerData.Data06,
                PassengerData.Data07

                );
        }
    }
}
