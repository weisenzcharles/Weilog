using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Web.Framework.Models
{
    public class UserModel : BaseModel
    {
        /// <summary>
        /// 用户名称。
        /// </summary>
        [DisplayName("登录账号*"), Required, StringLength(20, MinimumLength = 5, ErrorMessage = "长度在 5-20 个字符之间")]
        public string Username { get; set; }

        /// <summary>
        /// 密码。
        /// </summary>
        [DisplayName("登录密码*"), Required, StringLength(36, MinimumLength = 6, ErrorMessage = "长度在6-36个字符之间")]
        public string Password { get; set; }

        /// <summary>
        /// 用户昵称。
        /// </summary>
        public string Nicename { get; set; }

        /// <summary>
        /// 邮箱。
        /// </summary>
        [DisplayName("邮箱*"), Required, StringLength(36, MinimumLength = 5, ErrorMessage = "长度在5-36个字符之间")]
        public string Email { get; set; }

        /// <summary>
        /// 状态。
        /// </summary>
        [DisplayName("用户状态*"), Required]
        public bool Status { get; set; }

        /// <summary>
        /// 记住登录。
        /// </summary>
        [DisplayName("记住登录*"), Required]
        public bool RememberMe { get; set; }

        /// <summary>
        /// 用户角色。
        /// </summary>
        //[JsonIgnore]
        //public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
