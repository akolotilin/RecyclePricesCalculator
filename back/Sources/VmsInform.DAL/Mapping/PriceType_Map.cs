using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PriceType_Map : BaseEntityMap<PriceType>
    {
        public override void Configure(EntityTypeBuilder<PriceType> builder)
        {
            base.Configure(builder);

            builder.ToTable("price_types");

            builder.Property(a => a.Name)
                .HasMaxLength(100);

            builder.Property(a => a.Description)
                .HasMaxLength(1000)
                .HasDefaultValue(string.Empty)
                .IsRequired();
        }
    }
}
