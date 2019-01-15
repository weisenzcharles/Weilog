using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Weilog.Core.Mvc.Routes
{
    /// <summary>
    /// 表示提供路由发布的路由管理器。
    /// </summary>
    public interface IRouteManager
    {
        /// <summary>
        /// 注册路由。
        /// </summary>
        /// <param name="routes">为 ASP.NET 路由操作提供路由的集合。</param>
        void RegisterRoutes(RouteCollection routeCollection);
    }
}
