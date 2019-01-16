using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Weilog.Core.Domain.DataContext;
using Weilog.Core.Domain.Repositories;
using Weilog.Core.Domain.Uow;
using Weilog.Core.Infrastructure;
using Weilog.Data.Repositories;

namespace Weilog.Data.Uow
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        #region Private Fields

        private IDataContextAsync _dataContext;
        private bool _disposed;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;
        private Dictionary<string, dynamic> _repositories;

        #endregion Private Fields

        #region Constuctor/Dispose

        /// <summary>
        /// 使用 <seealso cref="IDataContextAsync"/> 初始化 <seealso cref="UnitOfWork"/> 类的新实例。
        /// </summary>
        /// <param name="dataContext"></param>
        public UnitOfWork(IDataContextAsync dataContext)
        {
            _dataContext = dataContext;
            _repositories = new Dictionary<string, dynamic>();
        }

        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放上下文。
        /// </summary>
        /// <param name="disposing">如果为 true，则同时释放托管资源和非托管资源；如果为 false，则仅释放非托管资源。</param>
        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                try
                {
                    if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                    {
                        _objectContext.Connection.Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                    // do nothing, the objectContext has already been disposed
                }
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    _dataContext = null;
                }
            }
            // release any unmanaged objects
            // set the object references to null
            _disposed = true;
        }

        #endregion Constuctor/Dispose

        /// <summary>
        /// 将在此上下文中所做的所有更改保存到基础数据库。
        /// </summary>
        /// <returns>已写入基础数据库的对象的数目。</returns>
        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        /// <summary>
        /// 此上下文中的数据仓储。
        /// </summary>
        /// <typeparam name="TEntity">实体对象。</typeparam>
        /// <returns>此上下文中的数据仓储。</returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IRepository<TEntity>>();
            }
            return RepositoryAsync<TEntity>();
        }

        /// <summary>
        /// 此上下文中支持异步的数据仓储。
        /// </summary>
        /// <typeparam name="TEntity">实体对象。</typeparam>
        /// <returns>此上下文中支持异步的数据仓储。</returns>
        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IRepositoryAsync<TEntity>>();
            }

            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepositoryAsync<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContext, this));
            return _repositories[type];
        }

        /// <summary>
        /// 将在此上下文中所做的所有更改异步保存到基础数据库。
        /// </summary>
        /// <returns>表示异步保存操作的任务。任务结果包含已写入基础数据库的对象数目。</returns>
        public Task<int> SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// 将在此上下文中所做的所有更改异步保存到基础数据库。
        /// </summary>
        /// <param name="cancellationToken">等待任务完成期间要观察的 <see cref="System.Threading.CancellationToken"/>。</param>
        /// <returns>表示异步保存操作的任务。任务结果包含已写入基础数据库的对象数目。</returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dataContext.SaveChangesAsync(cancellationToken);
        }

        #region Unit of Work Transactions

        /// <summary>
        /// 以指定的隔离级别启动数据库事务。
        /// </summary>
        /// <param name="isolationLevel">指定事务的隔离级别。</param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }
            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
        }

        /// <summary>
        /// 从挂起状态回滚事务。
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
            //_dataContext.SyncObjectsStatePostCommit();
        }

        #endregion
    }
}
