using Atividade1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1.Data
{
    public class AtividadeDbContext : DbContext
    {

        public DbSet<Galaxia> Galaxias { get; set; }
        public DbSet<Estrela> Estrelas { get; set; }
        public DbSet<Planeta> Planetas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
            => optionsbuilder.UseSqlServer("Server=localhost,1433;Database=SpaceX;User ID=sa;Password=1q2w3e4r@#$");

    }
}
