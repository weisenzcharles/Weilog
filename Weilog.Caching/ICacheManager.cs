using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Caching
{
    /// <summary>
    /// 表示实现内存中的缓存的管理器。
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 获取或具有指定的键关联的值。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <returns>具有指定键关联的值。</returns>
        T Get<T>(string key);

        /// <summary>
        /// 向缓存中插入缓存项，默认 3600 毫秒。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <param name="data">指定的对象缓存。</param>
        void Set(string key, object data);

        /// <summary>
        /// 向缓存中插入缓存项，同时指定基于时间的过期详细信息。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <param name="data">指定的对象缓存。</param>
        /// <param name="cacheTime">缓存时间。</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// 检查缓存中是否已存在该缓存项。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <returns> 如果缓存中包含具有与 key 相同的键值的缓存项，则为 true；否则为 false。</returns>
        bool Contains(string key);

        /// <summary>
        /// 从缓存中移除缓存项。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        void Remove(string key);

        /// <summary>
        /// 通过规则删除缓存项目。
        /// </summary>
        /// <param name="pattern">指定的规则。</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// 清除所有缓存数据。
        /// </summary>
        void Clear();
    }
}
