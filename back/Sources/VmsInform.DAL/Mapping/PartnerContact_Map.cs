using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PartnerContact_Map : BaseEntityMap<PartnerContact>
    {
        public override void Configure(EntityTypeBuilder<PartnerContact> builder)
        {
            base.Configure(builder);
            builder.ToTable("partner_contacts");
            builder.HasIndex(a => a.PartnerId);

            builder.HasOne(a => a.Partner)
                .WithMany(a => a.Contacts)
                .HasForeignKey(a => a.PartnerId)
                .IsRequired();
        }
    }
}
