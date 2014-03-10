using RockBandLeaderBoards.Services.DbModels;

namespace RockBandLeaderBoards.Services.Contracts
{
    public interface ILeaderboardRepository
    {
        void Commit();
        IRepository<Difficulty> Difficulties { get; }
        IRepository<Game> Games { get; } 
        IRepository<Instrument> Instruments { get; } 
        IRepository<Platform> Platforms { get; } 
        IRepository<Player> Players { get; } 
        IRepository<Score> Scores { get; } 
        IRepository<Song> Songs { get; } 
        IRepository<SongInstrumentDifficulty> SongInstrumentDifficulties { get; } 
    }
}
