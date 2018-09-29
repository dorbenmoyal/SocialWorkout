using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class Goals
    {
            public int caloriesOut { get; set; }
            public double distance { get; set; }
            public int floors { get; set; }
            public int steps { get; set; }
    }

    public class RootGoals
    {
        public Goals goals { get; set; }
    }
}