using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Caching
{
    /// <summary>
    /// 定义缓存过期时间（单位：分钟）。
    /// </summary>
    public static class CacheExpires
    {
        /// <summary>
        /// 1分钟。
        /// </summary>
        public static readonly int ONE_MINUTE = 1;

        /// <summary>
        /// 10分钟。
        /// </summary>
        public static readonly int TEN_MINUTE = 10;

        /// <summary>
        /// 半小时。
        /// </summary>
        public static readonly int HALF_HOUR = 30;

        /// <summary>
        /// 1小时。
        /// </summary>
        public static readonly int ONE_HOUR = 60;

        /// <summary>
        /// 半天。
        /// </summary>
        public static readonly int HALF_DAY = 60 * 12;

        /// <summary>
        /// 1天。
        /// </summary>
        public static readonly int ONE_DAY = 60 * 24;

        /// <summary>
        /// 1周。
        /// </summary>
        public static readonly int ONE_WEEK = 7 * 60 * 24;

        /// <summary>
        /// 1天。
        /// </summary>
        public static readonly int ONE_MONTH = 30 * 60 * 24;
    }
}
