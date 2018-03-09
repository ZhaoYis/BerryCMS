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
        /// 定义通用Cache
        /// </summary>
        /// <returns></returns>
        public static IBaseCache GetCache()
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