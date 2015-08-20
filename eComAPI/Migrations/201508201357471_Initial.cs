namespace ecommerceAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        OrderLine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderLines", t => t.OrderLine_Id)
                .Index(t => t.OrderLine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderLine_Id", "dbo.OrderLines");
            DropIndex("dbo.Orders", new[] { "OrderLine_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
        }
    }
}
