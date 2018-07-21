using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
namespace SocialWorkout.Controllers
{
    public class UsersController : ApiController
    {

        private readonly DBcontext Context = new DBcontext();
       
        
        
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Context.Users.FindAll();
        }

       // [Route("api/getU")]

        // GET: api/Users/{MongoId}
        public User Get(string Id)
        {
            var User = Context.Users.FindOneById(new ObjectId(Id));
            return User;
        }



        [HttpPost]
        public void Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Insert(user);
            }
        }



        // PUT: api/Users/5
        [HttpPut]
        public void Put([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Save(user);

            }
        }


        // DELETE: api/Users/5
        [HttpDelete]
        public void Delete(string id)
        {
           Context.Users.Remove(Query.EQ("_id", new ObjectId(id)));
        }
    }
}
