using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System.Web.Mvc;

namespace SocialWorkout.Controllers
{
    public class TrainerController : Controller
    {

        private readonly DBcontext Context = new DBcontext();

        [Filters.AutorizeAdmin]
        public ActionResult Index()
        {
            var Trainers = Context.Trainers.FindAll();
            return View(Trainers);
        }

        public ActionResult Create()
        {
            return View("Create");

        }
        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                Context.Trainers.Insert(trainer);
                return RedirectToAction("Index", "TrainerLogin");
            }
            return View();
        }

        public ActionResult Edit(string Id)
        {
            var Trainer = Context.Users.FindOneById(new ObjectId(Id));
            return View(Trainer);
        }

        [HttpPost]
        public ActionResult Edit(User _Trainer)
        {
            if (ModelState.IsValid)
            {
                Context.Trainers.Save(_Trainer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var Trainer = Context.Trainers.FindOneById(new ObjectId(Id));
            return View(Trainer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            var Trainer = Context.Trainers.Remove(Query.EQ("_id", new ObjectId(Id)));
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
