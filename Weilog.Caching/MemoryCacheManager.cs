using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weilog.Caching
{
    /// <summary>
    /// 表示实现内存中的缓存的管理器。
    /// </summary>
    public partial class MemoryCacheManager : ICacheManager
    {
        /// <summary>
        /// 获取当前缓存。
        /// </summary>
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        /// 获取或具有指定的键关联的值。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="key">指定的键。</param>
        /// <returns>具有指定键关联的值。</returns>
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// 添加指定的键和对象缓存，默认 3600 毫秒。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <param name="data">指定的对象缓存。</param>
        public virtual void Set(string key, object data)
        {
            Set(key, data, 3600);
        }

        /// <summary>
        /// 向缓存中插入缓存项，同时指定基于时间的过期详细信息。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <param name="data">指定的对象缓存。</param>
        /// <param name="cacheTime">缓存时间。</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// 获取一个值，指示是否具有指定键关联的缓存。
        /// </summary>
        /// <param name="key">指定的键。</param>
        /// <returns> 如果缓存中包含具有与 key 相同的键值的缓存项，则为 true；否则为 false。</returns>
        public virtual bool Contains(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// 从缓存中移除缓存项。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// 通过规则删除缓存项目。
        /// </summary>
        /// <param name="pattern">指定的规则。</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// 清除所有缓存数据。
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}
