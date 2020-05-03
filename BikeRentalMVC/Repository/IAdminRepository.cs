using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeRentalMVC.Repository
{
    public interface IAdminRepository
    {
        Task<List<Employees>> GetEmployees();
        Task<List<SelectListItem>> GetLocations(int? id);
        Task<List<Bikes>> GetBikes();
        Task<Bikes> GetBike(int? id);
        Task<Employees> GetEmployee(int? id);
        Task<bool> AddBike(Bikes bike);
        Task<bool> AddEmployee(Employees employee);
        Task<bool> DeleteBike(int? bikeId);
        Task<bool> DeleteEmployee(int? bikeId);
        Task<bool> UpdateBike(Bikes bike);
        Task<bool> UpdateEmployee(Employees employee);
    }
}
