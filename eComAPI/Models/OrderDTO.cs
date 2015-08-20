using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eComAPI.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Order_Id { get; set; }
        public int Quantity { get; set; }
        public int OrderStatusId { get; set; }
        public string Order_Date { get; set; }
        public int UserId { get; set; }
        public string LastUpdate { get; set; }

    }

    public class OrderLineDTO
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
    }
}