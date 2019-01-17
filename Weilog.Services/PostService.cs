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
    /// Weilog 内容管理系统 <see cref="Post"/> 业务服务类。
    /// </summary>
     public partial class PostService : IPostService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="PostService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="postRepository">数据仓储对象。</param>
        public PostService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            IPostRepository postRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="Post"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="post">指定的 <see cref="Post"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int AddPost(Post post, bool clearCache = true)
        {
            if (post == null)
                throw new ArgumentNullException("post");

            _postRepository.AddPost(post);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.POST_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(post);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="Post"/> 实体对象。
        /// </summary>
        /// <param name="post">指定的 <see cref="Post"/> 实体对象。</param>
        public int DeletePost(Post post)
        {
            if (post == null)
                throw new ArgumentNullException("post");

            _postRepository.DeletePost(post);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.POST_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(post);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="Post"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Post"/> 实体对象的唯一编号。</param>
        public int DeletePost(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _postRepository.DeletePost(id);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.POST_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(post);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="Post"/> 实体对象。
        /// </summary>
        /// <param name="post">指定的 <see cref="Post"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int UpdatePost(Post post, bool clearCache = true)
        {
            if (post == null)
                throw new ArgumentNullException("post");

            _postRepository.UpdatePost(post);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.POST_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(post);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="Post"/> 实体对象。
        /// </summary>
        /// <param name="post">指定的 <see cref="Post"/> 实体对象。</param>
        // public int RemovePost(Post post)
        // {
        //        if (post == null)
        //            throw new ArgumentNullException("post");
        //      _postRepository.RemovePost(post);
        //      _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="Post"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Post"/> 实体对象唯一编号。</param>
        // public int RemovePost(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _postRepository.RemovePost(id);
        //      _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="Post"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Post"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Post"/> 实体对象，否则返回 Null。</returns>
        public Post GetPost(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _postRepository.GetPost(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{Post}"/> 的数据集合。
        /// </summary>
        public IList<Post> GetPostList()
        {
            return _postRepository.GetPostList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="Post"/> 实体。
        /// </summary>
        public IPagedList<Post> GetPostPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _postRepository.Queryable();
            var postList = new PagedList<Post>(query, pageIndex, pageSize);
            return postList;
        }
        
        #endregion
    }
}