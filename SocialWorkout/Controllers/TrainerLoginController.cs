using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialWorkout.Controllers
{
    public class TrainerLoginController : Controller
    {
        private readonly DBcontext Context = new DBcontext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String email, String password)
        {

            // Check if User Is Administrator
            if (email == "admin@admin" && password == "admin")
            {
                User Admin = new User { Email = "admin@admin", Password = "admin" };

                Session.Add("Admin", Admin);
                return RedirectToAction("Index", "ControlPanel");
            }


            var search = Context.Trainers;
            var query = Query.And(
        Query<Trainer>.EQ(u => u.Email, email),
        Query<Trainer>.EQ(u => u.Password, password));
            Trainer trainer = search.FindOne(query);

            if (trainer == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Invalid User Name Or Password!');</script>");
            }


            if (trainer.FavoriteSports == null)
            {
                string uid = trainer.Id;
                return RedirectToAction("WizardTrainer", new { userObjectId = uid });
            }

            Session.Add("Trainer", trainer.Id);

            return RedirectToAction("Index", "Home", new { uid = trainer.Id });

        }

        public ActionResult WizardTrainer(string userObjectId)
        {

            ViewBag.TrainerId = userObjectId;

            return View();

        }


    }
}
