using System;
using System.Collections.Generic;
using System.Data;
using DownloadLeaderboards.Services;
using DownloadLeaderboards.Services.Contracts;
using DownloadLeaderboards.Services.Enums;
using DownloadLeaderboards.Services.Model;

namespace DownloadLeaderBoards.Common
{
	public class Instrument : IInstrument
	{
		public void GetScoresByInstrument(int platformId, string song)
		{
			DataTable dataTable = DbHelper.CreateScoreStage();
            var score = new ScoreHelper();
			foreach (int instrumentId in Enum.GetValues(typeof(Instruments)))
			{
			    var player = new PlayerHelper();
			    List<Ranking> playerStats = player.GetPlayerStats(instrumentId, platformId, song);
				List<ScoreDetail> currentScores = player.UpdatePlayerStats(playerStats, platformId, song, instrumentId);
				score.TransformScoresAndUpdate(dataTable, currentScores);
			}

		    score.UpdateScore(dataTable, dataTable.TableName, song);

		    dataTable.Clear();
		}
	}
}
