using System;
using System.Data.Entity;
using eComAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComAPI.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LastUpdate { get; set; }
        public int OrderStatusId { get; set; }

        public virtual OrderLine OrderLine { get; set; }
    }

    public class OrdersDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

    }
}