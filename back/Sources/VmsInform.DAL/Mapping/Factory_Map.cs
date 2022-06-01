using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.Mapping
{
    internal sealed class Factory_Map : BaseEntityMap<Factory>
    {
        public override void Configure(EntityTypeBuilder<Factory> builder)
        {
            base.Configure(builder);
            builder.ToTable("Factories");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.Comment)
                .HasDefaultValue(string.Empty)
                .HasColumnType("nvarchar(max)");

            builder.Property(a => a.Address)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.Distance)
                .HasColumnType("decimal(15,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(a => a.MinGarbage)
                .HasColumnType("decimal(15,2)")
                .IsRequired()
                .HasDefaultValue(0);


            builder.Property(a => a.MaxGarbage)
                .HasColumnType("decimal(15,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasMany(a => a.Partners)
                .WithOne(a => a.Factory)
                .HasForeignKey(a => a.FactoryId)
                .IsRequired();


        }
    }
}
