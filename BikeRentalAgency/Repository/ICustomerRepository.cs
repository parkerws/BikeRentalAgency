using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using BikeRentalAgency.ViewModel;

namespace BikeRentalAgency.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int? customerId);
        Task<CustomerViewModel> GetCustomerReservation(int? customerId);
        Task<int> AddCustomer(Customer customer);
        Task<int> DeleteCustomer(int? customerId);
        Task UpdateCustomer(Customer customer);
        Task<int> AddReservation(Reservations reservation);
        Task<int> DeleteReservation(int? reservationId);
        Task UpdateReservation(Reservations reservation);
    }
}
