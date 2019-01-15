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
        /// <param name="id">指定的 <see cref="Category"/> 实体对象的唯一编号。</param>
        public int DeleteCategory(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _categoryRepository.DeleteCategory(id);
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
        // public int RemoveCategory(Category category)
        // {
        //        if (category == null)
        //            throw new ArgumentNullException("category");
        //      _categoryRepository.RemoveCategory(category);
        //      _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Category"/> 实体对象唯一编号。</param>
        // public int RemoveCategory(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _categoryRepository.RemoveCategory(id);
        //      _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="Category"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Category"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Category"/> 实体对象，否则返回 Null。</returns>
        public Category GetCategory(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _categoryRepository.GetCategory(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{Category}"/> 的数据集合。
        /// </summary>
        public IList<Category> GetCategoryList()
        {
            return _categoryRepository.GetCategoryList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="Category"/> 实体。
        /// </summary>
        public IPagedList<Category> GetCategoryPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _categoryRepository.Queryable();
            var categoryList = new PagedList<Category>(query, pageIndex, pageSize);
            return categoryList;
        }
        
        #endregion
    }
}