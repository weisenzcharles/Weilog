using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;
using Weilog.Core.Domain.Repositories;

namespace Weilog.Repositories
{
    /// <summary>
    /// Weilog 内容管理系统 UserRoles 数据仓储类，无法继承此类。
    /// </summary>
    public sealed class UserRolesRepository : IUserRolesRepository
    {

        #region Fields...

        private readonly IRepositoryAsync<UserRoles> _repository;

        #endregion

        #region Constructors...


        /// <summary>
        /// 初始化 <see cref="UserRolesRepository"/> 类的新实例。
        /// </summary>
        public UserRolesRepository(IRepositoryAsync<UserRoles> userRolesRepository)
        {
            _repository = userRolesRepository;
        }

        #endregion

        #region Methods...

        /// <summary>
        /// 将指定的 <see cref="UserRoles"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="entity">指定的 <see cref="UserRoles"/> 实体对象。</param>
        public void AddUserRoles(UserRoles entity)
        {
            _repository.Insert(entity);
        }

        /// <summary>
        /// 删除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="UserRoles"/> 实体对象。</param>
        public void DeleteUserRoles(UserRoles entity)
        {
            _repository.Delete(entity);
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="UserRoles"/> 实体对象的唯一编号。</param>
        public void DeleteUserRoles(int id)
        {
            _repository.Delete(id);
        }
                
        /// <summary>
        /// 更新指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="UserRoles"/> 实体对象。</param>
        public void UpdateUserRoles(UserRoles entity)
        {
            _repository.Update(entity);
        }
        
        /// <summary>
        /// 移除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="UserRoles"/> 实体对象。</param>
        // public void RemoveUserRoles(UserRoles entity)
        // {
        //     _repository.Delete(entity);
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象唯一编号。</param>
        // public void RemoveUserRoles(int id)
        // {
        //     _repository.Delete(id);
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="UserRoles"/> 实体对象，否则返回 Null。</returns>
        public UserRoles GetUserRoles(int id)
        {
            return _repository.Get(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{UserRoles}"/> 的数据集合。
        /// </summary>
        public IList<UserRoles> GetUserRolesList()
        {
            return _repository.Queryable().ToList();
        }
        
        /// <summary>
        /// 获取 <see cref="IQueryable{UserRoles}"/> 的数据集合。
        /// </summary>
        public IQueryable<UserRoles> Queryable()
        {
            return _repository.Queryable();
        }
        
        #endregion
    }
}


