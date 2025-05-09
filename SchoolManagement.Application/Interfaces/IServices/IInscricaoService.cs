using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Queries;
namespace SchoolManagement.Application.Interfaces.IServices;

public interface IInscricaoService
{
    Task<IEnumerable<InscricaoDto>> ObterTodasAsync();
    Task<InscricaoDto?> ObterPorIdAsync(Guid id);
    Task<(IEnumerable<InscricaoDto> Data, int TotalCount)> ObterPorPessoaPaginadoAsync(Guid pessoaId, InscricaoQuery query);
    Task<Guid> CriarAsync(CreateInscricaoDto dto);
    Task AtualizarAsync(Guid id, CreateInscricaoDto dto);
    Task RemoverAsync(Guid id);
}
