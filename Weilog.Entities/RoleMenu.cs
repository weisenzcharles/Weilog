using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    public class RoleMenu : EntityBase
    {
        /// <summary>
        /// 角色 Id。
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单 Id。
        /// </summary>
        public int MenuId { get; set; }
    }
}
