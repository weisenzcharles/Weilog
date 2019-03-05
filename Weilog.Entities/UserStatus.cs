using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Entities
{
    /// <summary>
    /// 定义用户帐号的状态。
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 正常帐号。
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 帐号未激活。
        /// </summary>
        NotActivated = 0,
        /// <summary>
        /// 帐号禁用。
        /// </summary>
        Disabled = 2,
    }
}
