using System.Collections.Generic;

namespace PointOfSale.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            Orders = new List<OrderProduct>();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderProduct> Orders { get; set; }
    }
}
