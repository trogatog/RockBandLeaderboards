using System;
using RockBandLeaderBoards.Services.Enums;

namespace RockBandLeaderBoards.Common
{
	public static class WebsiteHelper
	{
		//Example: http://services.rockband.com/leaderboard_data/rb3/ps3/guitar/yyz/data.json

		internal static string BuildWebsiteAddress(string instrument, string platform, string songShortName)
		{
			return string.Format("http://www.rockband.com/leaderboard_data/rb3/{0}/{1}/{2}/data.json", platform.ToLower(), instrument.ToLower(), songShortName);
		}

		public static string BuildWebsiteAddress(int instrumentId, int platformId, string songShortName)
		{
			return BuildWebsiteAddress(Enum.GetName(typeof(Instruments), instrumentId), Enum.GetName(typeof(Platforms), platformId), songShortName );
		}
	}
}
