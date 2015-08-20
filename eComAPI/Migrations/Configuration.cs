namespace ecomAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using eComAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<eComAPI.Models.OrdersDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eComAPI.Models.OrdersDBContext context)
        {

            context.Orders.AddOrUpdate(o => o.Id,
                new Order() { Id = 1, UserId = 1, LastUpdate = DateTime.Now, OrderStatusId = 1 },
                new Order() { Id = 2, UserId = 1, LastUpdate = DateTime.Now, OrderStatusId = 1 },
                new Order() { Id = 3, UserId = 2, LastUpdate = DateTime.Now, OrderStatusId = 1 },
                new Order() { Id = 4, UserId = 1, LastUpdate = DateTime.Now, OrderStatusId = 1 }
                
                );

            context.OrderLines.AddOrUpdate(z => z.Id,
                new OrderLine { Id = 1, Order_Id = 1, Date = DateTime.Now, Product_Id = 1, Quantity = 10 },
                new OrderLine { Id = 2, Order_Id = 4, Date = DateTime.Now, Product_Id = 2, Quantity = 5 },
                new OrderLine { Id = 3, Order_Id = 1, Date = DateTime.Now, Product_Id = 1, Quantity = 10 },
                new OrderLine { Id = 4, Order_Id = 3, Date = DateTime.Now, Product_Id = 2, Quantity = 5 }
                ); 
        }
    }
}
