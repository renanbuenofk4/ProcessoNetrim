

namespace SchoolManagement.Domain.Entities;

public enum StatusInscricao
{
    Inscrito,
    EmFilaDeEspera,
    Confirmado
}

public class Inscricao
{
    public Guid Id { get; private set; }
    public Guid PessoaId { get; private set; }
    public Pessoa Pessoa { get; private set; } = null!;
    public Guid TurmaId { get; private set; }
    public Turma Turma { get; private set; } = null!;
    public StatusInscricao Status { get; private set; }

    protected Inscricao() { }

    public Inscricao(Guid pessoaId, Guid turmaId, StatusInscricao status)
    {
        Id = Guid.NewGuid();
        PessoaId = pessoaId;
        TurmaId = turmaId;
        Status = status;
    }

    public void AtualizarStatus(StatusInscricao novoStatus)
    {
        Status = novoStatus;
    }
}