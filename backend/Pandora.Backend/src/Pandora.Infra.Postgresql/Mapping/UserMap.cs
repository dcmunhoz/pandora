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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("users");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(p => p.Username)
                .HasColumnName("username")
                .HasColumnType("varchar(16)");

            builder.Property(p => p.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(64)");

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("timestamp");

        }
    }
}
