using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class EscolaService : IEscolaService
{
    private readonly IEscolaRepository _repository;

    public EscolaService(IEscolaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EscolaDto>> ObterTodasAsync()
    {
        var escolas = await _repository.GetAllAsync();
        return escolas.Select(e => new EscolaDto { Id = e.Id, Nome = e.Nome });
    }

    public async Task<EscolaDto?> ObterPorIdAsync(Guid id)
    {
        var escola = await _repository.GetByIdAsync(id);
        return escola == null ? null : new EscolaDto { Id = escola.Id, Nome = escola.Nome };
    }

    public async Task<(IEnumerable<EscolaDto> Data, int TotalCount)> ObterPaginadoAsync(EscolaQuery query)
    {
        var escolas = await _repository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(query.Nome))
            escolas = escolas.Where(e => e.Nome.Contains(query.Nome));

        var total = escolas.Count();
        var data = escolas
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(e => new EscolaDto
            {
                Id = e.Id,
                Nome = e.Nome
            });

        return (data, total);
    }



    public async Task<Guid> CriarAsync(CreateEscolaDto dto)
    {
        var escola = new Escola(dto.Nome);
        await _repository.AddAsync(escola);
        await _repository.SaveChangesAsync();
        return escola.Id;
    }

    public async Task AtualizarAsync(Guid id, CreateEscolaDto dto)
    {
        var escola = await _repository.GetByIdAsync(id);
        if (escola is null) throw new Exception("Escola não encontrada");
        escola = new Escola(dto.Nome);
        typeof(Escola).GetProperty("Id")?.SetValue(escola, id);
        _repository.Update(escola);
        await _repository.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var escola = await _repository.GetByIdAsync(id);
        if (escola != null)
        {
            _repository.Remove(escola);
            await _repository.SaveChangesAsync();
        }
    }
}
