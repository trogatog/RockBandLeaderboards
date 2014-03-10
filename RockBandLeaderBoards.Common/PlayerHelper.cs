using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RockBandLeaderBoards.Services;
using WhiteCliff.WebZinc;

namespace RockBandLeaderBoards.Common
{
	public static class PlayerHelper
	{
		public static List<Ranking> GetPlayerStats(int instrument, int platform, string song)
		{
			var scores = new List<Ranking>();
			try
			{
				var url = new WebZinc(WebsiteHelper.BuildWebsiteAddress(instrument, platform, song));
				scores = JsonConvert.DeserializeObject<List<Ranking>>(url.CurrentPage.RawHtml);
			}
			catch (Exception)
			{
				//don't care about the website not returning.  It happens, but the cleanup below will skip it anyways.  Just don't want to bomb out here...
			}

			return scores;
		}

		public static List<ScoreDetail> UpdatePlayerStats(List<Ranking> playerStats, int platform, string song, int instrument)
		{
		    return playerStats.Select(score => new ScoreDetail
		    {
		        PlayerName = score.Name, 
                PlatformId = platform, 
                DifficultyId = 5, 
                Percentage = 0, 
                Score = score.Score, 
                SongShortName = song, 
                InstrumentId = instrument
		    }).ToList();
		}
	}
}
