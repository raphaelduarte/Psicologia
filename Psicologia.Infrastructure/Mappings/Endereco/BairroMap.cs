using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Infrastructure.Mappings.Endereco;

public class BairroMap : IEntityTypeConfiguration<Bairro>
{
    public void Configure(EntityTypeBuilder<Bairro> builder)
    {
        builder.ToTable("Bairros");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.BairroName)
            .IsRequired()
            .HasColumnName("Bairro")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);


        // Relacionamentos
        builder
            .HasMany(x => x.Cidades)
            .WithMany(x => x.Bairros)
            .UsingEntity<Dictionary<string, object>>(
                "BairroCidade",
                bairro => bairro
                    .HasOne<Cidade>()
                    .WithMany()
                    .HasForeignKey("BairroId")
                    .HasConstraintName("FK_BairroCidade_BairroId")
                    .OnDelete(DeleteBehavior.Cascade),
                cidade => cidade
                    .HasOne<Bairro>()
                    .WithMany()
                    .HasForeignKey("CidadeId")
                    .HasConstraintName("FK_BairroCidade_CidadeId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}