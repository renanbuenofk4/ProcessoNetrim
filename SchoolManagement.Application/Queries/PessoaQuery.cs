namespace SchoolManagement.Application.Queries;

public class PessoaQuery : PagedQuery
{
    public string? Nome { get; set; }
    public string? Cpf { get; set; } 
}