using System;
using System.Data;
using DownloadLeaderBoards.Common;

namespace DownloadLeaderboards
{
	internal class Program
	{

		//args are going to be for forcing a song to update
		//args[0] = song short name
		//args[1] = PlatformId
		static void Main(string[] args)
		{
			if (args.GetUpperBound(0) != -1)
			{
				string song = args[0].Replace(",", string.Empty);
				if (args.GetUpperBound(0) > 1)
				{
					Console.WriteLine("Invalid number of arguments.  Defaulting to one song, all platforms: {0}", song);
					args = new[]{song};
				}
				
				if (args.GetUpperBound(0) == 1)
					PlatformHelper.InitializePlatformHelper(song, int.Parse(args[1]));
				else
					PlatformHelper.InitializePlatformHelper(song);
			}
			else
				PlatformHelper.InitializePlatformHelper();
			try
			{
				PlatformHelper.GetSongsByPlatform();
			}
			catch(Exception ex)
			{
				DataTable dataTable = DbHelper.CreateErrorLog();
				dataTable.Rows.Add(null, Environment.MachineName, ex.Message, DateTime.Now);
				if (ex.InnerException != null)
					dataTable.Rows.Add(null, Environment.MachineName, ex.InnerException.Message, DateTime.Now);
				DbHelper.BulkInsert(dataTable, dataTable.TableName);
				Environment.Exit(1);
			}

			Environment.Exit(0);
		}
	}
}
