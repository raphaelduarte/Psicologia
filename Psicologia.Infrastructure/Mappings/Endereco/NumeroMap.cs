using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Infrastructure.Mappings.Endereco;

public class NumeroMap : IEntityTypeConfiguration<NumeroEndereco>
{
    public void Configure(EntityTypeBuilder<NumeroEndereco> builder)
    {
        builder.ToTable("Numero");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Numero)
            .IsRequired()
            .HasColumnName("Numero")
            .HasMaxLength(10);
    }
}