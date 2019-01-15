using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Weilog.Logger;

namespace Weilog.Caching
{


    /// <summary>
    /// 包含用于实现输出文件缓存提供程序的抽象方法。
    /// </summary>
    public class FileCacheProvider : OutputCacheProvider
    {

        #region Fields...

        private static readonly ILog log = LoggerSource.Instance.GetLogger(typeof(FileCacheProvider));

        #endregion

        #region Properties...

        /// <summary>
        /// 获取或设置缓存文件的路径。
        /// </summary>
        public string CachePath { get; set; }

        #endregion

        #region Constructors...

        /// <summary>
        /// 初始化 <see cref="FileCacheProvider"/> 类的新实例。
        /// </summary>
        public FileCacheProvider()
        {

        }

        #endregion

        #region Method...

        #region Public Method...

        /// <summary>
        /// 初始化提供程序。
        /// </summary>
        /// <param name="name">该提供程序的名称。</param>
        /// <param name="attributes">名称/值对的集合，表示在配置中为该提供程序指定的、提供程序特定的属性。</param>
        public override void Initialize(string name, NameValueCollection attributes)
        {
            base.Initialize(name, attributes);
            CachePath = HttpContext.Current.Server.MapPath(attributes["cachePath"]);
        }

        /// <summary>
        /// 将指定项插入输出缓存中。
        /// </summary>
        /// <param name="key">entry 的唯一标识符。</param>
        /// <param name="entry">要添加到输出缓存的内容。</param>
        /// <param name="utcExpiry">缓存项到期的时间和日期。</param>
        /// <returns>对指定提供程序的引用。</returns>
        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            Object obj = Get(key);
            if (obj != null)    //这一步很重要
            {
                return obj;
            }
            Set(key, entry, utcExpiry);
            return entry;
        }

        /// <summary>
        /// 获取指定缓存标识符对象的引用。
        /// </summary>
        /// <param name="key">输出缓存中缓存项的唯一标识符。</param>
        /// <returns>在缓存中标识指定项的 key 值；如果指定项不在缓存中，则为 null。</returns>
        public override object Get(string key)
        {
            string path = GetPath(key);
            if (!File.Exists(path))
            {
                return null;
            }
            FileCacheItem item = null;
            using (FileStream file = File.OpenRead(path))
            {
                var formatter = new BinaryFormatter();
                item = (FileCacheItem)formatter.Deserialize(file);
            }

            if (item.ExpiryDate <= DateTime.Now.ToUniversalTime())
            {
                log.Info(item.ExpiryDate + "*" + key);
                Remove(key);
                return null;
            }
            return item.Item;
        }

        /// <summary>
        /// 从输出缓存中移除指定项。
        /// </summary>
        /// <param name="key">要从输出缓存中移除的项的唯一标识符。</param>
        public override void Remove(string key)
        {
            string path = GetPath(key);
            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// 将指定项插入输出缓存中，如果该项已缓存，则覆盖该项。
        /// </summary>
        /// <param name="key">entry 的唯一标识符。</param>
        /// <param name="entry">要添加到输出缓存的内容。</param>
        /// <param name="utcExpiry">缓存的 entry 到期的时间和日期。</param>
        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            FileCacheItem item = new FileCacheItem(entry, utcExpiry);
            string path = GetPath(key);
            using (FileStream file = File.OpenWrite(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, item);
            }
        }

        #endregion

        #region Private Method...

        /// <summary>
        /// 获取指定缓存标识符对象的缓存路径。
        /// </summary>
        /// <param name="key">指定缓存对象的唯一标识符。</param>
        /// <returns>缓存标识符对象的缓存路径。</returns>
        private string GetPath(string key)
        {
            string fileName = key.Replace('/', '-');
            return Path.Combine(CachePath, string.Format("{0}.txt", fileName));
        }

        #endregion

        #endregion
    }
}
