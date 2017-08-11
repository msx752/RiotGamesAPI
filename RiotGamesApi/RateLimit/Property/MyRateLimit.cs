using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.RateLimit.Property
{
    public class MyRateLimit
    {
        private readonly object _lock = new object();
        private ConcurrentDictionary<string, RUrlType> _regions = new ConcurrentDictionary<string, RUrlType>();

        public ConcurrentDictionary<string, RUrlType> Regions
        {
            get
            {
                lock (_lock)
                {
                    return _regions;
                }
            }
            set
            {
                lock (_lock)
                {
                    _regions = value;
                }
            }
        }

        /// <exception cref="OverflowException">
        /// The dictionary already contains the maximum number of elements ( <see cref="F:System.Int32.MaxValue" />). 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public void Add(string region, LolUrlType type, LolApiName name, List<LolApiMethodName> apiMethods, List<ApiLimit> limits)
        {
            var rut = new RUrlType();
            rut.Add(type, new RLolApiMethodName(name, apiMethods, limits.ToArray()));
            Add(region, rut);
        }

        /// <exception cref="OverflowException">
        /// The dictionary already contains the maximum number of elements ( <see cref="F:System.Int32.MaxValue" />). 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public void Add(string region, LolUrlType type, RLolApiName rla)
        {
            var rut = new RUrlType();
            rut.Add(type, rla);
            Add(region, rut);
        }

        /// <exception cref="OverflowException">
        /// The dictionary already contains the maximum number of elements ( <see cref="F:System.Int32.MaxValue" />). 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public void Add(string region, RUrlType rut)
        {
            var exists = Regions.ContainsKey(region);
            if (!exists)
            {
                Regions.TryAdd(region, rut);
            }
            else
            {
                foreach (var itm in rut.UrlTypes)
                {
                    Regions[region].Add(itm.Key, itm.Value);
                }
            }
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public bool ContainsUrlTypes(string platform)
        {
            return Regions.ContainsKey(platform);
        }

        /// <exception cref="KeyNotFoundException">
        /// The property is retrieved and <paramref name="key" /> does not exist in the collection. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public RLolApiMethodName Find(string region, LolUrlType type, LolApiName name, LolApiMethodName method)
        {
            var rut = Find(region);
            var rla = rut?.Find(type);
            var rlan = rla?.Find(name, method);
            return rlan;
        }

        /// <exception cref="KeyNotFoundException">
        /// The property is retrieved and <paramref name="key" /> does not exist in the collection. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public RUrlType Find(string region)
        {
            return ContainsUrlTypes(region) ? Regions[region] : null;
        }
    }
}