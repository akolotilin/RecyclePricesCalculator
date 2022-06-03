using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class User_Map : BaseEntityMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("users");

            builder.Property(a => a.EMail)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.PasswordHash)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasMaxLength(100);

            builder.HasIndex(a => a.EMail)
                .IsUnique();
        }
    }
}
