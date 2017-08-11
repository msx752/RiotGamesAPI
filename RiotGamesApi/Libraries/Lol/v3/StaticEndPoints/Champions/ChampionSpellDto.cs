using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class ChampionSpellDto
    {
        //
        [JsonProperty("cooldownBurn")]
        public string cooldownBurn { get; set; }

        //
        [JsonProperty("resource")]
        public string resource { get; set; }

        //
        [JsonProperty("leveltip")]
        public LevelTipDto leveltip { get; set; }

        //
        [JsonProperty("vars")]
        public List<SpellVarsDto> vars { get; set; }

        //
        [JsonProperty("costType")]
        public string costType { get; set; }

        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        //
        [JsonProperty("sanitizedDescription")]
        public string sanitizedDescription { get; set; }

        //
        [JsonProperty("sanitizedTooltip")]
        public string sanitizedTooltip { get; set; }

        //This field is a List of List of Double.
        [JsonProperty("effect")]
        public List<object> effect { get; set; }

        //
        [JsonProperty("tooltip")]
        public string tooltip { get; set; }

        //
        [JsonProperty("maxrank")]
        public int maxrank { get; set; }

        //
        [JsonProperty("costBurn")]
        public string costBurn { get; set; }

        //
        [JsonProperty("rangeBurn")]
        public string rangeBurn { get; set; }

        //This field is either a List of Integer or the String 'self' for spells that target one's own champion.
        [JsonProperty("range")]
        public object range { get; set; }

        //
        [JsonProperty("cooldown")]
        public List<double> cooldown { get; set; }

        //
        [JsonProperty("cost")]
        public List<int> cost { get; set; }

        //
        [JsonProperty("key")]
        public string key { get; set; }

        //
        [JsonProperty("description")]
        public string description { get; set; }

        //
        [JsonProperty("effectBurn")]
        public List<string> effectBurn { get; set; }

        //
        [JsonProperty("altimages")]
        public List<ImageDto> altimages { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}