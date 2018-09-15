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
    public class TrainersController : ApiController
    {

        private readonly DBcontext Context = new DBcontext();


        public Trainer Get(string Id)
        {
            var Trainer = Context.Trainers.FindOneById(new ObjectId(Id));
            return Trainer;
        }



        [HttpPost]
        public void Post([FromBody] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                Context.Trainers.Insert(trainer);
            }
        }



        // PUT: api/Users/5
        [HttpPut]
        public void Put([FromBody]Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                Context.Trainers.Save(trainer);

            }
        }
    }
}
