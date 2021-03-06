﻿using MongoDB.Bson;
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

        public string Description { get; set; }

        public string Gender { get; set; }

        public string location { get; set; }

        public int Age { get; set; }

        public int Price { get; set; }

        public List<string> FavoriteSports { get; set; }

        public bool Morning { get; set; }

        public bool Evening { get; set; }

        public bool Noon { get; set; }

        public string ImgSrc { get; set; }

        public MailBox mailBox { get; set; }

        public List <string> UsersJoined { get; set; }


    }
}