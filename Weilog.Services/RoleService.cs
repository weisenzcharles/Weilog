#region using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Weilog.Caching;
using Weilog.Core.UI.Paged;
using Weilog.Entities;
using Weilog.Repositories;
using Weilog.Core.Domain.Entities;
using Weilog.Core.Domain.Uow;

#endregion

namespace Weilog.Services
{

    /// <summary>
    /// Weilog 内容管理系统 <see cref="Role"/> 业务服务类。
    /// </summary>
     public partial class RoleService : IRoleService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="RoleService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="roleRepository">数据仓储对象。</param>
        public RoleService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            IRoleRepository roleRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="Role"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="role">指定的 <see cref="Role"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int AddRole(Role role, bool clearCache = true)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            _roleRepository.AddRole(role);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.ROLE_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(role);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="Role"/> 实体对象。
        /// </summary>
        /// <param name="role">指定的 <see cref="Role"/> 实体对象。</param>
        public int DeleteRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            _roleRepository.DeleteRole(role);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.ROLE_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(role);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="Role"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Role"/> 实体对象的唯一编号。</param>
        public int DeleteRole(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _roleRepository.DeleteRole(id);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.ROLE_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(role);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="Role"/> 实体对象。
        /// </summary>
        /// <param name="role">指定的 <see cref="Role"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int UpdateRole(Role role, bool clearCache = true)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            _roleRepository.UpdateRole(role);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.ROLE_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(role);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="Role"/> 实体对象。
        /// </summary>
        /// <param name="role">指定的 <see cref="Role"/> 实体对象。</param>
        // public int RemoveRole(Role role)
        // {
        //        if (role == null)
        //            throw new ArgumentNullException("role");
        //      _roleRepository.RemoveRole(role);
        //      _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="Role"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Role"/> 实体对象唯一编号。</param>
        // public int RemoveRole(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _roleRepository.RemoveRole(id);
        //      _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="Role"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Role"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Role"/> 实体对象，否则返回 Null。</returns>
        public Role GetRole(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _roleRepository.GetRole(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{Role}"/> 的数据集合。
        /// </summary>
        public IList<Role> GetRoleList()
        {
            return _roleRepository.GetRoleList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="Role"/> 实体。
        /// </summary>
        public IPagedList<Role> GetRolePagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _roleRepository.Queryable();
            var roleList = new PagedList<Role>(query, pageIndex, pageSize);
            return roleList;
        }
        
        #endregion
    }
}