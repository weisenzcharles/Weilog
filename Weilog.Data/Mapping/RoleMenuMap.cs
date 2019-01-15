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
    public class RoleMenuMap : EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuMap()
        {
            ToTable("RoleMenu");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(entity => entity.RoleId).IsRequired();
            Property(entity => entity.MenuId).IsRequired();
        }
    }
}
