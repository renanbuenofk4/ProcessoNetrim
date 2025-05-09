using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Mappings;

public class InscricaoMap : IEntityTypeConfiguration<Inscricao>
{
    public void Configure(EntityTypeBuilder<Inscricao> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasOne(i => i.Pessoa)
               .WithMany(p => p.Inscricoes)
               .HasForeignKey(i => i.PessoaId);

        builder.HasOne(i => i.Turma)
               .WithMany(t => t.Inscricoes)
               .HasForeignKey(i => i.TurmaId);

        builder.Property(i => i.Status)
               .IsRequired()
               .HasConversion<int>();
    }
}
