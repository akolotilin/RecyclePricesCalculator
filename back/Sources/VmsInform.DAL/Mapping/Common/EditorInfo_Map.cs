using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.Common;

namespace VmsInform.DAL.Mapping.Common
{
    internal class EditorInfo_Map<TEditorInfo>
        where TEditorInfo : class, IEditorInfo
    {
        public void Map(EntityTypeBuilder<TEditorInfo> builder)
        {
            builder.HasOne(a => a.LastEditor)
                .WithMany()
                .HasForeignKey(a => a.LastEditorId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Creator)
                .WithMany()
                .HasForeignKey(a => a.CreatorId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(a => a.LastEdit)
                .IsRequired();

            builder.Property(a => a.Created)
                .IsRequired();
        }
    }
}
