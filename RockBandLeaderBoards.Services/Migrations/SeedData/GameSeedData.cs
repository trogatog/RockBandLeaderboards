using System.Data.Entity.Migrations;
using RockBandLeaderBoards.Services.Context;
using RockBandLeaderBoards.Services.DbModels;

namespace RockBandLeaderBoards.Services.Migrations.SeedData
{
    public static class GameSeedData
    {
        public static void Seed(LeaderboardContext context)
        {
            var games = new[]
            {
                new Game
                {
                    GameName = "Rock Band",
                    ShortName = "RB1"
                },
                new Game
                {
                    GameName = "Rock Band 2",
                    ShortName = "RB2"
                },
                new Game
                {
                    GameName = "Rock Band 3",
                    ShortName = "RB3"
                }
            };

            context.Games.AddOrUpdate(g => g.ShortName, games);
            context.SaveChanges();
        }
    }
}
