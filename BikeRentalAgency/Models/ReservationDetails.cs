using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgency.Models
{
    public class ReservationDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Reservations")]
        public int ReservationId { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }

        [ForeignKey("Bikes")]
        public int BikeId { get; set; }
    }
}
