using System;
using System.Collections.Generic;
using System.Data;
using DownloadLeaderBoards.Model;

namespace DownloadLeaderBoards.Common
{
	public static class InstrumentHelper
	{
		public enum Instruments
		{
			Guitar = 1,
			Bass = 2,
			Drums = 3,
			Vocals = 4,
			Keys = 5,
			Real_Guitar = 6,
			Real_Bass = 7,
			Real_Drums = 8,
			Real_Keys = 9,
			Harmony = 10,
			Band = 11
		}
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
