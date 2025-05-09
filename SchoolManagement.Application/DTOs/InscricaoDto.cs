using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.DTOs;

public class InscricaoDto
{
    public Guid Id { get; set; }
    public Guid PessoaId { get; set; }
    public Guid TurmaId { get; set; }
    public StatusInscricao Status { get; set; }
}
