using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Infrastructure.Mappings.Endereco;

public class PaisMap : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Paises");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.PaisName)
            .IsRequired()
            .HasColumnName("Bairro")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
    }
}