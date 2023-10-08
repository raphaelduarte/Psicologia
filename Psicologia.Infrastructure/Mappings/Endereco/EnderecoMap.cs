using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Infrastructure.Mappings.Endereco;

public class EnderecoMap : IEntityTypeConfiguration<Domain.Entities.Endereco.Endereco>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Endereco.Endereco> builder)
    {
        builder.ToTable("Enderecos");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Logradouro.Id)
            .IsRequired()
            .HasColumnName("Bairro")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.HasOne(x => x.Logradouro)
            .WithMany(x => x.Enderecos)
            .HasConstraintName("FK_Logradouro_Endereco")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Pais)
            .WithMany(x => x.Enderecos)
            .HasConstraintName("FK_Pais_Endereco")
            .OnDelete(DeleteBehavior.Cascade);
    }
}