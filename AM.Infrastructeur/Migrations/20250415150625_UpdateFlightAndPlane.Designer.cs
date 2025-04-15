﻿// <auto-generated />
using System;
using AM.Infrastructeur;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructeur.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20250415150625_UpdateFlightAndPlane")]
    partial class UpdateFlightAndPlane
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
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
                    b.Property<string>("PassportNumber")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("BrithDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelNumber")
                        .HasColumnType("int");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.UseTptMappingStrategy();
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

            modelBuilder.Entity("AM.Applactioncore.Domaine.Ticket", b =>
                {
                    b.Property<int>("FlightFk")
                        .HasColumnType("int");

                    b.Property<string>("PassengerFk")
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Siege")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.Property<double>("prix")
                        .HasColumnType("float");

                    b.HasKey("FlightFk", "PassengerFk");

                    b.HasIndex("PassengerFk");

                    b.ToTable("Tickets");
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

                    b.ToTable("Staffs", (string)null);
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

                    b.ToTable("Travellers", (string)null);
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
                            b1.Property<string>("PassengerPassportNumber")
                                .HasColumnType("nvarchar(7)");

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

            modelBuilder.Entity("AM.Applactioncore.Domaine.Ticket", b =>
                {
                    b.HasOne("AM.Applactioncore.Domaine.Flight", "Flight")
                        .WithMany("tickets")
                        .HasForeignKey("FlightFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Applactioncore.Domaine.Passenger", "Passenger")
                        .WithMany("tickets")
                        .HasForeignKey("PassengerFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Staff", b =>
                {
                    b.HasOne("AM.Applactioncore.Domaine.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.Applactioncore.Domaine.Staff", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Traveller", b =>
                {
                    b.HasOne("AM.Applactioncore.Domaine.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.Applactioncore.Domaine.Traveller", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Flight", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Passenger", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("AM.Applactioncore.Domaine.Plane", b =>
                {
                    b.Navigation("flights");
                });
#pragma warning restore 612, 618
        }
    }
}
