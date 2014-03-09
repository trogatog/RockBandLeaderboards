using System;
using System.Collections.Generic;

namespace DownloadLeaderBoards.Common
{
	public enum Platforms
	{
		PS3 = 1,
		XBox = 2,
		Wii = 3
	}

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
			foreach (string song in _dbSongs)
			{
				Console.WriteLine("{0}: Acquiring Leaderboard Data for: {1}", ++i, song);
				try
				{
					foreach (int platformId in Platforms)
					{
						InstrumentHelper.GetScoresByInstrument(platformId, song);
					}
					SongHelper.UpdateLastAcquireDate(song);
				}
				catch(Exception ex)
				{
					throw ex;
				}
			}
		}

		private static void AddAllPlatforms()
		{
			foreach (int platformId in Enum.GetValues(typeof(Platforms)))
				Platforms.Add(platformId);
		}
	}
}
