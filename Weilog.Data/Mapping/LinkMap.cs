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
    public class LinkMap : EntityTypeConfiguration<Link>
    {
        public LinkMap()
        {
            ToTable("Link");
            HasKey(entity => entity.Id);
            Property(entity => entity.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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
