using Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Postgresql.Mapping
{
    public class TestMap : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("seqtest")
                .HasColumnType("integer");

            builder.Property(x => x.Username)
                .HasColumnName("username")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Password)
                .HasColumnName("username")
                .HasColumnType("varchar2(255)");

            builder.Property(x => x.LastUpdate)
                .HasColumnName("lastupdate")
                .HasColumnType("timestamp");

            builder.ToTable("fin_test");
        }
    }
}
