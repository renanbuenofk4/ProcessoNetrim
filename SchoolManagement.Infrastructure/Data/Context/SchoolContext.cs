using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Data.Context
{
    public class SchoolContext : DbContext
    {


        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolContext).Assembly);
        }
    }
}
