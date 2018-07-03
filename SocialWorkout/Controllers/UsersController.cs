using MongoDB.Bson;
using MongoDB.Driver.Builders;
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
        public User Get(string Id)
        {
            var User = Context.Users.FindOneById(new ObjectId(Id));
            return User;
        }

        //public bool GetUserMAil(string email)
        //{
        //    bool answer = false;
        //    var search = Context.Users;
        //    var query = Query<User>.EQ(u => u.Email, email);

        //    if (query != null)
        //    {
        //        answer = true;
        //    }

        //    return answer;
        //}

        // POST: api/Users

        public void Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Insert(user);
            }
        }

        // PUT: api/Users/5
        public void Put([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Save(user);

            }
        }

        // DELETE: api/Users/5
        public void Delete(string id)
        {
            var user = Context.Users.Remove(Query.EQ("_id", new ObjectId(id)));
        }
    }
}
