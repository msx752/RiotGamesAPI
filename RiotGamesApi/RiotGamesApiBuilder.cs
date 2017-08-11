using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.Models;
using RiotGamesApi.Models;

namespace RiotGamesApi
{
    public class RiotGamesApiBuilder : IApiBuilder
    {
        public RiotGamesApiBuilder()
        {
            RiotGamesApiOptions = new LolApiOptions();
        }

        public IApiOption RiotGamesApiOptions { get; }

        IApiOption IApiBuilder.Build()
        {
            return RiotGamesApiOptions;
        }

        IApiBuilder IApiBuilder.UseApiUrl(string _url)
        {
            RiotGamesApiOptions.Url = $"https://{{platformId}}.{_url}";
            return this;
        }

        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public IApiBuilder UseNonStaticApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            RiotGamesApiOptions.RiotGamesApis[LolUrlType.NonStatic] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.NonStaticUrl));
            return this;
        }

        IApiBuilder IApiBuilder.UseRiotApiKey(string riotApiKey)
        {
            RiotGamesApiOptions.RiotApiKey = riotApiKey;
            return this;
        }

        IApiBuilder IApiBuilder.UseStaticApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            this.RiotGamesApiOptions.RiotGamesApis[LolUrlType.Static] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.StaticUrl));
            return this;
        }

        IApiBuilder IApiBuilder.UseStatusApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            this.RiotGamesApiOptions.RiotGamesApis[LolUrlType.Status] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.StatusUrl));
            return this;
        }

        IApiBuilder IApiBuilder.UseTournamentApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            this.RiotGamesApiOptions.RiotGamesApis[LolUrlType.Tournament] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.TournamentUrl));
            return this;
        }
    }
}