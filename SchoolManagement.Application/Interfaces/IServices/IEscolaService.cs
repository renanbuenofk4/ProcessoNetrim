using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Queries;

namespace SchoolManagement.Application.Interfaces.IServices;

public interface IEscolaService
{
    Task<IEnumerable<EscolaDto>> ObterTodasAsync();
    Task<EscolaDto?> ObterPorIdAsync(Guid id);

    Task<(IEnumerable<EscolaDto> Data, int TotalCount)> ObterPaginadoAsync(EscolaQuery query);
    Task<Guid> CriarAsync(CreateEscolaDto dto);
    Task AtualizarAsync(Guid id, CreateEscolaDto dto);
    Task RemoverAsync(Guid id);
}