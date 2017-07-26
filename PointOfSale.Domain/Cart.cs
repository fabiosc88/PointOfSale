using System.Collections.Generic;

namespace PointOfSale.Domain.Entities
{
    public class Cart : EntityBase
    {
        public List<Product> Products { get; set; }
    }
}
