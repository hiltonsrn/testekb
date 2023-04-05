using Kanban.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kanban.Infra.Data.Mapping
{

    public class QuadrantMapp : Mapp<Domain.Entities.Quadrant>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Quadrant> builder)
        {
            base.Configure(builder);
            builder.ToTable("Quadrant");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.HasMany(c=> c.Cards).WithOne(c=> c.Quadrant).HasForeignKey(c=> c.QuadrantId);
            builder.HasOne(c => c.Board).WithMany(c => c.Quadrants).HasForeignKey(c => c.BoardId);
        }
    }
}
