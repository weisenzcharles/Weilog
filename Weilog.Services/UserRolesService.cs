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
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象的唯一编号。</param>
        public int DeleteUserRoles(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _userRolesRepository.DeleteUserRoles(id);
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
        // public int RemoveUserRoles(UserRoles userRoles)
        // {
        //        if (userRoles == null)
        //            throw new ArgumentNullException("userRoles");
        //      _userRolesRepository.RemoveUserRoles(userRoles);
        //      _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象唯一编号。</param>
        // public int RemoveUserRoles(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _userRolesRepository.RemoveUserRoles(id);
        //      _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="UserRoles"/> 实体对象，否则返回 Null。</returns>
        public UserRoles GetUserRoles(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _userRolesRepository.GetUserRoles(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{UserRoles}"/> 的数据集合。
        /// </summary>
        public IList<UserRoles> GetUserRolesList()
        {
            return _userRolesRepository.GetUserRolesList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="UserRoles"/> 实体。
        /// </summary>
        public IPagedList<UserRoles> GetUserRolesPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _userRolesRepository.Queryable();
            var userRolesList = new PagedList<UserRoles>(query, pageIndex, pageSize);
            return userRolesList;
        }
        
        #endregion
    }
}