using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PingPongAPI.Models;

namespace PingPongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly MatchContext _matchContext;
        private readonly PlayerContext _playerContext;

        public MatchesController(MatchContext matchContext, PlayerContext playerContext)
        {
            _matchContext = matchContext;
            _playerContext = playerContext;

            if (_playerContext.Players.Count() == 0)
            {
                _playerContext.Players.Add(new Player { ID = 0, Name = "Test Boy", Rank = 0, Rating = 0 });
                _playerContext.Players.Add(new Player { ID = 0, Name = "Test Girl", Rank = 0, Rating = 0 });
                _playerContext.SaveChanges();

            }


            if (_matchContext.Matches.Count() == 0)
            {
                _matchContext.Matches.Add(new Match { Id = 0, });
                _matchContext.Matches.Add(new Match { });
                _matchContext.SaveChanges();
            }

        }

        [HttpGet]
        public ActionResult<List<Match>> GetAll()
        {
            return _matchContext.Matches.ToList();
        }

        [HttpGet("{id}", Name = "GetMatches")]
        public ActionResult<Match> GetById(int id)
        {
            var match = _matchContext.Matches.Find(id);
            if (match == null)
                return NotFound();
            return match;
        }

        [HttpPost]
        public IActionResult Create(Match match)
        {
            _matchContext.Matches.Add(match);
            _matchContext.SaveChanges();           

            return CreatedAtRoute("GetMatches", new { ID = match.Id, Players = match.Players, Winner = match.Winner, Loser = match.Loser }, match);
        }
         

    }
}