using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;

namespace Weilog.Data.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            this.Property(bp => bp.MetaKeywords).HasMaxLength(400);
            this.Property(bp => bp.MetaTitle).HasMaxLength(400);
        }
    }
}
