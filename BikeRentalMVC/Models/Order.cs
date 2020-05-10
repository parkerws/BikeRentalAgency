using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;

namespace BikeRentalMVC.Models
{
    public class Order
    {
        private List<OrderLine> lineCollection = new List<OrderLine>();

        public virtual void AddBike(Bikes? bike, Accessories? acc)
        {

            if (bike != null)
            {
                OrderLine line = lineCollection
                    .FirstOrDefault(p => p.Bike.Id == bike.Id);
                lineCollection.Add(new OrderLine
                {
                    Bike = bike
                });
            }

            if (acc != null)
            {
                OrderLine line = lineCollection
                    .FirstOrDefault(p => p.Accessory.Id == acc.Id);
                lineCollection.Add(new OrderLine
                {
                    Accessory = acc
                });
            }

        }

        public virtual void AddAccessory(Accessories accessory)
        {
            OrderLine line = lineCollection
                .FirstOrDefault(p => p.Accessory.Id == accessory.Id);

            if (line == null)
            {
                lineCollection.Add(new OrderLine
                {
                    Accessory = accessory
                });
            }
        }

        public virtual void RemoveLine(Bikes bike) =>
            lineCollection.RemoveAll(l => l.Bike.Id == bike.Id);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<OrderLine> Lines => lineCollection;
    }

    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public Bikes? Bike { get; set; }
        public Accessories? Accessory { get; set; }

    }
}
