using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Caching
{

    /// <summary>
    /// 定义文件缓存项。
    /// </summary>
    [Serializable]
    public class FileCacheItem
    {
        #region Fields...

        /// <summary>
        /// 缓存的到期的时间和日期。
        /// </summary>
        public DateTime ExpiryDate;
        /// <summary>
        /// 要添加到输出缓存的内容。
        /// </summary>
        public object Item;

        #endregion

        #region Properties...

        /// <summary>
        /// 初始化 <see cref="FileCacheItem"/> 的新实例。
        /// </summary>
        /// <param name="entry">要添加到输出缓存的内容。</param>
        /// <param name="utcExpiry">缓存的 entry 到期的时间和日期。</param>
        public FileCacheItem(object entry, DateTime utcExpiry)
        {
            Item = entry;
            ExpiryDate = utcExpiry;
        }

        #endregion
    }
}
