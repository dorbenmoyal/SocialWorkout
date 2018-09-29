using System.Web.Mvc;
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
            var GOCL = new GoalsController();
            foreach (var CurrentUser in UsersList)
            {

                if (CurrentUser.Goals == null)
                {
                    CurrentUser.Goals = GOCL.GetRandomGoals();
                    Context.Users.Save(CurrentUser);

                }

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
                        double distance = System.Math.Round(System.Math.Sqrt(distanceAge + distanceLocation + distanceGender + distanceTime),0);



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

        public ActionResult RateUs()
        {
            return View();
        }


        public ActionResult Trainers()
        {
            var Trainers = Context.Trainers.FindAll();


            return View(Trainers);
        }
        public ActionResult TrainerDetails(string Id)
        {
            var Trainer = Context.Trainers.FindOneById(new ObjectId(Id));

            return View(Trainer);

        }


        public ActionResult ShowMesagges(string uid)
        {
            var UsersList = Context.Users.FindAll();
            var User = Context.Users.FindOneById(new ObjectId(uid));
          

            if (User.mailBox == null|| User.mailBox.UserMessages.Count == 0 )
            {
                return View("MailBoxEmpty");
            }


            List<Message> UserMessages = User.mailBox.UserMessages;

          


            return View(UserMessages);
        }


        public ActionResult DeleteMessage(string Massage, string SenderUserID)
        {
            var UsersList = Context.Users.FindAll();
            string currentUserMail = null;
            foreach (var user in UsersList)
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
                            Context.Users.Save(user);
                            currentUserMail = user.Id;
                            break;
                        }
                    }
                }

            }
            return RedirectToAction("ShowMesagges",new {uid=currentUserMail});

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MailBoxEmpty()
        {
         
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
        public ActionResult MyDetails(string Id)
        {
            var User = Context.Users.FindOneById(new ObjectId(Id));

            return View(User);

        }

        public ActionResult friends()
        {

            return View();
        }
        public ActionResult Events()
        {
            var AllEvents = Context.Events.FindAll();

            return View(AllEvents);
        }
        public ActionResult ContactUs()
        {
            

            return View();
        }

        public ActionResult Unauthorized()
        {

            return View();
        }
    }
}