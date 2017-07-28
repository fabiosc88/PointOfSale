namespace PointOfSale.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsPriceToOrderProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProduct", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.OrderProduct", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderProduct", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OrderProduct", "Price");
        }
    }
}
