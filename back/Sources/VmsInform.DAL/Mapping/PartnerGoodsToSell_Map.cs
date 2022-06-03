using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PartnerGoodsToSell_Map : BaseEntityMap<PartnerGoodsToSell>
    {
        public override void Configure(EntityTypeBuilder<PartnerGoodsToSell> builder)
        {
            base.Configure(builder);
            builder.ToTable("partner_goods_to_sell");

            builder.HasOne(a => a.Partner)
                .WithMany(a => a.GoodsToSell)
                .HasForeignKey(a => a.PartnerId)
                .IsRequired();

            builder.HasOne(a => a.Good)
                .WithMany()
                .HasForeignKey(a => a.GoodId)
                .IsRequired();

            builder.HasOne(a => a.Factory)
                .WithMany()
                .HasForeignKey(a => a.FactoryId)
                .IsRequired(false);

            builder.HasIndex(a => new { a.GoodId, a.PartnerId, a.FactoryId })
                .IsUnique();

            builder.HasIndex(a => a.PartnerId);

            builder.HasIndex(a => a.GoodId);

            builder.Property(a => a.Price)
                .HasColumnType("decimal(15,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(a => a.Currency)
                .WithMany()
                .HasForeignKey(a => a.CurrencyId)
                .IsRequired();

            builder.Property(a => a.ValidThru)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
