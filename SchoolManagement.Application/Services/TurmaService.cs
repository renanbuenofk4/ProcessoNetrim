using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class TurmaService : ITurmaService
{
    private readonly ITurmaRepository _repository;

    public TurmaService(ITurmaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TurmaDto>> ObterTodasAsync()
    {
        var turmas = await _repository.GetAllAsync();
        return turmas.Select(t => new TurmaDto
        {
            Id = t.Id,
            Nome = t.Nome,
            Nivel = t.Nivel,
            EscolaId = t.EscolaId
        });
    }

    public async Task<TurmaDto?> ObterPorIdAsync(Guid id)
    {
        var t = await _repository.GetByIdAsync(id);
        return t == null ? null : new TurmaDto
        {
            Id = t.Id,
            Nome = t.Nome,
            Nivel = t.Nivel,
            EscolaId = t.EscolaId
        };
    }

    public async Task<IEnumerable<TurmaDto>> ObterTurmasDisponiveisAsync(Guid pessoaId)
    {
        var turmas = await _repository.ObterTurmasDisponiveisAsync(pessoaId);

        return turmas.Select(t => new TurmaDto
        {
            Id = t.Id,
            Nome = t.Nome,
            Nivel = t.Nivel,
            EscolaId = t.EscolaId
        });
    }


    public async Task<(IEnumerable<TurmaDto> Data, int TotalCount)> ObterPaginadoAsync(TurmaQuery query)
    {
        var turmas = await _repository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(query.Nivel))
            turmas = turmas.Where(t => t.Nivel.Contains(query.Nivel));

        var total = turmas.Count();
        var data = turmas
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(t => new TurmaDto
            {
                Id = t.Id,
                Nome = t.Nome,
                Nivel = t.Nivel
            });

        return (data, total);
    }


    public async Task<Guid> CriarAsync(CreateTurmaDto dto)
    {
        var turma = new Turma(dto.Nome, dto.Nivel, dto.EscolaId);
        await _repository.AddAsync(turma);
        await _repository.SaveChangesAsync();
        return turma.Id;
    }

    public async Task AtualizarAsync(Guid id, CreateTurmaDto dto)
    {
        var turma = await _repository.GetByIdAsync(id);
        if (turma is null) throw new Exception("Turma não encontrada");
        turma = new Turma(dto.Nome, dto.Nivel, dto.EscolaId);
        typeof(Turma).GetProperty("Id")?.SetValue(turma, id);
        _repository.Update(turma);
        await _repository.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var turma = await _repository.GetByIdAsync(id);
        if (turma != null)
        {
            _repository.Remove(turma);
            await _repository.SaveChangesAsync();
        }
    }
}
