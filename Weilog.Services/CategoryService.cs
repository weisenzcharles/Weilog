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
    /// Weilog 内容管理系统 <see cref="Category"/> 业务服务类。
    /// </summary>
     public partial class CategoryService : ICategoryService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="CategoryService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="categoryRepository">数据仓储对象。</param>
        public CategoryService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            ICategoryRepository categoryRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="Category"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="category">指定的 <see cref="Category"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int AddCategory(Category category, bool clearCache = true)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.AddCategory(category);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.CATEGORY_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(category);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="category">指定的 <see cref="Category"/> 实体对象。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.DeleteCategory(category);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.CATEGORY_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(category);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="categoryId">指定的 <see cref="Category"/> 实体对象的唯一编号。</param>
        /// <returns>受影响记录数。</returns>
        public int DeleteCategory(int categoryId)
        {
            if (categoryId == 0)
                throw new ArgumentNullException("categoryId");
            _categoryRepository.DeleteCategory(categoryId);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.CATEGORY_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(category);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="category">指定的 <see cref="Category"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        public int UpdateCategory(Category category, bool clearCache = true)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.UpdateCategory(category);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.CATEGORY_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(category);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="category">指定的 <see cref="Category"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveCategory(Category category, bool clearCache = true)
        // {
        //    if (category == null)
        //        throw new ArgumentNullException("category");
        //    _categoryRepository.RemoveCategory(category);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.CATEGORY_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Category"/> 实体对象唯一编号。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        /// <returns>受影响记录数。</returns>
        // public int RemoveCategory(int categoryId, bool clearCache = true)
        //    if (categoryId == null)
        //        throw new ArgumentNullException("categoryId");
        //    _categoryRepository.RemoveCategory(categoryId);
        //    //cache
        //    if (clearCache)
        //        _cacheManager.RemoveByPattern(CacheKeys.CATEGORY_PATTERN_KEY);
        //    return _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="categoryId">指定的 <see cref="Category"/> 实体对象的唯一编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Category"/> 实体对象，否则返回 Null。</returns>
        public Category GetCategory(int categoryId)
        {
            if (categoryId == 0)
                throw new ArgumentNullException("categoryId");
            string key = string.Format(CacheKeys.CATEGORY_BY_ID_KEY, categoryId);
            return _cacheManager.Get(key, () => _categoryRepository.GetCategory(categoryId));
        }
        
        /// <summary>
        /// 获取 <see cref="Category"/> 实体列表。
        /// </summary>
        /// <returns>一个 <see cref="IList{Category}"/> 实体列表</returns>
        public IList<Category> GetCategoryList()
        {
            return _categoryRepository.GetCategoryList();
        }

        /// <summary>
        /// 分页获取 <see cref="Category"/> 实体列表。
        /// </summary>
        /// <param name="pageIndex">分页索引，默认从 0 开始。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <returns>一个支持分页的 <see cref="IPagedList{Category}"/> 实体列表</returns>
        public IPagedList<Category> GetCategoryPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var categoryList = new PagedList<Category>(new List<Category>(), pageIndex, pageSize);
            string key = string.Format(CacheKeys.CATEGORY_PAGED_KEY, pageIndex, pageSize);
            return _cacheManager.Get(key, () =>
             {
                 var query = _categoryRepository.Queryable();
                 categoryList = new PagedList<Category>(query, pageIndex, pageSize);
                 return categoryList;
             });
        }
        
        #endregion
    }
}