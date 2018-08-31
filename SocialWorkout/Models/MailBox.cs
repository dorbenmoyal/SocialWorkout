using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class MailBox
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

       public List <Message> UserMessages { get; set; }
    
    }


    public class MailMassageContent
    {

        [Required]
        public string SenderID{ get; set; }

        [Required]
        public string Massage { get; set; }

        [Required]
        public string ReciverID { get; set; }




    }

    public class Message
    {

        public string SenderUserID { get; set; }
        public string SenderUserName { get; set; }
        public string SenderUserEmail { get; set; }
        public string Massage { get; set; }


    }
}