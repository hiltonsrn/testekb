using Kanban.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kanban.Infra.Data.Mapping
{
    public class BoardMapp : Mapp<Board>
    {
        public override void Configure(EntityTypeBuilder<Board> builder)
        {
            base.Configure(builder);
            builder.ToTable("Board");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
        }
    }
}
