using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Context;
using BikeRentalAgency.Models;
using BikeRentalAgency.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminRepository adminRepository;

        public AdminController(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;
        }

        //GET: Bikes
        [HttpGet("GetBikes")]
        public async Task<IActionResult> GetBikes()
        {
            try
            {
                var bikes = await adminRepository.GetBikes();
                if (bikes == null)
                {
                    return NotFound();
                }

                return Ok(bikes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("GetBike/{id}")]
        public async Task<IActionResult> GetBike(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var bike = await adminRepository.GetBike(id);

                if (bike == null)
                {
                    return NotFound();
                }

                return Ok(bike);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Locations")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await adminRepository.GetLocations();
                if (locations == null)
                {
                    return NotFound();
                }

                return Ok(locations);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //GET: Customers
        [HttpGet("Employees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = adminRepository.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            } 
        }

        [HttpGet("Employees/{id}")]
        public async Task<ActionResult<Employees>> GetEmployee(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var employee = await adminRepository.GetEmployee(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("Bikes")]
        public async Task<IActionResult> AddBike([FromBody]Bikes bike)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bikeId = await adminRepository.AddBike(bike);
                    if (bikeId > 0)
                    {
                        return Ok(bikeId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPost("Customers")]
        public async Task<IActionResult> AddCustomer([FromBody]Employees employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await adminRepository.AddEmployee(employee);
                    if (empId > 0)
                    {
                        return Ok(empId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpDelete("Bikes/{id}")]
        public async Task<IActionResult> DeleteBike(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await adminRepository.DeleteBike(id);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Customers/{id}")]
        public async Task<ActionResult<Employees>> DeleteEmployee(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await adminRepository.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Bikes")]
        public async Task<IActionResult> UpdateBike([FromBody] Bikes bike)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await adminRepository.UpdateBike(bike);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
        [HttpPut("Employees")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employees employees)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await adminRepository.UpdateEmployee(employees);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}