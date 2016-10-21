using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace WX_TennisAssociation.Common
{
    public class MemoryCacheHelper
    {
        static readonly ObjectCache cache = MemoryCache.Default;

        public static T AddOrGetExisting<T>(string key, Func<T> createNew)
        {
            return AddOrGetExisting<T>(key, new TimeSpan(0, 0, 60, 0), createNew);
        }

        public static T AddOrGetExisting<T>(string key, TimeSpan cacheDuration, Func<T> createNew)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (createNew == null) throw new ArgumentNullException("createNew");
            if (!cache.Contains(key))
            {
                cache.Add(key, createNew(), DateTime.Now.Add(cacheDuration));
            }
            return (T)cache[key];
        }

        public static T GetCacheItem<T>(string key, Func<T> createNew, TimeSpan time)
        {
            return AddOrGetExisting<T>(key, time, createNew);
        }

    }
}