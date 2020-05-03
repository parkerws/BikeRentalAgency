using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRentalAgency.Context;
using BikeRentalAgency.Models;
using BikeRentalAgency.Repository;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository repo;

        public CustomersController(ICustomerRepository _customerRepository)
        {
            repo = _customerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await repo.GetCustomers();
                if (customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var customer = await repo.GetCustomer(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Customer")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repo.UpdateCustomer(customer);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var custId = await repo.AddCustomer(customer);
                    if (custId > 0)
                    {
                        return Ok(custId);
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

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repo.DeleteCustomer(id);
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

    }
}
