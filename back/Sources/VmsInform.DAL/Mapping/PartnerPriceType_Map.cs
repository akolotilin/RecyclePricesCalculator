using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PartnerPriceType_Map : BaseEntityMap<PartnerPriceType>
    {
        public override void Configure(EntityTypeBuilder<PartnerPriceType> builder)
        {
            base.Configure(builder);
            builder.ToTable("PartnerPriceType");

            builder.HasOne(a => a.Partner)
                .WithMany(a => a.PriceTypes)
                .HasForeignKey(a => a.PartnerId)
                .IsRequired();

            builder.HasIndex(a => a.PartnerId);

            builder.HasOne(a => a.PriceType)
                .WithMany()
                .HasForeignKey(a => a.PriceTypeId)
                .IsRequired();
        }
    }
}
