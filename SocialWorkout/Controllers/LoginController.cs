using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialWorkout.Controllers
{
    public class LoginController : Controller
    {
        // DB connection
        private readonly DBcontext Context = new DBcontext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String email,String password)
        {
           
            // Check if User Is Administrator
            if (email == "admin@admin" && password == "admin")
            {
                User Admin = new User { Email = "admin@admin", Password = "admin" };

                Session.Add("Admin", Admin);
                return RedirectToAction("Index", "ControlPanel");
            }


            var search = Context.Users;
            var query = Query.And(
        Query<User>.EQ(u => u.Email, email),
        Query<User>.EQ(u => u.Password, password));
            User user = search.FindOne(query);

            if (user == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Invalid User Name Or Password!');</script>");
            }
            Session.Add("Customer", user);

            return RedirectToAction("Index", "Home");

        }
  
    
    }
}