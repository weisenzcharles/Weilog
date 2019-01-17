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
    /// Weilog 内容管理系统 <see cref="UserRoles"/> 业务服务接口。
    /// </summary>
     public interface IUserRolesService
     {
     
        #region Interface...
        
        /// <summary>
        /// 将指定的 <see cref="UserRoles"/> 实体对象插入到数据库。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        int AddUserRoles(UserRoles userRoles, bool clearCache = true);

        /// <summary>
        /// 删除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        int DeleteUserRoles(UserRoles userRoles);
        
        /// <summary>
        /// 删除指定唯一编号的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象的唯一编号。</param>
        int DeleteUserRoles(int id);
                
        /// <summary>
        /// 更新指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        /// <param name="clearCache">是否清除缓存。</param>
        int UpdateUserRoles(UserRoles userRoles, bool clearCache = true);
        
        /// <summary>
        /// 移除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="userRoles">指定的 <see cref="UserRoles"/> 实体对象。</param>
        // int RemoveUserRoles(UserRoles userRoles);
        
        /// <summary>
        /// 移除指定的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象唯一编号。</param>
        // int RemoveUserRoles(int id);
            
        /// <summary>
        /// 查询指定编号的 <see cref="UserRoles"/> 实体对象。
        /// </summary>
        /// <param name="id">指定的 <see cref="UserRoles"/> 实体对象编号。</param>
        /// <returns>返回若存在则查询的 <see cref="UserRoles"/> 实体对象，否则返回 Null。</returns>
        UserRoles GetUserRoles(int id);

        
        /// <summary>
        /// 获取 <see cref="IList{UserRoles}"/> 的数据集合。
        /// </summary>
        IList<UserRoles> GetUserRolesList();

        /// <summary>
        /// 分页获取所有 <see cref="UserRoles"/> 实体。
        /// </summary>
        IPagedList<UserRoles> GetUserRolesPagedList(int pageIndex = 0, int pageSize = int.MaxValue);
        
        #endregion
        
    }

}