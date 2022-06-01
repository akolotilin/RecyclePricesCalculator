using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PartnerFactory_Map : BaseEntityMap<PartnerFactory>
    {
        public override void Configure(EntityTypeBuilder<PartnerFactory> builder)
        {
            base.Configure(builder);
            builder.ToTable("PartnerFactory");

            builder.HasOne(a => a.Partner)
                .WithMany(a => a.Factories)
                .HasForeignKey(a => a.PartnerId)
                .IsRequired();
        }
    }
}
