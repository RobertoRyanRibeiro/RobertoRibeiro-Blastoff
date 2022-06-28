using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade5.Data
{
    public class Atividade5DbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer("Server = localhost,1433;Database = faculdade,User ID=sa,Password = 1q2w3e4r@#$");
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
