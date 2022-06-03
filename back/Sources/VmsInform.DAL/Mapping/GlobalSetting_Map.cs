using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    class GlobalSetting_Map : IEntityTypeConfiguration<GlobalSetting>
    {
        public void Configure(EntityTypeBuilder<GlobalSetting> builder)
        {
            builder.ToTable("settings")
                .HasKey(a => a.Id);

            builder.Property(a => a.Id);

            builder.HasIndex(a => a.Name)
                .IsUnique();

            builder.Property(a => a.Name)
                .HasMaxLength(150);

            builder.Property(a => a.Value)
                .HasMaxLength(250);

            builder.Property(a => a.Type)
                .HasMaxLength(50);

            builder.Property(a => a.Order)
                .HasMaxLength(50);

            builder.Property(a => a.Domain)
                .HasMaxLength(500);
        }
    }
}
