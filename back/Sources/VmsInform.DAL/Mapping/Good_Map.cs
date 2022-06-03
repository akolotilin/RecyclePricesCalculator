using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class Good_Map : BaseEntityMap<Good> 
    {
        public override void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.ToTable("goods");
            base.Configure(builder);

            builder.Property(a => a.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.Comment)
                .HasMaxLength(1000)
                .HasDefaultValue(string.Empty);

            builder.HasOne(a => a.GoodGroup)
                .WithMany(a => a.Goods)
                .HasForeignKey(a => a.GoodGroupId)
                .IsRequired();

            builder.HasOne(a => a.BasePrice)
                .WithOne(a => a.Good)
                .HasForeignKey<BaseGoodPrice>(a => a.GoodId);

            builder.HasOne(a => a.BaseGoodRule)
                .WithOne()
                .HasForeignKey<Good>(a => a.BaseGoodRuleId)
                .IsRequired(false);

            builder.Property(a => a.Code)
                .HasMaxLength(25)
                .IsRequired(false);

            builder.Property(a => a.Guid)
                .IsRequired();
        }
    }
}
