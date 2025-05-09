using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;

namespace SchoolManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class PessoaController : ControllerBase
{
    private readonly IPessoaService _service;

    public PessoaController(IPessoaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetPessoas() => Ok(await _service.ObterTodasAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPessoaById(Guid id)
    {
        var result = await _service.ObterPorIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginated(PessoaQuery query)
    {
        var (data, total) = await _service.ObterPaginadoAsync(query);
        return Ok(new { total, data });
    }

    [HttpPost]
    public async Task<IActionResult> PostPessoa(CreatePessoaDto dto)
    {
        var idPessoa = await _service.CriarAsync(dto);
        return CreatedAtAction(nameof(GetPessoaById), new { idPessoa }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPessoa(Guid idPessoa, CreatePessoaDto dto)
    {
        await _service.AtualizarAsync(idPessoa, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePessoa(Guid idPessoa)
    {
        await _service.RemoverAsync(idPessoa);
        return NoContent();
    }
}