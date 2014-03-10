using System.Data.Entity;
using RockBandLeaderBoards.Services.DbModels;

namespace RockBandLeaderBoards.Services.Context
{
    public class LeaderboardContext : DbContext
    {
        static LeaderboardContext()
        {
            Database.SetInitializer<LeaderboardContext>(null);
        }

        public LeaderboardContext() : base("LeaderboardContext")
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbSet<Difficulty> Difficulties { get; set; } 
        public DbSet<Game> Games { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongInstrumentDifficulty> SongInstrumentDifficulties { get; set; }
    }
}
