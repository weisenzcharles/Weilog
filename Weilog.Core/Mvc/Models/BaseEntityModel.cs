using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Core.Mvc.Models
{
    /// <summary>
    /// 定义应用程序的基础实体对象模型。
    /// </summary>
    public partial class BaseEntityModel : BaseModel
    {
        /// <summary>
        /// 获取或设置唯一编号。
        /// </summary>
        public virtual int Id { get; set; }
    }
}
