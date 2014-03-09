using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DownloadLeaderBoards.Model;

namespace DownloadLeaderBoards.Common
{
	public static class ScoreHelper
	{

		public static void UpdateScore(DataTable dataTable, string tableName, string song)
		{
			try
			{
				DbHelper.BulkInsert(dataTable, tableName);
				SqlParameter parameter = new SqlParameter {ParameterName = "@SongShortName", Value = song};
				DbHelper.ExecuteStoredProcedure("dbo.InsertNewScoresBySongShortName", parameter);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void TransformScoresAndUpdate(DataTable dataTable, List<ScoreDetail> currentScores)
		{
			foreach (ScoreDetail score in currentScores)
				dataTable.Rows.Add(null, 3, score.SongShortName, score.InstrumentId, score.Score, null, score.Percentage, score.PlayerName, score.PlatformId, score.DifficultyId);
		}
	}
}
