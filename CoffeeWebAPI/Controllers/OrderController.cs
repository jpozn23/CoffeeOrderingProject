using CoffeeWebAPI.Classes;
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
        public ActionResult<List<UserOrder>> Get()
        {
            List<UserOrder> orders = new List<UserOrder>();
            orders = OrderService.GetAll();

            return orders;
        }

        // GET: api/Order/username
        [HttpGet("{username}")]
        public ActionResult<List<UserOrder>> Get(string username)
        {
            List<UserOrder> userorders = new List<UserOrder>();
            foreach (UserOrder order in OrderService.GetAll())
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
        public ActionResult<List<UserOrder>> Get(string username, Guid orderid)
        {
            List<UserOrder> userorders = new List<UserOrder>();
            UserOrder order = OrderService.Get(orderid);
            userorders.Add(order);

            return userorders;
        }

        // POST api/Order
        [HttpPost]
        public IActionResult Post([FromBody] UserOrder neworder)
        {
            OrderService.Add(neworder);
            return CreatedAtAction(nameof(Post), new { id = neworder.id }, neworder);
        }


        // PUT api/<GolfController>/5
        [HttpPut("{username}/{orderid}")]
        public void Put(string username, Guid id, [FromBody] UserOrder order)
        {
            OrderService.Update(id, order);
        }

    }
}
