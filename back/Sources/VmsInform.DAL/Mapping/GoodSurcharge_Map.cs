using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class GoodSurcharge_Map : BaseEntityMap<GoodSurcharge>
    {
        public override void Configure(EntityTypeBuilder<GoodSurcharge> builder)
        {
            base.Configure(builder);
            builder.ToTable("GoodSurcharge");

            builder.HasOne(a => a.Good)
                .WithMany(a => a.GoodSurcharges)
                .HasForeignKey(a => a.GoodId)
                .IsRequired();

            builder.HasOne(a => a.PriceType)
                .WithMany()
                .HasForeignKey(a => a.PriceTypeId)
                .IsRequired();

            builder.Property(a => a.Surcharge)
                .HasColumnType("decimal(10,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasIndex(a => a.GoodId);
        }
    }
}
