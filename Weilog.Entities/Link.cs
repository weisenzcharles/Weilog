using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    public class Link : EntityBase
    {
        /// <summary>
        /// 初始化 <seealso cref="Link"/> 类的新实例。
        /// </summary>
        public Link()
        {
    
        }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public string Target { get; set; }

        public string Description { get; set; }

        public bool Visible { get; set; }

        public int OrderIndex { get; set; }
        /// <summary>
        /// 更新时间。
        /// </summary>
        public DateTime ModifiedTime { get; set; }
    }
}
