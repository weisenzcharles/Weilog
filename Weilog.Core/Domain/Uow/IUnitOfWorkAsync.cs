using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weilog.Core.Domain.Repositories;
using Weilog.Core.Infrastructure;

namespace Weilog.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元异步接口。
    /// </summary>
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        /// <summary>
        /// 将在此上下文中所做的所有更改异步保存到基础数据库。
        /// </summary>
        /// <returns>表示异步保存操作的任务。任务结果包含已写入基础数据库的对象数目。</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 将在此上下文中所做的所有更改异步保存到基础数据库。
        /// </summary>
        /// <param name="cancellationToken">等待任务完成期间要观察的 CancellationToken。</param>
        /// <returns>表示异步保存操作的任务。任务结果包含已写入基础数据库的对象数目。</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 此上下文中支持异步的数据仓储。
        /// </summary>
        /// <typeparam name="TEntity">实体对象。</typeparam>
        /// <returns>此上下文中支持异步的数据仓储。</returns>
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}
