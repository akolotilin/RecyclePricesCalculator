using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.Products;

namespace VmsInform.DAL.Mapping.Products
{
    internal sealed class ProductGroupMap : BaseEntityMap<ProductGroupEntry>
    {
        public override void Configure(EntityTypeBuilder<ProductGroupEntry> builder)
        {
            builder.ToTable("product_groups");
            base.Configure(builder);

            builder.Property(a => a.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasOne(a => a.Parent)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(a => a.ParentId)
                .IsRequired(false);
        }
    }
}
