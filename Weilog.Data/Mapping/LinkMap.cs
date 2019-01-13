using System;
using System.Collections.Generic;
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
            ToTable("Links");
            HasKey(bp => bp.Id);
            Property(bp => bp.Name).IsRequired();
            Property(bp => bp.Description).IsRequired();

            Property(bp => bp.Deleted).IsRequired();
            Property(bp => bp.CreatedTime).IsRequired();

        }
    }
}
