using System.Collections.Concurrent;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit.Property;

namespace RiotGamesApi.RateLimit
{
	public class RateLimitOption
	{
		public RateLimitOption()
		{
			DisableLimiting = false;
		}

		/// <summary>
		/// rate-limits which defined from userSettings 
		/// </summary>
		public ConcurrentDictionary<LolUrlType, RLolApiName> All { get; internal set; }

		/// <summary>
		/// disable rate-limiter (default: false) 
		/// </summary>
		public bool DisableLimiting { get; internal set; }

		private ConcurrentDictionary<string, ApiLimit> SpecialLeaguesLimits { get; set; } =
			new ConcurrentDictionary<string, ApiLimit>();

		private ConcurrentDictionary<string, ApiLimit> SummonerIdAndByNameLimits { get; set; } =
			new ConcurrentDictionary<string, ApiLimit>();

		public ConcurrentDictionary<string, ApiLimit> SummonerAccountNameLimits { get; set; } =
			new ConcurrentDictionary<string, ApiLimit>();

		public void SetLeagueApiLimit(ConcurrentDictionary<string, ApiLimit> val)
		{
			SpecialLeaguesLimits = val;
		}

		/// remporary method rate limiter for the
		/// '/lol/summoner/v3/summoners/by-name/{summonerName}', '/lol/summoner/v3/summoners/{summonerId}'
		public void SetSummonerIdAndByNameApiLimit(ConcurrentDictionary<string, ApiLimit> val)
		{
			SummonerIdAndByNameLimits = val;
		}

		/// <summary>
		/// remporary method rate limiter for the '/lol/summoner/v3/summoners/by-account/{accountId}' 
		/// </summary>
		/// <param name="val">
		/// </param>
		public void SetSummonerAccountNameApiLimit(ConcurrentDictionary<string, ApiLimit> val)
		{
			SummonerAccountNameLimits = val;
		}

		public ApiLimit FindLeagueApiLimit(string platform)
		{
			if (SpecialLeaguesLimits.ContainsKey(platform))
			{
				return SpecialLeaguesLimits[platform];
			}
			else
			{
				return null;
			}
		}

		public ApiLimit FindSummonerApiLimit(string platform/*, LolApiPath[] paths*/)//paths for check '/lol/summoner/v3/summoners/by-account/{accountId}'
		{
			if (SummonerIdAndByNameLimits.ContainsKey(platform))
			{
				return SummonerIdAndByNameLimits[platform];
			}
			else
			{
				return null;
			}
		}
	}
}