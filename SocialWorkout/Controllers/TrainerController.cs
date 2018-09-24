using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SocialWorkout.Models;
using System.Collections.Generic;
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
            var Trainer = Context.Trainers.FindOneById(new ObjectId(Id));
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

        public ActionResult Home(string uid)
        {
            List<User> UpdatedUsers = new List<User>();


            Trainer currentTrainer = Context.Trainers.FindOneById(new ObjectId(uid));

            var UsersList = Context.Users.FindAll();

            if (currentTrainer.UsersJoined != null) {

            foreach (var user in UsersList)
            {

                if (currentTrainer.UsersJoined.Contains(user.Id))
                {
                    UpdatedUsers.Add(user);
                }

            }


            }


            return View(UpdatedUsers);
        }

        public ActionResult ShowMesagges(string uid)
        {
            
            var Trainer = Context.Trainers.FindOneById(new ObjectId(uid));


            if (Trainer.mailBox == null || Trainer.mailBox.UserMessages.Count == 0)
            {
                return View("MailBoxEmpty");
            }


            List<Message> UserMessages = Trainer.mailBox.UserMessages;




            return View(UserMessages);
        }

        public ActionResult Events()
        {
            var AllEvents = Context.Events.FindAll();

            return View(AllEvents);
        }

        public ActionResult DeleteMessage(string Massage, string SenderUserID)
        {
            var Trainers = Context.Trainers.FindAll();
            string currentUserMail = null;
            foreach (var user in Trainers)
            {
                var mailBox = user.mailBox;
                if (mailBox != null)
                {
                    var mailBoxMessagesList = mailBox.UserMessages;
                    foreach (var message in mailBoxMessagesList)
                    {
                        if (message.Massage == Massage && message.SenderUserID == SenderUserID)
                        {
                            mailBoxMessagesList.Remove(message);
                            user.mailBox.UserMessages = mailBoxMessagesList;
                            Context.Trainers.Save(user);
                            currentUserMail = user.Id;
                            break;
                        }
                    }
                }

            }
            return RedirectToAction("ShowMesagges", new { uid = currentUserMail });

        }

        public ActionResult Details(string Id)
        {
            var User = Context.Users.FindOneById(new ObjectId(Id));

            return View(User);

        }
    }


}
