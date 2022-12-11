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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Username)
                .IsRequired();

            builder.Property(p => p.Password)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired();

            builder.Property(p => p.CreationDate);

        }
    }
}
