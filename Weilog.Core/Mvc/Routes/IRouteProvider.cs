using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Weilog.Core.Mvc.Routes
{
    /// <summary>
    /// 表示路由提供程序。
    /// </summary>
    public interface IRouteProvider
    {
        /// <summary>
        /// 注册路由。
        /// </summary>
        /// <param name="routes">为路由操作提供路由的集合。</param>
        void RegisterRoutes(RouteCollection routes);

        /// <summary>
        /// 优先级别。
        /// </summary>
        int Priority { get; }
    }
}
