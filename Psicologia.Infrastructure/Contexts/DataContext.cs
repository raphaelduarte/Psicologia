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
        public DbSet<NumeroEndereco> NumeroEnderecos { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<BairroCidade> BairrosCidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<CidadeEstado> CidadesEstados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logradouro>().HasKey(x => x.Id);
            modelBuilder.Entity<Logradouro>().Property(x => x.LogradouroName).HasMaxLength(255).HasColumnType("varchar(255)");

            modelBuilder.Entity<NumeroEndereco>().HasKey(x => x.Id);
            modelBuilder.Entity<NumeroEndereco>().Property(x => x.Numero).HasMaxLength(50);
            
            modelBuilder.Entity<Bairro>().HasKey(x => x.Id);
            modelBuilder.Entity<Bairro>().Property(x => x.BairroName).HasMaxLength(50).HasColumnType("varchar(50)");
            
            modelBuilder.Entity<Cidade>().HasKey(x => x.Id);
            modelBuilder.Entity<Cidade>().Property(x => x.CidadeName).HasMaxLength(50).HasColumnType("varchar(50)");
            
            modelBuilder.Entity<BairroCidade>().HasKey(x => x.Id);
            modelBuilder.Entity<BairroCidade>().Property(x => x.Bairro.Id);
            modelBuilder.Entity<BairroCidade>().Property(x => x.Cidade.Id);
            
            
            modelBuilder.Entity<Estado>().HasKey(x => x.Id);
            modelBuilder.Entity<Estado>().Property(x => x.EstadoName).HasMaxLength(50).HasColumnType("varchar(50)");
            
            modelBuilder.Entity<CidadeEstado>().HasKey(x => x.Id);
            modelBuilder.Entity<CidadeEstado>().Property(x => x.Cidade.Id);
            modelBuilder.Entity<CidadeEstado>().Property(x => x.Estado.Id);
            
            modelBuilder.Entity<Pais>().Property(x => x.Id);
            modelBuilder.Entity<Pais>().Property(x => x.PaisName).HasMaxLength(50).HasColumnType("varchar(50)");
            
            
            modelBuilder.Entity<Endereco>().Property(x => x.Id);
            modelBuilder.Entity<Endereco>().Property(x => x.Logradouro.Id);
            modelBuilder.Entity<Endereco>().Property(x => x.Numero.Id);
            modelBuilder.Entity<Endereco>().Property(x => x.ETipoResidencia);
            modelBuilder.Entity<Endereco>().Property(x => x.BairroCidade.Id);
            modelBuilder.Entity<Endereco>().Property(x => x.CidadeEstado.Id);
            modelBuilder.Entity<Endereco>().Property(x => x.Pais.Id);
        }
    }
}
