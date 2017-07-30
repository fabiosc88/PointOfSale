using System;
using System.Collections.Generic;

namespace PointOfSale.Domain.Entities
{
    public class Product : EntityBase
    {

        public string Name { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
