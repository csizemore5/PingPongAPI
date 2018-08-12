using System;
using System.Collections.Generic;
using PingPongAPI.Models;

using Xunit;

namespace PingPongAPI.Tests
{
    public class ELOTest
    {
        [Fact]
        public void RatingTest()
        {

            // Assign
            List<double> newRating = new List<double>();
            Player player1 = new Player { Name = "Chauncey Tester", Rank = 1, Rating = 1500, Score = 0 };
            Player player2 = new Player { Name = "Testy Chauncey", Rank = 2, Rating = 1500, Score = 1 };

            // Act
            ELOCalculator elo = new ELOCalculator(player1.Rating, player2.Rating, player1.Score, player2.Score);
            newRating = elo.GetNewRatings();

            player1.Rating = newRating[0];
            player2.Rating = newRating[1];

            // Assert
            Assert.Equal(1492.5, player1.Rating);
            Assert.Equal(1507.5, player2.Rating);
        }
    }
}
