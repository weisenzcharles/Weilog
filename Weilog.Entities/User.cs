using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    public class User : EntityBase
    {
        /// <summary>
        /// 用户名称。
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户昵称。
        /// </summary>
        public string Nicename { get; set; }

        /// <summary>
        /// 邮箱。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 状态。
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 用户角色。
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
