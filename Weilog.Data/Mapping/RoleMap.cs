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
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Role");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(entity => entity.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(64);
            Property(entity => entity.Description).HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
        }
    }
}
