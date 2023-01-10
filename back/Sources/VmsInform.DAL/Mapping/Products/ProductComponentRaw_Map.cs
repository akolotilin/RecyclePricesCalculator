using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.Products;

namespace VmsInform.DAL.Mapping.Products
{
    internal sealed class ProductComponentRaw_Map : BaseEntityMap<ProductComponentRawEntry>
    {
        public override void Configure(EntityTypeBuilder<ProductComponentRawEntry> builder)
        {
            builder.ToTable("product_components_raw");
            base.Configure(builder);

            builder.HasOne(a => a.Good)
                .WithMany()
                .HasForeignKey(a => a.GoodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(a => a.Percentage)
                .HasPrecision(5, 3);
        }
    }
}
