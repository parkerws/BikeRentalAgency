using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeRentalAgency.Models
{
    public class Customer : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int Zip { get; set; }

        public List<Reservations> Reservations { get; set; }
    }
}