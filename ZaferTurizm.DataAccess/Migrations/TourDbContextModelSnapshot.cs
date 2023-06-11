﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZaferTurizm.DataAccess;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    [DbContext(typeof(TourDbContext))]
    partial class TourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ZaferTurizm.Domain.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("VehicleDefinitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleDefinitionId");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("ZaferTurizm.Domain.VehicleDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasToilet")
                        .HasColumnType("bit");

                    b.Property<bool>("HasWifi")
                        .HasColumnType("bit");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("AracınUretimYili");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("VehicleDefinition", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasToilet = true,
                            HasWifi = false,
                            SeatCount = 25,
                            VehicleModelId = 20,
                            Year = "2020"
                        },
                        new
                        {
                            Id = 2,
                            HasToilet = true,
                            HasWifi = true,
                            SeatCount = 48,
                            VehicleModelId = 20,
                            Year = "2022"
                        },
                        new
                        {
                            Id = 3,
                            HasToilet = true,
                            HasWifi = true,
                            SeatCount = 52,
                            VehicleModelId = 23,
                            Year = "2023"
                        });
                });

            modelBuilder.Entity("ZaferTurizm.Domain.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMake", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MAN"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Neoplan"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Otokar"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Volvo"
                        });
                });

            modelBuilder.Entity("ZaferTurizm.Domain.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModel", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 20,
                            Name = "Focus",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 21,
                            Name = "Octavia",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 22,
                            Name = "404",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 23,
                            Name = "Arda",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 24,
                            Name = "BBara",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 25,
                            Name = "Merdo",
                            VehicleMakeId = 1
                        });
                });

            modelBuilder.Entity("ZaferTurizm.Domain.Vehicle", b =>
                {
                    b.HasOne("ZaferTurizm.Domain.VehicleDefinition", "VehicleDefinition")
                        .WithMany()
                        .HasForeignKey("VehicleDefinitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleDefinition");
                });

            modelBuilder.Entity("ZaferTurizm.Domain.VehicleDefinition", b =>
                {
                    b.HasOne("ZaferTurizm.Domain.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("ZaferTurizm.Domain.VehicleModel", b =>
                {
                    b.HasOne("ZaferTurizm.Domain.VehicleMake", "VehicleMake")
                        .WithMany()
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });
#pragma warning restore 612, 618
        }
    }
}
