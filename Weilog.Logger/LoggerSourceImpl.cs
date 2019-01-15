using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using log4net.Util;
using System.IO;
using System.Globalization;

namespace Weilog.Logger
{
    /// <summary>
    /// 表示一个日志来源记录器的实现方法。
    /// </summary>
    [Serializable]
    public class LoggerSourceImpl : ILoggerSource
    {

        /// <summary>
        /// 初始化 <see cref="LoggerSourceImpl"/> 类的新实例。
        /// </summary>
        public LoggerSourceImpl()
        { 
        }

        public ILog GetLogger(Type type)
        {
            return new Logger(log4net.LogManager.GetLogger(type).Logger, type);
        }

        public ILog GetLogger(string name)
        {
            return new Logger(log4net.LogManager.GetLogger(name).Logger, null);
        }

       
    }
}
