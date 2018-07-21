using MongoDB.Bson;
using MongoDB.Driver;
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
   
    public class DataController : ApiController
    {

        private readonly DBcontext Context = new DBcontext();

        [Route("api/FavoriteSports")]
        public IEnumerable<Data> Get()
        {
            var search = Context.Data;
            var query = Query<Data>.EQ(d => d.header, "FavoriteSports");
            MongoCursor<Data> cursor = search.Find(query);
            return cursor;
        }



        public void Post([FromBody] Data data)
        {
            if (ModelState.IsValid)
            {
                Context.Data.Insert(data);
            }
        }

       
        public void Put([FromBody]Data data)
        {
            if (ModelState.IsValid)
            {
                Context.Data.Save(data);

            }
        }

       
        public void Delete(string id)
        {
          Context.Data.Remove(Query.EQ("_id", new ObjectId(id)));
        }
    }



}



