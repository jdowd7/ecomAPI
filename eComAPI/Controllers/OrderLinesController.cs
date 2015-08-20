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

namespace eComAPI.Controllers
{
    public class OrderLinesController : ApiController
    {
        private OrdersDBContext db = new OrdersDBContext();

        // GET api/OrderLines
        public IQueryable<OrderLine> GetOrderLines()
        {
            return db.OrderLines;
        }

        // GET api/OrderLines/5
        [ResponseType(typeof(OrderLine))]
        public IHttpActionResult GetOrderLine(int id)
        {
            OrderLine orderline = db.OrderLines.Find(id);
            if (orderline == null)
            {
                return NotFound();
            }

            return Ok(orderline);
        }

        // PUT api/OrderLines/5
        public IHttpActionResult PutOrderLine(int id, OrderLine orderline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderline.Id)
            {
                return BadRequest();
            }

            db.Entry(orderline).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
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

        // POST api/OrderLines
        [ResponseType(typeof(OrderLine))]
        public IHttpActionResult PostOrderLine(OrderLine orderline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderLines.Add(orderline);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderline.Id }, orderline);
        }

        // DELETE api/OrderLines/5
        [ResponseType(typeof(OrderLine))]
        public IHttpActionResult DeleteOrderLine(int id)
        {
            OrderLine orderline = db.OrderLines.Find(id);
            if (orderline == null)
            {
                return NotFound();
            }

            db.OrderLines.Remove(orderline);
            db.SaveChanges();

            return Ok(orderline);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderLineExists(int id)
        {
            return db.OrderLines.Count(e => e.Id == id) > 0;
        }
    }
}