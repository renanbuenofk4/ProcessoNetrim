using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data.Context;

namespace SchoolManagement.Infrastructure.Repositories;

public class TurmaRepository : Repository<Turma>, ITurmaRepository
{
    public TurmaRepository(SchoolContext context) : base(context) { }

    public async Task<IEnumerable<Turma>> ListarPorNivelAsync(string nivel)
    {
        return await _context.Turmas.Where(t => t.Nivel == nivel).ToListAsync();
    }

    public async Task<IEnumerable<Turma>> ObterTurmasDisponiveisAsync(Guid pessoaId)
    {
        return await _context.Turmas
            .Include(t => t.Inscricoes)
            .Where(t =>
                t.Inscricoes.Count(i => i.Status == StatusInscricao.Inscrito) < 15 &&
                !t.Inscricoes.Any(i => i.PessoaId == pessoaId)
            )
            .ToListAsync();
    }

}
