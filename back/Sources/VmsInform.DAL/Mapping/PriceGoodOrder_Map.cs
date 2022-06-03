using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PriceGoodOrder_Map : BaseEntityMap<PriceGoodOrder>
    {
        public override void Configure(EntityTypeBuilder<PriceGoodOrder> builder)
        {
            base.Configure(builder);
            builder.ToTable("price_good_order");

            builder.HasOne(a => a.Good)
                .WithOne()
                .HasForeignKey<PriceGoodOrder>(a => a.GoodId)
                .IsRequired();
        }
    }
}
