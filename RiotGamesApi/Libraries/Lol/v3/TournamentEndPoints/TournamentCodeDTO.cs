using System.Collections.Generic;
using Newtonsoft.Json;
using RiotGamesApi.Libraries.Enums;

namespace RiotGamesApi.Libraries.Lol.v3.TournamentEndPoints
{
    public class TournamentCodeDTO
    {
        //The game map for the tournament code game
        [JsonProperty("map")]
        public string map { get; set; }

        //The tournament code.
        [JsonProperty("code")]
        public string code { get; set; }

        //The spectator mode for the tournament code game.
        [JsonProperty("spectators")]
        public string spectators { get; set; }

        //The tournament code's region. (Legal values: BR, EUNE, EUW, JP, LAN, LAS, NA, OCE, PBE, RU, TR)
        [JsonConverter(typeof(ServiceRegion))]
        [JsonProperty("region")]
        public ServiceRegion region { get; set; }

        //The provider's ID.
        [JsonProperty("providerId")]
        public int providerId { get; set; }

        //The team size for the tournament code game.
        [JsonProperty("teamSize")]
        public int teamSize { get; set; }

        //
        [JsonProperty("participants")]
        public List<long> participants { get; set; }

        //The pick mode for tournament code game.
        [JsonProperty("pickType")]
        public string pickType { get; set; }

        //The tournament's ID.
        [JsonProperty("tournamentId")]
        public int tournamentId { get; set; }

        //The lobby name for the tournament code game.
        [JsonProperty("lobbyName")]
        public string lobbyName { get; set; }

        //The password for the tournament code game.
        [JsonProperty("password")]
        public string password { get; set; }

        //The tournament code's ID.
        [JsonProperty("id")]
        public int id { get; set; }

        //The metadata for tournament code.
        [JsonProperty("metaData")]
        public string metaData { get; set; }
    }
}