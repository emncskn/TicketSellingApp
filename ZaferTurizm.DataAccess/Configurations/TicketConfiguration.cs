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
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
           builder.ToTable(nameof(Ticket));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Price).HasColumnType("money");

            builder.HasOne(t=>t.Passenger)
                .WithMany()
                .HasForeignKey(t => t.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
