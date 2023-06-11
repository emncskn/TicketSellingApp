using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.Configurations;
using ZaferTurizm.DataAccess.Configurations.SeedData;
using ZaferTurizm.DataAccess.Settings;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess
{
    public class TourDbContext : DbContext
    {
        //DbSet veri tabanındaki tablolara denk gelir.
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleDefinition> VehicleDefinitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMakeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelSeedData());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionSeedData());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.DbConnectionString);
        }
    }
}
