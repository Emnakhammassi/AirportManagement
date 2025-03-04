using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
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
    }





    
}
