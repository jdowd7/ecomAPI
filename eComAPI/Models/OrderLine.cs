using System;
using System.Data.Entity;
using eComAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComAPI.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        //[ForeignKey("Order")]
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }

    }
}