using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Logger
{

    /// <summary>
    /// 表示一个日志来源记录器的接口。
    /// </summary>
    public interface ILoggerSource
    {

        /// <summary>
        /// 获取日志记录器。
        /// </summary>
        /// <param name="type">指定的类型。</param>
        /// <returns>返回日志对象。</returns>
        ILog GetLogger(Type type);

        /// <summary>
        /// 获取日志记录器。
        /// </summary>
        /// <param name="name">指定的名字。</param>
        /// <returns>返回日志对象。</returns>
        ILog GetLogger(string name);

    }
}
