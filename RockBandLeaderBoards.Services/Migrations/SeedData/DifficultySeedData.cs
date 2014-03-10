using System.Data.Entity.Migrations;
using RockBandLeaderBoards.Services.Context;
using RockBandLeaderBoards.Services.DbModels;

namespace RockBandLeaderBoards.Services.Migrations.SeedData
{
    public static class DifficultySeedData
    {
        public static void Seed(LeaderboardContext context)
        {
            var difficultySeedData = new[]
            {
                new Difficulty
                {
                    SmallDescription = "E",
                    Description = "Easy"
                },
                new Difficulty
                {
                    SmallDescription = "M",
                    Description = "Medium"
                },
                new Difficulty
                {
                    SmallDescription = "H",
                    Description = "Hard"
                },
                new Difficulty
                {
                    SmallDescription = "X",
                    Description = "Expert"
                }
            };
            context.Difficulties.AddOrUpdate(d => d.SmallDescription, difficultySeedData);
            context.SaveChanges();
        }
    }
}
