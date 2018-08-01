using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingPongAPI.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rank { get; set;}
        public double Rating { get; set; }
        //public List<Match> MatchHistory { get; set; }

    }
}
