using SchoolManagement.Domain.Entities;


namespace SchoolManagement.Domain.Interfaces;

public interface IEscolaRepository : IRepository<Escola>
{
    Task<IEnumerable<Escola>> ListarPorNomeAsync(string nome);
}
