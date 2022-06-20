using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMapBlog.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Table
            builder.ToTable("User");

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

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);

            builder.HasIndex(x=>x.Slug,"IX_User_Slug").IsUnique();

            builder.HasMany(x => x.Roles)
               .WithMany(x => x.Users)
               .UsingEntity<Dictionary<string, object>>(
                   "UserRole",
                   user => user.HasOne<Role>()
                   .WithMany()
                   .HasForeignKey("UserId")
                   .HasConstraintName("FK_UserRole_UserId")
                   .OnDelete(DeleteBehavior.Cascade),
                   role => role.HasOne<User>()
                   .WithMany()
                   .HasForeignKey("RoleId")
                   .HasConstraintName("FK_UserRole_UserId")
                   .OnDelete(DeleteBehavior.Cascade)
               );
        }
    }
}
