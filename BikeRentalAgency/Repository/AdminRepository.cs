using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BikeRentalAgency.Context;
using BikeRentalAgency.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BikeRentalAgency.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private BikeRentalContext db;

        public AdminRepository(BikeRentalContext _db)
        {
            db = _db;
        }

        public async Task<List<Bikes>> GetBikes()
        {
            if (db != null)
            {
                return await db.Bikes.ToListAsync();
            }

            return null;
        }

        public async Task<List<Location>> GetLocations()
        {
            if (db != null)
            {
                return await db.Locations.ToListAsync();
            }

            return null;
        }

        public async Task<List<Employees>> GetEmployees()
        {
            if (db != null)
            {
                return await db.Employees.ToListAsync();
            }

            return null;
        }

        public async Task<Bikes> GetBike(int? bikeId)
        {
            if (db != null)
            {
                return await db.Bikes.FirstOrDefaultAsync(x => x.Id == bikeId);
            }

            return null;
        }

        public async Task<Employees> GetEmployee(int? employeeId)
        {
            if (db != null)
            {
                return await db.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
            }

            return null;
        }

        public async Task<int> AddBike(Bikes bike)
        {
            if (db != null)
            {
                await db.Bikes.AddAsync(bike);
                await db.SaveChangesAsync();
                return bike.Id;
            }

            return 0;
        }

        public async Task<int> DeleteBike(int? bikeId)
        {
            int result = 0;
            if (db != null)
            {
                var bike = await db.Bikes.FirstOrDefaultAsync(x => x.Id == bikeId);
                if (bike != null)
                {
                    db.Bikes.Remove(bike);

                    result = await db.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }

        public async Task UpdateBike(Bikes bike)
        {
            if (db != null)
            {
                db.Bikes.Update(bike);

                await db.SaveChangesAsync();
            }
        }

        public async Task<int> AddEmployee(Employees employee)
        {
            if (db != null)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
                return employee.Id;
            }

            return 0;
        }

        public async Task<int> DeleteEmployee(int? employeeId)
        {
            int result = 0;
            if (db != null)
            {
                var employee = await db.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
                if (employee != null)
                {
                    db.Employees.Remove(employee);

                    result = await db.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }

        public async Task UpdateEmployee(Employees employee)
        {
            if (db != null)
            {
                db.Employees.Update(employee);

                await db.SaveChangesAsync();
            }
        }
    }
}
