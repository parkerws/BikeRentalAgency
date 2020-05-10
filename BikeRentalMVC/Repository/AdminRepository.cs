using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BikeRentalMVC.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private string baseUrl = "https://localhost:44305/api/admin/";

        public async Task<List<Bikes>> GetBikes()
        {
            List<Bikes> bikes = new List<Bikes>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("GetBikes");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    bikes = JsonConvert.DeserializeObject<List<Bikes>>(response);
                }

                return bikes;
            }
        }

        public async Task<List<SelectListItem>> GetLocations(int? id)
        {
            List<SelectListItem> location = new List<SelectListItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"Locations");

                if (res.IsSuccessStatusCode)
                {
                    var list = new List<Location>();
                    var response = res.Content.ReadAsStringAsync().Result;

                    list = JsonConvert.DeserializeObject<List<Location>>(response);

                    foreach (var item in list)
                    {
                        var selected = id.HasValue && item.Id == id.Value;
                        location.Add(new SelectListItem {Text = item.City, Value = item.Id.ToString(), Selected = selected});
                    }
                }

                return location;
            }
        }

        public async Task<List<Employees>> GetEmployees()
        {
            List<Employees> employees = new List<Employees>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"Employees");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    employees = JsonConvert.DeserializeObject<List<Employees>>(response);
                }

                return employees;
            }
        }

        public async Task<Bikes> GetBike(int? bikeId)
        {
            Bikes bike = new Bikes();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync($"Bikes?={bikeId}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    bike = JsonConvert.DeserializeObject<Bikes>(response);
                }
            }

            return bike;
        }

        public async Task<Employees> GetEmployee(int? employeeId)
        {
            Employees emp = new Employees();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync($"Employees?={employeeId}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    emp = JsonConvert.DeserializeObject<Employees>(response);
                }
            }

            return emp;
        }

        public async Task<bool> AddBike(Bikes bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "Bikes", bike);

                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteBike(int? id)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await client.DeleteAsync(
                    $"Bikes?id={id}");
                succeeded = response.IsSuccessStatusCode;
            }

            return succeeded;
        }

        public async Task<bool> AddEmployee(Employees employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "Employees", employee);

                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteEmployee(int? id)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await client.DeleteAsync(
                    $"Employees?id={id}");
                succeeded = response.IsSuccessStatusCode;
            }

            return succeeded;
        }

        public async Task<bool> UpdateBike(Bikes bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage result = await client.PutAsJsonAsync(
                    $"Bikes/{bike.Id}", bike);

                return result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdateEmployee(Employees employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage result = await client.PutAsJsonAsync(
                    $"Employees/{employee.Id}", employee);
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
