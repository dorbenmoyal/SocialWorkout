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
    public class ContactUsController : ApiController
    {
        private readonly DBcontext Context = new DBcontext();

        [HttpPost]
        [Route("api/ContactUs/ReciveContactUs")]
        public void ReciveMassage(ContactUs contact)
        {

            Context.ContactUs.Insert(contact);

        }

 

    }
}
