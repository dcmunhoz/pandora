using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Infra.Persistence.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.ParentId)
                .IsRequired(false);

            builder.Property(p => p.UserCreationId)
                .IsRequired();

            builder.HasOne(p => p.UserCreation)
                .WithOne();

            builder.HasOne(p => p.Parent)
                .WithOne();
        }
    }
}
