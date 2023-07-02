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
    internal class BusScedhuleConfig : IEntityTypeConfiguration<BusScedhule>
    {
        public void Configure(EntityTypeBuilder<BusScedhule> builder)
        {
            builder.ToTable(nameof(BusScedhule));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).HasColumnType("datetime2(0)");
            builder.Property(x => x.Price).HasColumnType("money");

            builder.HasOne(x=>x.Route)
                .WithMany()
                .HasForeignKey(x=>x.RouteId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Vehicle)
               .WithMany()
               .HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
