﻿using System.Web.Mvc;
using SocialWorkout.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace SocialWorkout.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBcontext Context = new DBcontext();

        public ActionResult Index(string uid)
        {
            var UsersList = Context.Users.FindAll();
            var User = Context.Users.FindOneById(new ObjectId(uid));
          
            // sum the prefrences of user
            double sum = User.preferens.AgePreference + User.preferens.GenderPreference + User.preferens.LocationPreference + User.preferens.RankPreference;

            List<string> Favorites = User.preferens.FavoriteSports;

            List<User> UpdatedUsers = new List<User>();
            //calculate euclidean distance between user to all other users
            foreach (var CurrentUser in UsersList)
            {
                bool favoriteFlag = false;
                if (CurrentUser.preferens != null)
                {
                    for (int i = 0; i < CurrentUser.preferens.FavoriteSports.Count; i++)
                    {
                        if (Favorites.Contains(CurrentUser.preferens.FavoriteSports[i]))
                        {
                            favoriteFlag = true;
                            break;
                        }
                    }

                    if (CurrentUser.Email != User.Email
                        && CurrentUser.Country.Equals(User.Country) && CurrentUser.preferens.Location.Equals(User.preferens.Location) && favoriteFlag)
                    {




                        double distanceAge = powNumber((CurrentUser.Age - User.Age)) * User.preferens.AgePreference / sum;
                        double distanceLocation = (double)((CheckValue(CurrentUser.preferens.Location, User.preferens.Location)) * User.preferens.LocationPreference / sum);
                        double distanceGender = (CheckValue(CurrentUser.Gender, User.Gender)) * User.preferens.GenderPreference / sum;
                        double distanceTime = (CheckTime(User.preferens.Morning, CurrentUser.preferens.Morning, User.preferens.Noon, CurrentUser.preferens.Noon, User.preferens.Evening, CurrentUser.preferens.Evening)
                            ) * User.preferens.RankPreference / sum;
                        double distance = System.Math.Sqrt(distanceAge + distanceLocation + distanceGender + distanceTime);



                        CurrentUser.distance = 100 - distance;
                        UpdatedUsers.Add(CurrentUser);

                    }
                }


            } 
            return View(UpdatedUsers);
        }

        public int CheckValue(string first,string second)
        {

            if (first.Equals(second))
            {
                return 0;

            }
            return 1;

        }

        public double powNumber(double number)
        {
            return number * number;
        }


        public int CheckTime(bool morningCU,bool morningUSER, bool eveningCU, bool eveningUSER, bool noonCU, bool noonUSER)
        {
            if (morningCU && morningUSER) { return 0; }
            if (eveningCU && eveningUSER) { return 0; }
            if (noonCU && noonUSER) { return 0; }


            return 1;

        }

    
        public ActionResult Home()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Details(string Id)
        {
            var User = Context.Users.FindOneById(new ObjectId(Id));

            return View(User);

        }

        public ActionResult friends()
        {

            return View();
        }
    }
}