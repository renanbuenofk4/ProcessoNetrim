using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces.IServices;
using SchoolManagement.Application.Queries;
using SchoolManagement.Application.Services;

namespace SchoolManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InscricaoController : ControllerBase
{
    private readonly IInscricaoService _service;

    public InscricaoController(IInscricaoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetInscricoes() => Ok(await _service.ObterTodasAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInscricaoById(Guid id)
    {
        var result = await _service.ObterPorIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("pessoa/{pessoaId}/paginated")]
    public async Task<IActionResult> GetInscricaoPaginated(Guid pessoaId, InscricaoQuery query)
    {
        var (data, total) = await _service.ObterPorPessoaPaginadoAsync(pessoaId, query);
        return Ok(new { total, data });
    }


    [HttpPost]
    public async Task<IActionResult> PostInscricao(CreateInscricaoDto dto)
    {
        var idInscricao = await _service.CriarAsync(dto);
        return CreatedAtAction(nameof(GetInscricaoById), new { idInscricao }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutInscricao(Guid idInscricao, CreateInscricaoDto dto)
    {
        await _service.AtualizarAsync(idInscricao, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInscricao(Guid idInscricao)
    {
        await _service.RemoverAsync(idInscricao);
        return NoContent();
    }
}