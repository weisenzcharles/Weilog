
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Xml;

namespace Weilog.Caching
{
    /// <summary>
    /// 应用程序内存缓存提供程序类，无法继承此类。
    /// </summary>
    public class MemoryCacheProvider
    {

        #region Fields...

        /// <summary>
        /// 声明应用程序缓存对象引用。
        /// </summary>
        private static System.Web.Caching.Cache _cache;

        private static object _lockObject = new object();

        #endregion

        #region Constructors...

        /// <summary>
        /// 初始化 <see cref="MemoryCacheProvider"/> 静态实例。
        /// </summary>
        static MemoryCacheProvider()
        {
            if (_cache == null)
            {
                lock (_lockObject)
                {
                    if (_cache == null)
                    {
                        _cache = HttpContext.Current.Cache;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化 <see cref="MemoryCacheProvider"/> 类的新实例。
        /// </summary>
        public MemoryCacheProvider()
        {

        }

        #endregion

        #region Method...

        #region Private Method...

        /// <summary>
        /// 验证要插入缓存的对象，防止插入空的键值或对象。
        /// </summary>
        /// <param name="key">缓存项的标识符。</param>
        /// <param name="obj">要插入缓存中的对象。</param>
        private static void CheckObject(string key, object obj)
        {
            if (string.IsNullOrEmpty(key) || obj == null)
            {
                return;
            }
        }

        #endregion

        #region Public Method...

        #region 向缓存中插入对象...

        /// <summary>
        /// 向缓存中插入对象。
        /// </summary>
        /// <param name="key">缓存项的标识符。</param>
        /// <param name="obj">要插入缓存中的对象。</param>
        public static void Insert(string key, object obj)
        {
            CheckObject(key, obj);
            lock (_lockObject)
            {
                _cache.Insert(key, obj);
            }
        }

        /// <summary>
        /// 向缓存中插入具有过期时间的对象。
        /// </summary>
        /// <param name="key">缓存项的标识符。</param>
        /// <param name="obj">要插入缓存中的对象。</param>
        /// <param name="expire">缓存对象的过期时间（单位：分钟）。</param>
        public static void Insert(string key, object obj, int expire)
        {
            CheckObject(key, obj);
            lock (_lockObject)
            {
                var date = DateTime.Now.AddMinutes(expire);
                _cache.Insert(key, obj, null, date, TimeSpan.Zero, CacheItemPriority.High, null);
            }
        }

        /// <summary>
        /// 向缓存中插入具有过期时间和时间间隔的对象。
        /// </summary>
        /// <param name="key">缓存键值。</param>
        /// <param name="obj">要插入缓存中的对象。</param>
        /// <param name="absoluteExpiration">缓存的绝对过期时间。</param>
        /// <param name="timespan">最后一次访问所插入对象时与该对象过期时之间的时间间隔</param>
        public static void Insert(string key, object obj, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            CheckObject(key, obj);
            lock (_lockObject)
            {
                _cache.Insert(key, obj, null, absoluteExpiration, slidingExpiration);
            }
        }

        #endregion

        #region 从系统缓存中检索指定的缓存对象...

        /// <summary>
        /// 从系统缓存中检索指定的缓存对象。
        /// </summary>
        /// <param name="key">要检索的缓存项的标识符。</param>
        /// <returns>检索到的缓存项，未找到该键时为 null。</returns>
        public static object Get(string key)
        {
            return _cache.Get(key);
        }

        /// <summary>
        /// 从系统缓存中检索指定的缓存对象。
        /// </summary>
        /// <typeparam name="TEntity">需要获取的数据类型。</typeparam>
        /// <param name="key">要检索的缓存项的标识符。</param>
        /// <returns>检索到的缓存项，未找到该键时为 null。</returns>
        public static TEntity Get<TEntity>(string key) where TEntity : class
        {
            return (TEntity)_cache.Get(key);
        }

        #endregion

        #region 检索缓存中的缓存对象枚举数...

        /// <summary>
        /// 检索缓存中的缓存对象枚举数。
        /// </summary>
        /// <returns>返回缓存对象枚举数。</returns>
        public static IDictionaryEnumerator GetEnumerator()
        {
            return _cache.GetEnumerator();
        }

        #endregion

        #region 从应用程序的缓存对象中移除指定项...

        /// <summary>
        /// 从应用程序的缓存对象中移除指定项。
        /// </summary>
        public static object Remove(string key)
        {
            lock (_lockObject)
            {
                return _cache.Remove(key);
            }
        }

        #endregion

        #region 从应用程序缓存中清除所有对象...

        /// <summary>
        /// 从应用程序缓存中清除所有对象。
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator cacheEnumerator = _cache.GetEnumerator();
            lock (_lockObject)
            {
                while (cacheEnumerator.MoveNext())
                {
                    _cache.Remove(cacheEnumerator.Key.ToString());
                }
            }
        }

        #endregion

        #region 判断是否存在指定标识符的缓存对象...

        /// <summary>
        /// 判断是否存在指定标识符的缓存对象。
        /// </summary>
        /// <param name="key">指定缓存标识符。</param>
        /// <returns>如果存在，则返回 true，否则返回 false。</returns>
        public static bool IsSet(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (_cache.Get(key) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Language...

        /// <summary>
        /// 初始化应用程序的语言信息缓存。
        /// </summary>
        /// <param name="filePath">指定的语言文件路径。</param>
        /// <param name="prefix">指定应用程序的语言缓存键的前缀（全局缓存前缀）。</param>
        public static void InitLanguage(string filePath, string prefix)
        {
            string cacheKey = string.Format(CacheKeys.LANGUAGES, prefix);
            Dictionary<string, string> languageData = new Dictionary<string, string>();
            if (File.Exists(filePath))
            {
                XmlTextReader reader = new XmlTextReader(filePath);
                while (reader.Read())
                {
                    if (reader.Name == "item")
                    {
                        string key = reader.GetAttribute("key");
                        string value = reader.GetAttribute("value");
                        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                        {
                            languageData.Add(key, value);
                        }
                    }
                }
                reader.Close();
            }
            Insert(cacheKey, languageData);
        }

        /// <summary>
        /// 获取与指定的键相关联的系统语言值。
        /// </summary>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="prefix">指定系统语言缓存键的前缀（全局缓存前缀）。</param>
        /// <returns>如果找到该键，便会返回与指定的键相关联的系统语言值；否则，则会返回 string.Empty 对象。</returns>
        public static string GetLanguage(string key, string prefix)
        {
            string cacheKey = string.Format(CacheKeys.LANGUAGES, prefix);
            string value = string.Empty;
            Dictionary<string, string> languageData = Get<Dictionary<string, string>>(cacheKey);
            if (!string.IsNullOrEmpty(key))
            {
                value = languageData.TryGetValue(key, out value) ? value : string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取应用程序的语言信息集合。
        /// </summary>
        /// <param name="prefix">指定应用程序的语言缓存键的前缀（全局缓存前缀）。</param>
        /// <returns>包含键和值的对象集合。</returns>
        public static Dictionary<string, string> GetLanguages(string prefix)
        {
            string cacheKey = string.Format(CacheKeys.LANGUAGES, prefix);
            Dictionary<string, string> languageData = Get<Dictionary<string, string>>(cacheKey);
            if (languageData == null && languageData.Count == 0)
            {
                languageData = new Dictionary<string, string>();
            }
            return languageData;
        }

        #endregion

        #endregion

        #endregion

    }
}
