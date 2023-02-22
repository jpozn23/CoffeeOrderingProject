using CoffeeOrderingApp.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/Order
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            List<Order> orders = new List<Order>();
            orders = OrderService.GetAll();

            return orders;
        }

        // GET: api/Order/username
        [HttpGet("{username}")]
        public ActionResult<List<Order>> Get(string username)
        {
            List<Order> userorders = new List<Order>();
            foreach (Order order in OrderService.GetAll())
            {
                if (order.userName == username)
                {
                    userorders.Add(order);
                }
            }

            return userorders;
        }

        // GET: api/Order/username/orderid
        [HttpGet("{username}/{orderid}")]
        public ActionResult<List<Order>> Get(string username, Guid orderid)
        {
            List<Order> userorders = new List<Order>();
            Order order = OrderService.Get(orderid);
            userorders.Add(order);

            return userorders;
        }

        // POST api/Order
        [HttpPost]
        public IActionResult Post([FromBody] Order neworder)
        {
            OrderService.Add(neworder);
            return CreatedAtAction(nameof(Post), new { id = neworder.id }, neworder);
        }


        // PUT api/Order/username/orderid
        [HttpPut("{username}/{orderid}")]
        public void Put(string username, Guid orderid, [FromBody] Order order)
        {
            OrderService.Update(orderid, order);
        }

    }
}
