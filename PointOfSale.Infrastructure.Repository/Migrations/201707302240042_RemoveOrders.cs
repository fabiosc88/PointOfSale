namespace PointOfSale.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "PaymentMethod_Id", "dbo.PaymentMethod");
            DropForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.OrderProduct", new[] { "OrderId" });
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            DropIndex("dbo.Order", new[] { "PaymentMethod_Id" });
            DropTable("dbo.OrderProduct");
            DropTable("dbo.Order");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        PaymentMethod_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId });
            
            CreateIndex("dbo.Order", "PaymentMethod_Id");
            CreateIndex("dbo.OrderProduct", "ProductId");
            CreateIndex("dbo.OrderProduct", "OrderId");
            AddForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product", "Id");
            AddForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order", "Id");
            AddForeignKey("dbo.Order", "PaymentMethod_Id", "dbo.PaymentMethod", "Id");
        }
    }
}
