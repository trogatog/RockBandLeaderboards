using System;
using System.Collections.Generic;
using RockBandLeaderBoards.Services.Enums;

namespace RockBandLeaderBoards.Common
{
	public static class PlatformHelper
	{
		private static List<string> _dbSongs = new List<string>();
		private static readonly List<int> Platforms = new List<int>();

		public static void InitializePlatformHelper()
		{
			_dbSongs = SongHelper.GetNextSongSet();
			AddAllPlatforms();
		}

		public static void InitializePlatformHelper(string song)
		{
			_dbSongs.Add(song);
			AddAllPlatforms();
		}

		public static void InitializePlatformHelper(string song, int platformId)
		{
			_dbSongs.Add(song);
			Platforms.Add(platformId);
		}

		public static void GetSongsByPlatform()
		{
			int i = 0;		
			foreach (var song in _dbSongs)
			{
				Console.WriteLine("{0}: Acquiring Leaderboard Data for: {1}", ++i, song);
			    foreach (var platformId in Platforms)
			    {
			        InstrumentHelper.GetScoresByInstrument(platformId, song);
			    }
			    SongHelper.UpdateLastAcquireDate(song);
			}
		}

		private static void AddAllPlatforms()
		{
			foreach (int platformId in Enum.GetValues(typeof(Platforms)))
				Platforms.Add(platformId);
		}
	}
}
