using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgency.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set;  }
        public string State { get; set; }
        public int Zip { get; set; }
        public int? ReservationId { get; set; }
        public string ReservationDate { get; set; }
    }
}
