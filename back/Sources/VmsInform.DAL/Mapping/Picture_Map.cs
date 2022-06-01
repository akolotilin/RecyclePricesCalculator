using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class Picture_Map : BaseEntityMap<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> builder)
        {
            base.Configure(builder);
            builder.ToTable("Pictures");

            builder.Property(a => a.Data)
                .IsRequired();
        }
    }
}
