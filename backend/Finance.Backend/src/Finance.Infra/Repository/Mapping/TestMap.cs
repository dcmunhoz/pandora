﻿using Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Repository.Mapping
{
    public class TestMap : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(p => p.Id)
                .HasColumnName("SEQTESTE")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(p => p.Username)
                .HasColumnName("USERNAME")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(p => p.LastUpdate)
                .HasColumnName("LASTUPDATE")
                .HasColumnType("TIMESTAMP");

            builder.ToTable("FIN_TEST");


        }
    }
}
