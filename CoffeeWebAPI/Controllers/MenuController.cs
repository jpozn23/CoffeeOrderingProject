using CoffeeWebAPI.Classes;
using CoffeeWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GET: api/Menu
        [HttpGet]
        public ActionResult<List<DrinkItem>> Get()
        {
            List<DrinkItem> menuitems = new List<DrinkItem>();
            menuitems = MenuService.GetAll();

            return menuitems;
        }

        // GET: api/Menu/itemname
        [HttpGet("{itemname}")]
        public ActionResult<List<DrinkItem>> Get(string itemname)
        {
            List<DrinkItem> items = new List<DrinkItem>();
            DrinkItem item = MenuService.Get(itemname);
            items.Add(item);

            return items;
        }

        // POST api/Menu
        [HttpPost]
        public IActionResult Post([FromBody] DrinkItem item)
        {
            MenuService.Add(item);
            return CreatedAtAction(nameof(Post), new { name = item.name }, item);
        }

        // PUT api/Menu/itemname
        [HttpPut("{itemname}")]
        public void Put(string itemname, [FromBody] DrinkItem item)
        {
            MenuService.Update(itemname, item);
        }


    }
}

