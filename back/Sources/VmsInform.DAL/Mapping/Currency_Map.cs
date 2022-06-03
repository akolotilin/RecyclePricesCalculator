using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class Currency_Map : BaseEntityMap<Currency>
    {
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);

            builder.ToTable("currencies");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Code)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(a => a.ExchangeRate)
                .IsRequired()
                .HasColumnType("decimal(15,2)")
                .HasDefaultValue(0);
        }
    }
}
