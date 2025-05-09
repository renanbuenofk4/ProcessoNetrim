using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Queries;

namespace SchoolManagement.Application.Interfaces.IServices;

public interface IPessoaService
{
    Task<IEnumerable<PessoaDto>> ObterTodasAsync();
    Task<PessoaDto?> ObterPorIdAsync(Guid id);
    Task<(IEnumerable<PessoaDto> Data, int TotalCount)> ObterPaginadoAsync(PessoaQuery query);

    Task<PessoaDto?> ObterPorEmailAsync(string email);
    Task<Guid> CriarAsync(CreatePessoaDto dto);
    Task AtualizarAsync(Guid id, CreatePessoaDto dto);
    Task RemoverAsync(Guid id);
}