using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System.Web.Mvc;


namespace SocialWorkout.Controllers
{
    public class ContactUsCController : Controller
    {
        private readonly DBcontext Context = new DBcontext();


        public ActionResult Index()
        {
            var ContactUsList = Context.ContactUs.FindAll();
            return View(ContactUsList);
        }

        public ActionResult Edit(string Id)
        {
            var contactForm = Context.ContactUs.FindOneById(new ObjectId(Id));
            return View(contactForm);
        }

        [HttpPost]
        public ActionResult Edit(ContactUs contactus)
        {
            if (ModelState.IsValid)
            {
                Context.ContactUs.Save(contactus);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var contact = Context.ContactUs.FindOneById(new ObjectId(Id));
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            var contact = Context.ContactUs.Remove(Query.EQ("_id", new ObjectId(Id)));
            return RedirectToAction("Index");
        }
    }
}