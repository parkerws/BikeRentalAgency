using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using BikeRentalMVC.ViewModels;

namespace BikeRentalMVC.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int? customerId);
        Task<CustomerViewModel> GetCustomerReservation(int? reservationId);
        Task<bool> AddCustomer(Customer customer);
        Task<bool> DeleteCustomer(int? id);
        Task<bool> UpdateCustomer(Customer customer);
        

    }
}
