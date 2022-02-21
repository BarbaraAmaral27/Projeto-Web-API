using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace Repositories
{
    public static class Cache
    {
        static ObjectCache cache = MemoryCache.Default;

        //public static bool existe(string chave)
        //{
        //    return cache.Contains(chave);
        //}

        public static object get(string chave)
        {
            return cache.Get(chave);
        }

        public static void add(string chave, object objeto, int segundos)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(segundos);
            cache.Add(chave, objeto, policy);
        }

        public static void remove(string chave)
        {
            cache.Remove(chave);
        }
    }
}