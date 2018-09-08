using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class EventLine
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public string line { get; set; }

    }
}