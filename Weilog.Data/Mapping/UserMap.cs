using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;

namespace Weilog.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// 初始化 <seealso cref="UserMap"/> 类的新实例。
        /// </summary>
        public UserMap()
        {
            ToTable("User");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(entity => entity.Username).HasMaxLength(64).IsRequired();
            Property(entity => entity.Password).HasMaxLength(256).IsRequired();
            Property(entity => entity.Nicename).HasMaxLength(64).IsRequired();
            Property(entity => entity.Email).HasMaxLength(256);
            Property(entity => entity.Status).IsRequired();
            Property(entity => entity.Deleted).IsRequired();
            Property(entity => entity.CreatedTime).IsRequired();
        }
    }
}
