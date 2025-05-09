using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Mappings;
public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Sobrenome).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Telefone).HasMaxLength(15);
        builder.Property(p => p.Endereco).HasMaxLength(200);
        builder.Property(p => p.Email).HasMaxLength(100);
    }
}
