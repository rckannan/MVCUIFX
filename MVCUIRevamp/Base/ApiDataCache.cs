using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RithV.FX.Base
{
    public sealed class ApiDataCache
    {
        private static readonly Lazy<ConcurrentDictionary<string, IEnumerable<DropDownClass>>> Datacache = new Lazy<ConcurrentDictionary<string, IEnumerable<DropDownClass>>>(() => new ConcurrentDictionary<string, IEnumerable<DropDownClass>>(), true);
        private static ApiDataCache _instance;
        private ApiDataCache()
        {
        }
        internal static void Create(string clientType, IEnumerable<DropDownClass> datatype)
        {
            if (ApiDataCache._instance == null)
            {
                ApiDataCache._instance = new ApiDataCache();
            }
            ApiDataCache.Datacache.Value.AddOrUpdate(clientType, datatype, (string s, IEnumerable<DropDownClass> context) => context);
        }
        internal static bool Update(string clientType, out IEnumerable<DropDownClass> datatype)
        {
            if (ApiDataCache._instance == null)
            {
                ApiDataCache._instance = new ApiDataCache();
            }
            return ApiDataCache.Datacache.Value.TryGetValue(clientType, out datatype);
        }

        internal static void Clear(string clientType, out IEnumerable<DropDownClass> datatype)
        {
            if (ApiDataCache._instance != null)
            {
                ApiDataCache.Datacache.Value.TryRemove(clientType, out datatype);
            }
            datatype = null;
        }

        internal static void Clearall()
        {
            if (ApiDataCache._instance != null)
            {
                ApiDataCache.Datacache.Value.Clear();
            }
        }
    }
}