using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    /// <summary>
    /// 文章。
    /// </summary>
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// 类型。
        /// </summary>
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedTime { get; set; }


    }
}