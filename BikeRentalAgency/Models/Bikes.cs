using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRentalAgency.Models
{
    public enum BikeTypes
    {
        BeachCruiser,
        MountainBike,
        RoadBike,
        ElectricBike,
        TandemBike
    }

    public enum FrameSize
    {
        Small,
        Medium,
        Large
    }

    public class Bikes : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public FrameSize Frame{ get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public BikeTypes type { get; set; }

        [Required]
        public bool OnHire { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
    }
}
