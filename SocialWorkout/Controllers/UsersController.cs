﻿using Microsoft.AspNetCore.Http;
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
    public class UsersController : ApiController
    {

        private readonly DBcontext Context = new DBcontext();


      
        [HttpPost]
        [Route("api/Users/ReciveMassage")]
        public void ReciveMassage(MailMassageContent mail) {

            User fromUser = Get(mail.SenderID);
            User ToUser = Get(mail.ReciverID);

            Message m = new Message() { Massage = mail.Massage, SenderUserID = fromUser.Id,SenderUserEmail=fromUser.Email,SenderUserName= fromUser.FirstName };

            if (ToUser.mailBox == null) {

                ToUser.mailBox = new MailBox();

                List<Message> messageList = new List<Message>();

                messageList.Add(m);

                ToUser.mailBox.UserMessages = messageList;

                Context.Users.Save(ToUser);

            }
            else
            {
                ToUser.mailBox.UserMessages.Add(m);
                Context.Users.Save(ToUser);

            }

        }


        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Context.Users.FindAll();
        }

        // [Route("api/getU")]

        // GET: api/Users/{MongoId}
        public User Get(string Id)
        {
            var User = Context.Users.FindOneById(new ObjectId(Id));
            return User;
        }



        [HttpPost]
        public void Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Insert(user);
            }
        }



        // PUT: api/Users/5
        [HttpPut]
        public void Put([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Save(user);

            }
        }


        // DELETE: api/Users/5
        [HttpPost]
        [Route("api/Users/DeleteMe")]
        public void Delete(string id)
        {
            Context.Users.Remove(Query.EQ("_id", new ObjectId(id)));
        }

        [HttpPost]
        [Route("api/Users/ReciveEvent")]
        public void GetMatchedUsers(Event obj)
        {

            User one = Get(obj.userId);

            switch (obj.EventName)
            {
                case "Event1": {
                        string event1 ="playing With mosh";

                        string line1 = one.FirstName + " " + one.LastName + " " + "Is going to " + event1;

                        EventLine ev = new EventLine() { line = line1 };
                        Context.Events.Insert(ev);

                        return;
                        }

                case "Event2":
                    {
                        string event2 = "playing Socker With Tzach";

                        string line2 = one.FirstName + " " + one.LastName + " " + "Is going to " + event2;
                        EventLine ev = new EventLine() { line = line2 };
                        Context.Events.Insert(ev);

                        return;
                    }
                


                case "Event3":
                    {
                        string event3 = "Swimming With Adi";

                        string line3 = one.FirstName + " " + one.LastName + " " + "Is going to " + event3;
                        EventLine ev = new EventLine() { line = line3 };
                        Context.Events.Insert(ev);

                        return;
                    }



            }




        }


    }


}
