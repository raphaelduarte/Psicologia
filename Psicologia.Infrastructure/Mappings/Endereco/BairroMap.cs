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
    }
}