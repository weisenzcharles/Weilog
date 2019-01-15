using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Infrastructure;

namespace Weilog.Core.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IObjectState
    {
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        /// <summary>
        /// 将指定的 <see cref="TEntity"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="entity">指定的 <see cref="TEntity"/> 实体对象。</param>
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void InsertOrUpdateGraph(TEntity entity);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// 更新指定的 <see cref="TEntity"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="TEntity"/> 实体对象。</param>
        void Update(TEntity entity);
        /// <summary>
        /// 删除指定唯一编号的 <see cref="TEntity"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="TEntity"/> 实体对象的唯一编号。</param>
        void Delete(object id);
        /// <summary>
        /// 删除指定的 <see cref="TEntity"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="TEntity"/> 实体对象。</param>
        void Delete(TEntity entity);
        /// <summary>
        /// 查询指定编号的 <see cref="TEntity"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="TEntity"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="TEntity"/> 实体对象，否则返回 Null。</returns>
        TEntity Get(object id);
        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);
        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);
        IQueryFluent<TEntity> Query();
        IQueryable<TEntity> Queryable(bool isTracking);
        /// <summary>
        /// 获取 <see cref="IQueryable{TEntity}"/> 的数据集合。
        /// </summary>
        /// <returns><see cref="IQueryable{TEntity}"/> 的数据集合。</returns>
        IQueryable<TEntity> Queryable();
        IRepository<T> GetRepository<T>() where T : class, IObjectState;
    }
}
