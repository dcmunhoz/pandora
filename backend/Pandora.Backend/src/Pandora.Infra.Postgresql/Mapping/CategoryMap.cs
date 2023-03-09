using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Infra.Postgresql.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(16)");

            builder.Property(p => p.ParentId)
                .HasColumnName("id_parent")
                .HasColumnType("uuid");

            builder.Property(p => p.UserCreationId)
                .HasColumnName("id_user")
                .HasColumnType("uuid");

            builder.ToTable("categories");
        }
    }
}
