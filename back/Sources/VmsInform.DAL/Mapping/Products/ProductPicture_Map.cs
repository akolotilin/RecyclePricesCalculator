using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.Products;

namespace VmsInform.DAL.Mapping.Products
{
    internal sealed class ProductPicture_Map : BaseEntityMap<ProductPictureEntry>
    {
        public override void Configure(EntityTypeBuilder<ProductPictureEntry> builder)
        {
            builder.ToTable("product_pictures");
            base.Configure(builder);

            builder.HasOne(a => a.Picture)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(a => a.PictureId)
                .IsRequired();

            builder.HasOne(a => a.Product)
                .WithMany(a => a.Pictures)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
