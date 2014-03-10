using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using RockBandLeaderBoards.Services;
using WhiteCliff.WebZinc;

namespace RockBandLeaderBoards.Common
{
	public static class SongHelper
	{
        private const string URL = "http://www.rockband.com/services.php/music/all-songs.json";

		public static void UpdateLastAcquireDate(string song)
		{
			DbHelper.ExecuteStoredProcedure("UpdateScoreAcquireDate",  new SqlParameter("@SongShortName", song));
		}

		public static List<string> GetNextSongSet()
		{
			var ds = new DataSet();

			DbHelper.ExecuteStoredProcedure("SelectNextTopShortNames", ds, "ShortName");
			
			return (from DataRow song in ds.Tables["ShortName"].Rows
					select song[0].ToString()).ToList();

		}

	    public static void UpdateSongList()
	    {
            var result = new WebZinc(URL);
            var songs = new List<SongName>();

            try
            {
                songs = JsonConvert.DeserializeObject<List<SongName>>(result.CurrentPage.RawHtml);
            }
            finally
            {
                var dataTable = DbHelper.CreateSongStage();

                foreach (var t in songs)
                {
                    if (t.ShortName == "goodriddance")
                        t.ShortName = t.ShortName;
                    dataTable.Rows.Add(null, t.Id ?? 0, t.ShortName, t.Artist, t.Artist_Tr, t.Name,
                                       t.Name_Tr, t.Genre_Symbol,
                                       t.Source, SqlByte.Parse(t.Rating.ToString(CultureInfo.InvariantCulture)), t.Difficulty_Vocals, t.Difficulty_Guitar,
                                       t.Difficulty_Pro_Guitar, t.Difficulty_Drums,
                                       t.Difficulty_Pro_Drums, t.Difficulty_Keys, t.Difficulty_Pro_Keys,
                                       t.Difficulty_Bass, t.Difficulty_Pro_Bass,
                                       t.Difficulty_Band, SqlByte.Parse(t.Vocal_Parts.ToString(CultureInfo.InvariantCulture)), t.Year_Released, t.Decade,
                                       t.Starts_With, t.Cover, t.Name, DateTime.Now, 0);

                }

                DbHelper.BulkInsert(dataTable, dataTable.TableName);
                DbHelper.ExecuteStoredProcedure("dbo.InsertNewSongs");
            }
	    }
	}
}
