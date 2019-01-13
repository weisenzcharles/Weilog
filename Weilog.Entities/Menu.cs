using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    /// <summary>
    /// 菜单。
    /// </summary>
    public class Menu : EntityBase
    {
        /// <summary>
        /// 父级 Id。
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 类型。
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Url。
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序索引。
        /// </summary>
        public int OrderIndex { get; set; }
    }
}
