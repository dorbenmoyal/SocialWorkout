using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using SocialWorkout.Models;

namespace SocialWorkout.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        [Required(ErrorMessage = "Please enter your Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your First name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your LastName.")]
        public string LastName { get; set; }

        public int Age { get; set; }

     
        public string Country { get; set; }

        public string Gender { get; set; }

       public string ImgSrc { get; set; }


        public Preferens preferens { get; set; }

        public double distance { get; set; }

        public MailBox mailBox { get; set; }

        
    }
}