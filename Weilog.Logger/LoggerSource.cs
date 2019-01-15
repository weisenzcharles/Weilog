using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Logger
{
    /// <summary>
    /// 表示一个日志来源记录器。
    /// </summary>
    public static class LoggerSource
    {
        /// <summary>
        /// 声明 <see cref="ILoggerSource"/> 对象实例的引用。
        /// </summary>
        static ILoggerSource _instance = new LoggerSourceImpl();

        /// <summary>
        /// 取得日志来源记录器对象实例。
        /// </summary>
        public static ILoggerSource Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 设置日志来源记录器对象。
        /// </summary>
        /// <param name="loggerSource"></param>
        public static void SetTestableInstance(ILoggerSource loggerSource)
        {
            _instance = loggerSource;
        }

    }
}
