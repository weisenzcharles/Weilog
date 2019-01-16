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
    /// Weilog 内容管理系统 <see cref="UserRoles"/> 业务服务类。
    /// </summary>
     public partial class UserRolesService : IUserRolesService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly IUserRolesRepository _userRolesRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="UserRolesService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="userRolesRepository">数据仓储对象。</param>
        public UserRolesService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            IUserRolesRepository userRolesRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _userRolesRepository = userRolesRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="UserRoles"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int AddUserRoles(UserRoles userRoles, bool clearCache = true)
        {
            if (userRoles == null)
                throw new ArgumentNullException("userRoles");

            _userRolesRepository.AddUserRoles(userRoles);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.USERROLES_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(userRoles);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteUserRoles(UserRoles userRoles)
        {
            if (userRoles == null)
                throw new ArgumentNullException("userRoles");

            _userRolesRepository.DeleteUserRoles(userRoles);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.USERROLES_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(userRoles);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRolesId">指定的 <see cref="UserRoles"/> 实体对象的唯一编号。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteUserRoles(int userRolesId)
        {
            if (userRolesId == 0)
                throw new ArgumentNullException("userRolesId");

            _userRolesRepository.DeleteUserRoles(userRolesId);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.USERROLES_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(userRoles);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int UpdateUserRoles(UserRoles userRoles, bool clearCache = true)
        {
            if (userRoles == null)
                throw new ArgumentNullException("userRoles");

            _userRolesRepository.UpdateUserRoles(userRoles);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.USERROLES_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(userRoles);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveUserRoles(UserRoles userRoles, bool clearCache = true)
        // {
        //    if (userRoles == null)
        //        throw new ArgumentNullException("userRoles");
        //    _userRolesRepository.RemoveUserRoles(userRoles);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.USERROLES_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象唯一编号。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveUserRoles(int userRolesId, bool clearCache = true)
        //    if (userRolesId == null)
        //        throw new ArgumentNullException("userRolesId");
        //    _userRolesRepository.RemoveUserRoles(userRolesId);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.USERROLES_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRolesId">指定的 <see cref="UserRoles"/> 实体对象的唯一编号。</param>
        /// <returns>返回若存在则查询的 <see cref="UserRoles"/> 实体对象，否则返回 Null。</returns>
        public UserRoles GetUserRoles(int userRolesId)
        {
            if (userRolesId == 0)
                throw new ArgumentNullException("userRolesId");
            string key = string.Format(CacheKeys.USERROLES_BY_ID_KEY, userRolesId);
            return _cacheManager.Get(key, () => _userRolesRepository.GetUserRoles(userRolesId));
        }
        
        /// <summary>
        /// 获取 <see cref="UserRoles"/> 实体列表。
        /// </summary>
        /// <returns>一个 <see cref="IList{UserRoles}"/> 实体列表</returns>
        public IList<UserRoles> GetUserRolesList()
        {
            return _userRolesRepository.GetUserRolesList();
        }

        /// <summary>
        /// 分页获取 <see cref="UserRoles"/> 实体列表。
        /// </summary>
        /// <param name="pageIndex">分页索引，默认从 0 开始。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <returns>一个支持分页的 <see cref="IPagedList{UserRoles}"/> 实体列表</returns>
        public IPagedList<UserRoles> GetUserRolesPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var userRolesList = new PagedList<UserRoles>(new List<UserRoles>(), pageIndex, pageSize);
            string key = string.Format(CacheKeys.USERROLES_PAGED_KEY, pageIndex, pageSize);
            return _cacheManager.Get(key, () =>
             {
                 var query = _userRolesRepository.Queryable();
                 userRolesList = new PagedList<UserRoles>(query, pageIndex, pageSize);
                 return userRolesList;
             });
        }
        
        #endregion
    }
}