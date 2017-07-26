using System;
using System.Collections.Generic;

namespace PointOfSale.Domain.Entities
{
    public class Order : EntityBase
    {
        public List<Product> Products { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
