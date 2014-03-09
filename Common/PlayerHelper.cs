using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using DownloadLeaderBoards.Model;
using Newtonsoft.Json;
using WhiteCliff.WebZinc;

namespace DownloadLeaderBoards.Common
{
	public enum Difficulties
	{
		E = 1,
		M = 2,
		H = 3,
		X = 4
	} 
	public static class PlayerHelper
	{
		public static List<Ranking> GetPlayerStats(int instrument, int platform, string song)
		{
			List<Ranking> scores = new List<Ranking>();
			try
			{
				WebZinc url = new WebZinc(WebsiteHelper.BuildWebsiteAddress(instrument, platform, song));
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
			List<ScoreDetail> currentScores = new List<ScoreDetail>();
			foreach (var score in playerStats)
			{
				ScoreDetail detail = new ScoreDetail();

				detail.PlayerName = score.Name;
				detail.PlatformId = platform;
				detail.DifficultyId = 5;// (int)Enum.Parse(typeof(Difficulties), scoreDetail[2]);
				detail.Percentage = 0;// int.Parse(scoreDetail[3].Replace("%", string.Empty));
				detail.Score = score.Score;
				detail.SongShortName = song;
				detail.InstrumentId = instrument;
				currentScores.Add(detail);

			}
			return currentScores;
		}

	}
}
