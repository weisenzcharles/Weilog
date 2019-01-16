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
    /// Weilog 内容管理系统 <see cref="Menu"/> 业务服务类。
    /// </summary>
     public partial class MenuService : IMenuService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly IMenuRepository _menuRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="MenuService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="menuRepository">数据仓储对象。</param>
        public MenuService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            IMenuRepository menuRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _menuRepository = menuRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="Menu"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int AddMenu(Menu menu, bool clearCache = true)
        {
            if (menu == null)
                throw new ArgumentNullException("menu");

            _menuRepository.AddMenu(menu);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.MENU_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(menu);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteMenu(Menu menu)
        {
            if (menu == null)
                throw new ArgumentNullException("menu");

            _menuRepository.DeleteMenu(menu);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.MENU_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(menu);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menuId">指定的 <see cref="Menu"/> 实体对象的唯一编号。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteMenu(int menuId)
        {
            if (menuId == 0)
                throw new ArgumentNullException("menuId");
            _menuRepository.DeleteMenu(menuId);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.MENU_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(menu);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int UpdateMenu(Menu menu, bool clearCache = true)
        {
            if (menu == null)
                throw new ArgumentNullException("menu");

            _menuRepository.UpdateMenu(menu);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.MENU_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(menu);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveMenu(Menu menu, bool clearCache = true)
        // {
        //    if (menu == null)
        //        throw new ArgumentNullException("menu");
        //    _menuRepository.RemoveMenu(menu);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.MENU_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Menu"/> 实体对象唯一编号。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveMenu(int menuId, bool clearCache = true)
        //    if (menuId == null)
        //        throw new ArgumentNullException("menuId");
        //    _menuRepository.RemoveMenu(menuId);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.MENU_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menuId">指定的 <see cref="Menu"/> 实体对象的唯一编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Menu"/> 实体对象，否则返回 Null。</returns>
        public Menu GetMenu(int menuId)
        {
            if (menuId == 0)
                throw new ArgumentNullException("menuId");
            string key = string.Format(CacheKeys.MENU_BY_ID_KEY, menuId);
            return _cacheManager.Get(key, () => _menuRepository.GetMenu(menuId));
        }
        
        /// <summary>
        /// 获取 <see cref="Menu"/> 实体列表。
        /// </summary>
        /// <returns>一个 <see cref="IList{Menu}"/> 实体列表</returns>
        public IList<Menu> GetMenuList()
        {
            return _menuRepository.GetMenuList();
        }

        /// <summary>
        /// 分页获取 <see cref="Menu"/> 实体列表。
        /// </summary>
        /// <param name="pageIndex">分页索引，默认从 0 开始。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <returns>一个支持分页的 <see cref="IPagedList{Menu}"/> 实体列表</returns>
        public IPagedList<Menu> GetMenuPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var menuList = new PagedList<Menu>(new List<Menu>(), pageIndex, pageSize);
            string key = string.Format(CacheKeys.MENU_PAGED_KEY, pageIndex, pageSize);
            return _cacheManager.Get(key, () =>
             {
                 var query = _menuRepository.Queryable();
                 menuList = new PagedList<Menu>(query, pageIndex, pageSize);
                 return menuList;
             });
        }
        
        #endregion
    }
}