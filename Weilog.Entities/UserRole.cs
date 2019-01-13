using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    /// <summary>
    /// 用户角色。
    /// </summary>
    public class UserRole : EntityBase
    {
        /// <summary>
        /// 用户 Id。
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色 Id。
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 所属用户。
        /// </summary>
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
