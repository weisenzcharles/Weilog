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
    /// Weilog 内容管理系统 <see cref="Link"/> 业务服务类。
    /// </summary>
     public partial class LinkService : ILinkService
     {
     
        #region Constants...

        #endregion

        #region Fields...

        private readonly ILinkRepository _linkRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor...
     
        /// <summary>
        /// 初始化 <see cref="LinkService"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器对象。</param>
        ///// <param name="eventPublisher">事件发布对象</param>
        ///<param name="unitOfWork">工作单元对象。</param>
        /// <param name="linkRepository">数据仓储对象。</param>
        public LinkService(ICacheManager cacheManager,
            /* IEventPublisher eventPublisher,*/
            IUnitOfWorkAsync unitOfWork,
            ILinkRepository linkRepository)
        {
            _cacheManager = cacheManager;
            //_eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
            _linkRepository = linkRepository;
        }
        
        #endregion
       
        #region Methods...
        
        /// <summary>
        /// 将指定的 <see cref="Link"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="link">指定的 <see cref="Link"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int AddLink(Link link, bool clearCache = true)
        {
            if (link == null)
                throw new ArgumentNullException("link");

            _linkRepository.AddLink(link);
            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.LINK_PATTERN_KEY);

            ////event notification
            //_eventPublisher.EntityInserted(link);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除指定的 <see cref="Link"/> 实体对象。
        /// </summary>
        /// <param name="link">指定的 <see cref="Link"/> 实体对象。</param>
        public int DeleteLink(Link link)
        {
            if (link == null)
                throw new ArgumentNullException("link");

            _linkRepository.DeleteLink(link);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.LINK_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(link);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="Link"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Link"/> 实体对象的唯一编号。</param>
        public int DeleteLink(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            _linkRepository.DeleteLink(id);
            //cache
            _cacheManager.RemoveByPattern(CacheKeys.LINK_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityDeleted(link);
            return _unitOfWork.SaveChanges();
        }
                
        /// <summary>
        /// 更新指定的 <see cref="Link"/> 实体对象。
        /// </summary>
        /// <param name="link">指定的 <see cref="Link"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        public int UpdateLink(Link link, bool clearCache = true)
        {
            if (link == null)
                throw new ArgumentNullException("link");

            _linkRepository.UpdateLink(link);

            //cache
            if (clearCache)
                _cacheManager.RemoveByPattern(CacheKeys.LINK_PATTERN_KEY);

            //event notification
            //_eventPublisher.EntityUpdated(link);
            return _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// 移除指定的 <see cref="Link"/> 实体对象。
        /// </summary>
        /// <param name="link">指定的 <see cref="Link"/> 实体对象。</param>
        // public int RemoveLink(Link link)
        // {
        //        if (link == null)
        //            throw new ArgumentNullException("link");
        //      _linkRepository.RemoveLink(link);
        //      _unitOfWork.SaveChanges();
        // }
        
        /// <summary>
        /// 移除指定的 <see cref="Link"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Link"/> 实体对象唯一编号。</param>
        // public int RemoveLink(int id)
        //        if (id == null)
        //            throw new ArgumentNullException("id");
        //      _linkRepository.RemoveLink(id);
        //      _unitOfWork.SaveChanges();
        // }
            
        /// <summary>
        /// 查询指定编号的 <see cref="Link"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Link"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Link"/> 实体对象，否则返回 Null。</returns>
        public Link GetLink(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");
            return _linkRepository.GetLink(id);
        }
        
        /// <summary>
        /// 获取 <see cref="IList{Link}"/> 的数据集合。
        /// </summary>
        public IList<Link> GetLinkList()
        {
            return _linkRepository.GetLinkList();
        }

        /// <summary>
        /// 分页获取所有 <see cref="Link"/> 实体。
        /// </summary>
        public IPagedList<Link> GetLinkPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _linkRepository.Queryable();
            var linkList = new PagedList<Link>(query, pageIndex, pageSize);
            return linkList;
        }
        
        #endregion
    }
}