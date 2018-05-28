using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialWorkout.Models;

namespace SocialWorkout.Models
{
    public class PreferenseUserViewModel
    {
        public User user { get; set; }
        public Preferens preferens {get; set;}

    }
}