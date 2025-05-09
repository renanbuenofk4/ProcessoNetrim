using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;

namespace SchoolManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmaController : ControllerBase
{
    private readonly ITurmaService _service;

    public TurmaController(ITurmaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetTurmas() => Ok(await _service.ObterTodasAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTurmaById(Guid id)
    {
        var result = await _service.ObterPorIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginated(TurmaQuery query)
    {
        var (data, total) = await _service.ObterPaginadoAsync(query);
        return Ok(new { total, data });
    }

    [HttpGet("disponiveis/{pessoaId}")]
    public async Task<IActionResult> GetDisponiveis(Guid pessoaId)
    {
        var turmas = await _service.ObterTurmasDisponiveisAsync(pessoaId);
        return Ok(turmas);
    }

    [HttpPost]
    public async Task<IActionResult> PostTurma(CreateTurmaDto dto)
    {
        var id = await _service.CriarAsync(dto);
        return CreatedAtAction(nameof(GetTurmaById), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTurma(Guid idTurma, CreateTurmaDto dto)
    {
        await _service.AtualizarAsync(idTurma, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTurma(Guid idTurma)
    {
        await _service.RemoverAsync(idTurma);
        return NoContent();
    }
}