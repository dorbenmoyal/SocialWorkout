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
    public class dropDownDataController : ApiController
    {

        private readonly DBcontext Context = new DBcontext();
        // GET: api/Users
        public IEnumerable<dropDownData> Get()
        {
            return Context.dropDownData.FindAll();
        }



        public void Post([FromBody] dropDownData data)
        {
            if (ModelState.IsValid)
            {
                Context.dropDownData.Insert(data);
            }
        }

        // PUT: api/Users/5
        public void Put([FromBody]dropDownData data)
        {
            if (ModelState.IsValid)
            {
                Context.dropDownData.Save(data);

            }
        }

        // DELETE: api/Users/5
        public void Delete(string id)
        {
            var data = Context.dropDownData.Remove(Query.EQ("_id", new ObjectId(id)));
        }
    }



}



