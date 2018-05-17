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

        public MongoCollection<Country> Countriess
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
                var Countries = Database.GetCollection<Country>("Users");

                return Users;
            }
        }
    }

}