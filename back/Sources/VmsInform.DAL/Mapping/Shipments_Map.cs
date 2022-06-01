using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class Shipments_Map : BaseEntityMap<Shipment>
    {
        public override void Configure(EntityTypeBuilder<Shipment> builder)
        {
            base.Configure(builder);
            builder.ToTable("Shipments");

            AddEditorInfo(builder);

            builder.Property(a => a.Comment)
                .HasColumnType("nvarchar(max)")
                .IsRequired()
                .HasDefaultValue(string.Empty);

            builder.Property(a => a.ShipmentDate)
                .IsRequired();

            builder.HasMany(a => a.Pictures)
                .WithOne();

            builder.HasOne(a => a.Partner)
                .WithMany()
                .HasForeignKey(a => a.PartnerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Factory)
                .WithMany()
                .HasForeignKey(a => a.FactoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
