using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using BikeRentalMVC.ViewModels;
using Newtonsoft.Json;

namespace BikeRentalMVC.Repository
{
    public class CustomerRepository
    {
        private string baseUrl = "https://localhost:44305/api/customers";
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> bikes = new List<Customer>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"Customers");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    bikes = JsonConvert.DeserializeObject<List<Customer>>(response);
                }

                return bikes;
            }
        }

        public async Task<Customer> GetCustomer(int? customerId)
        {
            Customer customer = new Customer();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync($"Customers?={customerId}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(response);
                }
            }

            return customer;
        }

        public async Task<CustomerViewModel> GetCustomerReservation(int? reservationId)
        {
            CustomerViewModel cust = new CustomerViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"reservation/{reservationId}");

                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    cust = JsonConvert.DeserializeObject<CustomerViewModel>(res);
                }
            }

            return cust;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "Customers", customer);

                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteCustomer(int? id)
        {
            bool successful = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await client.DeleteAsync(
                    $"Customers/{id}");
                successful = response.IsSuccessStatusCode;

            }

            return successful;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage result = await client.PutAsJsonAsync(
                    "Customers", customer);

                return result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> AddReservation(Reservations reservation)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "Reservation", reservation);

                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteReservation(int? id)
        {
            bool successful = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await client.DeleteAsync(
                    $"Reservation/{id}");
                successful = response.IsSuccessStatusCode;

            }

            return successful;
        }

        public async Task<bool> UpdateReservation(Reservations reservation)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage result = await client.PutAsJsonAsync(
                    "Reservation", reservation);

                return result.IsSuccessStatusCode;
            }
        }
    }
}
