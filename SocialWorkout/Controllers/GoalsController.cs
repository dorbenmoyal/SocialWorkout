using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System;
using System.Web.Mvc;

namespace SocialWorkout.Controllers
{
    public class GoalsController : Controller
    {
        // GET: Goals




        public RootGoals GetRandomGoals()
        {
            Random rnd = new Random();
            RootGoals g = new RootGoals();

            g.goals = new Goals();

            g.goals.caloriesOut =  rnd.Next(500, 5000);
            g.goals.distance = rnd.Next(1, 12);
            g.goals.floors = rnd.Next(1, 25);
            g.goals.steps = rnd.Next(20, 30000);


            return g;

        }
    }
}