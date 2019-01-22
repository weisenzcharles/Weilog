using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Weilog.Core.Dependency;
using Weilog.Core.Domain.DataContext;
using Weilog.Core.Domain.Repositories;
using Weilog.Core.Domain.Uow;
using Weilog.Core.Fakes;
using Weilog.Core.Infrastructure;
using Weilog.Data.DataContext;
using Weilog.Data.Repositories;
using Weilog.Data.Uow;
using Weilog.Entities;
using Weilog.Repositories;
using Weilog.Services;
using System.Data.SQLite;
using Weilog.Caching;

namespace Weilog.Web.Framework
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //    System.Diagnostics.Debugger.Break();

            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase)).As<HttpContextBase>().InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request).As<HttpRequestBase>().InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response).As<HttpResponseBase>().InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server).As<HttpServerUtilityBase>().InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session).As<HttpSessionStateBase>().InstancePerLifetimeScope();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            // DbContext
            builder.Register<IDataContextAsync>(c => new SQLiteDbContext("uow")).InstancePerLifetimeScope();

            // UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerLifetimeScope();

            // repository
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>)).InstancePerLifetimeScope();

            // caches
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("weilog_cache_static").SingleInstance();
            builder.RegisterType<RequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("weilog_cache_per_request").InstancePerLifetimeScope();

            // repositories
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LinkRepository>().As<ILinkRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MenuRepository>().As<IMenuRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleMenuRepository>().As<IRoleMenuRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRolesRepository>().As<IUserRolesRepository>().InstancePerLifetimeScope();

            // services
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<LinkService>().As<ILinkService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleMenuService>().As<IRoleMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRolesService>().As<IUserRolesService>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }
}
