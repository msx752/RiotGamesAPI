using System;
using RiotGamesApi.Interfaces;

namespace RiotGamesApi.Models
{
	/// <summary>
	/// Api Response Data 
	/// </summary>
	/// <typeparam name="T">
	/// </typeparam>
	public class RiotGamesApiResult<T> : IResult<T> where T : new()
	{
		public RiotGamesApiResult(Exception exp)
		{
			this.Exception = exp;
		}

		public RiotGamesApiResult()
		{
		}

		public Exception Exception { get; set; }
		public bool HasError { get { return Exception != null; } }
		public T Result { get; set; }
		public string CurrentXAppRateLimit { get; set; } = "";
		public string CurrentXMethodRateLimit { get; set; } = "";

		/// <summary>
		/// whether data comes from cache or not 
		/// </summary>
		public bool IsCache { get; set; } = false;
	}
}