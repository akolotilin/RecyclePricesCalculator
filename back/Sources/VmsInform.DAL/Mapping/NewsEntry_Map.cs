using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal class NewsEntry_Map : BaseEntityMap<NewsEntry>
    {
        public override void Configure(EntityTypeBuilder<NewsEntry> builder)
        {
            base.Configure(builder);

            builder.ToTable("News");

            builder.HasOne(a => a.Author)
                .WithMany()
                .HasForeignKey(a => a.AuthorId)
                .IsRequired();

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.Text)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
        }
    }
}
