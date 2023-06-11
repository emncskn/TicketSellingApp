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
    internal class VehicleModelConfiguration:IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)

        {
            builder.ToTable(nameof(VehicleModel));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");

            builder.HasOne(model => model.VehicleMake).WithMany()
                .HasForeignKey(model => model.VehicleMakeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
