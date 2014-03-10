using System.Data.Entity.Migrations;
using RockBandLeaderBoards.Services.Context;
using RockBandLeaderBoards.Services.Migrations.SeedData;

namespace RockBandLeaderBoards.Services.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LeaderboardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeaderboardContext context)
        {
            //Use if seeding fails somewhere
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
            DifficultySeedData.Seed(context);
            InstrumentSeedData.Seed(context);
            PlatformSeedData.Seed(context);
            GameSeedData.Seed(context);
        }
    }
}
