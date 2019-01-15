
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Weilog.Caching
{
    /// <summary>
    /// 表示实现 Http 请求的缓存的管理器。
    /// </summary>
    public partial class RequestCacheManager : ICacheManager
    {
        private readonly HttpContextBase _context;

        /// <summary>
        /// 初始化 <see cref="RequestCacheManager"/> 类的新实例。
        /// </summary>
        /// <param name="context">HTTP 请求内容。</param>
        public RequestCacheManager(HttpContextBase context)
        {
            this._context = context;
        }

        /// <summary>
        /// 获取一个键/值集合，该集合在 HTTP 请求过程中可以用于在模块与处理程序之间组织和共享数据。
        /// </summary>
        /// <returns>一个键/值集合，使用指定的键提供对集合中单个值的访问。</returns>
        protected virtual IDictionary GetItems()
        {
            if (_context != null)
                return _context.Items;

            return null;
        }

        /// <summary>
        /// 获取或具有指定的键关联的值。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <returns>具有指定键关联的值。</returns>
        public virtual T Get<T>(string key)
        {
            var items = GetItems();
            if (items == null)
                return default(T);

            return (T)items[key];
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
            var items = GetItems();
            if (items == null)
                return;

            if (data != null)
            {
                if (items.Contains(key))
                    items[key] = data;
                else
                    items.Add(key, data);
            }
        }

        /// <summary>
        /// 检查缓存中是否已存在该缓存项。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        /// <returns> 如果缓存中包含具有与 key 相同的键值的缓存项，则为 true；否则为 false。</returns>
        public virtual bool Contains(string key)
        {
            var items = GetItems();
            if (items == null)
                return false;

            return (items[key] != null);
        }

        /// <summary>
        /// 从缓存中移除缓存项。
        /// </summary>
        /// <param name="key">该缓存项的唯一标识符。</param>
        public virtual void Remove(string key)
        {
            var items = GetItems();
            if (items == null)
                return;

            items.Remove(key);
        }

        /// <summary>
        /// 通过规则删除缓存项目。
        /// </summary>
        /// <param name="pattern">指定的规则。</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var items = GetItems();
            if (items == null)
                return;

            var enumerator = items.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Key.ToString()))
                {
                    keysToRemove.Add(enumerator.Key.ToString());
                }
            }

            foreach (string key in keysToRemove)
            {
                items.Remove(key);
            }
        }

        /// <summary>
        /// 清除所有缓存数据。
        /// </summary>
        public virtual void Clear()
        {
            var items = GetItems();
            if (items == null)
                return;

            var enumerator = items.GetEnumerator();
            var keysToRemove = new List<String>();
            while (enumerator.MoveNext())
            {
                keysToRemove.Add(enumerator.Key.ToString());
            }

            foreach (string key in keysToRemove)
            {
                items.Remove(key);
            }
        }
    }
}
