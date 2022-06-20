using Atividade3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3.Data
{
    public class Atividade3DbContext : DbContext
    {

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Computador> Computadors{ get; set; }
        public DbSet<Software> Softwares{ get; set; }
        public DbSet<Funciona> Funcionas{ get; set; }
        public DbSet<Compativel> Compativels{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Museu;User ID=sa;Password=1q2w3e4r@#$");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compativel>()
                        .HasOne(m => m.Computador)
                        .WithMany(t => t.Compativels)
                        .HasForeignKey(m => m.Id_Computador)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Compativel>()   
                        .HasOne(m => m.Computador2)
                        .WithMany(t => t.Compativels2)
                        .HasForeignKey(m => m.Id_Computador2)
                        .OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<Funciona>()
                        .HasOne(m => m.Software)
                        .WithMany(x => x.Funcionas)
                        .HasForeignKey(x => x.Id_Software)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Funciona>()
                        .HasOne(m => m.Computador)
                        .WithMany(x => x.Funcionas)
                        .HasForeignKey(x => x.Id_Computador)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
