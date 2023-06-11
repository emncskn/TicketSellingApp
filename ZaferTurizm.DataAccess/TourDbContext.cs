using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.Configurations;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess
{
    public class TourDbContext:DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleDefinition> VehicleDefinitions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMakeConfiguration());//Yaptığımız configurationı ekledik.
            modelBuilder.ApplyConfiguration(new VehicleModelConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionSeedData());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionLaptopStringSettings);
        }
    }
}
