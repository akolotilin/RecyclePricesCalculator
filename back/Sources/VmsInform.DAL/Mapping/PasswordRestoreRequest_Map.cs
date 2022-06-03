using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class PasswordRestoreRequest_Map : BaseEntityMap<PasswordRestoreRequest>
    {
        public override void Configure(EntityTypeBuilder<PasswordRestoreRequest> builder)
        {
            base.Configure(builder);
            builder.ToTable("password_restore_requests");

            builder.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.Key)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.CreateDate)
                .IsRequired();

            builder.Property(a => a.ExpiryDate)
                .IsRequired();
        }
    }
}
