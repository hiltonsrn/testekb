using Kanban.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kanban.Infra.Data.Mapping
{

    public class CardMapp : Mapp<Domain.Entities.Card>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Card> builder)
        {
            base.Configure(builder);
            builder.ToTable("Card");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(c => c.Description).IsRequired().HasColumnName("Description").HasMaxLength(255);
            builder.HasOne(c=> c.Quadrant).WithMany(c=> c.Cards).HasForeignKey(c => c.QuadrantId);
            builder.HasOne(c=> c.Resource).WithMany(c=> c.Cards).HasForeignKey(c => c.ResourceId);
            builder.HasOne(c => c.Squad).WithMany(c => c.Cards).HasForeignKey(c => c.SquadId);
        }
    }
}
