using Atividade4.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4.Data
{
    public class Atividade4DbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer("Server = localhost,1433;Database = Mercadinho;User ID=sa;Password=1q2w3e4r@#$");

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
