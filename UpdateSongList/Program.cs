using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using DownloadLeaderBoards.Common;
using DownloadLeaderBoards.Model;
using Newtonsoft.Json;
using WhiteCliff.WebZinc;

namespace UpdateSongList
{
	class Program
	{
		private const string URL = "http://www.rockband.com/services.php/music/all-songs.json";
		static void Main()
		{
			WebZinc result = new WebZinc(URL);
			List<SongName> songs = new List<SongName>();

			try
			{
				songs = JsonConvert.DeserializeObject<List<SongName>>(result.CurrentPage.RawHtml);
			}
			catch (Exception)
			{

			}
			finally
			{
				DataTable dataTable = DbHelper.CreateSongStage();

				foreach (SongName t in songs)
				{
					if (t.ShortName == "goodriddance")
						t.ShortName = t.ShortName;
					dataTable.Rows.Add(null, t.Id ?? 0, t.ShortName, t.Artist, t.Artist_Tr, t.Name,
					                   t.Name_Tr, t.Genre_Symbol,
					                   t.Source, SqlByte.Parse(t.Rating.ToString()), t.Difficulty_Vocals, t.Difficulty_Guitar,
					                   t.Difficulty_Pro_Guitar, t.Difficulty_Drums,
					                   t.Difficulty_Pro_Drums, t.Difficulty_Keys, t.Difficulty_Pro_Keys,
					                   t.Difficulty_Bass, t.Difficulty_Pro_Bass,
					                   t.Difficulty_Band, SqlByte.Parse(t.Vocal_Parts.ToString()), t.Year_Released, t.Decade,
					                   t.Starts_With, t.Cover, t.Name, DateTime.Now, 0);

				}

				DbHelper.BulkInsert(dataTable, dataTable.TableName);
				DbHelper.ExecuteStoredProcedure("dbo.InsertNewSongs");
			}
		}
	}
}
