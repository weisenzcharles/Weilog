using Weilog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weilog.Data.Mapping
{
    /// <summary>
    /// Weilog 内容管理系统 UserRoles 实体类型映射配置类。
    /// </summary>
    public partial class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// 初始化 <see cref="UserRolesMap"/> 类的新实例。
        /// </summary>
        public UserRoleMap()
        {
            ToTable("UserRoles");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(entity => entity.Id).IsRequired();
            Property(entity => entity.UserId).IsRequired();
            Property(entity => entity.RoleId).IsRequired();
            Property(entity => entity.CreatedTime).IsRequired();
            Property(entity => entity.Deleted).IsRequired();
        }
    }
}