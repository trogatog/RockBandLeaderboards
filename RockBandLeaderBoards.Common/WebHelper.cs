using System;
using DownloadLeaderboards.Services.Contracts;
using DownloadLeaderboards.Services.Enums;

namespace DownloadLeaderBoards.Common
{
	public class WebHelper : IWeb
	{
		//Example: http://services.rockband.com/leaderboard_data/rb3/ps3/guitar/yyz/data.json

		internal string BuildWebsiteAddress(string instrument, string platform, string songShortName)
		{
			return string.Format("http://www.rockband.com/leaderboard_data/rb3/{0}/{1}/{2}/data.json", platform.ToLower(), instrument.ToLower(), songShortName);
		}

		public string BuildWebsiteAddress(int instrumentId, int platformId, string songShortName)
		{
			return BuildWebsiteAddress(Enum.GetName(typeof(Instruments), instrumentId), Enum.GetName(typeof(Platforms), platformId), songShortName );
		}
	}
}
