using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;
using Weilog.Core.Extensions;
using Weilog.Core.Infrastructure;
using Weilog.Entities;

namespace Weilog.Data.DataContext
{
    /// <summary>
    /// 在首次使用 <see cref="SQLiteDbContext"/> 派生类的实例时初始化基础数据库，与对给定模型使用迁移相关的配置。
    /// </summary>
    public class SQLiteDbInitializer : DbMigrationsConfiguration<SQLiteDbContext>
    {
        private readonly DateTime now = new DateTime(2016, 5, 1, 23, 22, 21);

        /// <summary>
        /// 初始化 <see cref="SQLiteDbInitializer"/> 类的新实例。
        /// </summary>
        public SQLiteDbInitializer()
        {
            AutomaticMigrationsEnabled = true; // 启用自动迁移
            AutomaticMigrationDataLossAllowed = true; // 是否允许接受数据丢失的情况，false = 不允许，会抛异常；true = 允许，有可能数据会丢失。
        }

        /// <summary>
        /// 应重写以向上下文实际添加数据来设置种子的方法。默认实现不执行任何操作。
        /// </summary>
        /// <param name="context">要设置种子的上下文。</param>
        protected override void Seed(SQLiteDbContext context)
        {

            #region 初始化用户...

            var admin = new User
            {
                Username = "admin",
                Nicename = "超级管理员",
                Password = "123456".ToMD5(),
                Email = "master@weilog.net",
                Status = UserStatus.Normal,
                Deleted = false,
                CreatedTime = now
            };
            var guest = new User
            {
                Username = "xiaowei",
                Nicename = "小伟",
                Password = "123456".ToMD5(),
                Email = "xiaowei@weilog.net",
                Status = UserStatus.Normal,
                Deleted = false,
                CreatedTime = now
            };
            // 用户
            var user = new List<User>
            {
                admin,
                guest
            };
            #endregion

            AddOrUpdate(context, m => m.Username, user.ToArray());

        }

        /// <summary>
        /// 调用 SaveChanges 时，按自定义标识表达式添加或更新实体。
        /// </summary>
        /// <typeparam name="T">实体的类型。</typeparam>
        /// <param name="context">DbContext 提供程序。</param>
        /// <param name="exp">指定在确定是应执行添加操作还是更新操作时应使用的属性的表达式。</param>
        /// <param name="param">要添加或更新的实体。</param>
        private void AddOrUpdate<T>(DbContext context, Expression<Func<T, object>> identifierExpression, T[] param) where T : class
        {
            DbSet<T> set = context.Set<T>();
            set.AddOrUpdate(identifierExpression, param);
        }

    }
}
