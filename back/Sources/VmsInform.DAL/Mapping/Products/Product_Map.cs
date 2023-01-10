using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.Products;

namespace VmsInform.DAL.Mapping.Products
{
    internal sealed class Product_Map : BaseEntityMap<ProductEntry>
    {
        public override void Configure(EntityTypeBuilder<ProductEntry> builder)
        {
            builder.ToTable("products");
            base.Configure(builder);

            builder.Property(a => a.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasMaxLength(1000)
                .HasDefaultValue(string.Empty);

            builder.HasOne(a => a.Group)
                .WithMany(a => a.Products)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false)
                .HasForeignKey(a => a.GroupId);

            builder.HasMany(a => a.ComponentsRaw)
                .WithOne()
                .HasForeignKey(a => a.ProductId)
                .IsRequired();
        }
    }
}
