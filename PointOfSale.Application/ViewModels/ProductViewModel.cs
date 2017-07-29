using PointOfSale.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PointOfSale.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
