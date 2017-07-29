using PointOfSale.Domain.Entities;
using System;

namespace PointOfSale.Application.ViewModels
{
    public class OrderProductViewModel
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
