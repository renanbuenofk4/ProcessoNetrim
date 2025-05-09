
namespace SchoolManagement.Domain.Entities;

public class Escola
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public ICollection<Turma> Turmas { get; private set; } = new List<Turma>();

    protected Escola() { }

    public Escola(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }

    public void AdicionarTurma(Turma turma)
    {
        Turmas.Add(turma);
    }
}