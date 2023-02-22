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
    public class AccountController : ControllerBase
    {
        // GET: api/Account
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            List<User> accounts = new List<User>();
            accounts = AccountService.GetAll();

            return accounts;
        }

        // POST api/Account
        [HttpPost]
        public IActionResult Post([FromBody] User newuser)
        {
            AccountService.Add(newuser);
            return CreatedAtAction(nameof(Post), new { username = newuser.username }, newuser);
        }

        // PUT api/Account/username
        [HttpPut("{username}")]
        public void Put(string username, [FromBody] User user)
        {
            AccountService.Update(username, user);
        }
    }
}
