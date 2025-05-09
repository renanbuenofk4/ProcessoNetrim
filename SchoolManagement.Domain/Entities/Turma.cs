using SchoolManagement.Domain.Entities;

public class Turma
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Nivel { get; private set; }

    public Guid EscolaId { get; private set; } 
    public Escola Escola { get; private set; } = null!; 

    public ICollection<Inscricao> Inscricoes { get; private set; } = new List<Inscricao>();

    protected Turma() { }

    public Turma(string nome, string nivel, Guid escolaId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Nivel = nivel;
        EscolaId = escolaId;
    }

    public bool PossuiVagasDisponiveis()
    {
        return Inscricoes.Count(i => i.Status == StatusInscricao.Inscrito) < 15;
    }
}
