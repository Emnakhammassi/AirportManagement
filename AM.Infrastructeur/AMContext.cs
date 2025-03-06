using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
using AM.Infrastructeur.configurations;
using AM.Infrastructeur.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructeur
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        // OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                      Initial Catalog=AirportManagementDB;
                                      Integrated Security=true;
                                      MultipleActiveResultSets=True");
            base.OnConfiguring(optionsBuilder);
        }
    

    //onModel
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1err methode
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            //2eme methode
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>().Property(P => P.Capacity).HasColumnName("PlaneCapacity");


            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //configure owend 

            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);


        }

        protected override void ConfigureConventions( ModelConfigurationBuilder ConfigurationBuilder)
        {
            ConfigurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
            base.ConfigureConventions(ConfigurationBuilder);

        }


    } }
