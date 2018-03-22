using BerryCMS.ICache;
using BerryCMS.Redis;
using BerryCMS.Utils;
using BerryCMS.WebCache;

namespace BerryCMS.CacheFactory
{
    public class CacheFactory
    {
        private static readonly string CacheType;
        
        static CacheFactory()
        {
            CacheType = ConfigHelper.GetValue("CacheType");
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <returns></returns>
        public static IBaseCache GetCacheInstance()
        {
            switch (CacheType)
            {
                case "Redis":
                    return new RedisCache();
                case "WebCache":
                    return new Cache();
                default:
                    return new Cache();
            }
        }
    }
}