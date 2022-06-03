using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class Partner_Map : BaseEntityMap<Partner>
    {
        public override void Configure(EntityTypeBuilder<Partner> builder)
        {
            base.Configure(builder);

            builder.ToTable("partners");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.Comment)
                .HasDefaultValue(string.Empty)
                .HasMaxLength(1000);

            builder.Property(a => a.TaxNumber)
                .HasMaxLength(12)
                .IsRequired()
                .HasDefaultValue(string.Empty);

            builder.Property(a => a.TransportPrice)
                .HasColumnType("decimal(15,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(a => a.UsePriceOffersByFactories)
                .HasDefaultValue(false);
        }
    }
}
