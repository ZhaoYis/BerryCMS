﻿using System;
using System.Collections;
using System.Web;

namespace BerryCMS.WebCache
{
    public class Cache : ICache.IBaseCache
    {
        private readonly System.Web.Caching.Cache _cache = HttpRuntime.Cache;

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T : class
        {
            if (_cache[cacheKey] != null)
            {
                return _cache[cacheKey] as T;
            }
            return default(T);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            _cache.Insert(cacheKey, value, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            _cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键，all代表清除所有</param>
        public void RemoveCache(string cacheKey)
        {
            if (cacheKey.ToLower().Equals("all"))
            {
                this.RemoveCache();
            }
            else
            {
                _cache.Remove(cacheKey);
            }
        }
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveCache()
        {
            IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                if (cacheEnum.Key != null) _cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}