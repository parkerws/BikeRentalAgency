using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Context;
using BikeRentalAgency.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly BikeRentalContext _context;

        public AdminController(BikeRentalContext context)
        {
            _context = context;
        }

        //GET: Bikes
        [HttpGet("Bikes")]
        public async Task<ActionResult<IEnumerable<Bikes>>> GetBikes()
        {

            var bikes = _context.Bikes.OrderBy(x => x.Id);
            return await bikes.ToListAsync();
        }

        [HttpGet("Bikes/{id}")]
        public async Task<ActionResult<Bikes>> GetBike(int id)
        {

            var bike = await _context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }
            return bike;
        }

        [HttpGet("Locations")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = _context.Locations.OrderBy(x => x.City);
            return await locations.ToListAsync();
        }

        //GET: Customers
        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = _context.Customers.OrderBy(x => x.FirstName);
            return await customers.ToListAsync();
        }

        [HttpGet("Customers/{id}")]
        public async Task<ActionResult<Employees>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }


        [HttpPost("Bikes")]
        public async Task<ActionResult> CreateBike(Bikes bike)
        {
            _context.Bikes.Add(bike);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBike", new { id = bike.Id }, bike);
        }

        [HttpPost("Customers")]
        public async Task<ActionResult> CreateCustomer(Employees employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpDelete("Bikes/{id}")]
        public async Task<ActionResult<Bikes>> DeleteBike(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bike);
            await _context.SaveChangesAsync();

            return bike;
        }

        [HttpDelete("Customers/{id}")]
        public async Task<ActionResult<Employees>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool BikeExists(int id)
        {
            return _context.Bikes.Any(x => x.Id == id);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Customers.Any(x => x.Id == id);
        }
    }
}