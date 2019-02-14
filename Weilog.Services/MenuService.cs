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
        /// <param name="id">指定的 <see cref="Menu"/> 实体对象的唯一编号。</param>
        public int DeleteMenu(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _menuRepository.DeleteMenu(id);
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
        // public int RemoveMenu(Menu menu)
        // {
        //        if (menu == null)
        //            throw new ArgumentNullException("menu");
        //      _menuRepository.RemoveMenu(menu);
        //      _unitOfWork.SaveChanges();
        // }

        /// <summary>
        /// 移除指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Menu"/> 实体对象唯一编号。</param>
        // public int RemoveMenu(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _menuRepository.RemoveMenu(id);
        //      _unitOfWork.SaveChanges();
        // }

        /// <summary>
        /// 查询指定编号的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Menu"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Menu"/> 实体对象，否则返回 Null。</returns>
        public Menu GetMenu(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _menuRepository.GetMenu(id);
        }

        /// <summary>
        /// 获取指定用户的菜单。
        /// </summary>
        /// <param name="userId">用户编号。</param>
        /// <returns><see cref="IList{Menu}"/> 的数据集合</returns>
        public IList<Menu> GetMenusByUser(int userId)
        {
            // 获取我的角色
            var userRoles = _unitOfWork.Repository<UserRoles>().Queryable().Where(item => !item.Deleted && item.UserId == userId);
            var roleIds = userRoles.Select(item => item.RoleId).Distinct();
            // 获取我的角色权限
            var roleMenus = _unitOfWork.Repository<RoleMenu>().Queryable().Where(item => !item.Deleted && roleIds.Contains(item.RoleId));
            var menuIds = roleMenus.Select(item => item.MenuId).Distinct();

            return _unitOfWork.Repository<Menu>().Queryable().Where(item => !item.Deleted && menuIds.Contains(item.Id)).ToList();
        }

        /// <summary>
        /// 获取 <see cref="IList{Menu}"/> 的数据集合。
        /// </summary>
        public IList<Menu> GetMenuList()
        {
            return _menuRepository.GetMenuList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="Menu"/> 实体。
        /// </summary>
        public IPagedList<Menu> GetMenuPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _menuRepository.Queryable();
            var menuList = new PagedList<Menu>(query, pageIndex, pageSize);
            return menuList;
        }

        #endregion
    }
}