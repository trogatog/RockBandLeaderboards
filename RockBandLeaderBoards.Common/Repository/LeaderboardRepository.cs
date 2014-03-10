using System;
using RockBandLeaderBoards.Services.Context;
using RockBandLeaderBoards.Services.Contracts;
using RockBandLeaderBoards.Services.DbModels;

namespace RockBandLeaderBoards.Common.Repository
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private LeaderboardContext DbContext { get; set; }
        protected IRepositoryProvider RepositoryProvider { get; set; }

        public LeaderboardRepository(IRepositoryProvider provider)
        {
            CreateDbContext();
            RepositoryProvider = provider;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IRepository<Difficulty> Difficulties { get { return GetStandardRepo<Difficulty>(); } }
        public IRepository<Game> Games { get { return GetStandardRepo<Game>(); } }
        public IRepository<Instrument> Instruments { get { return GetStandardRepo<Instrument>(); } }
        public IRepository<Platform> Platforms { get { return GetStandardRepo<Platform>(); }}
        public IRepository<Player> Players { get { return GetStandardRepo<Player>(); } }
        public IRepository<Score> Scores { get { return GetStandardRepo<Score>(); } }
        public IRepository<Song> Songs { get { return GetStandardRepo<Song>(); } }
        public IRepository<SongInstrumentDifficulty> SongInstrumentDifficulties { get{ return GetStandardRepo<SongInstrumentDifficulty>(); } }

        protected void CreateDbContext()
        {
            DbContext = new LeaderboardContext();
        }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
