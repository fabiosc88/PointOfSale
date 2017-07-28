using System;
using System.Collections.Generic;

namespace PointOfSale.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {
            Products = new List<OrderProduct>();
        }

        public DateTime TimeStamp { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<OrderProduct> Products { get; set; }
    }
}
