using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace RockBandLeaderBoards.Common
{
	public static class DbHelper
	{
		readonly static SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["LeaderBoard"]);
		private const int TIMEOUT = 3600;
		public static void ExecuteStoredProcedure(string procedureName, SqlParameter parameter)
		{
			bool failed = true;
			var command = new SqlCommand(procedureName, Conn)
			{
				CommandType = CommandType.StoredProcedure,
				CommandTimeout = TIMEOUT
			};
			if (!string.IsNullOrEmpty(parameter.ParameterName))
				command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);

			if (Conn.State == ConnectionState.Closed)
				Conn.Open();
			int tryCount = 0;
			while (failed)
			{
				try
				{
					command.ExecuteNonQuery();
					failed = false;
				}
				catch (Exception)
				{
					System.Threading.Thread.Sleep(new TimeSpan(0, 0, 5));
					tryCount++;
				}
				if (tryCount > 10)
					throw new Exception("An error occurred while executing procedure " + procedureName + " parameters: " +
										(parameter != null ? parameter.ParameterName + " value:" + parameter.Value : "None"));

			}

			Conn.Close();
		}

		public static void BulkInsert(DataTable dataTable, string destTableName)
		{
			bool failed = true;
			if (Conn.State == ConnectionState.Closed)
				Conn.Open();

			var sqlBulkCopy = new SqlBulkCopy(Conn)
			{
				BulkCopyTimeout = TIMEOUT,
				DestinationTableName = destTableName
			};

			int tryCount = 0;
			while (failed)
			{
				//To get around deadlock when another instance is writing to the database.
				//Wait 30 seconds and try again.
				try
				{
					sqlBulkCopy.WriteToServer(dataTable);
					failed = false;
				}
				catch (Exception)
				{
					System.Threading.Thread.Sleep(new TimeSpan(0,0,5));
					tryCount++;
				}
				if (tryCount > 10)
					throw new Exception("An error occurred while trying to bulk copy for song " + dataTable.Rows[0][2], new Exception(dataTable.Rows[0][2].ToString()));
				
			}
			sqlBulkCopy.Close();
			Conn.Close();
		}

		public static DataTable CreateScoreStage()
		{
			DataTable dataTable = new DataTable {TableName = "ScoreStage"};
			dataTable.Columns.Add("ScoreStageId");
			dataTable.Columns.Add("GameId");
			dataTable.Columns.Add("SongId");
			dataTable.Columns.Add("InstrumentId");
			dataTable.Columns.Add("Score");
			dataTable.Columns.Add("StarScore");
			dataTable.Columns.Add("Percentage");
			dataTable.Columns.Add("PlayerName");
			dataTable.Columns.Add("PlatformId");
			dataTable.Columns.Add("DifficultyId");

			return dataTable;
		}

		public static DataTable CreateSongStage()
		{
			DataTable dataTable = new DataTable {TableName = "SongStage"};
			dataTable.Columns.Add("SongStageId", typeof(int));
			dataTable.Columns.Add("HmxSongId", typeof(int));
			dataTable.Columns.Add("ShortName", typeof(string));
			dataTable.Columns.Add("Artist", typeof(string));
			dataTable.Columns.Add("ArtistTr", typeof(string));
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("NameTr", typeof(string));
			dataTable.Columns.Add("Genre", typeof(string));
			dataTable.Columns.Add("Source", typeof(string));
			dataTable.Columns.Add("Rating", typeof(SqlByte));
			dataTable.Columns.Add("VocalDifficulty", typeof(short));
			dataTable.Columns.Add("GuitarDifficulty", typeof(short));
			dataTable.Columns.Add("ProGuitarDifficulty", typeof(short));
			dataTable.Columns.Add("DrumsDifficulty", typeof(short));
			dataTable.Columns.Add("ProDifficulty", typeof(short));
			dataTable.Columns.Add("KeysDifficulty", typeof(short));
			dataTable.Columns.Add("ProKeysDifficulty", typeof(short));
			dataTable.Columns.Add("BassDifficulty", typeof(short));
			dataTable.Columns.Add("ProBassDifficulty", typeof(short));
			dataTable.Columns.Add("BandDifficulty", typeof(short));
			dataTable.Columns.Add("VocalParts", typeof(SqlByte));
			dataTable.Columns.Add("YearReleased", typeof(int));
			dataTable.Columns.Add("Decade", typeof(string));
			dataTable.Columns.Add("StartsWith", typeof(string));
			dataTable.Columns.Add("Cover", typeof(string));
			dataTable.Columns.Add("SongDisplayName", typeof(string));
			dataTable.Columns.Add("LastUpdatedDate", typeof(DateTime));
			dataTable.Columns.Add("SongId");
			return dataTable;
		}

		public static DataTable CreateErrorLog()
		{
			DataTable dataTable = new DataTable{TableName = "ErrorLog"};
			dataTable.Columns.Add("ErrorId", typeof (int));
			dataTable.Columns.Add("MachineName", typeof (string));
			dataTable.Columns.Add("ErrorDescription", typeof (string));
			dataTable.Columns.Add("ErrorTime", typeof (DateTime));
			return dataTable;
		}

		public static void ExecuteStoredProcedure(string procedureName, DataSet dataSet, string tableName)
		{
			if (Conn.State == ConnectionState.Closed)
				Conn.Open();
			SqlCommand command = new SqlCommand(procedureName, Conn) {CommandType = CommandType.StoredProcedure};
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			adapter.Fill(dataSet, tableName);
			Conn.Close();
		}

		public static void ExecuteStoredProcedure(string procedureName)
		{
			ExecuteStoredProcedure(procedureName, new SqlParameter());
		}
	}
}
