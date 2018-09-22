using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class ContactUs


    {

        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }


        public string  UserEmail { get; set; }

        public string Message { get; set; }

    }
}