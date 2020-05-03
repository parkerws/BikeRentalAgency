using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BikeRentalAgency.Context;
using BikeRentalAgency.Models;
using BikeRentalAgency.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalAgency.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private BikeRentalContext db;

        public CustomerRepository(BikeRentalContext _db)
        {
            db = _db;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            if (db != null)
            {
                return await db.Customers.ToListAsync();
            }

            return null;
        }

        public async Task<Customer> GetCustomer(int? customerId)
        {
            if (db != null)
            {
                return await db.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
            }

            return null;
        }

        public async Task<CustomerViewModel> GetCustomerReservation(int? reservationId)
        {
            if (db != null)
            {
                return await (from c in db.Customers
                    from r in db.Reservations
                    where r.Id == reservationId
                    select new CustomerViewModel
                    {
                        CustomerId = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        City = c.City,
                        State = c.State,
                        Zip = c.Zip,
                        Address = c.Address,
                        ReservationId = r.Id,
                        ReservationDate = r.BeginDate.ToLongDateString()
                    }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            if (db != null)
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
                return customer.Id;
            }

            return 0;
        }

        public async Task<int> DeleteCustomer(int? customerId)
        {
            int result = 0;
            if (db != null)
            {
                var customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    result = await db.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            if (db != null)
            {
                db.Customers.Update(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task<int> AddReservation(Reservations reservation)
        {
            if (db != null)
            {
                await db.Reservations.AddAsync(reservation);
                await db.SaveChangesAsync();
                return reservation.Id;
            }

            return 0;
        }

        public async Task<int> DeleteReservation(int? reservationId)
        {
            int result = 0;
            if (db != null)
            {
                var reservation = await db.Reservations.FirstOrDefaultAsync(x => x.Id == reservationId);
                if (reservation != null)
                {
                    db.Reservations.Remove(reservation);
                    result = await db.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }
        public async Task UpdateReservation(Reservations reservation)
        {
            if (db != null)
            {
                db.Reservations.Update(reservation);
                await db.SaveChangesAsync();
            }
        }
    }
        
    }

