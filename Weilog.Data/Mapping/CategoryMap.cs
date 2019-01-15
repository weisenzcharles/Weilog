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
    /// Weilog 内容管理系统 Category 实体类型映射配置类。
    /// </summary>
    public partial class CategoryMap : EntityTypeConfiguration<Category>
    {
        /// <summary>
        /// 初始化 <see cref="CategoryMap"/> 类的新实例。
        /// </summary>
        public CategoryMap()
        {
            ToTable("Category");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(entity => entity.Id).IsRequired();
            Property(entity => entity.Name).IsRequired().HasMaxLength(128);
            Property(entity => entity.Url).HasMaxLength(1024);
            Property(entity => entity.Image).HasMaxLength(1024);
            Property(entity => entity.Target).HasMaxLength(64);
            Property(entity => entity.Description).HasMaxLength(512);
            Property(entity => entity.Visible).IsRequired();
            Property(entity => entity.OrderIndex).IsRequired();
            Property(entity => entity.ModifiedTime).IsRequired();
            Property(entity => entity.CreatedTime).IsRequired();
            Property(entity => entity.Deleted).IsRequired();
        }
    }
}