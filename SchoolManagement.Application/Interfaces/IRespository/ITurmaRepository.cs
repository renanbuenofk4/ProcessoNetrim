using SchoolManagement.Domain.Entities;


namespace SchoolManagement.Domain.Interfaces;

public interface ITurmaRepository : IRepository<Turma>
{
    Task<IEnumerable<Turma>> ListarPorNivelAsync(string nivel);
    Task<IEnumerable<Turma>> ObterTurmasDisponiveisAsync(Guid pessoaId);
}
