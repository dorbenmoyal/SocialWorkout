using System.Web.Mvc;
using SocialWorkout.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace SocialWorkout.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBcontext Context = new DBcontext();

        public ActionResult Index()
        {
         
            return View();
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


        public ActionResult tryMap()
        {

            return View();
        }

        public ActionResult tryLayout()
        {

            return View();
        }
    }
}