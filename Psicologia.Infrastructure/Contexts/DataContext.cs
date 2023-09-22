﻿using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logradouro>().Property(x => x.Id);
            modelBuilder.Entity<Logradouro>().Property(x => x.LogradouroName).HasMaxLength(255);

            modelBuilder.Entity<NumeroEndereco>().Property(x => x.Id);
            modelBuilder.Entity<NumeroEndereco>().Property(x => x.Numero).HasMaxLength(50);
            
            modelBuilder.Entity<Bairro>().Property(x => x.Id);
            modelBuilder.Entity<Bairro>().Property(x => x.BairroName).HasMaxLength(255);
        }
    }
}
