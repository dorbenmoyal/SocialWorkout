using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialWorkout.Models;
using SocialWorkout.Models;

namespace SocialWorkout.Controllers
{

    [Filters.AutorizeAdmin]

    public class ControlPanelController : Controller
    {
     


        private readonly DBcontext database = new DBcontext();

        
        public ActionResult Index()
        {
         
        

            ControlPanelViewModel CPVM = new ControlPanelViewModel();


            CPVM.Users = database.Users.FindAll();

            CPVM.Trainers = database.Trainers.FindAll();

            CPVM.events = database.Events.FindAll();




            return View(CPVM);
        }
    }
}