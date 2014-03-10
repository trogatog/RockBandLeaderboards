using System.Data.Entity.Migrations;
using RockBandLeaderBoards.Services.Context;
using RockBandLeaderBoards.Services.DbModels;

namespace RockBandLeaderBoards.Services.Migrations.SeedData
{
    public static class InstrumentSeedData
    {
        public static void Seed(LeaderboardContext context)
        {
            var instruments = new[]
            {
                new Instrument
                {
                    Description = "Guitar"
                },
                new Instrument
                {
                    Description = "Bass"
                },
                new Instrument
                {
                    Description = "Drums"
                },
                new Instrument
                {
                    Description = "Vocals"
                },
                new Instrument
                {
                    Description = "Keys"
                },
                new Instrument
                {
                    Description = "Real_Guitar"
                },
                new Instrument
                {
                    Description = "Real_Bass"
                },
                new Instrument
                {
                    Description = "Real_Drums"
                },
                new Instrument
                {
                    Description = "Real_Keys"
                },
                new Instrument
                {
                    Description = "Harmony"
                },
                new Instrument
                {
                    Description = "Band"
                }
            };

            context.Instruments.AddOrUpdate(i => i.Description, instruments);
            context.SaveChanges();
        }
    }
}
