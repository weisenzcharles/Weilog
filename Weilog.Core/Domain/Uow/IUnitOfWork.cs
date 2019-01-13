using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Repositories;
using Weilog.Core.Infrastructure;

namespace Weilog.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元接口。
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 将在此上下文中所做的所有更改保存到基础数据库。
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// 此上下文中的数据仓储。
        /// </summary>
        /// <typeparam name="TEntity">实体对象。</typeparam>
        /// <returns>此上下文中的数据仓储。</returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        /// <summary>
        /// 开始数据库事务。
        /// </summary>
        /// <param name="isolationLevel">以指定的隔离级别启动数据库事务。</param>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        /// <returns></returns>
        bool Commit();
        /// <summary>
        /// 从挂起状态回滚事务。
        /// </summary>
        void Rollback();
        /// <summary>
        /// 释放上下文。
        /// </summary>
        /// <param name="disposing">如果为 true，则同时释放托管资源和非托管资源；如果为 false，则仅释放非托管资源。</param>
        void Dispose(bool disposing);
    }
}
