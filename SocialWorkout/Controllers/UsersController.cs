using SocialWorkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialWorkout.Controllers
{
    public class UsersController : ApiController
    {

        private readonly DBcontext Context = new DBcontext();
        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return Context.Users.FindAll();
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
      
        public void Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Insert(user);
            }
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
