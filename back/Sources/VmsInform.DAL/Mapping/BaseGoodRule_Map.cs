using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class BaseGoodRule_Map : BaseEntityMap<BaseGoodRule>
    {
        public override void Configure(EntityTypeBuilder<BaseGoodRule> builder)
        {
            base.Configure(builder);
            builder.ToTable("BaseGoodRules");

            builder.HasOne(a => a.BaseGood)
                .WithMany()
                .HasForeignKey(a => a.BaseGoodId)
                .IsRequired();

            builder.Property(a => a.Multiplier)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(a => a.Add)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
