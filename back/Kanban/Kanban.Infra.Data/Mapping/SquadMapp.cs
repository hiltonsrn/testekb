using Kanban.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kanban.Infra.Data.Mapping
{
    public class SquadMapp : Mapp<Squad>
    {
        public override void Configure(EntityTypeBuilder<Squad> builder)
        {
            base.Configure(builder);
            builder.ToTable("Squad");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.HasMany(c => c.Cards).WithOne(c=> c.Squad).HasForeignKey(c => c.SquadId);
            builder.HasMany(c => c.Resources).WithOne(c => c.Squad).HasForeignKey(c => c.SquadId);

        }
    }
}
