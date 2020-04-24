using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgency.Models
{
    public enum BikeAccessories
    {
        Helmet,
        Trailer,
        Basket,
        Flashlight,
        Tirepump,
        Repairkit
    }

    public class Accessories
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [Required]
        public BikeAccessories Accessory { get; set; }
    }
}
