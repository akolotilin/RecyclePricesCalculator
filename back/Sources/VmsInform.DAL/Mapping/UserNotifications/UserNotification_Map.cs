using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.DAL.Mapping.UserNotifications
{
    internal sealed class UserNotification_Map : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.ToTable("UserNotifications");

            builder.Property(a => a.Id)
                .HasColumnName("UserNotificationid");

            builder.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.Subject)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
