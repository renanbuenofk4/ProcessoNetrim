
namespace SchoolManagement.Application.DTOs;

public class CreateTurmaDto
{
    public string Nome { get; set; } = string.Empty;
    public string Nivel { get; set; } = string.Empty;
    public Guid EscolaId { get; set; }
}
