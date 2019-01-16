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
    /// Weilog 内容管理系统 Posts 实体类型映射配置类。
    /// </summary>
    public partial class PostMap : EntityTypeConfiguration<Post>
    {
        /// <summary>
        /// 初始化 <see cref="PostsMap"/> 类的新实例。
        /// </summary>
        public PostMap()
        {
            ToTable("Post");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(entity => entity.Id).IsRequired();
            Property(entity => entity.Title).HasMaxLength(512);
            Property(entity => entity.Author).HasMaxLength(400);
            Property(entity => entity.Excerpt).HasMaxLength(1024);
            Property(entity => entity.Content).HasMaxLength(400);
            Property(entity => entity.Type).IsRequired();
            Property(entity => entity.Status).IsRequired();
            Property(entity => entity.ModifiedTime).IsRequired();
            Property(entity => entity.CreatedTime).IsRequired();
            Property(entity => entity.Deleted).IsRequired();
        }
    }
}