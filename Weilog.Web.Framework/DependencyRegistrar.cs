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
            //builder.RegisterType<SQLiteDbContext>().As<IDataContextAsync>().InstancePerLifetimeScope();
            //builder.Register(context => new SQLiteDbContext(context.Resolve <SQLiteConnection("data source=:memory:")> ()))
            //.As<IDataContext>().InstancePerLifetimeScope();
            //builder.Register(context => new SQLiteDbContext(new SQLiteConnection("data source=:memory:"), false)).As<IDataContextAsync>().InstancePerLifetimeScope();
            builder.Register<IDataContextAsync>(c => new SQLiteDbContext("uow")).InstancePerLifetimeScope();
            //builder.Register(c => (new SQLiteDbContext(""))
            // UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerLifetimeScope();

            // repository
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>)).InstancePerLifetimeScope();

            // repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            // services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
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
