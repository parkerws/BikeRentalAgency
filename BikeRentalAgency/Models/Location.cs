using System.ComponentModel.DataAnnotations;

namespace BikeRentalAgency.Models
{
    public class Location : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int Zip { get; set; }

        [Required]
        public string BranchEmail { get; set; }
    }
}