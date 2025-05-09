using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Interfaces;

public interface IPessoaRepository : IRepository<Pessoa>
{
    Task<Pessoa?> ObterPorEmailAsync(string email);
    Task<(IEnumerable<Pessoa> Data, int TotalCount)> GetByFilterAsync(PessoaQuery query);
}