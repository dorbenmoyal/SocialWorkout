using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class Trainer
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

        public String Description { get; set; }

        public List<string> Sports { get; set; }




    }
}