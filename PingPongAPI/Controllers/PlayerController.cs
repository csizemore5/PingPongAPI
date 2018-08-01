using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PingPongAPI.Models;

namespace PingPongAPI.Controllers
{
    [Route("api/Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext _context;

        public PlayerController(PlayerContext context)
        {
            _context = context;

            if (_context.Players.Count() == 0)
            {
                _context.Players.Add(new Player { Rank = 1, Rating = 1000, Name = "David Yost" });
                _context.Players.Add(new Player { Rank = 2, Rating = 750, Name = "Sean Peoples" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return _context.Players.ToList();
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public ActionResult<Player> GetById(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
                return NotFound();
            return player;
        }
        [HttpPost]
        public IActionResult Create(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();

            return CreatedAtRoute("GetPlayer", new { Name = player.Name, rank = player.Rank, rating = player.Rating }, player);
        }

        [HttpPut]
        public IActionResult UpdateRating(List<Player> players)
        {
            var _player1 = _context.Players.Find(players[0].ID);
            var _player2 = _context.Players.Find(players[1].ID);

            var player1 = _player1;
            var player2 = _player2;

            ELOCalculator ratings = new ELOCalculator(player1.Rating, player2.Rating, ELOCalculator.WIN, ELOCalculator.LOSE);
            List<double> newRatings = ratings.GetNewRatings();

            player1.Rating = newRatings[0];
            player2.Rating = newRatings[1];

            _context.Players.Update(player1);
            _context.Players.Update(player2);
            return NoContent();

        }

    }
}