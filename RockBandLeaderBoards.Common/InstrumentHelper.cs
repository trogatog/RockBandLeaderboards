using System;
using System.Collections.Generic;
using System.Data;
using RockBandLeaderBoards.Services;
using RockBandLeaderBoards.Services.Enums;

namespace RockBandLeaderBoards.Common
{
	public static class InstrumentHelper
	{
		public static void GetScoresByInstrument(int platformId, string song)
		{
			DataTable dataTable = DbHelper.CreateScoreStage();
			foreach (int instrumentId in Enum.GetValues(typeof(Instruments)))
			{
				List<Ranking> playerStats = PlayerHelper.GetPlayerStats(instrumentId, platformId, song);
				List<ScoreDetail> currentScores = PlayerHelper.UpdatePlayerStats(playerStats, platformId, song, instrumentId);
				ScoreHelper.TransformScoresAndUpdate(dataTable, currentScores);
			}
			try
			{
				ScoreHelper.UpdateScore(dataTable, dataTable.TableName, song);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			dataTable.Clear();
		}
	}
}
