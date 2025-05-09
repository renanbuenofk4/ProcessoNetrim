using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IRespository;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services;

public class InscricaoService : IInscricaoService
{
    private readonly IInscricaoRepository _repository;

    public InscricaoService(IInscricaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InscricaoDto>> ObterTodasAsync()
    {
        var inscricoes = await _repository.GetAllAsync();
        return inscricoes.Select(inscricao => new InscricaoDto
        {
            Id = inscricao.Id,
            PessoaId = inscricao.PessoaId,
            TurmaId = inscricao.TurmaId,
            Status = inscricao.Status
        });
    }

    public async Task<InscricaoDto?> ObterPorIdAsync(Guid id)
    {
        var inscricao = await _repository.GetByIdAsync(id);
        return inscricao == null ? null : new InscricaoDto
        {
            Id = inscricao.Id,
            PessoaId = inscricao.PessoaId,
            TurmaId = inscricao.TurmaId,
            Status = inscricao.Status
        };
    }

    public async Task<(IEnumerable<InscricaoDto> Data, int TotalCount)> ObterPorPessoaPaginadoAsync(Guid pessoaId, InscricaoQuery query)
    {
        var (inscricoes, total) = await _repository.GetByFilterAsync(pessoaId, query);

        var data = inscricoes.Select(i => new InscricaoDto
        {
            Id = i.Id,
            PessoaId = i.PessoaId,
            TurmaId = i.TurmaId,
            Status = i.Status
        });

        return (data, total);
    }


    public async Task<Guid> CriarAsync(CreateInscricaoDto dto)
    {
        var inscricao = new Inscricao(dto.PessoaId, dto.TurmaId, dto.Status);
        await _repository.AddAsync(inscricao);
        await _repository.SaveChangesAsync();
        return inscricao.Id;
    }

    public async Task AtualizarAsync(Guid id, CreateInscricaoDto dto)
    {
        var inscricao = await _repository.GetByIdAsync(id);
        if (inscricao is null) throw new Exception("Inscrição não encontrada");
        inscricao.AtualizarStatus(dto.Status);
        _repository.Update(inscricao);
        await _repository.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var inscricao = await _repository.GetByIdAsync(id);
        if (inscricao != null)
        {
            _repository.Remove(inscricao);
            await _repository.SaveChangesAsync();
        }
    }
}