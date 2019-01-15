using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Logger
{
    /// <summary>
    /// 表示一个记录应用程序日志信息的接口。
    /// </summary>
    public interface ILog
    {

        bool DebugEnabled { get; }
        bool InfoEnabled { get; }
        bool TraceEnabled { get; }
        bool WarnEnabled { get; }
        bool ErrorEnabled { get; }
        bool FatalEnabled { get; }

        void Debug(object message);
        void Debug(object message, Exception exception);
        void DebugFormat(string format, params object[] args);
        void DebugFormat(IFormatProvider provider, string format, params object[] args);

        void Info(object message);
        void Info(object message, Exception exception);
        void InfoFormat(string format, params object[] args);
        void InfoFormat(IFormatProvider provider, string format, params object[] args);

        void Trace(object message);
        void Trace(object message, Exception exception);
        void TraceFormat(string format, params object[] args);
        void TraceFormat(IFormatProvider provider, string format, params object[] args);

        void Warn(object message);
        void Warn(object message, Exception exception);
        void WarnFormat(string format, params object[] args);
        void WarnFormat(IFormatProvider provider, string format, params object[] args);

        void Error(object message);
        void Error(object message, Exception exception);
        void ErrorFormat(string format, params object[] args);
        void ErrorFormat(IFormatProvider provider, string format, params object[] args);

        void Fatal(object message);
        void Fatal(object message, Exception exception);
        void FatalFormat(string format, params object[] args);
        void FatalFormat(IFormatProvider provider, string format, params object[] args);

    }
}
