using System.Collections.Generic;

namespace PointOfSale.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
