using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Mappings;

public class TurmaMap : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Nome).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Nivel).IsRequired().HasMaxLength(50);

        builder.HasOne(t => t.Escola)
               .WithMany(e => e.Turmas)
               .HasForeignKey(t => t.EscolaId);
    }
}
