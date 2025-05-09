using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Interfaces.IRespository;
using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Data.Context;
namespace SchoolManagement.Infrastructure.Repositories;

public class InscricaoRepository : Repository<Inscricao>, IInscricaoRepository
{
    public InscricaoRepository(SchoolContext context) : base(context) { }

    public async Task<IEnumerable<Inscricao>> ListarPorStatusAsync(StatusInscricao status)
    {
        return await _context.Inscricoes
            .Include(i => i.Pessoa)
            .Include(i => i.Turma)
            .Where(i => i.Status == status)
            .ToListAsync();
    }

    public async Task<(IEnumerable<Inscricao> Data, int TotalCount)> GetByFilterAsync(Guid pessoaId, InscricaoQuery query)
    {
        var inscricoes = _context.Inscricoes
            .Include(i => i.Pessoa)
            .Include(i => i.Turma)
            .Where(i => i.PessoaId == pessoaId);

        if (query.Status.HasValue)
            inscricoes = inscricoes.Where(i => i.Status == query.Status);

        var totalCount = await inscricoes.CountAsync();
        var result = await inscricoes
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return (result, totalCount);
    }
}