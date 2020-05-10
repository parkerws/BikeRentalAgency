using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;

namespace BikeRentalMVC.ViewModels
{
    public class ReservationCreateViewModel
    {
        public Customer Customer { get; set; }
        public Bikes Bike { get; set; } 
        public List<Accessories> Accessories { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        
    }
}
