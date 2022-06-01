using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal class UserSession_Map : BaseEntityMap<UserSession>
    {
        public override void Configure(EntityTypeBuilder<UserSession> builder)
        {
            base.Configure(builder);
            builder.ToTable("UserSessions");

            builder.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.StartTime)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(a => a.SessionKey)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
