using System.ComponentModel.DataAnnotations;

namespace RestTomas.Data.Dtos.Technicians
{
    public record CreateTechnicianDto([Required] string Name, [Required] string Specialization);
}
