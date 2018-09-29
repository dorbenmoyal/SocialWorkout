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


       public ActionResult Statistics()
        {

            ControlPanelViewModel CPVM = new ControlPanelViewModel();

            CPVM.Users = database.Users.FindAll();

            CPVM.Trainers = database.Trainers.FindAll();

            CPVM.events = database.Events.FindAll();




            return View(CPVM);



        }

        public ActionResult Survey()
        {
            var survey = database.Survey.FindAll();

            //Sumnumber Vars

            int q1=0;
            int q2=0;
            int q3=0;
            int q4=0;
            int q5=0;
            int q6=0;
            int q7=0;

            List<long> meanCalc = new List<long>();


            foreach (var list in survey)
            {
                    foreach (var answer in list.Answers)
                    {
                        
                        if(answer.Key == "Question.1")
                            {
                                q1 += answer.Value;
                            }

                    if (answer.Key == "Question.2")
                    {
                        q2 += answer.Value;
                    }

                    if (answer.Key == "Question.3")
                    {
                        q3 += answer.Value;
                    }

                    if (answer.Key == "Question.4")
                    {
                        q4 += answer.Value;
                    }

                    if (answer.Key == "Question.5")
                    {
                        q5 += answer.Value;
                    }

                    if (answer.Key == "Question.6")
                    {
                        q6 += answer.Value;
                    }

                    if (answer.Key == "Question.7")
                    {
                        q7 += answer.Value;
                    }

                }
                        
            }


            meanCalc.Add((q1 / survey.Count()));

            meanCalc.Add((q2 / survey.Count()));

            meanCalc.Add((q3 / survey.Count()));

            meanCalc.Add((q4 / survey.Count()));

            meanCalc.Add((q5 / survey.Count()));

            meanCalc.Add((q6 / survey.Count()));

            meanCalc.Add((q7 / survey.Count()));



            ViewBag.MeanList = meanCalc;

            return View();
        }
    }
}