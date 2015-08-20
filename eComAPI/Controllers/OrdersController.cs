using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eComAPI.Models;
using Newtonsoft.Json;


namespace eComAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private OrdersDBContext db = new OrdersDBContext();

        //public int Id { get; set; }
        //public int Product_Id { get; set; }
        //public int Order_Id { get; set; }
        //public int Quantity { get; set; }
        //public int OrderStatusId { get; set; }
        //public string Order_Date { get; set; }
        //public int UserId { get; set; }
        //public string LastUpdate { get; set; }

        // GET api/Orders
        public IQueryable<OrderDTO> GetOrders()
        {
            var orders = db.Orders.Select(o => new OrderDTO()
                {
                    Id = o.Id,
                    Product_Id = o.OrderLine.Product_Id,
                    Order_Id = o.OrderLine.Id,
                    Quantity = o.OrderLine.Quantity,
                    OrderStatusId = o.OrderStatusId,
                    Order_Date = o.OrderLine.Date.ToString(),
                    UserId = o.UserId,
                    LastUpdate = o.LastUpdate.ToString()
                });


            return orders;
        }

        // GET api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            var order = db.Orders.Select(o => new OrderDTO()
            {
                Id = o.Id,
                Product_Id = o.OrderLine.Product_Id,
                Order_Id = o.OrderLine.Id,
                Quantity = o.OrderLine.Quantity,
                OrderStatusId = o.OrderStatusId,
                Order_Date = o.OrderLine.Date.ToString(),
                UserId = o.UserId,
                LastUpdate = o.LastUpdate.ToString()
            }).SingleOrDefault(z => z.Id.Equals(id));

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT api/Orders/5
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {

            //dynamic jason
            //var deJason = JsonConvert.DeserializeObject<OrderDTO>(jason.ToString());
            //var jOrder = deJason.Content.ReadAsStringAsync().Result;

            //Order order = new Order();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }
    }
}