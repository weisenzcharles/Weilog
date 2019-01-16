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
    /// Weilog 内容管理系统 <see cref="User"/> 业务服务类。
    /// </summary>
     public partial class UserService : IUserService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="UserService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="userRepository">数据仓储对象。</param>
        public UserService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            IUserRepository userRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="User"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="user">指定的 <see cref="User"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int AddUser(User user, bool clearCache = true)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.AddUser(user);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.USER_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(user);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="user">指定的 <see cref="User"/> 实体对象。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.DeleteUser(user);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.USER_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(user);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="userId">指定的 <see cref="User"/> 实体对象的唯一编号。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteUser(int userId)
        {
            if (userId == 0)
                throw new ArgumentNullException("userId");
            _userRepository.DeleteUser(userId);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.USER_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(user);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="user">指定的 <see cref="User"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int UpdateUser(User user, bool clearCache = true)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.UpdateUser(user);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.USER_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(user);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="user">指定的 <see cref="User"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveUser(User user, bool clearCache = true)
        // {
        //    if (user == null)
        //        throw new ArgumentNullException("user");
        //    _userRepository.RemoveUser(user);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.USER_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="User"/> 实体对象唯一编号。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveUser(int userId, bool clearCache = true)
        //    if (userId == null)
        //        throw new ArgumentNullException("userId");
        //    _userRepository.RemoveUser(userId);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.USER_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="userId">指定的 <see cref="User"/> 实体对象的唯一编号。</param>
        /// <returns>返回若存在则查询的 <see cref="User"/> 实体对象，否则返回 Null。</returns>
        public User GetUser(int userId)
        {
            if (userId == 0)
                throw new ArgumentNullException("userId");
            string key = string.Format(CacheKeys.USER_BY_ID_KEY, userId);
            return _cacheManager.Get(key, () => _userRepository.GetUser(userId));
        }
        
        /// <summary>
        /// 获取 <see cref="User"/> 实体列表。
        /// </summary>
        /// <returns>一个 <see cref="IList{User}"/> 实体列表</returns>
        public IList<User> GetUserList()
        {
            return _userRepository.GetUserList();
        }

        /// <summary>
        /// 分页获取 <see cref="User"/> 实体列表。
        /// </summary>
        /// <param name="pageIndex">分页索引，默认从 0 开始。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <returns>一个支持分页的 <see cref="IPagedList{User}"/> 实体列表</returns>
        public IPagedList<User> GetUserPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var userList = new PagedList<User>(new List<User>(), pageIndex, pageSize);
            string key = string.Format(CacheKeys.USER_PAGED_KEY, pageIndex, pageSize);
            return _cacheManager.Get(key, () =>
             {
                 var query = _userRepository.Queryable();
                 userList = new PagedList<User>(query, pageIndex, pageSize);
                 return userList;
             });
        }
        
        #endregion
    }
}