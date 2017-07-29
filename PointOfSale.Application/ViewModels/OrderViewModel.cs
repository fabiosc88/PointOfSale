using PointOfSale.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PointOfSale.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
