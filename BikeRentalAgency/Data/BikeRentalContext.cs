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
        public DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BikeRentalAgency;Trusted_Connection=True;ConnectRetryCount=0");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bikes>().HasData(
                new Bikes {Id = 1, Brand = "Trek", Frame = FrameSize.Medium, type = BikeTypes.MountainBike, OnHire = false, LocationId = 1},
                new Bikes { Id = 2, Brand = "Mongoose", Frame = FrameSize.Small, type = BikeTypes.RoadBike, OnHire = false, LocationId = 3},
                new Bikes { Id = 3, Brand = "Raleigh", Frame = FrameSize.Medium, type = BikeTypes.TandemBike, OnHire = false, LocationId = 1},
                new Bikes { Id = 4, Brand = "Diamondback", Frame = FrameSize.Medium, type = BikeTypes.BeachCruiser, OnHire = false, LocationId = 4},
                new Bikes { Id = 5, Brand = "Specialized", Frame = FrameSize.Large, type = BikeTypes.RoadBike, OnHire = false, LocationId = 1});

            modelBuilder.Entity<Location>().HasData(
                new Location {Id = 1, City = "Jacksonville", Address = "123 North Street", BranchEmail = "JaxBranch@KoolBikes.com", State = "NC", Zip = 28542},
                new Location {Id = 2, City = "New Bern", Address = "456 South Street", BranchEmail = "NewBern@KoolBikes.com", State = "NC", Zip = 25343},
                new Location {Id = 3, City = "Wilmington", Address = "678 West Street", BranchEmail = "Wilminton@KoolBikes.com", State = "NC", Zip = 24423},
                new Location {Id = 4, City = "Raleigh", Address = "234 East Street", BranchEmail = "Raleigh@KoolBikes.com", State = "NC", Zip = 24242},
                new Location {Id = 5, City = "Emerald Isle", Address = "525 Center Street", BranchEmail = "Emerald@KoolBikes.com", State = "NC", Zip = 26876});

            modelBuilder.Entity<Employees>().HasData(
                new Employees {Id = 1, Admin = true, FirstName = "John", LastName = "Smith", LocationId = 2},
                new Employees {Id = 2, Admin = false, FirstName = "Tyler", LastName = "Johnson", LocationId = 1},
                new Employees {Id = 3, Admin = false, FirstName = "Banana", LastName = "Backpack", LocationId = 4});

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1, FirstName = "John", LastName = "Smith", PhoneNumber = "123-456-7890", Address = "212 Front St", City = "Jacksonville", State = "NC", Zip = 12345
                });

            modelBuilder.Entity<Accessories>().HasData(
                new Accessories {Id = 1, Accessory = BikeAccessories.Tirepump},
                new Accessories {Id = 2, Accessory = BikeAccessories.Basket},
                new Accessories {Id = 3, Accessory = BikeAccessories.Flashlight},
                new Accessories {Id = 4, Accessory = BikeAccessories.Helmet},
                new Accessories {Id = 5, Accessory = BikeAccessories.Repairkit},
                new Accessories {Id = 6, Accessory = BikeAccessories.Trailer});

        }
    }
}
