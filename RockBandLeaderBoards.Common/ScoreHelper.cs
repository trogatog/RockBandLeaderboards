using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RockBandLeaderBoards.Services;

namespace RockBandLeaderBoards.Common
{
	public static class ScoreHelper
	{

		public static void UpdateScore(DataTable dataTable, string tableName, string song)
		{
		    DbHelper.BulkInsert(dataTable, tableName);
		    var parameter = new SqlParameter {ParameterName = "@SongShortName", Value = song};
		    DbHelper.ExecuteStoredProcedure("dbo.InsertNewScoresBySongShortName", parameter);
		}

		public static void TransformScoresAndUpdate(DataTable dataTable, List<ScoreDetail> currentScores)
		{
			foreach (ScoreDetail score in currentScores)
				dataTable.Rows.Add(null, 3, score.SongShortName, score.InstrumentId, score.Score, null, score.Percentage, score.PlayerName, score.PlatformId, score.DifficultyId);
		}
	}
}
