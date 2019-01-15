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
        /// <param name="id">指定的 <see cref="User"/> 实体对象的唯一编号。</param>
        public int DeleteUser(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _userRepository.DeleteUser(id);
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
        // public int RemoveUser(User user)
        // {
        //        if (user == null)
        //            throw new ArgumentNullException("user");
        //      _userRepository.RemoveUser(user);
        //      _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="User"/> 实体对象唯一编号。</param>
        // public int RemoveUser(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _userRepository.RemoveUser(id);
        //      _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="User"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="User"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="User"/> 实体对象，否则返回 Null。</returns>
        public User GetUser(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _userRepository.GetUser(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{User}"/> 的数据集合。
        /// </summary>
        public IList<User> GetUserList()
        {
            return _userRepository.GetUserList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="User"/> 实体。
        /// </summary>
        public IPagedList<User> GetUserPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _userRepository.Queryable();
            var userList = new PagedList<User>(query, pageIndex, pageSize);
            return userList;
        }
        
        #endregion
    }
}