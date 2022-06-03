using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class BaseGoodPrice_Map : BaseEntityMap<BaseGoodPrice>
    {
        public override void Configure(EntityTypeBuilder<BaseGoodPrice> builder)
        {
            base.Configure(builder);
            builder.ToTable("base_good_prices");

            builder.Property(a => a.GoodId)
                .IsRequired();

            builder.HasOne(a => a.Partner)
                .WithMany()
                .HasForeignKey(a => a.PartnerId)
                .IsRequired(false);

            builder.HasOne(a => a.Factory)
                .WithMany()
                .HasForeignKey(a => a.FactoryId)
                .IsRequired(false);

            builder.Property(a => a.Price)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("numeric(15,2)");

            builder.HasOne(a => a.Currency)
                .WithMany()
                .HasForeignKey(a => a.CurrencyId);
        }
    }
}
