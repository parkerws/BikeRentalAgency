using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;

namespace BikeRentalAgency.Repository
{
    public interface IAdminRepository
    {
        Task<List<Bikes>> GetBikes();
        Task<List<Location>> GetLocations();
        Task<List<Employees>> GetEmployees();
        Task<Bikes> GetBike(int? bikeId);
        Task<Employees> GetEmployee(int? employeeId);
        Task<int> AddBike(Bikes bike);
        Task<int> DeleteBike(int? bikeId);
        Task UpdateBike(Bikes bike);
        Task<int> AddEmployee(Employees employee);
        Task<int> DeleteEmployee(int? employeeId);
        Task UpdateEmployee(Employees employee);
    }
}
