using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _repository;

    public PessoaService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PessoaDto>> ObterTodasAsync()
    {
        var pessoas = await _repository.GetAllAsync();
        return pessoas.Select(p => new PessoaDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Sobrenome = p.Sobrenome,
            Telefone = p.Telefone,
            Endereco = p.Endereco,
            Email = p.Email
        });
    }

    public async Task<PessoaDto?> ObterPorIdAsync(Guid id)
    {
        var pessoa = await _repository.GetByIdAsync(id);
        return pessoa == null ? null : new PessoaDto
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome,
            Sobrenome = pessoa.Sobrenome,
            Telefone = pessoa.Telefone,
            Endereco = pessoa.Endereco,
            Email = pessoa.Email
        };
    }

    public async Task<PessoaDto?> ObterPorEmailAsync(string email)
    {
        var pessoa = await _repository.ObterPorEmailAsync(email);
        return pessoa == null ? null : new PessoaDto
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome,
            Sobrenome = pessoa.Sobrenome,
            Telefone = pessoa.Telefone,
            Endereco = pessoa.Endereco,
            Email = pessoa.Email
        };
    }

    public async Task<(IEnumerable<PessoaDto> Data, int TotalCount)> ObterPaginadoAsync(PessoaQuery query)
    {
        var (pessoas, total) = await _repository.GetByFilterAsync(query);

        var data = pessoas.Select(p => new PessoaDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Sobrenome = p.Sobrenome,
            Telefone = p.Telefone,
            Endereco = p.Endereco,
            Email = p.Email
        });

        return (data, total);
    }


    public async Task<Guid> CriarAsync(CreatePessoaDto dto)
    {
        var pessoa = new Pessoa(dto.Nome, dto.Sobrenome, dto.Telefone, dto.Endereco, dto.Email);
        await _repository.AddAsync(pessoa);
        await _repository.SaveChangesAsync();
        return pessoa.Id;
    }

    public async Task AtualizarAsync(Guid id, CreatePessoaDto dto)
    {
        var pessoa = await _repository.GetByIdAsync(id);
        if (pessoa is null) throw new Exception("Pessoa não encontrada");

        pessoa = new Pessoa(dto.Nome, dto.Sobrenome, dto.Telefone, dto.Endereco, dto.Email);
        typeof(Pessoa).GetProperty("Id")?.SetValue(pessoa, id);

        _repository.Update(pessoa);
        await _repository.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var pessoa = await _repository.GetByIdAsync(id);
        if (pessoa != null)
        {
            _repository.Remove(pessoa);
            await _repository.SaveChangesAsync();
        }
    }
}