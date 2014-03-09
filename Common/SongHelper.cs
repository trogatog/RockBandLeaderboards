using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DownloadLeaderBoards.Common
{
	public static class SongHelper
	{
		public static void UpdateLastAcquireDate(string song)
		{
			DbHelper.ExecuteStoredProcedure("UpdateScoreAcquireDate",  new SqlParameter("@SongShortName", song));
		}

		public static List<string> GetNextSongSet()
		{
			DataSet ds = new DataSet();

			DbHelper.ExecuteStoredProcedure("SelectNextTopShortNames", ds, "ShortName");
			
			return (from DataRow song in ds.Tables["ShortName"].Rows
					select song[0].ToString()).ToList();

		}
	}
}
