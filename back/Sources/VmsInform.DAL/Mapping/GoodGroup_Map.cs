using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    class GoodGroup_Map : BaseEntityMap<GoodGroup>
    {
        public override void Configure(EntityTypeBuilder<GoodGroup> builder)
        {
            base.Configure(builder);
            builder.ToTable("good_groups");

            builder.HasOne(a => a.Parent)
                .WithMany()
                .HasForeignKey(a => a.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Guid)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(a => a.Code)
                .HasMaxLength(25)
                .IsRequired(false);

        }
    }
}
