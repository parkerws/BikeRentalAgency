using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;

namespace BikeRentalMVC.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<Reservations> Reservations { get; set; }
    }
}
