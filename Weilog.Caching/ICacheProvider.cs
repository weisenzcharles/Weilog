using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Caching
{
    /// <summary>
    /// 应用程序缓存提供程序接口。
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// 向缓存中插入对象。
        /// </summary>
        /// <param name="key">缓存项的标识符。</param>
        /// <param name="obj">要插入缓存中的对象。</param>
        void Insert(string key, object obj);

        /// <summary>
        /// 向缓存中插入具有过期时间的对象。
        /// </summary>
        /// <param name="key">缓存项的标识符。</param>
        /// <param name="obj">要插入缓存中的对象。</param>
        /// <param name="expire">缓存对象的过期时间（单位：分钟）。</param>
        void Insert(string key, object obj, int expire);

        /// <summary>
        /// 向缓存中插入具有过期时间和时间间隔的对象。
        /// </summary>
        /// <param name="key">缓存键值。</param>
        /// <param name="obj">要插入缓存中的对象。</param>
        /// <param name="absoluteExpiration">缓存的绝对过期时间。</param>
        /// <param name="timespan">最后一次访问所插入对象时与该对象过期时之间的时间间隔</param>
        void Insert(string key, object obj, DateTime absoluteExpiration, TimeSpan slidingExpiration);

        /// <summary>
        /// 从系统缓存中检索指定的缓存对象。
        /// </summary>
        /// <param name="key">要检索的缓存项的标识符。</param>
        /// <returns>检索到的缓存项，未找到该键时为 null。</returns>
        object Get(string key);

        /// <summary>
        /// 从系统缓存中检索指定的缓存对象。
        /// </summary>
        /// <typeparam name="TEntity">需要获取的数据类型。</typeparam>
        /// <param name="key">要检索的缓存项的标识符。</param>
        /// <returns>检索到的缓存项，未找到该键时为 null。</returns>
        TEntity Get<TEntity>(string key) where TEntity : class;

        /// <summary>
        /// 检索缓存中的缓存对象枚举数。
        /// </summary>
        /// <returns>返回缓存对象枚举数。</returns>
        IDictionaryEnumerator GetEnumerator();

        /// <summary>
        /// 从应用程序的缓存对象中移除指定项。
        /// </summary>
        object Remove(string key);

        /// <summary>
        /// 从应用程序缓存中清除所有对象。
        /// </summary>
        void Clear();

        /// <summary>
        /// 判断是否存在指定标识符的缓存对象。
        /// </summary>
        /// <param name="key">指定缓存标识符。</param>
        /// <returns>如果存在，则返回 true，否则返回 false。</returns>
        bool IsSet(string key);

        #region Language...

        /// <summary>
        /// 初始化语言信息缓存。
        /// </summary>
        /// <param name="filePath">指定的语言文件路径。</param>
        /// <param name="prefix">指定系统语言缓存键的前缀（全局缓存前缀）。</param>
        void InitLanguage(string key, string prefix);

        /// <summary>
        /// 获取与指定的键相关联的系统语言值。
        /// </summary>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="prefix">指定系统语言缓存键的前缀（全局缓存前缀）。</param>
        /// <returns>如果找到该键，便会返回与指定的键相关联的系统语言值；否则，则会返回 string.Empty 对象。</returns>
        string GetLanguage(string key, string prefix);

        /// <summary>
        /// 获取系统语言信息集合。
        /// </summary>
        /// <param name="prefix">指定系统语言缓存键的前缀（全局缓存前缀）。</param>
        /// <returns>包含键和值的对象集合。</returns>
        Dictionary<string, string> GetLanguages(string prefix);

        #endregion

    }
}
