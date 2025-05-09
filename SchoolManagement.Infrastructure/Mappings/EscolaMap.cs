using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Mappings;

public class EscolaMap : IEntityTypeConfiguration<Escola>
{
    public void Configure(EntityTypeBuilder<Escola> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
    }
}
