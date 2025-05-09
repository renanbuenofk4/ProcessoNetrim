

namespace SchoolManagement.Domain.Entities;

public class Pessoa
{
    protected Pessoa() { }

    public Pessoa(string nome, string sobrenome, string telefone, string endereco, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Sobrenome = sobrenome;
        Telefone = telefone;
        Endereco = endereco;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Sobrenome { get; private set; }
    public string Telefone { get; private set; }
    public string Endereco { get; private set; }
    public string Email { get; private set; }

    public ICollection<Inscricao> Inscricoes { get; private set; } = new List<Inscricao>();
}