using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Items
{
    public class InventoryDataStatsDto
    {
        //
        [JsonProperty("PercentCritDamageMod")]
        public double PercentCritDamageMod { get; set; }

        //
        [JsonProperty("PercentSpellBlockMod")]
        public double PercentSpellBlockMod { get; set; }

        //
        [JsonProperty("PercentHPRegenMod")]
        public double PercentHPRegenMod { get; set; }

        //
        [JsonProperty("PercentMovementSpeedMod")]
        public double PercentMovementSpeedMod { get; set; }

        //
        [JsonProperty("FlatSpellBlockMod")]
        public double FlatSpellBlockMod { get; set; }

        //
        [JsonProperty("FlatCritDamageMod")]
        public double FlatCritDamageMod { get; set; }

        //
        [JsonProperty("FlatEnergyPoolMod")]
        public double FlatEnergyPoolMod { get; set; }

        //
        [JsonProperty("PercentLifeStealMod")]
        public double PercentLifeStealMod { get; set; }

        //
        [JsonProperty("FlatMPPoolMod")]
        public double FlatMPPoolMod { get; set; }

        //
        [JsonProperty("FlatMovementSpeedMod")]
        public double FlatMovementSpeedMod { get; set; }

        //
        [JsonProperty("PercentAttackSpeedMod")]
        public double PercentAttackSpeedMod { get; set; }

        //
        [JsonProperty("FlatBlockMod")]
        public double FlatBlockMod { get; set; }

        //
        [JsonProperty("PercentBlockMod")]
        public double PercentBlockMod { get; set; }

        //
        [JsonProperty("FlatEnergyRegenMod")]
        public double FlatEnergyRegenMod { get; set; }

        //
        [JsonProperty("PercentSpellVampMod")]
        public double PercentSpellVampMod { get; set; }

        //
        [JsonProperty("FlatMPRegenMod")]
        public double FlatMPRegenMod { get; set; }

        //
        [JsonProperty("PercentDodgeMod")]
        public double PercentDodgeMod { get; set; }

        //
        [JsonProperty("FlatAttackSpeedMod")]
        public double FlatAttackSpeedMod { get; set; }

        //
        [JsonProperty("FlatArmorMod")]
        public double FlatArmorMod { get; set; }

        //
        [JsonProperty("FlatHPRegenMod")]
        public double FlatHPRegenMod { get; set; }

        //
        [JsonProperty("PercentMagicDamageMod")]
        public double PercentMagicDamageMod { get; set; }

        //
        [JsonProperty("PercentMPPoolMod")]
        public double PercentMPPoolMod { get; set; }

        //
        [JsonProperty("FlatMagicDamageMod")]
        public double FlatMagicDamageMod { get; set; }

        //
        [JsonProperty("PercentMPRegenMod")]
        public double PercentMPRegenMod { get; set; }

        //
        [JsonProperty("PercentPhysicalDamageMod")]
        public double PercentPhysicalDamageMod { get; set; }

        //
        [JsonProperty("FlatPhysicalDamageMod")]
        public double FlatPhysicalDamageMod { get; set; }

        //
        [JsonProperty("PercentHPPoolMod")]
        public double PercentHPPoolMod { get; set; }

        //
        [JsonProperty("PercentArmorMod")]
        public double PercentArmorMod { get; set; }

        //
        [JsonProperty("PercentCritChanceMod")]
        public double PercentCritChanceMod { get; set; }

        //
        [JsonProperty("PercentEXPBonus")]
        public double PercentEXPBonus { get; set; }

        //
        [JsonProperty("FlatHPPoolMod")]
        public double FlatHPPoolMod { get; set; }

        //
        [JsonProperty("FlatCritChanceMod")]
        public double FlatCritChanceMod { get; set; }

        [JsonProperty("FlatEXPBonus")]
        public double FlatEXPBonus { get; set; }
    }
}