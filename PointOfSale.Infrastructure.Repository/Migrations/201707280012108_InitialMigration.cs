namespace PointOfSale.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30, unicode: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Category_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Amount = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        PaymentMethod_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethod_Id)
                .Index(t => t.PaymentMethod_Id);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "PaymentMethod_Id", "dbo.PaymentMethod");
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropIndex("dbo.Order", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            DropIndex("dbo.OrderProduct", new[] { "OrderId" });
            DropIndex("dbo.Product", new[] { "Category_Id" });
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Order");
            DropTable("dbo.OrderProduct");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
