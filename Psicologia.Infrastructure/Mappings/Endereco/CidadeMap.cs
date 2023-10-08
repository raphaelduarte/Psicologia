using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Infrastructure.Mappings.Endereco;

public class CidadeMap : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        builder.ToTable("Cidades");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.CidadeName)
            .IsRequired()
            .HasColumnName("Cidade")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        // Relacionamentos
        builder
            .HasMany(x => x.Estados)
            .WithMany(x => x.Cidades)
            .UsingEntity<Dictionary<string, object>>(
                "CidadeEstado",
                cidade => cidade
                    .HasOne<Estado>()
                    .WithMany()
                    .HasForeignKey("CidadeId")
                    .HasConstraintName("FK_CidadeEstado_CidadeId")
                    .OnDelete(DeleteBehavior.Cascade),
                estado => estado
                    .HasOne<Cidade>()
                    .WithMany()
                    .HasForeignKey("EstadoId")
                    .HasConstraintName("FK_CidadeEstado_EstadoId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}