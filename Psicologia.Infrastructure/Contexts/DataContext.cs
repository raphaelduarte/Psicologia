using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Infrastructure.Mappings.Endereco;

namespace Psicologia.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Logradouro> Logradouros { get; set; }
        public DbSet<NumeroEndereco> NumeroEnderecos { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("connectionString");
            //options.UseNpgsql("postgres://postgres:cachorromajo@localhost:5432/postgres");
            options.UseInMemoryDatabase("Database");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogradouroMap());
            modelBuilder.ApplyConfiguration(new NumeroMap());
            modelBuilder.ApplyConfiguration(new BairroMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
        }
    }
}
