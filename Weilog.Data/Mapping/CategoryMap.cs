using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;

namespace Weilog.Data.Mapping
{
    /// <summary>
    /// 分类实体数据映射配置。
    /// </summary>
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        /// <summary>
        /// 初始化 <seealso cref="CategoryMap"/> 类的新实例。
        /// </summary>
        public CategoryMap()
        {
            ToTable("Category");
            HasKey(bp => bp.Id);
            Property(bp => bp.Name).IsRequired();

            Property(bp => bp.Deleted).IsRequired();
            Property(bp => bp.CreatedTime).IsRequired();
        }
    }
}
