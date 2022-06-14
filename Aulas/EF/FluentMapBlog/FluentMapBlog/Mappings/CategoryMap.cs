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

        }
    }
}
