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
    /// Weilog 内容管理系统 RoleMenu 数据仓储类，无法继承此类。
    /// </summary>
    public sealed class RoleMenuRepository : IRoleMenuRepository
    {

        #region Fields...

        private readonly IRepositoryAsync<RoleMenu> _repository;

        #endregion

        #region Constructors...


        /// <summary>
        /// 初始化 <see cref="RoleMenuRepository"/> 类的新实例。
        /// </summary>
        public RoleMenuRepository(IRepositoryAsync<RoleMenu> roleMenuRepository)
        {
            _repository = roleMenuRepository;
        }

        #endregion

        #region Methods...

        /// <summary>
        /// 将指定的 <see cref="RoleMenu"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="entity">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        public void AddRoleMenu(RoleMenu entity)
        {
            _repository.Insert(entity);
        }

        /// <summary>
        /// 删除指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        public void DeleteRoleMenu(RoleMenu entity)
        {
            _repository.Delete(entity);
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="RoleMenu"/> 实体对象的唯一编号。</param>
        public void DeleteRoleMenu(int id)
        {
            _repository.Delete(id);
        }
                
        /// <summary>
        /// 更新指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        public void UpdateRoleMenu(RoleMenu entity)
        {
            _repository.Update(entity);
        }
        
        /// <summary>
        /// 移除指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="entity">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        // public void RemoveRoleMenu(RoleMenu entity)
        // {
        //     _repository.Delete(entity);
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="RoleMenu"/> 实体对象唯一编号。</param>
        // public void RemoveRoleMenu(int id)
        // {
        //     _repository.Delete(id);
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="RoleMenu"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="RoleMenu"/> 实体对象，否则返回 Null。</returns>
        public RoleMenu GetRoleMenu(int id)
        {
            return _repository.Get(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{RoleMenu}"/> 的数据集合。
        /// </summary>
        public IList<RoleMenu> GetRoleMenuList()
        {
            return _repository.Queryable().ToList();
        }
        
        /// <summary>
        /// 获取 <see cref="IQueryable{RoleMenu}"/> 的数据集合。
        /// </summary>
        public IQueryable<RoleMenu> Queryable()
        {
            return _repository.Queryable();
        }
        
        #endregion
    }
}


