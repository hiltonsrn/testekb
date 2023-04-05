using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kanban.Domain.Entities;

namespace Kanban.Infra.Data.Mapping
{
    public class Mapp<T> : IEntityTypeConfiguration<T>
    where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired();
        }
    }
}