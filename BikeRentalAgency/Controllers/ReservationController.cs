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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ICustomerRepository repo;

        public ReservationController(ICustomerRepository _customerRepository)
        {
            repo = _customerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> GetReservations()
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
        public async Task<IActionResult> GetCustomerReservation(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var reservation = await repo.GetCustomerReservation(id);
                if (reservation == null)
                {
                    return NotFound();
                }

                return Ok(reservation);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> UpdateReservation([FromBody] Reservations reservation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repo.UpdateReservation(reservation);
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
        public async Task<IActionResult> AddReservation([FromBody] Reservations reservations)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resId = await repo.AddReservation(reservations);
                    if (resId > 0)
                    {
                        return Ok(resId);
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
        public async Task<IActionResult> DeleteReservation(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repo.DeleteReservation(id);
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
