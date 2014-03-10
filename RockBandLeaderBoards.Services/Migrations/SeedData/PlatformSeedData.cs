using System.Data.Entity.Migrations;
using RockBandLeaderBoards.Services.Context;
using RockBandLeaderBoards.Services.DbModels;

namespace RockBandLeaderBoards.Services.Migrations.SeedData
{
    public static class PlatformSeedData
    {
        public static void Seed(LeaderboardContext context)
        {
            var platforms = new[]
            {
                new Platform
                {
                    ShortName = "PS3",
                    ConsoleName = "PlayStation 3"
                },
                new Platform
                {
                    ShortName = "XBox",
                    ConsoleName = "XBox 360"
                },
                new Platform
                {
                    ShortName = "Wii",
                    ConsoleName = "Nintendo Wii"
                }
            };

            context.Platforms.AddOrUpdate(p => p.ShortName, platforms);
            context.SaveChanges();
        }
    }
}
