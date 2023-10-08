using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Infrastructure.Mappings.Endereco;

public class EstadoMap : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estados");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.EstadoName)
            .IsRequired()
            .HasColumnName("Bairro")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
    }
}