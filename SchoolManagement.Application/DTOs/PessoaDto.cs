
namespace SchoolManagement.Application.DTOs;

public class PessoaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}