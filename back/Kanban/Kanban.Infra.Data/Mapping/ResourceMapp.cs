using Kanban.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kanban.Infra.Data.Mapping
{
    public class ResourceMapp : Mapp<Resource>
    {
        public override void Configure(EntityTypeBuilder<Resource> builder)
        {
            base.Configure(builder);
            builder.ToTable("Resource");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(c => c.Login).IsRequired().HasColumnName("Login").HasMaxLength(50);
            builder.Property(c => c.Password).IsRequired().HasColumnName("Password").HasMaxLength(255);
            builder.Ignore(c => c.Acronym);
            builder.HasMany(c => c.Cards).WithOne(c=> c.Resource).HasForeignKey(c => c.ResourceId);
        }
    }
}
