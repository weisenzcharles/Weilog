using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Weilog.Data.DataContext
{
    /// <summary>
    ///  DbContext 实例表示工作单元和存储库模式的组合，可用来查询数据库并将更改组合在一起，这些更改稍后将作为一个单元写回存储区中。
    ///  DbContext 在概念上与 ObjectContext 类似。
    /// </summary>
    public class SQLiteDbContext : DataContext
    {

        #region Constructors

        /// <summary>
        /// Constructs a new context instance using conventions to create the name of the
        /// database to which a connection will be made. The by-convention name is the full
        /// name (namespace + class name) of the derived context class. See the class remarks
        /// for how this is used to create a connection.
        /// </summary>
        static SQLiteDbContext()
        {
            Database.SetInitializer<SQLiteDbContext>(null);
            Database.SetInitializer(new CreateDatabaseIfNotExists<SQLiteDbContext>());
        }

        /// <summary>
        /// Constructs a new context instance using conventions to create the name of the
        /// database to which a connection will be made. The by-convention name is the full
        /// name (namespace + class name) of the derived context class. See the class remarks
        /// for how this is used to create a connection.
        /// </summary>
        public SQLiteDbContext() : base("uow")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection
        /// string for the database to which a connection will be made. See the class remarks
        /// for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public SQLiteDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configure();
        }

        /// <summary>
        /// 通过现有连接来连接到数据库以构造一个新的上下文实例。如果 contextOwnsConnection 是 false，则释放上下文时将不会释放该连接。
        /// </summary>
        /// <param name="existingConnection">要用于新的上下文的现有连接。</param>
        /// <param name="contextOwnsConnection">如果设置为 true，则释放上下文时将释放该连接；否则调用方必须释放该连接。</param>
        public SQLiteDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// 在完成对派生上下文的模型的初始化后，并在该模型已锁定并用于初始化上下文之前，将调用此方法。
        /// 虽然此方法的默认实现不执行任何操作，但可在派生类中重写此方法，这样便能在锁定模型之前对其进行进一步的配置。
        /// </summary>
        /// <param name="modelBuilder">定义要创建的上下文的模型的生成器。</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new SQLiteDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);

            // dynamically load all configuration
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
