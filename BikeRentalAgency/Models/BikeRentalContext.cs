using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalAgency.Context
{
    public class BikeRentalContext : DbContext
    {
        //Used for the connection string in the startup.cs
        public BikeRentalContext(DbContextOptions<BikeRentalContext> options)
            : base(options)
        { }


        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<Bikes> Bikes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ReservationDetails> ReservationDetails { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
    }
}
