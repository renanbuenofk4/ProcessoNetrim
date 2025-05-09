using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Queries;

public class InscricaoQuery : PagedQuery
{
    public StatusInscricao? Status { get; set; }
}