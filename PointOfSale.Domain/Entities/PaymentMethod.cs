using System.Collections.Generic;

namespace PointOfSale.Domain.Entities
{
    public class PaymentMethod : EntityBase
    {
        public PaymentMethod()
        {
            Orders = new List<Order>();
        }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
