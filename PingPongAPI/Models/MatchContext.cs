using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PingPongAPI.Models
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options)
    : base(options)
        {

        }

        public DbSet<Match> Matches { get; set; }
    }
}
