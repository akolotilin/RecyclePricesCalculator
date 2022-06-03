using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PartnerShipmentAddress_Map : BaseEntityMap<PartnerShipmentAddress>
    {
        public override void Configure(EntityTypeBuilder<PartnerShipmentAddress> builder)
        {
            base.Configure(builder);

            builder.ToTable("partner_shipment_addresses");

            builder.HasOne(a => a.Partner)
                .WithMany(a => a.ShipmentAddresses)
                .HasForeignKey(a => a.PartnerId)
                .IsRequired();

            builder.Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
