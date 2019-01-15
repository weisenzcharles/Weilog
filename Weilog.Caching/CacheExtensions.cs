using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Caching
{
    /// <summary>
    /// 封装一组缓存管理的扩展方法。
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// 获取指定类型的缓存对象。
        /// </summary>
        /// <typeparam name="T">指定的对象类型。</typeparam>
        /// <param name="cacheManager">缓存管理器。</param>
        /// <param name="key">指定的键值。</param>
        /// <param name="acquire">获取的对象表达式。</param>
        /// <returns>返回指定类型的对象。</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        /// <summary>
        /// 获取指定类型的缓存对象。
        /// </summary>
        /// <typeparam name="T">指定的对象类型。</typeparam>
        /// <param name="cacheManager">缓存管理器。</param>
        /// <param name="key">指定的键值。</param>
        /// <param name="cacheTime">指定的缓存时间。</param>
        /// <param name="acquire">获取的对象表达式。</param>
        /// <returns>返回指定类型的对象。</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.Contains(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                //if (result != null)
                cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }
    }
}
