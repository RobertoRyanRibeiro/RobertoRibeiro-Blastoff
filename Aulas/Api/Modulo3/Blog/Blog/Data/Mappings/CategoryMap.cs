﻿using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMapBlog.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Table
            builder.ToTable("Category");

            //PK
            builder.HasKey(x => x.Id);

            //Identity PK
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();

        }
    }
}
