using SchoolManagement.Domain.Entities;
using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Interfaces.IRespository;
public interface IInscricaoRepository : IRepository<Inscricao>
{
    Task<IEnumerable<Inscricao>> ListarPorStatusAsync(StatusInscricao status);

    Task<(IEnumerable<Inscricao> Data, int TotalCount)> GetByFilterAsync(Guid pessoaId, InscricaoQuery query);

}