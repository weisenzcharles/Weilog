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
    /// Weilog 内容管理系统 <see cref="Menu"/> 业务服务接口。
    /// </summary>
     public interface IMenuService
     {
     
        #region Interface...
        
        /// <summary>
        /// 将指定的 <see cref="Menu"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        int AddMenu(Menu menu, bool clearCache = true);

        /// <summary>
        /// 删除指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        int DeleteMenu(Menu menu);
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Menu"/> 实体对象的唯一编号。</param>
        int DeleteMenu(int id);
                
        /// <summary>
        /// 更新指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        int UpdateMenu(Menu menu, bool clearCache = true);
        
        /// <summary>
        /// 移除指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="menu">指定的 <see cref="Menu"/> 实体对象。</param>
        // int RemoveMenu(Menu menu);
        
        /// <summary>
        /// 移除指定的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Menu"/> 实体对象唯一编号。</param>
        // int RemoveMenu(int id);
            
        /// <summary>
        /// 查询指定编号的 <see cref="Menu"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="Menu"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="Menu"/> 实体对象，否则返回 Null。</returns>
        Menu GetMenu(int id);

        /// <summary>
        /// 获取指定用户的菜单。
        /// </summary>
        /// <param name="userId">用户编号。</param>
        /// <returns><see cref="IList{Menu}"/> 的数据集合</returns>
        IList<Menu> GetMenusByUser(int userId);

        /// <summary>
        /// 获取 <see cref="IList{Menu}"/> 的数据集合。
        /// </summary>
        /// <returns><see cref="IList{Menu}"/> 的数据集合</returns>
        IList<Menu> GetMenuList();

        /// <summary>
        /// 分页获取所有 <see cref="Menu"/> 实体。
        /// </summary>
        IPagedList<Menu> GetMenuPagedList(int pageIndex = 0, int pageSize = int.MaxValue);
        
        #endregion
        
    }

}