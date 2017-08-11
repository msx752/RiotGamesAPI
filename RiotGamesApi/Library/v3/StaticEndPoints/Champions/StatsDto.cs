using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Champions
{
    public class StatsDto
    {
        //
        [JsonProperty("armorperlevel")]
        public double armorperlevel { get; set; }

        //
        [JsonProperty("hpperlevel")]
        public double hpperlevel { get; set; }

        //
        [JsonProperty("attackdamage")]
        public double attackdamage { get; set; }

        //
        [JsonProperty("mpperlevel")]
        public double mpperlevel { get; set; }

        //
        [JsonProperty("attackspeedoffset")]
        public double attackspeedoffset { get; set; }

        //
        [JsonProperty("armor")]
        public double armor { get; set; }

        //
        [JsonProperty("hp")]
        public double hp { get; set; }

        //
        [JsonProperty("hpregenperlevel")]
        public double hpregenperlevel { get; set; }

        //
        [JsonProperty("spellblock")]
        public double spellblock { get; set; }

        //
        [JsonProperty("attackrange")]
        public double attackrange { get; set; }

        //
        [JsonProperty("movespeed")]
        public double movespeed { get; set; }

        //
        [JsonProperty("attackdamageperlevel")]
        public double attackdamageperlevel { get; set; }

        //
        [JsonProperty("mpregenperlevel")]
        public double mpregenperlevel { get; set; }

        //
        [JsonProperty("mp")]
        public double mp { get; set; }

        //
        [JsonProperty("spellblockperlevel")]
        public double spellblockperlevel { get; set; }

        //
        [JsonProperty("crit")]
        public double crit { get; set; }

        //
        [JsonProperty("mpregen")]
        public double mpregen { get; set; }

        //
        [JsonProperty("attackspeedperlevel")]
        public double attackspeedperlevel { get; set; }

        //
        [JsonProperty("hpregen")]
        public double hpregen { get; set; }

        [JsonProperty("critperlevel")]
        public double critperlevel { get; set; }
    }
}