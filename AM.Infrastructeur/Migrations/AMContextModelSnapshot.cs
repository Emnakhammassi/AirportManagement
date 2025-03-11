﻿// <auto-generated />
using System;
using AM.Infrastructeur;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructeur.Migrations
{
    [DbContext(typeof(AMContext))]
    partial class AMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AM.Applactioncore.Domaine.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveArrival")
                        .HasColumnType("datetime");

                    b.Property<int>("EstimationDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime");

                    b.Property<int>("planeFK")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("planeFK");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Passenger", b =>
                {
                    b.Property<int>("PassportNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassportNumber"));

                    b.Property<DateTime>("BrithDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelNumber")
                        .HasColumnType("int");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.HasDiscriminator().HasValue("Passenger");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCapacity");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("datetime");

                    b.Property<int>("planeType")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("MyPlanes", (string)null);
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("flightsFlightId")
                        .HasColumnType("int");

                    b.Property<int>("passengersPassportNumber")
                        .HasColumnType("int");

                    b.HasKey("flightsFlightId", "passengersPassportNumber");

                    b.HasIndex("passengersPassportNumber");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Staff", b =>
                {
                    b.HasBaseType("AM.Applactioncore.Domaine.Passenger");

                    b.Property<DateTime>("EmployementDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Traveller", b =>
                {
                    b.HasBaseType("AM.Applactioncore.Domaine.Passenger");

                    b.Property<string>("HealthInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Traveller");
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Flight", b =>
                {
                    b.HasOne("AM.Applactioncore.Domaine.Plane", "plane")
                        .WithMany("flights")
                        .HasForeignKey("planeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plane");
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Passenger", b =>
                {
                    b.OwnsOne("AM.Applactioncore.Domaine.FullName", "FullName", b1 =>
                        {
                            b1.Property<int>("PassengerPassportNumber")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)")
                                .HasColumnName("PassFirstName");

                            b1.Property<string>("Lastname")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PassLastName");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("AM.Applactioncore.Domaine.Flight", null)
                        .WithMany()
                        .HasForeignKey("flightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Applactioncore.Domaine.Passenger", null)
                        .WithMany()
                        .HasForeignKey("passengersPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Plane", b =>
                {
                    b.Navigation("flights");
                });
#pragma warning restore 612, 618
        }
    }
}
