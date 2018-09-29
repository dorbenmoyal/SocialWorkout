using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class DBcontext
    {
        //For Best practice, Please put this in the web.config. This is only for demo purpose.
        //====================================================
        public String connectionString = "mongodb://ProjectSport:Ss123123@ds036617.mlab.com:36617/socialworkout";
        public String DataBaseName = "socialworkout";
        //====================================================

        public MongoDatabase Database;

        public DBcontext()
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            Database = server.GetDatabase(DataBaseName);
        }

        public MongoCollection<Country> Countries
        {
            get
            {
                var Countries = Database.GetCollection<Country>("Countries");

                return Countries;
            }
        }

        public MongoCollection<User> Users
        {
            get
            {
                var Users = Database.GetCollection<User>("Users");

                return Users;
            }
        }
        public MongoCollection<Data> Data
        {
            get
            {
                var DATA = Database.GetCollection<Data>("Data");

                return DATA;
            }
        }
        public MongoCollection<Trainer> Trainers
        {
            get
            {
                var Trainers = Database.GetCollection<Trainer>("Trainer");

                return Trainers;
            }
        }
        public MongoCollection<EventLine> Events
        {
            get
            {
                var events = Database.GetCollection<EventLine>("EventLine");

                return events;
            }
        }
        public MongoCollection<ContactUs> ContactUs
        {
            get
            {
                var ContactUs = Database.GetCollection<ContactUs>("ContactUs");

                return ContactUs;
            }
        }

        public MongoCollection<Survey> Survey
        {
            get
            {
                var Survey = Database.GetCollection<Survey>("Survey");

                return Survey;
            }
        }
    }

}