using System;
using RiotGamesApi.Library.Enums;

namespace RiotGamesApi.Library
{
    public static class Extensions
    {
        /// <summary>
        /// returns empty string if it is null 
        /// </summary>
        /// <param name="obj">
        /// </param>
        /// <returns>
        /// </returns>
        public static string ToSafetyString(this object obj)
        {
            if (obj != null)
                return obj.ToString();
            else
                return string.Empty;
        }

        public static string ToUpperFirstLetter(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static ServicePlatform ToPlatform(this ServiceRegion enumVal)
        {
            switch (enumVal)
            {
                case ServiceRegion.tr:
                    return ServicePlatform.TR1;

                case ServiceRegion.ru:
                    return ServicePlatform.RU;

                case ServiceRegion.las:
                    return ServicePlatform.LA2;

                case ServiceRegion.lan:
                    return ServicePlatform.LA1;

                case ServiceRegion.oce:
                    return ServicePlatform.OC1;

                case ServiceRegion.kr:
                    return ServicePlatform.KR;

                case ServiceRegion.na:
                    return ServicePlatform.NA1;

                case ServiceRegion.euw:
                    return ServicePlatform.EUW1;

                case ServiceRegion.br:
                    return ServicePlatform.BR1;

                case ServiceRegion.eune:
                    return ServicePlatform.EUN1;

                case ServiceRegion.jp:
                    return ServicePlatform.JP1;

                case ServiceRegion.pbe:
                    return ServicePlatform.PBE1;

                default:
                    return ServicePlatform.TR1;
            }
        }

        public static ServiceRegion ToRegion(this ServicePlatform enumVal)
        {
            switch (enumVal)
            {
                case ServicePlatform.TR1:
                    return ServiceRegion.tr;

                case ServicePlatform.NA1:
                    return ServiceRegion.na;

                case ServicePlatform.BR1:
                    return ServiceRegion.br;

                case ServicePlatform.RU:
                    return ServiceRegion.ru;

                case ServicePlatform.EUW1:
                    return ServiceRegion.euw;

                case ServicePlatform.KR:
                    return ServiceRegion.kr;

                case ServicePlatform.LA1:
                    return ServiceRegion.lan;

                case ServicePlatform.LA2:
                    return ServiceRegion.las;

                case ServicePlatform.OC1:
                    return ServiceRegion.oce;

                case ServicePlatform.EUN1:
                    return ServiceRegion.eune;

                case ServicePlatform.JP1:
                    return ServiceRegion.jp;

                case ServicePlatform.PBE1:
                    return ServiceRegion.pbe;

                default:
                    return ServiceRegion.tr;
            }
        }

        public static Language ToLanguage(this ServiceRegion enumVal)
        {
            return enumVal.ToPlatform().ToLanguage();
        }

        public static Language ToLanguage(this ServicePlatform enumVal)
        {
            switch (enumVal)
            {
                case ServicePlatform.TR1:
                    return Language.tr_TR;

                default:
                    return Language.en_US;
            }
        }

        /// <summary>
        /// get enum value from stringName 
        /// </summary>
        /// <typeparam name="T">
        /// Type Of enum 
        /// </typeparam>
        /// <param name="enumValName">
        /// StringName of enum 
        /// </param>
        /// <returns>
        /// </returns>
        public static T GetEnumValue<T>(string enumValName) where T : new()
        {
            return (T)Enum.Parse(typeof(T), enumValName);
        }
    }
}