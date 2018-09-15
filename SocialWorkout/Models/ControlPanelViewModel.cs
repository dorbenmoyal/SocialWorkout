using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialWorkout.Models;

namespace SocialWorkout.Models
{
    public class ControlPanelViewModel
    {
        public IEnumerable<User> Users { get; set; }

        public IEnumerable<EventLine> events { get; set; }

        public IEnumerable<Trainer> Trainers { get; set; }



    }
}