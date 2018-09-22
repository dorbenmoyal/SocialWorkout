using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System.Web.Mvc;

namespace SocialWorkout.Controllers
{
    public class UserController : Controller
    {

        private readonly DBcontext Context = new DBcontext();

        [Filters.AutorizeAdmin]
        public ActionResult Index()
        {
            var Users = Context.Users.FindAll();
            return View(Users);
        }

        public ActionResult Create()
        {
            return View("SignUp");

        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Insert(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult Edit(string Id)
        {
            var User = Context.Users.FindOneById(new ObjectId(Id));
            return View(User);
        }

        [HttpPost]
        public ActionResult Edit(User _User)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Save(_User);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var rental = Context.Users.FindOneById(new ObjectId(Id));
            return View(rental);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            var rental = Context.Users.Remove(Query.EQ("_id", new ObjectId(Id)));
            return RedirectToAction("Index");
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

        public ActionResult Tryto()
        {
            return View();
        }
    }
}