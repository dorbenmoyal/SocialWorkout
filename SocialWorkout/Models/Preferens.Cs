using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class Preferens
    {
      


        
        public bool Specialization { get; set; }


        public String PreferedTime { get; set; }


        public String Description { get; set; }


    }
}