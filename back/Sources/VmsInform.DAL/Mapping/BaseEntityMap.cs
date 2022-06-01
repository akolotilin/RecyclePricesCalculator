using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain.Common;
using VmsInform.DAL.Mapping.Common;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Mapping
{
    internal abstract class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : VmsInformEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(a => a.Id);
        }

        protected void AddEditorInfo<TEditorInfo>(EntityTypeBuilder<TEditorInfo> builder)
            where TEditorInfo : class, IEditorInfo
        {
            new EditorInfo_Map<TEditorInfo>().Map(builder);
        }
    }
}
