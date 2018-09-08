using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialWorkout.Models
{
    public class Preferens
    {
      
        public bool Morning { get; set; }

        public bool Evening { get; set; }

        public bool Noon { get; set; }

        public bool Trainer { get; set; }

        public int AgePreference { get; set; }
        public int GenderPreference { get; set; }
        public int LocationPreference { get; set; }
        public int RankPreference { get; set; }

        public string Location { get; set; }

        public String Description { get; set; }


        public List<string> FavoriteSports { get; set; }


    }
}