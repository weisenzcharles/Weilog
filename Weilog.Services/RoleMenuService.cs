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
    /// Weilog 内容管理系统 <see cref="RoleMenu"/> 业务服务类。
    /// </summary>
     public partial class RoleMenuService : IRoleMenuService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly IRoleMenuRepository _roleMenuRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="RoleMenuService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="roleMenuRepository">数据仓储对象。</param>
        public RoleMenuService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            IRoleMenuRepository roleMenuRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _roleMenuRepository = roleMenuRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="RoleMenu"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="roleMenu">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int AddRoleMenu(RoleMenu roleMenu, bool clearCache = true)
        {
            if (roleMenu == null)
                throw new ArgumentNullException("roleMenu");

            _roleMenuRepository.AddRoleMenu(roleMenu);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.ROLEMENU_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(roleMenu);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="roleMenu">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        public int DeleteRoleMenu(RoleMenu roleMenu)
        {
            if (roleMenu == null)
                throw new ArgumentNullException("roleMenu");

            _roleMenuRepository.DeleteRoleMenu(roleMenu);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.ROLEMENU_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(roleMenu);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="RoleMenu"/> 实体对象的唯一编号。</param>
        public int DeleteRoleMenu(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _roleMenuRepository.DeleteRoleMenu(id);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.ROLEMENU_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(roleMenu);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="roleMenu">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int UpdateRoleMenu(RoleMenu roleMenu, bool clearCache = true)
        {
            if (roleMenu == null)
                throw new ArgumentNullException("roleMenu");

            _roleMenuRepository.UpdateRoleMenu(roleMenu);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.ROLEMENU_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(roleMenu);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="roleMenu">指定的 <see cref="RoleMenu"/> 实体对象。</param>
        // public int RemoveRoleMenu(RoleMenu roleMenu)
        // {
        //        if (roleMenu == null)
        //            throw new ArgumentNullException("roleMenu");
        //      _roleMenuRepository.RemoveRoleMenu(roleMenu);
        //      _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="RoleMenu"/> 实体对象唯一编号。</param>
        // public int RemoveRoleMenu(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _roleMenuRepository.RemoveRoleMenu(id);
        //      _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="RoleMenu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="RoleMenu"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="RoleMenu"/> 实体对象，否则返回 Null。</returns>
        public RoleMenu GetRoleMenu(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _roleMenuRepository.GetRoleMenu(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{RoleMenu}"/> 的数据集合。
        /// </summary>
        public IList<RoleMenu> GetRoleMenuList()
        {
            return _roleMenuRepository.GetRoleMenuList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="RoleMenu"/> 实体。
        /// </summary>
        public IPagedList<RoleMenu> GetRoleMenuPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _roleMenuRepository.Queryable();
            var roleMenuList = new PagedList<RoleMenu>(query, pageIndex, pageSize);
            return roleMenuList;
        }
        
        #endregion
    }
}