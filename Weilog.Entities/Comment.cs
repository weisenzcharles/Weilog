using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    /// <summary>
    /// 评论。
    /// </summary>
    public class Comment : EntityBase
    {
        /// <summary>
        /// 初始化 <seealso cref="Comment"/> 类的新实例。
        /// </summary>
        public Comment()
        {

        }

        public string Content { get; set; }

        public string Author { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorUrl { get; set; }

        public string AuthorIP { get; set; }

        public int PostId { get; set; }
        /// <summary>
        /// 类型。
        /// </summary>
        public string Type { get; set; }
    }
}
