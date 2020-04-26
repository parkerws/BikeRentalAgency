using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRentalAgency.Context;
using BikeRentalAgency.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly BikeRentalContext _context;

        public ReservationController(BikeRentalContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservationByCustomerId(int id)
        {
            var reservationList = await _context.Reservations.Where(x => x.CustomerId == id).ToListAsync();

            if (reservationList == null)
            {
                return NotFound();
            }

            return reservationList;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservation(int id)
        {
            var reservations = await _context.Reservations.FindAsync(id);

            if (reservations == null)
            {
                return NotFound();
            }

            return reservations;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservations reservations)
        {
            if (id != reservations.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservations

        [HttpPost]
        public async Task<ActionResult<Reservations>> PostReservation(Reservations reservations)
        {

            
            _context.Reservations.Add(reservations);
            

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservations.Id }, reservations);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservations>> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
