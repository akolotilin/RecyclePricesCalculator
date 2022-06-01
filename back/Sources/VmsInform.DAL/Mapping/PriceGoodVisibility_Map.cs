using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PriceGoodVisibility_Map : BaseEntityMap<PriceGoodVisibility>
    {
        public override void Configure(EntityTypeBuilder<PriceGoodVisibility> builder)
        {
            base.Configure(builder);

            builder.ToTable("PriceGoodsVisibility");
            builder.HasOne(a => a.Good)
                .WithMany()
                .HasForeignKey(a => a.GoodId)
                .IsRequired();

            builder.HasIndex(a => a.GoodId)
                .IsUnique();

        }
    }
}
