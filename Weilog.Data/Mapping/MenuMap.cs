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
   /// <summary>
   /// 菜单表配置
   /// </summary>
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(entity => entity.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(64);
            Property(entity => entity.Type).IsRequired();
            Property(entity => entity.Url).HasColumnType("varchar").IsRequired().HasMaxLength(512);
        }
    }
}
