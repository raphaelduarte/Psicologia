using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Logradouro> Logradouros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logradouro>().Property(x => x.Id);
            modelBuilder.Entity<Logradouro>().Property(x => x.LogradouroName).HasMaxLength(255);
        }
    }
}
