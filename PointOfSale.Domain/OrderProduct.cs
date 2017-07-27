using PointOfSale.Domain.Entities;
using System;

namespace PointOfSale.Domain
{
    public class OrderProduct
    {
        public int Amount { get; set; }
        public decimal Total { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
