using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data.Context;

namespace SchoolManagement.Infrastructure.Repositories;

public class EscolaRepository : Repository<Escola>, IEscolaRepository
{
    public EscolaRepository(SchoolContext context) : base(context) { }

    public async Task<IEnumerable<Escola>> ListarPorNomeAsync(string nome)
    {
        return await _context.Escolas.Where(e => e.Nome.Contains(nome)).ToListAsync();
    }
}