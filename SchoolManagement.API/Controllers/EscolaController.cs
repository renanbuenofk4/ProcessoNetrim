using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;
using SchoolManagement.Application.Services;

namespace SchoolManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EscolaController : ControllerBase
{
    private readonly IEscolaService _service;

    public EscolaController(IEscolaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEscolas() => Ok(await _service.ObterTodasAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEscolaById(Guid id)
    {
        var result = await _service.ObterPorIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginated(EscolaQuery query)
    {
        var (data, total) = await _service.ObterPaginadoAsync(query);
        return Ok(new { total, data });
    }

    [HttpPost]
    public async Task<IActionResult> PostEscola(CreateEscolaDto dto)
    {
        var idEscola = await _service.CriarAsync(dto);
        return CreatedAtAction(nameof(GetEscolaById), new { idEscola }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEscola(Guid idEscola, CreateEscolaDto dto)
    {
        await _service.AtualizarAsync(idEscola, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEscola(Guid idEscola)
    {
        await _service.RemoverAsync(idEscola);
        return NoContent();
    }
}