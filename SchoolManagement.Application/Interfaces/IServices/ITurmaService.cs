using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Queries;

namespace SchoolManagement.Application.Interfaces.IServices;

public interface ITurmaService
{
    Task<IEnumerable<TurmaDto>> ObterTodasAsync();
    Task<TurmaDto?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<TurmaDto>> ObterTurmasDisponiveisAsync(Guid pessoaId);

    Task<(IEnumerable<TurmaDto> Data, int TotalCount)> ObterPaginadoAsync(TurmaQuery query);
    Task<Guid> CriarAsync(CreateTurmaDto dto);
    Task AtualizarAsync(Guid id, CreateTurmaDto dto);
    Task RemoverAsync(Guid id);
}