using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

using SchoolManagement.Infrastructure.Data.Context;

namespace SchoolManagement.Infrastructure.Repositories;

public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
{
    public PessoaRepository(SchoolContext context) : base(context) { }

    public async Task<Pessoa?> ObterPorEmailAsync(string email)
    {
        return await _context.Pessoas.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<(IEnumerable<Pessoa> Data, int TotalCount)> GetByFilterAsync(PessoaQuery query)
    {
        var pessoas = _context.Pessoas.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Nome))
            pessoas = pessoas.Where(p => p.Nome.Contains(query.Nome));

        if (!string.IsNullOrWhiteSpace(query.Cpf))
            pessoas = pessoas.Where(p => p.Telefone.Contains(query.Cpf)); // ajuste se tiver campo CPF

        var totalCount = await pessoas.CountAsync();
        var result = await pessoas
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return (result, totalCount);
    }
}