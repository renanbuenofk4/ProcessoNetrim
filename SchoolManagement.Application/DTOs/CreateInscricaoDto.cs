using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.DTOs;

public class CreateInscricaoDto
{
    public Guid PessoaId { get; set; }
    public Guid TurmaId { get; set; }
    public StatusInscricao Status { get; set; }
}
