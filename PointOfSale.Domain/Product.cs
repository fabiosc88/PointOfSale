namespace PointOfSale.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
    }
}
