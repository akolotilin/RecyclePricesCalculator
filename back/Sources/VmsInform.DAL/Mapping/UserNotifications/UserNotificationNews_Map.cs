using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.DAL.Mapping.UserNotifications
{
    internal sealed class UserNotificationNews_Map : IEntityTypeConfiguration<UserNotificationNews>
    {
        public void Configure(EntityTypeBuilder<UserNotificationNews> builder)
        {
            builder.HasOne(a => a.News)
                .WithMany()
                .HasForeignKey(a => a.NewsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
