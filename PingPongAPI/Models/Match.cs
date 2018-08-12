using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingPongAPI.Models
{
    public class Match
    {
        public int Id { get; set; }
        public List<Player> Players { get; set; }
        public Player Winner { get; set; }
        public Player Loser { get; set; }
        

    }
}
